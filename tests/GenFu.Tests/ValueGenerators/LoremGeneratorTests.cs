namespace GenFu.Tests.ValueGenerators;

using global::GenFu.ValueGenerators.Lorem;

using Xunit;

public class LoremGeneratorTests
{
    [Fact]
    public void CanGenerateValues()
    {
        var value = Lorem.GenerateWords(10);
        Assert.True(value.Length > 0);
    }
}
