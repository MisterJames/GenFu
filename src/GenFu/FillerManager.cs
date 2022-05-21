﻿namespace GenFu;

using global::GenFu.Fillers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

public class FillerManager
{
    private IDictionary<string, IDictionary<string, IPropertyFiller>> _specificPropertyFillersByObjectType;
    private IDictionary<Type, IPropertyFiller> _genericPropertyFillersByPropertyType;
    private IList<IPropertyFiller> _propertyFillers;

    static ReaderWriterLockSlim rwl = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

    public FillerManager() => ResetFillers();

    public void ResetFillers()
    {
        try
        {
            rwl.EnterWriteLock();
            if (_propertyFillers == null)
            {
                _propertyFillers = new List<IPropertyFiller>();

                _propertyFillers.Add(new CharFiller());
                _propertyFillers.Add(new NullableCharFiller());
                _propertyFillers.Add(new IntFiller());
                _propertyFillers.Add(new NullableIntFiller());
                _propertyFillers.Add(new NullableUIntFiller());
                _propertyFillers.Add(new LongFiller());
                _propertyFillers.Add(new NullableLongFiller());
                _propertyFillers.Add(new NullableULongFiller());
                _propertyFillers.Add(new DecimalFiller());
                _propertyFillers.Add(new NullableDecimalFiller());
                _propertyFillers.Add(new ShortFiller());
                _propertyFillers.Add(new NullableShortFiller());
                _propertyFillers.Add(new NullableUShortFiller());
                _propertyFillers.Add(new BooleanFiller());
                _propertyFillers.Add(new NullableBooleanFiller());

                _propertyFillers.Add(new AgeFiller());
                _propertyFillers.Add(new PriceFiller());

                _propertyFillers.Add(new CompanyNameFiller());

                _propertyFillers.Add(new CookingFiller.IngredientFiller());


                DateTimeNullableFiller DateTimeNullableFiller = new DateTimeAdapterFiller<DateTime?>();
                _propertyFillers.Add(new DateTimeFiller());
                _propertyFillers.Add(new DateTimeOffsetFiller());
                _propertyFillers.Add(DateTimeNullableFiller);


                _propertyFillers.Add(new BirthDateFiller());
                _propertyFillers.Add(new GuidFiller());
                _propertyFillers.Add(new ArticleTitleFiller());

                _propertyFillers.Add(new FirstNameFiller());
                _propertyFillers.Add(new LastNameFiller());
                _propertyFillers.Add(new EmailFiller());
                _propertyFillers.Add(new PersonTitleFiller());

                _propertyFillers.Add(new TwitterFiller());

                _propertyFillers.Add(new AddressFiller());
                _propertyFillers.Add(new AddressLine2Filler());
                _propertyFillers.Add(new CityFiller());
                _propertyFillers.Add(new StateFiller());
                _propertyFillers.Add(new ProvinceFiller());
                _propertyFillers.Add(new ZipCodeFiller());
                _propertyFillers.Add(new PostalCodeFiller());
                _propertyFillers.Add(new PhoneNumberFiller());

                _propertyFillers.Add(new MusicAlbumTitleFiller());
                _propertyFillers.Add(new MusicArtistNameFiller());
                _propertyFillers.Add(new MusicGenreDescriptionFiller());
                _propertyFillers.Add(new MusicGenreNameFiller());

                _propertyFillers.Add(new CanadianSocialInsuranceNumberFiller());
                _propertyFillers.Add(new USASocialSecurityNumberFiller());

                _propertyFillers.Add(new DrugFiller());
                _propertyFillers.Add(new MedicalProcedureFiller());

                _propertyFillers.Add(new StringFiller());
            }

            _specificPropertyFillersByObjectType = new Dictionary<string, IDictionary<string, IPropertyFiller>>();

            foreach (IPropertyFiller propertyFiller in _propertyFillers.Where(p => !p.IsGenericFiller))
            {
                RegisterFiller(propertyFiller);
            }

            _genericPropertyFillersByPropertyType = new Dictionary<Type, IPropertyFiller>();
            foreach (IPropertyFiller propertyFiller in _propertyFillers.Where(p => p.IsGenericFiller))
            {
                _genericPropertyFillersByPropertyType.Add(propertyFiller.PropertyType, propertyFiller);
            }
        }
        finally
        {
            rwl.ExitWriteLock();
        }
    }

    public void ResetFillers<T>()
    {
        try
        {
            rwl.EnterWriteLock();
            string objectTypeName = typeof(T).FullName.ToLowerInvariant();
            if (_specificPropertyFillersByObjectType.ContainsKey(objectTypeName))
            {
                _specificPropertyFillersByObjectType.Remove(objectTypeName);
            }
        }
        finally
        {
            rwl.ExitWriteLock();
        }
    }

    public void RegisterFiller(IPropertyFiller filler)
    {
        try
        {
            rwl.EnterWriteLock();
            foreach (string objectTypeName in filler.ObjectTypeNames.Select(s => s.ToLowerInvariant()))
            {
                if (!_specificPropertyFillersByObjectType.ContainsKey(objectTypeName))
                {
                    _specificPropertyFillersByObjectType[objectTypeName] = new Dictionary<string, IPropertyFiller>();
                }
                IDictionary<string, IPropertyFiller> typeFillers = _specificPropertyFillersByObjectType[objectTypeName];
                foreach (var key in filler.PropertyNames)
                {
                    typeFillers[key] = filler;
                }
            }
        }
        finally
        {
            rwl.ExitWriteLock();
        }
    }

    public IPropertyFiller GetFiller(PropertyInfo propertyInfo)
        => GetFiller(propertyInfo.DeclaringType, propertyInfo.Name, propertyInfo.PropertyType);

    public IPropertyFiller GetFiller(ParameterInfo parameterInfo)
        => GetFiller(parameterInfo.Member.DeclaringType, parameterInfo.Name, parameterInfo.ParameterType);

    public IPropertyFiller GetFiller(Type declaringType, string name, Type type)
    {
        rwl.EnterReadLock();
        var newRegistrations = new Dictionary<Type, IPropertyFiller>();
        IPropertyFiller result = null;
        try
        {
            Type objectType = declaringType;
            while (objectType != null && result == null)
            {
                //First try to get a specific filler based on a full type name (including namespace)
                string fullTypeName = objectType.FullName.ToLowerInvariant();

                if (_specificPropertyFillersByObjectType.ContainsKey(fullTypeName))
                {
                    IDictionary<string, IPropertyFiller> propertyFillers = _specificPropertyFillersByObjectType[fullTypeName];
                    result = GetMatchingPropertyFiller(name, type, propertyFillers);
                }

                //Second try to get a more generic filler based on only the class name (no namespace)
                if (result == null)
                {
                    string classTypeName = objectType.Name.ToLowerInvariant();
                    if (_specificPropertyFillersByObjectType.ContainsKey(classTypeName))
                    {
                        IDictionary<string, IPropertyFiller> propertyFillers = _specificPropertyFillersByObjectType[classTypeName];
                        result = GetMatchingPropertyFiller(name, type, propertyFillers);
                    }
                }

                objectType = objectType.GetTypeInfo().BaseType;
            }

            if (result == null)
            {
                //Finally, grab a generic property filler for that property type
                if (_genericPropertyFillersByPropertyType.ContainsKey(type))
                {
                    result = _genericPropertyFillersByPropertyType[type];
                }
                else if (type.GetTypeInfo().BaseType == typeof(System.Enum))
                {
                    result = new EnumFiller(type);
                }
                else
                {
                    //TODO: Can we build a custom filler here for other value types that we have not explicitly implemented (eg. long, decimal, etc.)
                    result = new CustomFiller<object>("*", typeof(object), true, () => null);
                    newRegistrations[type] = result;
                }
            }
        }
        finally
        {
            rwl.ExitReadLock();
        }

        if (newRegistrations.Any())
        {
            rwl.EnterWriteLock();
            foreach (var newRegistration in newRegistrations)
            {
                _genericPropertyFillersByPropertyType[newRegistration.Key] = newRegistration.Value;
            }
            rwl.ExitWriteLock();
        }
        return result;
    }

    public IPropertyFiller GetMethodFiller(MethodInfo methodInfo)
    {
        try
        {
            rwl.EnterReadLock();

            IPropertyFiller result = null;
            Type objectType = methodInfo.DeclaringType;
            while (objectType != null && result == null)
            {
                //First try to get a specific filler based on a full type name (including namespace)
                string fullTypeName = objectType.FullName.ToLowerInvariant();
                if (_specificPropertyFillersByObjectType.ContainsKey(fullTypeName))
                {
                    IDictionary<string, IPropertyFiller> propertyFillers = _specificPropertyFillersByObjectType[fullTypeName];
                    result = GetMatchingMethodFiller(methodInfo, propertyFillers);
                }


                //Second try to get a more generic filler based on only the class name (no namespace)
                if (result == null)
                {
                    string classTypeName = objectType.Name.ToLowerInvariant();
                    if (_specificPropertyFillersByObjectType.ContainsKey(classTypeName))
                    {
                        IDictionary<string, IPropertyFiller> propertyFillers = _specificPropertyFillersByObjectType[classTypeName];
                        result = GetMatchingMethodFiller(methodInfo, propertyFillers);
                    }
                }

                objectType = objectType.GetTypeInfo().BaseType;
            }

            //            // TODO: Would like to exclude methods for fill unless we explicity specify to include
            //            if (result == null)
            //            {
            //                var paramType = methodInfo.GetParameters()[0].ParameterType;
            //
            //                //Finally, grab a generic property filler for that property type
            //                if (_genericPropertyFillersByPropertyType.ContainsKey(paramType))
            //                {
            //                    result = _genericPropertyFillersByPropertyType[paramType];
            //                }
            //                else
            //                {
            //                    //TODO: Can we build a custom filler here for other value types that we have not explicitly implemented (eg. long, decimal, etc.)
            //                    result = new CustomFiller<object>("*", typeof(object), true, () => null);
            //
            //                    _genericPropertyFillersByPropertyType.Add(paramType, result);
            //                }
            //            }

            return result;
        }
        finally
        {
            rwl.ExitReadLock();
        }
    }

    private static IPropertyFiller GetMatchingPropertyFiller(string name, Type type, IDictionary<string, IPropertyFiller> propertyFillers)
    {
        IPropertyFiller result = null;
        foreach (IPropertyFiller propertyFiller in propertyFillers.Values)
        {
            if (propertyFiller.PropertyType == type &&
                propertyFiller.PropertyNames.Any(s => name.ToLowerInvariant().Equals(s.ToLowerInvariant())))
            {
                result = propertyFiller;
                break;
            }
        }
        return result;
    }

    private static IPropertyFiller GetMatchingMethodFiller(MethodInfo methodInfo, IDictionary<string, IPropertyFiller> propertyFillers)
    {
        const string setPattern = @"^Set([A-Z].*|_.*)";
        string cleanName = null;
        if (Regex.IsMatch(methodInfo.Name, setPattern))
        {
            cleanName = Regex.Match(methodInfo.Name, setPattern).Groups[1].Value;
        }

        IPropertyFiller result = null;
        foreach (IPropertyFiller propertyFiller in propertyFillers.Values)
        {
            if (propertyFiller.PropertyType == methodInfo.GetParameters()[0].ParameterType &&
               (propertyFiller.PropertyNames.Any(s => methodInfo.Name.ToLowerInvariant().Contains(s.ToLowerInvariant()))
               || (cleanName != null && propertyFiller.PropertyNames.Any(s => cleanName.ToLowerInvariant().Contains(s.ToLowerInvariant())))))
            {
                result = propertyFiller;
                break;
            }
        }
        return result;
    }

    public Result GetGenericFiller<Input, Result>()
    {
        var type = typeof(Input);
        try
        {
            rwl.EnterReadLock();
            return (Result)_genericPropertyFillersByPropertyType[type];
        }
        finally
        {
            rwl.ExitReadLock();
        }
    }
    public IPropertyFiller GetGenericFillerForType(Type t)
    {
        try
        {
            rwl.EnterReadLock();
            return _genericPropertyFillersByPropertyType[t];
        }
        finally
        {
            rwl.ExitReadLock();
        }
    }
}
