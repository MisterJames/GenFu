namespace GenFu.Tests;

using global::GenFu.Tests.TestEntities;

using Xunit;

public class When_configuring_property_with_specific_value
{
    public When_configuring_property_with_specific_value() => A.Reset();

    [Fact]
    public void integer_property_should_always_be_set_to_specific_value()
    {
        A.Configure<BlogPost>().Fill(b => b.BlogPostId, 0);

        var bunchOfPosts = A.ListOf<BlogPost>(1000);
        Assert.Equal(1000, bunchOfPosts.Count);
        foreach (var post in bunchOfPosts)
        {
            Assert.Equal(0, post.BlogPostId);
        }
    }

    [Fact]
    public void string_property_should_always_be_set_to_specific_value()
    {
        var expectedString = "The value";
        A.Configure<BlogPost>().Fill(b => b.Body, expectedString);

        var bunchOfPosts = A.ListOf<BlogPost>(1000);
        Assert.Equal(1000, bunchOfPosts.Count);
        foreach (var post in bunchOfPosts)
        {
            Assert.Equal(expectedString, post.Body);
        }
    }
}
