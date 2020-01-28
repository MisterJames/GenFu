using System;
using GenFu;
using System.Linq;
using System.Collections.Generic;
using GenFu.ValueGenerators.People;
using GenFu.ValueGenerators.Geospatial;
using GenFu.ValueGenerators.Temporal;
using Xunit;

namespace GenFu.Tests
{
    public class BaseValueGeneratorTests
    {

        [Fact]
        public void GetRandomValueFromArray()
        {
            string[] possibleValues = new[] { "A", "B", "C", "D", "E" };
            for (int i = 0; i < 500; i++)
            {
                string randomValue = BaseValueGenerator.GetRandomValue(possibleValues);
                Assert.NotNull(randomValue);
                Assert.NotEmpty(randomValue);
                Assert.Contains(possibleValues, x => x == randomValue);
            }
        }

        [Fact]
        public void GetRandomValueFromList()
        {
            List<string> possibleValues = new List<string> { "1", "2", "3", "4", "5" };
            for (int i = 0; i < 500; i++)
            {
                string randomValue = BaseValueGenerator.GetRandomValue(possibleValues);
                Assert.NotNull(randomValue);
                Assert.NotEmpty(randomValue);
                Assert.Contains(possibleValues, x => x == randomValue);
            }
        }

        [Fact]
        public void GetRandomValueFromEnumerable()
        {
            IEnumerable<string> possibleValues = (new[] { "1A", "2A", "3A", "4A", "5A" }).Select(s => s);
            for (int i = 0; i < 500; i++)
            {
                string randomValue = BaseValueGenerator.GetRandomValue(possibleValues);
                Assert.NotNull(randomValue);
                Assert.NotEmpty(randomValue);
                Assert.Contains(possibleValues, x => x == randomValue);
            }
        }

        [Fact]
        public void MakeDateRuleFutureIsCorrect()
        {
            A.Reset();
            var now = DateTime.Now;
            var date = CalendarDate.Date(DateRules.FutureDates);
            Assert.True(date > now);
        }

        [Fact]
        public void MakeDateRulePastIsCorrect()
        {
            A.Reset();
            var now = DateTime.Now;
            var date = CalendarDate.Date(DateRules.PastDate);
            Assert.True(now > date);
        }

        [Fact]
        public void MakeDateWithinSpecifiedRange()
        {
            A.Reset();

            var minDate = DateTime.Now;
            var maxDate = DateTime.Now.AddDays(1);

            for (int i = 0; i < 1000; i++)
            {
                var date = CalendarDate.Date(minDate, maxDate);
                Assert.True(date >= minDate);
                Assert.True(date <= maxDate);
            }

        }

        [Fact]
        public void AddressContainsNumbers()
        {
            var addressLine = Address.AddressLine();

            var streetNumber = 0;
            var addressPrefix = addressLine.Split(' ')[0];

            Assert.True(int.TryParse(addressPrefix, out streetNumber));

        }

        [Fact]
        public void CanSetCustomDomainOnEmail()
        {
            var domain = "foofoofoobarbarbar.com";
            var email = ContactInformation.Email(domain);
            Assert.Contains(domain, email);
        }

        [Fact]
        public void PhoneNumberIsExpectedLength()
        {
            for (int i = 0; i < 1000; i++)
            {
                var phoneNumber = ContactInformation.PhoneNumber();
                Assert.Equal(14, phoneNumber.Length);
            }
        }


    }
}
