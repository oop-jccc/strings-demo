using System.Text;
using NUnit.Framework;

namespace StringTests;

[TestFixture]
public class StringConcatTests
{
    private const string HelloWorld = "--Hello World!--";
    private const string Hello = "Hello";
    private const string World = "World";
    private const string Exclamation = "!";

    [Test]
    public void StringConcatTest1()
    {
        const string testStr = "--" + Hello + " " + World + Exclamation + "--";
        Assert.AreEqual(HelloWorld, testStr);
    }

    [Test]
    public void StringConcatTest2()
    {
        var testStr = string.Concat("--", Hello, " ", World, Exclamation, "--");
        Assert.AreEqual(HelloWorld, testStr);
    }

    [Test]
    public void StringFormatTest()
    {
        var testStr = string.Format("--{0} {1}{2}--", Hello, World, Exclamation);
        Assert.AreEqual(HelloWorld, testStr);
    }

    [Test]
    public void InterpolationTest()
    {
        var testStr = $"--{Hello} {World}{Exclamation}--";
        Assert.AreEqual(HelloWorld, testStr);
    }

    [Test]
    public void StringBuilderTest()
    {
        var buffer = new StringBuilder("--");
        buffer.Append("Hello ").Append("World!").Append("--");
        var testStr = buffer.ToString();
        Assert.AreEqual(HelloWorld, testStr);
    }
}