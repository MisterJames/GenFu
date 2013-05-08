using System;
using Angela.Core;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Angela.Tests
{
    [TestFixture]
    class JenTests
    {

        [Test]
        public void GetRandomValueFromArray()
        {
            string[] possibleValues = new[] {"A", "B", "C", "D", "E"};
            for (int i = 0; i < 500; i++)
            {
                string randomValue = Jen.GetRandomValue(possibleValues);
                Assert.IsNotNullOrEmpty(randomValue);
                CollectionAssert.Contains(possibleValues, randomValue);
            }
        }

        [Test]
        public void GetRandomValueFromList()
        {
            List<string> possibleValues = new List<string> { "1", "2", "3", "4", "5" };
            for (int i = 0; i < 500; i++)
            {
                string randomValue = Jen.GetRandomValue(possibleValues);
                Assert.IsNotNullOrEmpty(randomValue);
                CollectionAssert.Contains(possibleValues, randomValue);
            }
        }

        [Test]
        public void GetRandomValueFromEnumerable()
        {
            IEnumerable<string> possibleValues = (new []{ "1A", "2A", "3A", "4A", "5A" }).Select(s => s);
            for (int i = 0; i < 500; i++)
            {
                string randomValue = Jen.GetRandomValue(possibleValues);
                Assert.IsNotNullOrEmpty(randomValue);
                CollectionAssert.Contains(possibleValues, randomValue);
            }
        }

        [Test]
        public void MakeDateRuleFutureIsCorrect()
        {
            Angie.Reset();
            var date = Jen.Date(DateRules.FutureDates);
            Assert.Greater(date, DateTime.Now);
        }

        [Test]
        public void MakeDateRulePastIsCorrect()
        {
            Angie.Reset();
            var date = Jen.Date(DateRules.PastDate);
            Assert.Greater(DateTime.Now, date);
        }

        [Test]
        public void MakeDateWithinSpecifiedRange()
        {
            Angie.Reset();

            var minDate = DateTime.Now;
            var maxDate = DateTime.Now.AddDays(1);

            for (int i = 0; i < 1000; i++)
            {
                var date = Jen.Date(minDate, maxDate);
                Assert.GreaterOrEqual(date, minDate);
                Assert.LessOrEqual(date, maxDate);
            }

        }

        [Test]
        public void AddressContainsNumbers()
        {
            var addressLine = Jen.AddressLine();

            var streetNumber = 0;
            var addressPrefix = addressLine.Split(' ')[0];

            Assert.IsTrue(int.TryParse(addressPrefix, out streetNumber));

        }

        [Test]
        public void CanSetCustomDomainOnEmail()
        {
            var domain = "foofoofoobarbarbar.com";
            var email = Jen.Email(domain);
            Assert.True(email.Contains(domain));
        }

        [Test]
        public void PhoneNumberIsExpectedLength()
        {
            for (int i = 0; i < 1000; i++)
            {
                var phoneNumber = Jen.PhoneNumber();
                Assert.AreEqual(14, phoneNumber.Length);
            }
        }


    }
}
