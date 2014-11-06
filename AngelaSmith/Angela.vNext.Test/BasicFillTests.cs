using System;
using GenFu;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using GenFu.ValueGenerators.Geospatial;

namespace Angela.Tests
{
    [TestFixture]
    class BasicFillTests
    {
        [SetUp]
        public void ResetAngie()
        {
            A.Reset();
        }

        [Test]
        public void FirstNamesResourcesLoad()
        {
            var person = A.New<Person>();
            string nameFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_FIRST_NAMES);

            Assert.AreNotEqual(string.Empty, person.FirstName, nameFail);
        }

        [Test]
        public void LastNamesResourcesLoad()
        {
            var person = A.New<Person>();
            string nameFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_LAST_NAMES);

            Assert.AreNotEqual(string.Empty, person.LastName, nameFail);
        }

        [Test]
        public void TitleResourcesLoad()
        {
            var post = A.New<BlogPost>();
            string titleFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_TITLES);

            Assert.AreNotEqual(string.Empty, post.Title, titleFail);
        }

        [Test]
        public void WordsResourcesLoad()
        {
            var person = A.New<Person>();
            string wordFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_WORDS);

            Assert.AreNotEqual(string.Empty, person.Title, wordFail);
        }

        [Test]
        public void DomainResourceTest()
        {
            var person = A.New<Person>();
            string twitterFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_FIRST_NAMES);

            Assert.AreNotEqual(string.Empty, person.Twitter, twitterFail);
        }

        [Test]
        public void TwitterResourceTest()
        {
            var person = A.New<Person>();
            string emailFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_DOMAIN_NAMES);

            Assert.AreNotEqual(string.Empty, person.EmailAddress, emailFail);
        }


        [Test]
        public void StreetNameResourceTest()
        {
            string addressFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_STREET_NAMES);
            var addressLine = Address.AddressLine();

            Assert.AreNotEqual(string.Empty, addressLine, addressFail);
        }

        [Test]
        public void CityNameResourceTest()
        {
            string cityFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_CITY_NAMES);
            var city = Address.City();

            Assert.AreNotEqual(string.Empty, city, cityFail);
        }

        [Test]
        public void CanadianProvinceResourceTest()
        {
            string provinceFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_CDN_PROVINCE_NAMES);
            var city = Address.City();

            Assert.AreNotEqual(string.Empty, city, provinceFail);
        }

        [Test]
        public void UsaStatesResourceTest()
        {
            string statesFail = string.Format(A.Defaults.STRING_LOADFAIL, A.Defaults.FILE_USA_STATE_NAMES);
            var city = Address.City();

            Assert.AreNotEqual(string.Empty, city, statesFail);
        }
    }
}
