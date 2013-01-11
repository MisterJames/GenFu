using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Angela.Core
{
    [InheritedExport]
    public interface IPropertyFiller
    {
        string[] PropertyNames { get; }
        bool IsGenericFiller { get; }
        Type ObjectType { get; }
        Type PropertyType { get; }
        object GetValue();
    }
}