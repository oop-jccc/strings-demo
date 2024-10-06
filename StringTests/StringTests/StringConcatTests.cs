using System.Runtime.CompilerServices;
using System.Text;
using NUnit.Framework;

namespace StringTests;

[TestFixture]
public class StringConcatTests
{
    // Spans:
    // - Introduced in .NET Core 2.1 and available in .NET Standard 2.1 and later.
    // - Span<T> is a stack-only type that provides memory-safe, efficient access to contiguous memory regions.
    // - Utilized extensively in modern .NET for high-performance string operations, including:
    //     - String.Concat
    //     - String.Format
    //     - String Interpolation
    //     - DefaultInterpolatedStringHandler and other string handlers
    // - Allows manipulation of memory slices without heap allocations, reducing garbage collection pressure.
    // - Enhances performance by enabling low-level memory operations, such as directly writing characters to a buffer.

    private const string HelloWorld = "--Hello World!--";
    private const string Hello = "Hello";
    private const string World = "World";
    private const string Exclamation = "!";

    [Test]
    public void StringConcatTest1()
    {
        const string testStr = "--" + Hello + " " + World + Exclamation + "--";
        Assert.AreEqual(HelloWorld, testStr);

        // Low-Level C#
        // The compiler optimizes by inlining and concatenating all const strings at compile time.
        // Therefore, 'testStr' is "--Hello World!--" without performing runtime concatenation.
        Assert.AreEqual("--Hello World!--", "--Hello World!--");
    }

    [Test]
    public void StringConcatTestNonConstant()
    {
        var dynamicPart = "Dynamic";
        var testStr = "--" + Hello + " " + World + dynamicPart + Exclamation + "--";
        Assert.AreEqual("--Hello WorldDynamic!--", testStr);

        // Low-Level C#
        // 'dynamicPart' is not a const, so the compiler cannot inline it.
        // As a result, the strings are concatenated at runtime using String.Concat.
        Assert.AreEqual("--Hello WorldDynamic!--", string.Concat("--Hello World", dynamicPart, "!--"));
    }

    [Test]
    public void StringConcatTest2()
    {
        var testStr = string.Concat("--", Hello, " ", World, Exclamation, "--");
        Assert.AreEqual(HelloWorld, testStr);

        // Low-Level C#:
        // The compiler inlines all const string values, replacing constants with their literal values.
        // Therefore, the IL uses the actual string literals instead of referencing the constant variables.
        Assert.AreEqual("--Hello World!--", string.Concat("--", "Hello", " ", "World", "!", "--"));
    }

    [Test]
    public void StringFormatTest()
    {
        var testStr = string.Format("--{0} {1}{2}--", Hello, World, Exclamation);
        Assert.AreEqual(HelloWorld, testStr);

        // Low-Level C#:
        // The compiler inlines all const string values, replacing constants with their literal values.
        Assert.AreEqual("--Hello World!--", string.Format("--{0} {1}{2}--", "Hello", "World", "!"));
    }

    [Test]
    public void InterpolationTest()
    {
        var testStr = $"--{Hello} {World}{Exclamation}--";
        Assert.AreEqual(HelloWorld, testStr);

        // Low-Level C#:
        // The compiler inlines all const string values, replacing constants with their literal values.
        Assert.AreEqual("--Hello World!--", "--Hello World!--");
    }

    [Test]
    public void InterpolationTestNonConstant()
    {
        var dynamicPart = "Dynamic";
        var testStr = $"--{Hello} {World}{dynamicPart}{Exclamation}--";
        Assert.AreEqual("--Hello WorldDynamic!--", testStr);

        // Low-Level C#:
        // Since 'dynamicPart' is not a const, the compiler generates code using DefaultInterpolatedStringHandler
        // to handle runtime string construction. It appends literals and formatted values step-by-step.
        var interpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 4);
        interpolatedStringHandler.AppendLiteral("--");
        interpolatedStringHandler.AppendFormatted("Hello");
        interpolatedStringHandler.AppendLiteral(" ");
        interpolatedStringHandler.AppendFormatted("World");
        interpolatedStringHandler.AppendFormatted(dynamicPart);
        interpolatedStringHandler.AppendFormatted("!");
        interpolatedStringHandler.AppendLiteral("--");
        Assert.AreEqual("--Hello WorldDynamic!--", interpolatedStringHandler.ToStringAndClear());
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