using GenFu;
using Xunit;

namespace Angela.Tests
{
    public class PluginPropertyFiller : PropertyFiller<string>
    {
        public const string Value = "This is the expected value";
        public PluginPropertyFiller() : 
            base(new []{"TestClass"}, new []{"TestProperty"})
        {
        }

        public override object GetValue()
        {
            return Value;
        }
    }

    public class TestClass
    {
        public string TestProperty { get; set; }
    }

    public class PluginFillersTest
    {
        [Fact]
        public void TestThatAdditionalFiltersAreFoundAndUsed()
        {
            TestClass testClass = A.New<TestClass>();
            Assert.Equal(PluginPropertyFiller.Value, testClass.TestProperty);

        }
    }
}
