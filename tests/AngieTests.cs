using Angela.Core;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Angela.Tests
{
    [TestFixture]
    class AngieTests
    {
        [SetUp]
        public void ResetAngie()
        {
            Angie.Reset();
        }

        [Test]
        public void StringInNewClassIsPopulated()
        {
            var person = Angie.FastMake<Person>();
            Assert.IsTrue(!string.IsNullOrEmpty(person.FirstName));
        }

        [Test]
        public void IntInNewClassIsPopulated()
        {
            var person = Angie.FastMake<Person>();
            Assert.IsTrue(person.Age != default(int));
        }

        [Test]
        public void BasicTypesInExistingClassArePopulated()
        {
            var person = Angie.FastFill<Person>(new Person());

            // for test brievity
            Assert.IsTrue(!string.IsNullOrEmpty(person.FirstName), "String property was not populated. Aborting additional asserts in test.");
            Assert.IsTrue(person.Age != default(int), "Int property was not populated. Aborting additional asserts in test.");
            Assert.IsTrue(person.BirthDate != default(DateTime), "DateTime was left as default value. Aborting additional asserts in test.");
        }

        [Test]
        public void PopulatedBasicTypesInExistingClassRemainsUnchanged()
        {
            var firstName = "Angie";
            var age = 29;
            var date = DateTime.Now.AddYears(-29);
            var person = Angie.FastFill<Person>(new Person { FirstName = firstName, Age = age, BirthDate = date });

            // for test brievity
            Assert.AreEqual(person.FirstName, firstName, "String property was altered. Aborting additional asserts in test.");
            Assert.AreEqual(person.Age, age, "Int property was altered. Aborting additional asserts in test.");
            Assert.AreEqual(person.BirthDate, date, "Date was altered. Aborting additional asserts in test.");
        }

        [Test]
        public void IntMaxNotExceededOnGeneratedValue()
        {
            var maxAge = 5;

            for (int i = 0; i < 2500; i++)
            {
                var person = Angie
                    .Configure()
                    .MaxInt(maxAge)
                    .Make<Person>();

                if (!(person.Age <= maxAge))
                    Assert.Fail("Int max was exceeded: {0} ", person.Age);
            }

        }
        
        [Test]
        public void IntMinNotExceededOnGeneratedValue()
        {
            var minAge = 5;

            for (int i = 0; i < 2500; i++)
            {
                var person = Angie
                    .Configure()
                    .MinInt(minAge)
                    .Make<Person>();

                if (!(person.Age >= minAge))
                    Assert.Fail("Int min was exceeded: {0} ", person.Age);
            }

            

        }
        
        [Test]
        public void IntRangeWithinBoundsOnGeneratedValue()
        {
            var success = true;

            // use a small window to try to force collisions
            var minAge = 20;
            var maxAge = 22;

            for (int i = 0; i < 1000; i++)
            {
                var person = Angie
                    .Configure()
                    .IntRange(minAge, maxAge)
                    .Make<Person>();

                if (!(person.Age >= minAge && person.Age <= maxAge))
                    success = false;
                else
                    Assert.IsTrue(success, "Int was generated outside of range.{0}", person.Age);
            }

            

        }

        [Test]
        public void AgeIsAlwaysPositive()
        {
            var person = Angie.FastMake<Person>();
            Assert.IsTrue(person.Age >= 0);
        }

        [Test]
        public void FastListDefaultGenerates25Entries()
        {
            var people = Angie.FastList<Person>();

            Assert.AreEqual(Angie.Defaults.LIST_COUNT, people.Count(),
                string.Format("Expected {0} but collection contained {1}", 
                Angie.Defaults.LIST_COUNT, people.Count())
                );
        }

        [Test]
        public void FastListGeneratesCorrectNumberOfEntries()
        {
            var personCount = 17;
            var people = Angie.FastList<Person>(personCount);
            Assert.AreEqual(people.Count(), personCount);
        }

        [Test]
        public void MakeListDefaultsTo25Entries()
        {
            var people = Angie
                .Configure()                // get an instantiated object for the non-static call
                .MakeList<Person>();
            Assert.IsTrue(people.Count() == Angie.Defaults.LIST_COUNT);
        }

        [Test]
        public void MakeListGeneratesCorrectNumberOfEntries()
        {
            var personCount = 13;
            var people = Angie
                .Configure()
                .ListCount(personCount)
                .MakeList<Person>();
            Assert.IsTrue(people.Count() == personCount);
        }

        [Test]
        public void DateTimesAreInitialized()
        {
            var post = Angie.FastMake<BlogPost>();
            Assert.IsTrue(post.CreateDate != default(DateTime));
        }

        [Test]
        public void DateTimesStayWithinConfiguredDates()
        {
            var success = true;

            // use a small window to try to force collisions
            var minDate = DateTime.Now.AddMilliseconds(-5);
            var maxDate = DateTime.Now.AddMilliseconds(5);

            for (int i = 0; i < 1000; i++)
            {
                var person = Angie
                    .Configure()
                    .DateRange(DateTime.Now.AddMilliseconds(-10), DateTime.Now.AddMilliseconds(10))
                    .Make<Person>();

                if (!(person.BirthDate >= minDate && person.BirthDate <= maxDate))
                    success = false;
                else
                    Assert.IsTrue(success, "Date was generated outside of range.{0}", person.BirthDate);
            }


        }

        [Test]
        public void IntPropertyFilledBySpecificMethod()
        {
            var age = 11;

            var person = Angie.Configure()
                .FillBy("age", delegate() { return age; })
                .Make<Person>();

            Assert.IsTrue(person.Age == age);

        }

        [Test]
        public void StringPropertyFilledBySpecificMethod()
        {
            var blogTitle = "Angie";

            var post = Angie.Configure()
                .FillBy("title", delegate() { return blogTitle; })
                .Make<BlogPost>();

            Assert.IsTrue(post.Title == blogTitle);
        }

        [Test]
        public void DateTimeFilledWithExpectedDateGivenRules()
        {
            var future = DateTime.Now.AddSeconds(1);

            var comments = Angie
                .Configure()
                .ListCount(1000)
                .FillBy("CommentDate", delegate() { return Angie.MakeDate(DateRules.FutureDates); })
                .MakeList<BlogComment>();

            foreach (var comment in comments)
            {
                Assert.Greater(comment.CommentDate, future);
            }
        }

        [Test]
        public void MakeDateRuleFutureIsCorrect()
        {
            var future = DateTime.Now.AddMilliseconds(1);
            var date = Angie.MakeDate(DateRules.FutureDates);
            Assert.Greater(date, future);
        }

        [Test]
        public void MakeDateRulePastIsCorrect()
        {
            var past = DateTime.Now.AddMilliseconds(-1);
            var date = Angie.MakeDate(DateRules.PastDate);
            Assert.Greater(past, date);
        }



    }
}
