using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

namespace GenFu.Tests
{
   
    public class When_testing_for_default_values
    {
        [Fact]
        public void Default_int_should_return_false()
        {
            var post = new BlogPost();
            Assert.False(DefaultValueChecker.HasValue(post, typeof(BlogPost).GetProperties().First(x => x.Name == "BlogPostId")));
        }

        [Fact]
        public void Filled_int16_should_return_true()
        {
            var post = new Person { NumberOfToes = 12 };
            Assert.True(DefaultValueChecker.HasValue(post, typeof(Person).GetProperties().First(x => x.Name == "NumberOfToes")));
        }
         
        [Fact]
        public void Default_int16_should_return_false()
        {
            var post = new Person();
            Assert.False(DefaultValueChecker.HasValue(post, typeof(Person).GetProperties().First(x => x.Name == "NumberOfToes")));
        }

        [Fact]
        public void Filled_long_should_return_true()
        {
            var post = new Person { HeightInMiliMeters = 12 };
            Assert.True(DefaultValueChecker.HasValue(post, typeof(Person).GetProperties().First(x => x.Name == "HeightInMiliMeters")));
        }

        [Fact]
        public void Default_long_should_return_false()
        {
            var post = new Person();
            Assert.False(DefaultValueChecker.HasValue(post, typeof(Person).GetProperties().First(x => x.Name == "HeightInMiliMeters")));
        }

        [Fact]
        public void Filled_decimal_should_return_true()
        {
            var post = new Person { HeightInMetres = 12 };
            Assert.True(DefaultValueChecker.HasValue(post, typeof(Person).GetProperties().First(x => x.Name == "HeightInMetres")));
        }

        [Fact]
        public void Default_decimal_should_return_false()
        {
            var post = new Person();
            Assert.False(DefaultValueChecker.HasValue(post, typeof(Person).GetProperties().First(x => x.Name == "HeightInMetres")));
        }

        [Fact]
        public void Filled_ulong_should_return_true()
        {
            var post = new Person { HeightInCentiMeters = 12 };
            Assert.True(DefaultValueChecker.HasValue(post, typeof(Person).GetProperties().First(x => x.Name == "HeightInCentiMeters")));
        }

        [Fact]
        public void Default_ulong_should_return_false()
        {
            var post = new Person();
            Assert.False(DefaultValueChecker.HasValue(post, typeof(Person).GetProperties().First(x => x.Name == "HeightInCentiMeters")));
        }

        [Fact]
        public void Filled_int_should_return_true()
        {
            var post = new BlogPost { BlogPostId = 12 };
            Assert.True(DefaultValueChecker.HasValue(post, typeof(BlogPost).GetProperties().First(x => x.Name == "BlogPostId")));
        }

        [Fact]
        public void Default_string_should_return_false()
        {
            var post = new BlogPost { };
            Assert.False(DefaultValueChecker.HasValue(post, typeof(BlogPost).GetProperties().First(x => x.Name == "Title")));
        }

        [Fact]
        public void Filled_string_should_return_true()
        {
            var post = new BlogPost { Title = "Bob" };
            Assert.True(DefaultValueChecker.HasValue(post, typeof(BlogPost).GetProperties().First(x => x.Name == "Title")));
        }

        [Fact]
        public void Default_datetime_should_return_false()
        {
            var post = new BlogPost { };
            Assert.False(DefaultValueChecker.HasValue(post, typeof(BlogPost).GetRuntimeProperties().First(x => x.Name == "CreateDate")));
        }

        [Fact]
        public void Filled_datetime_should_return_true()
        {
            var post = new BlogPost { CreateDate = DateTime.Now };
            Assert.True(DefaultValueChecker.HasValue(post, typeof(BlogPost).GetProperties().First(x => x.Name == "CreateDate")));
        }
    }
}
