using System;
using Angela.Core;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        public void EmailAddressInNewClassIsValid()
        {
            Person person = Angie.FastMake<Person>();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(person.EmailAddress);
            Assert.IsTrue(match.Success, "Invalid Email Address: {0}", person.EmailAddress);

        }

        [Test]
        public void PhoneNumberInNewClassIsPopulated()
        {
            var person = Angie.FastMake<Person>();
            Assert.IsTrue(!string.IsNullOrEmpty(person.PhoneNumber));
        }

        [Test]
        public void IntInNewClassIsPopulated()
        {
            var person = Angie.FastMake<Person>();
            Assert.IsTrue(person.NumberOfKids != default(int));
        }

        [Test]
        public void BasicTypesInExistingClassArePopulated()
        {
            var person = Angie.FastFill(new Person());

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
            var person = Angie.FastFill(new Person { FirstName = firstName, Age = age, BirthDate = date });

            // for test brievity
            Assert.AreEqual(person.FirstName, firstName, "String property was altered. Aborting additional asserts in test.");
            Assert.AreEqual(person.Age, age, "Int property was altered. Aborting additional asserts in test.");
            Assert.AreEqual(person.BirthDate, date, "Date was altered. Aborting additional asserts in test.");
        }

        [Test]
        public void IntMaxNotExceededOnGeneratedValue()
        {
            var maxNumberOfKids = 5;

            Angie.Default()
                .MaxInt(maxNumberOfKids);

            for (int i = 0; i < 500; i++)
            {
                var person = Angie
                    .FastMake<Person>();

                if (!(person.NumberOfKids <= maxNumberOfKids))
                    Assert.Fail("Int max was exceeded: {0} ", person.NumberOfKids);
            }

        }
        
        [Test]
        public void IntMinNotExceededOnGeneratedValue()
        {
            var minNumberOfKids = 5;

            Angie.Default()
                .MinInt(minNumberOfKids);

            for (int i = 0; i < 500; i++)
            {
                var person = Angie
                    .FastMake<Person>();

                if (!(person.NumberOfKids >= minNumberOfKids))
                    Assert.Fail("Int min was exceeded: {0} ", person.NumberOfKids);
            }                      

        }
        
        [Test]
        public void IntRangeWithinBoundsOnGeneratedValue()
        {
            var success = true;

            // use a small window to try to force collisions
            var minAge = 20;
            var maxAge = 22;

            Angie.Reset();

            for (int i = 0; i < 500; i++)
            {
                var person = Angie                    
                    .Configure<Person>()
                    .Fill(p=> p.Age)
                    .WithinRange(minAge, maxAge)
                    .Make<Person>();

                success = (person.Age >= minAge && person.Age <= maxAge);

                Assert.IsTrue(success, "Int was generated outside of range.{0}", person.Age);
            }            
        }


        private class ClassWithShortProperty
        {
            public short ShortProperty { get; set; }
        }

        [Test]
        public void ShortMaxNotExceededOnGeneratedValue()
        {
            short maxShort = 4;

            Angie.Default()
                .MaxShort(maxShort);

            for (int i = 0; i < 500; i++)
            {
                var instance = Angie
                    .FastMake<ClassWithShortProperty>();

                if (!(instance.ShortProperty <= maxShort))
                    Assert.Fail("Short max was exceeded: {0} ", instance.ShortProperty);
            }

        }

        [Test]
        public void ShortMinNotExceededOnGeneratedValue()
        {
            short minNumberOfKids = 5;

            Angie.Default()
                .MinShort(minNumberOfKids);

            for (int i = 0; i < 500; i++)
            {
                var instance = Angie
                    .FastMake<ClassWithShortProperty>();

                if (!(instance.ShortProperty >= minNumberOfKids))
                    Assert.Fail("Short min was exceeded: {0} ", instance.ShortProperty);
            }

        }

        [Test]
        public void ShortRangeWithinBoundsOnGeneratedValue()
        {
            // use a small window to try to force collisions
            const short minValue = 20;
            const short maxValue = 22;

            Angie.Reset();

            for (int i = 0; i < 500; i++)
            {
                var person = Angie
                    .Configure<ClassWithShortProperty>()
                    .Fill(p => p.ShortProperty)
                    .WithinRange(minValue, maxValue)
                    .Make();

                bool success = (person.ShortProperty >= minValue && person.ShortProperty <= maxValue);

                Assert.IsTrue(success, "Short was generated outside of range.{0}", person.ShortProperty);
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
        public void MakeListGeneratesCorrectNumberOfEntriesWithDefaults()
        {
            Angie.Reset();
            var personCount = 13;

            Angie.Default()
                .ListCount(personCount);

            var people = Angie
                .FastList<Person>();

            Assert.AreEqual(people.Count(), personCount);
        }

        [Test]
        public void MakeListGeneratesCorrectNumberOfEntriesWithStaticOverload()
        {
            Angie.Reset();
            var personCount = 13;

            var people = Angie
                .FastList<Person>(personCount);

            Assert.AreEqual(people.Count(), personCount);
        }

        [Test]
        public void MakeListGeneratesCorrectNumberOfEntriesWithInstanceOverload()
        {
            Angie.Reset();
            var personCount = 13;

            var people = Angie
                .Configure<Person>()
                .MakeList<Person>(personCount);

            Assert.AreEqual(people.Count(), personCount);
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

            for (int i = 0; i < 500; i++)
            {
                Angie.Default()
                    .DateRange(DateTime.Now.AddMilliseconds(-10), DateTime.Now.AddMilliseconds(10));

                var person = Angie
                    .Configure()
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

            var person = Angie.Configure<Person>()
                .Fill(p => p.Age, delegate() { return age; })
                .Make<Person>();

            Assert.IsTrue(person.Age == age);

        }

        [Test]
        public void StringPropertyFilledBySpecificMethod()
        {
            var blogTitle = "Angie";

            var post = Angie.Configure<BlogPost>()
                .Fill(b => b.Title, () => blogTitle)
                .Make<BlogPost>();

            Assert.AreEqual(blogTitle, post.Title);
        }

        [Test]
        public void DateTimeFilledWithExpectedDateGivenRules()
        {
            var future = DateTime.Now.AddSeconds(1);

            Angie.Default()
                .ListCount(1000);

            var comments = Angie
                .Configure<BlogComment>()                
                .Fill(b => b.CommentDate, delegate() { return BaseValueGenerator.Date(DateRules.FutureDates); })
                .MakeList<BlogComment>();

            foreach (var comment in comments)
            {
                Assert.Greater(comment.CommentDate, future);
            }
        }

        [Test]
        public void ComplexPropertyFillsExecuted()
        {
            Angie.Default()
                .ListCount(5);

            var postcomments = Angie
            .Configure()
            .MakeList<BlogComment>();

            var blogpost = Angie
                .Configure<BlogPost>()
                .Fill(b => b.Comments, delegate { return postcomments; })
                .Make<BlogPost>();

            Assert.IsNotNull(blogpost.Comments);

        }

        [Test]
        public void CanadianProvinceIsFilled()
        {
            var location = Angie.FastMake<CanadianLocation>();
            Assert.IsFalse(string.IsNullOrEmpty(location.Province));
        }

        [Test]
        public void UsaStateIsFilled()
        {
            var location = Angie.FastMake<AmericanLocation>();
            Assert.IsFalse(string.IsNullOrEmpty(location.State));
        }

        [Test]
        public void CustomPropertyFillsAreChainableUsingSet()
        {
            Angie.Default()
                .ListCount(5);

            var blogpost = Angie
                .Configure<BlogPost>()
                .Fill(b => b.CreateDate, delegate() { return BaseValueGenerator.Date(DateRules.PastDate); })
                .Fill(b => b.Comments, delegate()
                {
                    return Angie
                        .Set<BlogComment>()
                        .Fill(b => b.CommentDate, delegate() { return BaseValueGenerator.Date(DateRules.PastDate); })
                        .MakeList<BlogComment>();
                })
            .Make<BlogPost>();

            Assert.IsNotNull(blogpost.Comments);
        }

        [Test]
        public void CustomPropertyFillsAreChainableUsingConfigure()
        {
            const string theTitle = "THE TITLE";

            var blogposts = Angie
                .Configure<BlogPost>()
                .Fill(b => b.Title, () => theTitle)
                .Fill(b => b.Comments, delegate()
                {
                    return Angie
                        .Configure<BlogComment>()
                        .Fill(b => b.CommentDate, delegate() { return BaseValueGenerator.Date(DateRules.PastDate); })
                        .MakeList<BlogComment>();
                })
            .MakeList<BlogPost>();

            foreach (var blogPost in blogposts)
            {
                Assert.AreEqual(theTitle, blogPost.Title);    
            }
            
        }
    }
}
