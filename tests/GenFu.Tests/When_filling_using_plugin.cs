﻿namespace GenFu.Tests;

using global::GenFu;

using Xunit;

public class PluginPropertyFiller : PropertyFiller<string>
{
    public const string Value = "This is the expected value";
    public PluginPropertyFiller() : base(typeof(TestClass), "TestProperty") { }

    public override object GetValue(object instance)
    {
        return Value;
    }
}

public class TestClass
{
    public string TestProperty { get; set; }
}

public class When_filling_using_plugin
{
    [Fact(Skip = "not implemented yet")]
    public void Additional_Filters_are_Found_and_Used()
    {
        TestClass testClass = A.New<TestClass>();
        Assert.Equal(PluginPropertyFiller.Value, testClass.TestProperty);
    }
}
