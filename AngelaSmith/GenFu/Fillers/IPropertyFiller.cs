using System;

namespace Angela.Core
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