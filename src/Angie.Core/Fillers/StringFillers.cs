using System;

namespace Angela.Core.Fillers
{

    public class StringFiller : IPropertyFiller
    {
        public string[] PropertyNames { get { return new[] { "*" }; } }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }

        public object GetValue()
        {
            return Susan.GetWord();
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

        public object GetValue()
        {
            return Susan.GetTitle();
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

        public object GetValue()
        {
            return Susan.GetFirstName();
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

        public object GetValue()
        {
            return Susan.GetLastName();
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

        public object GetValue()
        {
            return Susan.FillEmail();
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

        public object GetValue()
        {
            return Susan.FillAddressLine();
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

        public object GetValue()
        {
            return Susan.FillAddressLine2();
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

        public object GetValue()
        {
            return Susan.FillCity();
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

        public object GetValue()
        {
            return Susan.FillUsaState();
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

        public object GetValue()
        {
            return Susan.FillCanadianProvince();
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

        public object GetValue()
        {
            return Susan.FillPhoneNumber();
        }
    }

    public static class StringFillerExtensions
    {
        public static AngieStringConfigurator<T> AsEmailAddress<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.FillEmail());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsArticleTitle<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.GetTitle());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsPhoneNumber<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.FillPhoneNumber());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsFirstName<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.GetFirstName());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsLastName<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.GetLastName());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsAddress<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.FillAddressLine());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsAddressLine2<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.FillAddressLine2());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsCity<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.FillCity());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsCanadianProvince<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.FillCanadianProvince());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

        public static AngieStringConfigurator<T> AsUsaState<T>(this AngieStringConfigurator<T> configurator) where T : new()
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => Susan.FillUsaState());
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }
    }
}
