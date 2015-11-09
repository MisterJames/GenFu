using GenFu;
using Xunit;

namespace GenFu.Tests
{
    public class PluginPropertyFiller : PropertyFiller<string>
    {
        public const string Value = "This is the expected value";
        public PluginPropertyFiller() : 
            base(new []{"TestClass"}, new []{"TestProperty"})
        {
        }

        public override object GetValue(object instance)
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
        [Fact(Skip = "not implemented yet")]
        public void TestThatAdditionalFiltersAreFoundAndUsed()
        {
            TestClass testClass = A.New<TestClass>();
            Assert.Equal(PluginPropertyFiller.Value, testClass.TestProperty);

        }
    }
}
