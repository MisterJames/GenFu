using System;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace Angela.Core
{
    [InheritedExport]
    public interface IPropertyFiller
    {
        string[] PropertyNames { get; }
        string[] ObjectTypeNames { get; }
        bool IsGenericFiller { get; }
        Type PropertyType { get; }
        object GetValue();
    }
}