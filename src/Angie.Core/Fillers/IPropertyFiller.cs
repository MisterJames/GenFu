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
}