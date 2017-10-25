using GenFu.Tests.TestEntities;
using System;
using Xunit;

namespace GenFu.Tests.Fillers
{
    public class EnumFillerTests
    {
        [Fact]
        void Can_get_a_value()
        {
            var sut = new EnumFiller(typeof(BlogTypeEnum));
            var result = (BlogTypeEnum)sut.GetValue(null);
            Assert.NotNull(Enum.GetName(typeof(BlogTypeEnum), result));
        }
    }
}
