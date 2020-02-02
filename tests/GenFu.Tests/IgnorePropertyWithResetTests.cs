using GenFu.Tests.TestEntities;
using Xunit;

namespace GenFu.Tests
{
    public class IgnorePropertyWithResetTests
    {
        public IgnorePropertyWithResetTests()
        {
            A.Configure<Person>()
                .Ignore(x => x.FirstName);
        }
        [Fact]
        public void WhenResetNotCalled()
        {
            var person = A.New<Person>();
            Assert.Null(person.FirstName);
        }

        [Fact]
        public void WhenResetPersonCalled()
        {
            A.Reset<Person>();
            var person = A.New<Person>();
            Assert.NotNull(person.FirstName);
        }

        [Fact]
        public void WhenResetCalled()
        {
            A.Reset();
            var person = A.New<Person>();
            Assert.NotNull(person.FirstName);
        }

        [Fact]
        public void WhenResetCalledForOneType()
        {
            A.Configure<ApplicationUser>()
                .Ignore(x => x.UserName);

            //It will only reset the ignore properties of Person decalred in constructor
            A.Reset<Person>();

            var person = A.New<Person>();
            var applicationUser = A.New<ApplicationUser>();

            Assert.NotNull(person.FirstName);
            Assert.Null(applicationUser.UserName);
        }
    }
}
