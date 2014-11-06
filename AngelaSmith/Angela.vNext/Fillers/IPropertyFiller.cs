using System;
using System.Composition;

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