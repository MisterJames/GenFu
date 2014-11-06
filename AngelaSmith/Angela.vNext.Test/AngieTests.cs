using System;
using Angela.Core;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Angela.Core.ValueGenerators.Temporal;
using Xunit;

namespace Angela.Tests
{
    public class AngieTests
    {
        [Fact]
        public void StringInNewClassIsPopulated()
        {

            var person = Angie.New<Person>();
            Assert.True(!string.IsNullOrEmpty(person.FirstName));
        }

        [Fact]
        public void EmailAddressInNewClassIsValid()
        {
            Person person = Angie.New<Person>();
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(person.EmailAddress);
            Assert.True(match.Success, "Invalid Email Address: {0}");

        }

        [Fact]
        public void PhoneNumberInNewClassIsPopulated()
        {
            var person = A.New<Person>();
            Assert.True(!string.IsNullOrEmpty(person.PhoneNumber));
        }

        [Fact]
        public void IntInNewClassIsPopulated()
        {
            var person = A.New<Person>();
            Assert.True(person.NumberOfKids != default(int));
        }

        [Fact]
        public void BasicTypesInExistingClassArePopulated()
        {
            var person = A.New(new Person());

            // for test brievity
            Assert.True(!string.IsNullOrEmpty(person.FirstName));
            Assert.True(person.Age != default(int));
            Assert.True(person.BirthDate != default(DateTime));
        }

        [Fact]
        public void PopulatedBasicTypesInExistingClassRemainsUnchanged()
        {
            var firstName = "Angie";
            var age = 29;
            var date = DateTime.Now.AddYears(-29);
            var person = A.New(new Person { FirstName = firstName, Age = age, BirthDate = date });

            // for test brievity
            Assert.Equal(person.FirstName, firstName);
            Assert.Equal(person.Age, age);
            Assert.Equal(person.BirthDate, date);
        }

        [Fact]
        public void IntMaxNotExceededOnGeneratedValue()
        {
            var maxNumberOfKids = 5;

            Angie.Default()
                .MaxInt(maxNumberOfKids);

            for (int i = 0; i < 10; i++)
            {
                var person = Angie
                    .New<Person>();

                Assert.True(person.NumberOfKids <= maxNumberOfKids);

            }

        }

        [Fact]
        public void IntMinNotExceededOnGeneratedValue()
        {
            var minNumberOfKids = 5;

            Angie.Default()
                .MinInt(minNumberOfKids);

            for (int i = 0; i < 10; i++)
            {
                var person = Angie
                    .New<Person>();

                Assert.True(person.NumberOfKids >= minNumberOfKids);
            }

        }

        [Fact]
        public void IntRangeWithinBoundsOnGeneratedValue()
        {
            var success = true;

            // use a small window to try to force collisions
            var minAge = 20;
            var maxAge = 22;

            Angie.Reset();

            for (int i = 0; i < 500; i++)
            {
                Angie
                    .Configure<Person>()
                    .Fill(p => p.Age)
                    .WithinRange(minAge, maxAge);
                var person = A.New<Person>();

                success = (person.Age >= minAge && person.Age <= maxAge);

                Assert.True(success);
            }
        }


        private class ClassWithShortProperty
        {
            public short ShortProperty { get; set; }
        }

        [Fact]
        public void ShortMaxNotExceededOnGeneratedValue()
        {
            short maxShort = 4;

            Angie.Default()
                .MaxShort(maxShort);

            for (int i = 0; i < 500; i++)
            {
                var instance = Angie
                    .New<ClassWithShortProperty>();

                Assert.True(instance.ShortProperty <= maxShort);
            }

        }

        [Fact]
        public void ShortMinNotExceededOnGeneratedValue()
        {
            short minNumberOfKids = 5;

            Angie.Default()
                .MinShort(minNumberOfKids);

            for (int i = 0; i < 500; i++)
            {
                var instance = Angie
                    .New<ClassWithShortProperty>();

                Assert.True(instance.ShortProperty >= minNumberOfKids);
            }

        }

        [Fact]
        public void ShortRangeWithinBoundsOnGeneratedValue()
        {
            // use a small window to try to force collisions
            const short minValue = 20;
            const short maxValue = 22;

            Angie.Reset();

            for (int i = 0; i < 500; i++)
            {
                Angie
                       .Configure<Person>()
                       .Fill(p => p.NumberOfToes)
                       .WithinRange(minValue, maxValue);

                var person = A.New<Person>();

                Assert.True(person.NumberOfToes >= minValue && person.NumberOfToes <= maxValue);

            }

        }

        //[Test]
        //public void AgeIsAlwaysPositive()
        //{
        //    var person = Angie.New<Person>();
        //    Assert.IsTrue(person.Age >= 0);
        //}

        //[Test]
        //public void ListOfDefaultGenerates25Entries()
        //{
        //    var people = Angie.ListOf<Person>();

        //    Assert.AreEqual(Angie.Defaults.LIST_COUNT, people.Count(),
        //        string.Format("Expected {0} but collection contained {1}", 
        //        Angie.Defaults.LIST_COUNT, people.Count())
        //        );
        //}

        //[Test]
        //public void ListOfGeneratesCorrectNumberOfEntries()
        //{
        //    var personCount = 17;
        //    var people = Angie.ListOf<Person>(personCount);
        //    Assert.AreEqual(people.Count(), personCount);
        //}

        //[Test]
        //public void MakeListDefaultsTo25Entries()
        //{
        //    var people = Angie
        //        .Configure()                // get an instantiated object for the non-static call
        //        .MakeList<Person>();
        //    Assert.IsTrue(people.Count() == Angie.Defaults.LIST_COUNT);
        //}

        //[Test]
        //public void MakeListGeneratesCorrectNumberOfEntriesWithDefaults()
        //{
        //    Angie.Reset();
        //    var personCount = 13;

        //    Angie.Default()
        //        .ListCount(personCount);

        //    var people = Angie
        //        .ListOf<Person>();

        //    Assert.AreEqual(people.Count(), personCount);
        //}

        //[Test]
        //public void MakeListGeneratesCorrectNumberOfEntriesWithStaticOverload()
        //{
        //    Angie.Reset();
        //    var personCount = 13;

        //    var people = Angie
        //        .ListOf<Person>(personCount);

        //    Assert.AreEqual(people.Count(), personCount);
        //}

        //[Test]
        //public void MakeListGeneratesCorrectNumberOfEntriesWithInstanceOverload()
        //{
        //    Angie.Reset();
        //    var personCount = 13;

        //    var people = Angie
        //        .Configure<Person>()
        //        .MakeList<Person>(personCount);

        //    Assert.AreEqual(people.Count(), personCount);
        //}

        //[Test]
        //public void DateTimesAreInitialized()
        //{
        //    var post = Angie.New<BlogPost>();
        //    Assert.IsTrue(post.CreateDate != default(DateTime));
        //}

        //[Test]
        //public void DateTimesStayWithinConfiguredDates()
        //{
        //    var success = true;

        //    // use a small window to try to force collisions
        //    var minDate = DateTime.Now.AddMilliseconds(-5);
        //    var maxDate = DateTime.Now.AddMilliseconds(5);

        //    for (int i = 0; i < 500; i++)
        //    {
        //        Angie.Default()
        //            .DateRange(DateTime.Now.AddMilliseconds(-10), DateTime.Now.AddMilliseconds(10));

        //        var person = Angie
        //            .Configure()
        //            .Make<Person>();

        //        if (!(person.BirthDate >= minDate && person.BirthDate <= maxDate))
        //            success = false;
        //        else
        //            Assert.IsTrue(success, "Date was generated outside of range.{0}", person.BirthDate);
        //    }


        //}

        //[Test]
        //public void IntPropertyFilledBySpecificMethod()
        //{
        //    var age = 11;

        //    var person = Angie.Configure<Person>()
        //        .Fill(p => p.Age, delegate() { return age; })
        //        .Make<Person>();

        //    Assert.IsTrue(person.Age == age);

        //}

        //[Test]
        //public void StringPropertyFilledBySpecificMethod()
        //{
        //    var blogTitle = "Angie";

        //    var post = Angie.Configure<BlogPost>()
        //        .Fill(b => b.Title, () => blogTitle)
        //        .Make<BlogPost>();

        //    Assert.AreEqual(blogTitle, post.Title);
        //}

        //[Test]
        //public void DateTimeFilledWithExpectedDateGivenRules()
        //{
        //    var future = DateTime.Now.AddSeconds(1);

        //    Angie.Default()
        //        .ListCount(1000);

        //    var comments = Angie
        //        .Configure<BlogComment>()
        //        .Fill(b => b.CommentDate, delegate() { return CalendarDate.Date(DateRules.FutureDates); })
        //        .MakeList<BlogComment>();

        //    foreach (var comment in comments)
        //    {
        //        Assert.Greater(comment.CommentDate, future);
        //    }
        //}

        //[Test]
        //public void ComplexPropertyFillsExecuted()
        //{
        //    Angie.Default()
        //        .ListCount(5);

        //    var postcomments = Angie
        //    .Configure()
        //    .MakeList<BlogComment>();

        //    var blogpost = Angie
        //        .Configure<BlogPost>()
        //        .Fill(b => b.Comments, delegate { return postcomments; })
        //        .Make<BlogPost>();

        //    Assert.IsNotNull(blogpost.Comments);

        //}

        //[Test]
        //public void CanadianProvinceIsFilled()
        //{
        //    var location = Angie.New<CanadianLocation>();
        //    Assert.IsFalse(string.IsNullOrEmpty(location.Province));
        //}

        //[Test]
        //public void UsaStateIsFilled()
        //{
        //    var location = Angie.New<AmericanLocation>();
        //    Assert.IsFalse(string.IsNullOrEmpty(location.State));
        //}

        //[Test]
        //public void CustomPropertyFillsAreChainableUsingSet()
        //{
        //    Angie.Default()
        //        .ListCount(5);

        //    var blogpost = Angie
        //        .Configure<BlogPost>()
        //        .Fill(b => b.CreateDate, delegate() { return CalendarDate.Date(DateRules.PastDate); })
        //        .Fill(b => b.Comments, delegate()
        //        {
        //            return Angie
        //                .Set<BlogComment>()
        //                .Fill(b => b.CommentDate, delegate() { return CalendarDate.Date(DateRules.PastDate); })
        //                .MakeList<BlogComment>();
        //        })
        //    .Make<BlogPost>();

        //    Assert.IsNotNull(blogpost.Comments);
        //}

        //[Test]
        //public void CustomPropertyFillsAreChainableUsingConfigure()
        //{
        //    const string theTitle = "THE TITLE";

        //    var blogposts = Angie
        //        .Configure<BlogPost>()
        //        .Fill(b => b.Title, () => theTitle)
        //        .Fill(b => b.Comments, delegate()
        //        {
        //            return Angie
        //                .Configure<BlogComment>()
        //                .Fill(b => b.CommentDate, delegate() { return CalendarDate.Date(DateRules.PastDate); })
        //                .MakeList<BlogComment>();
        //        })
        //    .MakeList<BlogPost>();

        //    foreach (var blogPost in blogposts)
        //    {
        //        Assert.AreEqual(theTitle, blogPost.Title);    
        //    }

        //}

        //[Test]
        //public void ShouldIgnoreUnsettableProperties()
        //{
        //    var list = Angie.Configure<BlogCommenter>()
        //        .MakeList<BlogCommenter>();
        //}

        //[Test]
        //public void MethodIsLeftAloneWhenMatchesNothing()
        //{
        //    // currently fills
        //    var person = Angie.New<Person>();
        //    Assert.IsTrue(string.IsNullOrEmpty(person.GetMiddleName()));
        //}

        //[Test]
        //public void MethodIsFilledWhenSpecified()
        //{
        //    var person = Angie.Configure<Person>().MethodFill<string>(x => x.SetMiddleName(null)).Make<Person>();
        //    Assert.IsTrue(!string.IsNullOrEmpty(person.GetMiddleName()));
        //}


        //[Test]
        //public void MethodFillStrategyCanBeSpecified()
        //{
        //    IList<string> names = new List<string> {"aaa", "bbb", "ccc"};
        //    var person =
        //        Angie.Configure<Person>()
        //            .MethodFill<string>(x => x.SetMiddleName(null))
        //            .WithRandom(names)
        //            .Make<Person>();
        //    Assert.IsTrue(!string.IsNullOrEmpty(person.GetMiddleName()));
        //    CollectionAssert.Contains(names, person.GetMiddleName());
        //}

        //[Test]
        //public void MethodCanBeSet()
        //{
        //    var expected = "q";
        //    var person = Angie.Configure<Person>().MethodFill<string>(x => x.SetMiddleName(null), () => expected).Make<Person>();
        //    Assert.IsTrue(!string.IsNullOrEmpty(person.GetMiddleName()));
        //    Assert.AreEqual(expected, person.GetMiddleName());
        //}
    }
}
