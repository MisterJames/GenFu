namespace GenFu.Tests;

using global::GenFu;
using global::GenFu.Tests.TestEntities;

using System.Collections.Generic;

using Xunit;

public class When_filling_object_graph
{
    private class Dog
    {
        public string Name { get; set; }
        public Person Owner { get; set; }
    }

    [Fact]
    public void FillPropertyWithRandomValuesFromList()
    {
        IList<Person> peeps = A.ListOf<Person>(10);

        A.Default().ListCount(25);

        A.Configure<Dog>().Fill(d => d.Owner).WithRandom(peeps);

        var dogs = A.ListOf<Dog>();
        foreach (Dog dog in dogs)
        {
            Assert.NotNull(dog.Owner);
            Assert.True(peeps.Contains(dog.Owner));
        }
    }

    [Fact]
    public void Inherited_fields_are_filed()
    {
        var comment = "Your blog is grrreat";
        A.Configure<ColourfulBlogComment>().Fill(x => x.Comment, () => comment);
        var item = A.New<ColourfulBlogComment>();

        Assert.NotNull(item.Comment);
        Assert.Equal("Your blog is grrreat", item.Comment);
    }

    [Fact(Skip = "Not yet supported but should be")]
    public void Inherited_fields_do_not_clash_with_other_subclasses()
    {
        var comment = "Your blog is grrreat";
        A.Configure<ColourfulBlogComment>().Fill(x => x.Comment, () => comment);
        A.Configure<DirtyBlogComment>().Fill(x => x.Comment, () => comment + "tt");

        var item = A.New<ColourfulBlogComment>();

        Assert.NotNull(item.Comment);
        Assert.Equal("Your blog is grrreat", item.Comment);
    }
}
