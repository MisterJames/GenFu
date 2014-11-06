using Angela.Core;
using NUnit.Framework;

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


    [TestFixture]
    public class PluginFillersTest
    {
        [Test]
        public void TestThatAdditionalFiltersAreFoundAndUsed()
        {
            TestClass testClass = Angie.New<TestClass>();
            Assert.AreEqual(PluginPropertyFiller.Value, testClass.TestProperty);

        }
    }
}
