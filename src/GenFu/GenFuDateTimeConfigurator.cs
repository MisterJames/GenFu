namespace GenFu;

using System.Reflection;

public class GenFuDateTimeConfigurator<T> : GenFuConfigurator<T> where T : new()
{
    private MemberInfo _propertyInfo;

    public GenFuDateTimeConfigurator(GenFu genfu, FillerManager fillerManager, MemberInfo propertyInfo)
        : base(genfu, fillerManager)
    {
        _propertyInfo = propertyInfo;
    }

    public MemberInfo PropertyInfo => _propertyInfo;
}
