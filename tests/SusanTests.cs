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
        public void WordsResourcesLoad()
        {
            var person = Angie.FastMake<Person>();
            string wordFail = string.Format(Angie.Defaults.STRING_LOAD_FAIL, Angie.Defaults.FILE_WORDS);

            Assert.AreNotEqual(wordFail, person.Title, wordFail);
        }
    }
}
