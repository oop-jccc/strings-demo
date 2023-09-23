using NUnit.Framework;

namespace StringTests;

[TestFixture]
public class StartWithContainsTest
{
    [Test]
    public void StartsWithTest()
    {
        Assert.IsTrue("Hello".StartsWith("He"));
    }

    [Test]
    public void EndsWithTest()
    {
        Assert.IsTrue("Hello".EndsWith("lo"));
    }

    [Test]
    public void ContainsTest()
    {
        Assert.IsTrue("Hello".Contains("lo"));
    }
}