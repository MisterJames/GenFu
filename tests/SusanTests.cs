using System;
using Angela.Core;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Angela.Tests
{
    [TestFixture]
    class SusanTests
    {
        [SetUp]
        public void ResetAngie()
        {
            Angie.Reset();
        }

        [Test]
        public void FirstNamesResourcesLoad()
        {
            var person = Angie.FastMake<Person>();
            string nameFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_FIRST_NAMES);

            Assert.AreNotEqual(string.Empty, person.FirstName, nameFail);
        }

        [Test]
        public void LastNamesResourcesLoad()
        {
            var person = Angie.FastMake<Person>();
            string nameFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_LAST_NAMES);

            Assert.AreNotEqual(string.Empty, person.LastName, nameFail);
        }

        [Test]
        public void TitleResourcesLoad()
        {
            var post = Angie.FastMake<BlogPost>();
            string titleFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_TITLES);

            Assert.AreNotEqual(string.Empty, post.Title, titleFail);
        }

        [Test]
        public void WordsResourcesLoad()
        {
            var person = Angie.FastMake<Person>();
            string wordFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_WORDS);

            Assert.AreNotEqual(string.Empty, person.Title, wordFail);
        }

        [Test]
        public void DomainResourceTest()
        {
            var person = Angie.FastMake<Person>();
            string twitterFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_FIRST_NAMES);

            Assert.AreNotEqual(string.Empty, person.Twitter, twitterFail);
        }

        [Test]
        public void TwitterResourceTest()
        {
            var person = Angie.FastMake<Person>();
            string emailFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_DOMAIN_NAMES);

            Assert.AreNotEqual(string.Empty, person.EmailAddress, emailFail);
        }


        [Test]
        public void StreetNameResourceTest()
        {
            string addressFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_STREET_NAMES);
            var addressLine = BaseValueGenerator.AddressLine();

            Assert.AreNotEqual(string.Empty, addressLine, addressFail);
        }

        [Test]
        public void CityNameResourceTest()
        {
            string cityFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_CITY_NAMES);
            var city = BaseValueGenerator.City();

            Assert.AreNotEqual(string.Empty, city, cityFail);
        }

        [Test]
        public void CanadianProvinceResourceTest()
        {
            string provinceFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_CDN_PROVINCE_NAMES);
            var city = BaseValueGenerator.City();

            Assert.AreNotEqual(string.Empty, city, provinceFail);
        }

        [Test]
        public void UsaStatesResourceTest()
        {
            string statesFail = string.Format(Angie.Defaults.STRING_LOADFAIL, Angie.Defaults.FILE_USA_STATE_NAMES);
            var city = BaseValueGenerator.City();

            Assert.AreNotEqual(string.Empty, city, statesFail);
        }
    }
}
