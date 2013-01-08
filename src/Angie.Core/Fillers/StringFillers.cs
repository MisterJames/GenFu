using System;
using System.ComponentModel.Composition;

namespace Angela.Core.Fillers
{
    public class StringFiller : IPropertyFiller
    {
        public string[] PropertyNames { get { return new[] { "*" }; } }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return true; } }

        public object GetValue()
        {
            return Jen.Word();
        }
    }

    public class ArticleTitleFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "title"}; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Title();
        }
    }

    public class FirstNameFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "firstname", "fname", "first_name" }; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.FirstName();
        }
    }

    public class LastNameFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "lastname", "lname", "last_name" }; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.LastName();
        }
    }

    public class EmailFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "email", "emailaddress", "email_address" }; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.Email();
        }
    }

    public class AddressFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "address", "adress1", "adress_1", "billingaddress", "billing_address" }; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.AddressLine();
        }
    }

    public class AddressLine2Filler : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "address2", "adress_2" }; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.AddressLine2();
        }
    }

    public class CityFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "city", "cityname", "city_name" }; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.City();
        }
    }

    public class StateFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "state", "statename", "state_name" }; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.UsaState();
        }
    }

    public class ProvinceFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "provice", "provincename", "province_name"}; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.CanadianProvince();
        }
    }

    public class PhoneNumberFiller : IPropertyFiller
    {
        public string[] PropertyNames
        {
            get { return new[] { "fax", "phone", "phonenumber", "phone_number", "homenumber", "worknumber" }; }
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }
        public bool IsGenericFiller { get { return false; } }

        public object GetValue()
        {
            return Jen.PhoneNumber();
        }
    }

    public static class StringFillerExtensions
    {
        public static AngieConfigurator<T> AsEmailAddress<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Email());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsArticleTitle<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.Title());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsPhoneNumber<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.PhoneNumber());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsFirstName<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.FirstName());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsLastName<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.LastName());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsAddress<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.AddressLine());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsAddressLine2<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.AddressLine2());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsCity<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.City());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsCanadianProvince<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.CanadianProvince());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieConfigurator<T> AsUsaState<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Jen.UsaState());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }
    }
}
