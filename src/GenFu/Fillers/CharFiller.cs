namespace GenFu.Fillers;

using System;

public class CharFiller : PropertyFiller<char>
{
    public CharFiller() : base(typeof(object), "*", true) { }

    public CharFiller(Type objectType, string propertyName) : base(objectType, propertyName) { }

    public override object GetValue(object instance)
     => (char)GenFu.Random.Next(char.MinValue, char.MaxValue);
}

public class NullableCharFiller : PropertyFiller<char?>
{
    public NullableCharFiller() : base(typeof(object), "*", true) { }

    public NullableCharFiller(Type objectType, string propertyName) : base(objectType, propertyName) { }

    public override object GetValue(object instance)
     => new char?((char)GenFu.Random.Next(char.MinValue, char.MaxValue));
}
