using Angela.Core;
using NUnit.Framework;

namespace Angela.Tests
{
    [TestFixture]
    class ExtensionMethodTests
    {
        [SetUp]
        public void ResetAngie()
        {
            Angie.Reset();
        }

        [Test]
        public void AsEmailAddressForDomain()
        {
            var domain = "foofoofoobarbarbar.com";

            Angie.Configure<Person>()
                .Fill(p => p.EmailAddress)
                .AsEmailAddressForDomain(domain);

            var person = A.New<Person>();

            Assert.True(person.EmailAddress.Contains(domain));
        }

    }
}
