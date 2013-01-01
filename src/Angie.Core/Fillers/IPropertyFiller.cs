using System;

namespace Angela.Core.Fillers
{
    public interface IPropertyFiller
    {
        string[] PropertyNames { get; }
        Type ObjectType { get; }
        Type PropertyType { get; }
        object GetValue();
    }

    public class GenericStringFiller : IPropertyFiller
    {
        public string[] PropertyNames { get { return new[] { "*" }; } }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }

        public object GetValue()
        {
            return Susan.GetWord();
        }
    }

    public class IntFiller : IPropertyFiller
    {
        Random _random = new Random();


        public IntFiller()
        {
            Min = Angie.Defaults.MIN_INT;
            Max = Angie.Defaults.MAX_INT;
            PropertyNames = new[] { "*" };
            ObjectType = typeof(object);
        }

        public IntFiller(Type objectType, string propertyName, int min, int max)
        {
            Min = min;
            Max = max;
            PropertyNames = new[] { propertyName };
            ObjectType = objectType;
        }

        public string[] PropertyNames { get; private set; }

        public Type ObjectType { get; private set; }
        public Type PropertyType { get { return typeof(int); } }

        public int Min { get; set; }
        public int Max { get; set; }

        public object GetValue()
        {
            return _random.Next(Min, Max);
        }
    }

    public class GenericDateTimeFiller : IPropertyFiller
    {
        private Random _random = new Random();

        public DateTime Min { get; set; }
        public DateTime Max { get; set; }

        public string[] PropertyNames { get { return new[] { "*" }; } }
        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(DateTime); } }
        public object GetValue()
        {
            int totalDays = (Max - Min).Days;
            int randomDays = _random.Next(totalDays);
            int seconds = _random.Next(24 * 60 * 60);
            return Min.AddDays(randomDays).AddSeconds(seconds);
        }
    }

    public class AgeFiller : IPropertyFiller
    {
        Random _random = new Random();
        private const int _minAge = 1;
        private const int _maxAge = 93;

        public string[] PropertyNames
        {
            get { return new[] { "Age" }; }
        }
        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(int); } }

        public object GetValue()
        {
            return Math.Abs(_random.Next(_minAge, _maxAge));
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
            return string.Format("{0}.{1}@{2}", Susan.GetFirstName(), Susan.GetLastName(), Susan.GetDomainName());

        }
    }
    public static class EmailFillerExtensions
    {
        public static AngieStringConfigurator<T> AsEmailAddress<T>(this AngieStringConfigurator<T> configurator)
        {
            CustomFiller<string> filler = new CustomFiller<string>(configurator.PropertyInfo.Name, typeof(T), () => "blah@blah.com");
            configurator.Maggie.RegisterFiller(filler);
            return configurator;
        }

    }


    public class CustomFiller<T> : IPropertyFiller
    {
        private string _propertyName;
        private Type _objectType;
        private Type _propertyType;
        private Func<T> _filler;

        public CustomFiller(string propertyName, Type objectType, Func<T> filler)
        {
            _propertyName = propertyName;
            _objectType = objectType;
            _propertyType = typeof(T);
            _filler = filler;
        }

        public string[] PropertyNames
        {
            get
            {
                return new[]
                    {
                        _propertyName
                    };
            }
        }
        public Type ObjectType { get { return _objectType; } }
        public Type PropertyType { get { return _propertyType; } }
        public object GetValue()
        {
            return _filler.Invoke();
        }
    }
}