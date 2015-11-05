using GenFu;
using Xunit;

namespace GenFu.Tests
{
    public class ExtensionMethodTests
    {
        public ExtensionMethodTests()
        {
            A.Reset();
        }

        [Fact]
        public void AsEmailAddressForDomain()
        {
            var domain = "foofoofoobarbarbar.com";

            A.Configure<Person>()
                .Fill(p => p.EmailAddress)
                .AsEmailAddressForDomain(domain);

            var person = A.New<Person>();

            Assert.True(person.EmailAddress.Contains(domain));
        }

    }
}
