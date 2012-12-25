using Angela.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string nameFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_FIRST_NAMES);

            Assert.AreNotEqual(nameFail, person.FirstName, nameFail);
        }

        [Test]
        public void LastNamesResourcesLoad()
        {
            var person = Angie.FastMake<Person>();
            string nameFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_LAST_NAMES);

            Assert.AreNotEqual(nameFail, person.LastName, nameFail);
        }

        [Test]
        public void TitleResourcesLoad()
        {
            var post = Angie.FastMake<BlogPost>();
            string titleFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_TITLES);

            Assert.AreNotEqual(titleFail, post.Title, titleFail);
        }

        [Test]
        public void WordsResourcesLoad()
        {
            var person = Angie.FastMake<Person>();
            string wordFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_WORDS);

            Assert.AreNotEqual(wordFail, person.Title, wordFail);
        }

        [Test]
        public void DomainResourceTest()
        {
            var person = Angie.FastMake<Person>();
            string emailFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_DOMAIN_NAMES);

            Assert.AreNotEqual(emailFail, person.EmailAddress, emailFail);
        }

        [Test]
        public void MakeDateRuleFutureIsCorrect()
        {
            var future = DateTime.Now.AddMilliseconds(1);
            var date = Susan.FillDate(DateRules.FutureDates);
            Assert.Greater(date, future);
        }

        [Test]
        public void MakeDateRulePastIsCorrect()
        {
            var past = DateTime.Now.AddMilliseconds(-1);
            var date = Susan.FillDate(DateRules.PastDate);
            Assert.Greater(past, date);
        }

        [Test]
        public void AddressContainsNumbers()
        {
            var addressLine = Susan.FillAddressLine();

            var streetNumber = 0;
            var addressPrefix = addressLine.Split(' ')[0];

            Assert.IsTrue(int.TryParse(addressPrefix, out streetNumber));
            
        }

        [Test]
        public void StreetNameResourceTest()
        {
            string addressFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_STREET_NAMES);
            var addressLine = Susan.FillAddressLine();

            Assert.AreNotEqual(addressFail, addressLine, addressFail);
        }

        [Test]
        public void CityNameResourceTest()
        {
            string cityFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_CITY_NAMES);
            var city = Susan.FillCity();

            Assert.AreNotEqual(cityFail, city, cityFail);
        }

        [Test]
        public void CanadianProvinceResourceTest()
        {
            string provinceFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_CDN_PROVINCE_NAMES);
            var city = Susan.FillCity();

            Assert.AreNotEqual(provinceFail, city, provinceFail);
        }

        [Test]
        public void CanadianProvinceIsFilled()
        {
            var location = Angie.FastMake<CanadianLocation>();
            Assert.IsFalse(string.IsNullOrEmpty(location.Province));
        }

        [Test]
        public void UsaStatesResourceTest()
        {
            string statesFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_USA_STATE_NAMES);
            var city = Susan.FillCity();

            Assert.AreNotEqual(statesFail, city, statesFail);
        }

        [Test]
        public void UsaStateIsFilled()
        {
            var location = Angie.FastMake<AmericanLocation>();
            Assert.IsFalse(string.IsNullOrEmpty(location.State));
        }


    }
}
