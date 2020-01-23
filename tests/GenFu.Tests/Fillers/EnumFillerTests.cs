using GenFu.Tests.TestEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GenFu.Tests.Fillers
{
    public class EnumFillerTests
    {
        [Fact]
        public void Can_get_a_value()
        {
            var sut = new EnumFiller(typeof(BlogTypeEnum));
            var result = (BlogTypeEnum)sut.GetValue(null);
            Assert.NotNull(Enum.GetName(typeof(BlogTypeEnum), result));
        }

        [Fact]
        public void FillsRandomlyWithAllPossibleValues()
        {
            var valuesNotYetUsed = new HashSet<BlogTypeEnum>();
            var allPossibleValues = Enum.GetValues(typeof(BlogTypeEnum));
            foreach (var value in allPossibleValues)
            {
                valuesNotYetUsed.Add((BlogTypeEnum)value);
            }
            var filler = new EnumFiller(typeof(BlogTypeEnum));

            for (int i = 0; i < 10000; i++)
            {
                var result = (BlogTypeEnum)filler.GetValue(null);
                if (valuesNotYetUsed.Contains(result))
                {
                    valuesNotYetUsed.Remove(result);
                    if (!valuesNotYetUsed.Any())
                    {
                        break;
                    }
                }
            }


            Assert.False(valuesNotYetUsed.Any(), "Enum filler did not use all possible values");

        }
    }
}
