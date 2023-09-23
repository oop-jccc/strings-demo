using System;
using NUnit.Framework;

namespace StringTests;

[TestFixture]
public class StringComparingTest
{
    [Test]
    public void EqualsNullTest()
    {
        Assert.Throws<NullReferenceException>(() =>
        {
            string string1 = null;
            _ = string1.Equals("Hello World");
        });
    }

    [Test]
    public void EqualsTrueTest()
    {
        Assert.IsTrue("Hello World".Equals("Hello World"));
    }

    [Test]
    public void EqualsFalseTest()
    {
        Assert.IsFalse("hello world".Equals("Hello World"));
    }

    [Test]
    public void EqualsIgnoreCaseTest()
    {
        Assert.IsTrue("hello world".ToUpper().Equals("Hello World".ToUpper()));
        Assert.IsTrue("hello world".Equals("Hello World", StringComparison.InvariantCultureIgnoreCase));
        Assert.IsTrue(" hello world   ".ToUpper().Trim().Equals("Hello World".ToUpper()));
    }

    [Test]
    public void EqualityOperatorTest()
    {
        string string1 = null;
        Assert.IsFalse(string1 == "Hello World");
    }

    [Test]
    public void CompareToTest()
    {
        Assert.AreEqual("aaa".CompareTo("bbb"), -1);
        Assert.AreEqual("aaa".CompareTo("aaa"), 0);
        Assert.AreEqual("bbb".CompareTo("aaa"), 1);
    }

    [Test]
    public void IntCompareToTest()
    {
        int CompareTo(int a, int b)
        {
            return a - b;
        }

        Assert.AreEqual(CompareTo(1, 2), -1);
        Assert.AreEqual(CompareTo(1, 1), 0);
        Assert.AreEqual(CompareTo(2, 1), 1);
    }
}