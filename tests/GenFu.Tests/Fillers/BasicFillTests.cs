namespace GenFu.Tests;

using global::GenFu.Tests.TestEntities;
using global::GenFu.ValueGenerators.Geospatial;
using global::GenFu.ValueGenerators.Medical;
using global::GenFu.ValueGenerators.People;

using System.Linq;

using Xunit;

public class BasicFillTests
{
    public BasicFillTests()
    {
        A.Reset();
    }

    [Fact]
    public void FirstNamesResourcesLoad()
    {
        var person = A.New<Person>();

        Assert.NotEqual(string.Empty, person.FirstName);
    }

    [Fact]
    public void LastNamesResourcesLoad()
    {
        var person = A.New<Person>();

        Assert.NotEqual(string.Empty, person.LastName);
    }

    [Fact]
    public void TitleResourcesLoad()
    {
        var post = A.New<BlogPost>();

        Assert.NotEqual(string.Empty, post.Title);
    }

    [Fact]
    public void WordsResourcesLoad()
    {
        var person = A.New<Person>();

        Assert.NotEqual(string.Empty, person.Title);
    }

    [Fact]
    public void DomainResourceTest()
    {
        var person = A.New<Person>();

        Assert.NotEqual(string.Empty, person.Twitter);
    }

    [Fact]
    public void TwitterResourceTest()
    {
        var person = A.New<Person>();

        Assert.NotEqual(string.Empty, person.EmailAddress);
    }


    [Fact]
    public void StreetNameResourceTest()
    {
        var addressLine = Address.AddressLine();

        Assert.NotEqual(string.Empty, addressLine);
    }

    [Fact]
    public void CityNameResourceTest()
    {
        var city = Address.City();

        Assert.NotEqual(string.Empty, city);
    }

    [Fact]
    public void CanadianProvinceResourceTest()
    {
        var city = Address.CanadianProvince();

        Assert.NotEqual(string.Empty, city);
    }

    [Fact]
    public void UsaStatesResourceTest()
    {
        var state = Address.UsaState();

        Assert.NotEqual(string.Empty, state);
    }

    [Fact]
    public void CanadianProvinceAbbreviationsResourceTest()
    {
        var canadianProvinceAbbreviation = Address.CanadianProvinceAbbreviation();

        Assert.NotEqual(string.Empty, canadianProvinceAbbreviation);
    }

    [Fact]
    public void UsaStateAbbreviationsResourceTest()
    {
        var stateAbbreviation = Address.UsaStateAbbreviation();

        Assert.NotEqual(string.Empty, stateAbbreviation);
    }

    [Fact]
    public void InjuryResourceTest()
    {
        var injury = Injuries.Injury();

        Assert.NotEqual(string.Empty, injury);
    }

    [Fact]
    public void GenderResourceTest()
    {
        var gender = Qualities.Gender();

        Assert.NotEqual(string.Empty, gender);
    }

    [Fact]
    public void DrugResourceTest()
    {
        var drug = Drugs.Drug();

        Assert.NotEqual(string.Empty, drug);
    }

    [Fact]
    public void UseSuppliedResourceDataTest()
    {
        GenFu.Configure().Data(PropertyType.FirstNames, @"testdata\singlename.txt");
        var people = A.ListOf<Person>(25);
        Assert.Equal(25, people.Where(p => p.FirstName == "Angela").Count());
    }
}
