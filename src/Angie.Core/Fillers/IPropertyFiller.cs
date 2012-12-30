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
        public string[] PropertyNames { get { return new[] {"*"}; } }

        public Type ObjectType { get { return typeof (object); } }
        public Type PropertyType { get { return typeof (string); } }

        public object GetValue()
        {
            return Susan.FillWord();
        }
    }

    public class GenericIntFiller : IPropertyFiller
    {        
        Random _random = new Random();

        public GenericIntFiller()
        {
            Min = Angie.Defaults.MIN_INT;
            Max = Angie.Defaults.MAX_INT;
        }

        public string[] PropertyNames { get { return new[] { "*" }; } }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(int); } }

        public int Min { get; set; }
        public int Max { get; set; }

        public object GetValue()
        {
            return _random.Next(Min, Max);
        }
    }

    public class AgeFiller : IPropertyFiller
    {
        Random _random = new Random();

        public string[] PropertyNames {
            get { return new[] {"Age"}; } 
        }
        public Type ObjectType { get { return typeof (object); } }
        public Type PropertyType { get { return typeof (int); } }
        
        public object GetValue()
        {
            return Math.Abs(_random.Next(Angie.Defaults.MIN_INT, Angie.Defaults.MAX_INT));
        }
    }

    public class FirstNameFiller : IPropertyFiller
    {
        public string[] PropertyNames {
            get { return new[] {"firstname", "fname", "first_name"}; } 
        }

        public Type ObjectType { get { return typeof(object); } }
        public Type PropertyType { get { return typeof(string); } }

        public object GetValue()
        {
            return Susan.FillFirstName();
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

    public class CustomFiller : IPropertyFiller
    {
        private string _propertyName;
        private Type _objectType;
        private Type _propertyType;
        private Func<object> _filler; 

        public CustomFiller(string propertyName, Type objectType, Type propertyType, Func<object> filler )
        {
            _propertyName = propertyName;
            _objectType = objectType;
            _propertyType = propertyType;
            _filler = filler;
        }

        public string[] PropertyNames {
            get
            {
                return new[]
                    {
                        _propertyName
                    };
            }
        }
        public Type ObjectType { get { return _objectType;  } }
        public Type PropertyType { get { return _propertyType; } }
        public object GetValue()
        {
            return _filler.Invoke();
        }
    }
}