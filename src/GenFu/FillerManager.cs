using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using GenFu.Fillers;

namespace GenFu
{
    public class FillerManager
    {
        private IDictionary<string, IDictionary<string, IPropertyFiller>> _specificPropertyFillersByObjectType;
        private IDictionary<Type, IPropertyFiller> _genericPropertyFillersByPropertyType;
        private IList<IPropertyFiller> _propertyFillers;

        private ReaderWriterLockSlim rwl = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);
        public GenFuInstance GenFu { get; }

        public FillerManager()
        {
            GenFu = A.GenFuInstance;
            ResetFillers();
        }

        public FillerManager(GenFuInstance genFu)
        {
            GenFu = genFu;
            ResetFillers();
        }

        public void ResetFillers()
        {
            try
            {
                rwl.EnterWriteLock();
                if (_propertyFillers == null)
                {
                    _propertyFillers = new List<IPropertyFiller>();

                    _propertyFillers.Add(new CharFiller(GenFu));
                    _propertyFillers.Add(new NullableCharFiller(GenFu));
                    _propertyFillers.Add(new IntFiller(GenFu));
                    _propertyFillers.Add(new NullableIntFiller(GenFu));
                    _propertyFillers.Add(new NullableUIntFiller(GenFu));
                    _propertyFillers.Add(new LongFiller(GenFu));
                    _propertyFillers.Add(new NullableLongFiller(GenFu));
                    _propertyFillers.Add(new NullableULongFiller(GenFu));
                    _propertyFillers.Add(new DecimalFiller(GenFu));
                    _propertyFillers.Add(new NullableDecimalFiller(GenFu));
                    _propertyFillers.Add(new ShortFiller(GenFu));
                    _propertyFillers.Add(new NullableShortFiller(GenFu));
                    _propertyFillers.Add(new NullableUShortFiller(GenFu));
                    _propertyFillers.Add(new BooleanFiller(GenFu));
                    _propertyFillers.Add(new NullableBooleanFiller(GenFu));

                    _propertyFillers.Add(new AgeFiller(GenFu));
                    _propertyFillers.Add(new PriceFiller(GenFu));

                    _propertyFillers.Add(new CompanyNameFiller(GenFu));

                    _propertyFillers.Add(new CookingFiller.IngredientFiller(GenFu));


                    DateTimeNullableFiller DateTimeNullableFiller = new DateTimeAdapterFiller<DateTime?>(GenFu);
                    _propertyFillers.Add(new DateTimeFiller(GenFu));
                    _propertyFillers.Add(new DateTimeOffsetFiller(GenFu));
                    _propertyFillers.Add(DateTimeNullableFiller);


                    _propertyFillers.Add(new BirthDateFiller(GenFu));
                    _propertyFillers.Add(new GuidFiller(GenFu));
                    _propertyFillers.Add(new ArticleTitleFiller(GenFu));

                    _propertyFillers.Add(new FirstNameFiller(GenFu));
                    _propertyFillers.Add(new LastNameFiller(GenFu));
                    _propertyFillers.Add(new EmailFiller(GenFu));
                    _propertyFillers.Add(new PersonTitleFiller(GenFu));

                    _propertyFillers.Add(new TwitterFiller(GenFu));

                    _propertyFillers.Add(new AddressFiller(GenFu));
                    _propertyFillers.Add(new AddressLine2Filler(GenFu));
                    _propertyFillers.Add(new CityFiller(GenFu));
                    _propertyFillers.Add(new StateFiller(GenFu));
                    _propertyFillers.Add(new ProvinceFiller(GenFu));
                    _propertyFillers.Add(new ZipCodeFiller(GenFu));
                    _propertyFillers.Add(new PostalCodeFiller(GenFu));
                    _propertyFillers.Add(new PhoneNumberFiller(GenFu));

                    _propertyFillers.Add(new MusicAlbumTitleFiller(GenFu));
                    _propertyFillers.Add(new MusicArtistNameFiller(GenFu));
                    _propertyFillers.Add(new MusicGenreDescriptionFiller(GenFu));
                    _propertyFillers.Add(new MusicGenreNameFiller(GenFu));

                    _propertyFillers.Add(new CanadianSocialInsuranceNumberFiller(GenFu));
                    _propertyFillers.Add(new USASocialSecurityNumberFiller(GenFu));

                    _propertyFillers.Add(new DrugFiller(GenFu));
                    _propertyFillers.Add(new MedicalProcedureFiller(GenFu));

                    _propertyFillers.Add(new StringFiller(GenFu));

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
        {
            rwl.EnterReadLock();
            var newRegistrations = new Dictionary<Type, IPropertyFiller>();
            IPropertyFiller result = null;
            try
            {
                Type objectType = propertyInfo.DeclaringType;
                while (objectType != null && result == null)
                {
                    //First try to get a specific filler based on a full type name (including namespace)
                    string fullTypeName = objectType.FullName.ToLowerInvariant();

                    if (_specificPropertyFillersByObjectType.ContainsKey(fullTypeName))
                    {
                        IDictionary<string, IPropertyFiller> propertyFillers = _specificPropertyFillersByObjectType[fullTypeName];
                        result = GetMatchingPropertyFiller(propertyInfo, propertyFillers);
                    }

                    //Second try to get a more generic filler based on only the class name (no namespace)
                    if (result == null)
                    {
                        string classTypeName = objectType.Name.ToLowerInvariant();
                        if (_specificPropertyFillersByObjectType.ContainsKey(classTypeName))
                        {
                            IDictionary<string, IPropertyFiller> propertyFillers = _specificPropertyFillersByObjectType[classTypeName];
                            result = GetMatchingPropertyFiller(propertyInfo, propertyFillers);
                        }
                    }

                    objectType = objectType.GetTypeInfo().BaseType;
                }

                if (result == null)
                {
                    //Finally, grab a generic property filler for that property type
                    if (_genericPropertyFillersByPropertyType.ContainsKey(propertyInfo.PropertyType))
                    {
                        result = _genericPropertyFillersByPropertyType[propertyInfo.PropertyType];
                    }
                    else if (propertyInfo.PropertyType.GetTypeInfo().BaseType == typeof(System.Enum))
                    {
                        result = new EnumFiller(this.GenFu, propertyInfo.PropertyType);
                    }
                    else
                    {
                        //TODO: Can we build a custom filler here for other value types that we have not explicitly implemented (eg. long, decimal, etc.)
                        result = new CustomFiller<object>(GenFu, "*", typeof(object), true, () => null);
                        newRegistrations[propertyInfo.PropertyType] = result;
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

        private static IPropertyFiller GetMatchingPropertyFiller(PropertyInfo propertyInfo, IDictionary<string, IPropertyFiller> propertyFillers)
        {
            IPropertyFiller result = null;
            foreach (IPropertyFiller propertyFiller in propertyFillers.Values)
            {
                if (propertyFiller.PropertyType == propertyInfo.PropertyType &&
                    propertyFiller.PropertyNames.Any(s => propertyInfo.Name.ToLowerInvariant().Equals(s.ToLowerInvariant())))
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
                return (Result) _genericPropertyFillersByPropertyType[type];
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
}
