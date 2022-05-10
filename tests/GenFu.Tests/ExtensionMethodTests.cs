namespace GenFu.Tests;

using global::GenFu;
using global::GenFu.Tests.TestEntities;

using System.Linq;

using Xunit;

public class ExtensionMethodTests
{
    public ExtensionMethodTests() => A.Reset();

    [Fact]
    public void AsEmailAddressForDomain()
    {
        var domain = "foofoofoobarbarbar.com";

        A.Configure<Person>()
            .Fill(p => p.EmailAddress)
            .AsEmailAddressForDomain(domain);

        var person = A.New<Person>();

        Assert.Contains(domain, person.EmailAddress);
    }

    [Fact]
    public void AsLoremIpsumWords()
    {
        int wordCount = 1000;
        A.Configure<BlogPost>()
            .Fill(p => p.Body)
            .AsLoremIpsumWords(wordCount);

        var post = A.New<BlogPost>();

        Assert.True(post.Body.Split(' ').Length == wordCount);

    }

    [Fact]
    public void AsLoremIpsumSentences()
    {
        int sentenceCount = 10;
        A.Configure<BlogPost>()
            .Fill(p => p.Body)
            .AsLoremIpsumSentences(sentenceCount);

        var post = A.New<BlogPost>();

        Assert.True(post.Body.Where(c => c == '.').Count() == sentenceCount);
    }
}
