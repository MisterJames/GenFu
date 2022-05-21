using GenFu.Tests.TestEntities;
using System.Collections.Generic;
using Xunit;

namespace GenFu.Tests
{
    public class IgnorePropertyTests
    {
        [Fact]
        public void IgnoreStringField()
        {
            A.Reset<Person>();
            A.Configure<Person>()
                .Ignore(x => x.FirstName);

            var person = A.New<Person>();
            Assert.Null(person.FirstName);
        }

        [Fact]
        public void IgnoreIntField()
        {
            A.Reset<Person>();
            A.Configure<Person>()
                .Ignore(x => x.Id);

            var person = A.New<Person>();
            Assert.Equal(default, person.Id);
        }

        [Fact]
        public void IgnoreDateTimeField()
        {
            A.Reset<Person>();
            A.Configure<Person>()
                .Ignore(x => x.BirthDate)
                .Ignore(x => x.DateOfDeath);

            var person = A.New<Person>();
            Assert.Null(person.DateOfDeath);
            Assert.Equal(default, person.BirthDate);
        }

        [Fact]
        public void IgnoreGuidField()
        {
            A.Reset<ApplicationUser>();
            A.Configure<ApplicationUser>()
                .Ignore(x => x.Id);

            var applicationUser = A.New<ApplicationUser>();
            Assert.Equal(default, applicationUser.Id);
        }

        [Fact]
        public void IgnoreNullableFields()
        {
            A.Reset<Nullables>();
            A.Configure<Nullables>()
                .Ignore(x => x.NullableBoolean)
                .Ignore(x => x.NullableChar)
                .Ignore(x => x.NullableDateTime)
                .Ignore(x => x.NullableDecimal)
                .Ignore(x => x.NullableDouble)
                .Ignore(x => x.NullableInt)
                .Ignore(x => x.NullableLong)
                .Ignore(x => x.NullableShort)
                .Ignore(x => x.NullableUInt)
                .Ignore(x => x.NullableULong);

            var nullableObject = A.New<Nullables>();

            Assert.Null(nullableObject.NullableBoolean);
            Assert.Null(nullableObject.NullableChar);
            Assert.Null(nullableObject.NullableDateTime);
            Assert.Null(nullableObject.NullableDecimal);
            Assert.Null(nullableObject.NullableDouble);
            Assert.Null(nullableObject.NullableInt);
            Assert.Null(nullableObject.NullableLong);
            Assert.Null(nullableObject.NullableShort);
            Assert.Null(nullableObject.NullableUInt);
            Assert.Null(nullableObject.NullableULong);
        }

        [Fact]
        public void IgnoreEnumField()
        {
            A.Reset();
            A.Configure<BlogPost>()
                .Ignore(x => x.Type);

            var blogPost = A.New<BlogPost>();
            Assert.Equal(default, blogPost.Type);
        }

        [Fact]
        public void IgnoreConstructorInitializedCollectionField()
        {
            A.Reset();
            A.Configure<BlogPost>()
                .Ignore(x => x.Tags);

            var blogPost = A.New<BlogPost>();
            Assert.Equal(new HashSet<string>(), blogPost.Tags);
        }

        [Fact]
        public void IgnoreUnInitializedCollectionField()
        {
            A.Reset();
            var postcomments = A.ListOf<BlogComment>();

            A.Configure<BlogPost>()
                .Fill(b => b.Comments, () => postcomments)
                .Ignore(x => x.Comments);
            var blogPost = A.New<BlogPost>();

            Assert.Equal(default, blogPost.Comments);
        }

        [Fact]
        public void IgnoreMultipleFields()
        {
            A.Reset<Person>();
            A.Configure<Person>()
                .Ignore(x=>x.NumberOfToes)
                .Ignore(x => x.LastName)
                .Ignore(x => x.FirstName);

            var person = A.New<Person>();
            Assert.Equal(default, person.NumberOfToes);
            Assert.Null(person.LastName);
            Assert.Null(person.FirstName);
        }
    }
}
