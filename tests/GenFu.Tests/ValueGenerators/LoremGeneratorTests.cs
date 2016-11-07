using GenFu.ValueGenerators.Lorem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GenFu.Tests.ValueGenerators
{
    public class LoremGeneratorTests
    {
        [Fact]
        public void CanGenerateValues()
        {
            var value = Lorem.GenerateWords(10);
            Assert.True(value.Length > 0);
        }
    }
}
