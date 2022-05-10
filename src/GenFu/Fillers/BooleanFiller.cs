namespace GenFu.Fillers;

using System;

public class BooleanFiller : PropertyFiller<bool>
{
    public BooleanFiller() : base(typeof(object), "*", true) { }

    public BooleanFiller(Type objectType, string propertyName)
        : base(objectType, propertyName, false) { }

    public override object GetValue(object instance) => GenFu.Random.Next() % 2 == 0;
}

public class NullableBooleanFiller : PropertyFiller<bool?>
{

    public NullableBooleanFiller() : base(typeof(object), "*", true) { }

    public NullableBooleanFiller(Type objectType, string propertyName)
        : base(objectType, propertyName, false) { }

    public override object GetValue(object instance) => GenFu.Random.Next() % 2 == 0;
}
