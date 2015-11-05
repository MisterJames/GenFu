using System;

namespace GenFu
{
    public interface IPropertyFiller
    {
        string[] PropertyNames { get; }
        string[] ObjectTypeNames { get; }
        bool IsGenericFiller { get; }
        Type PropertyType { get; }
        object GetValue();
    }
}