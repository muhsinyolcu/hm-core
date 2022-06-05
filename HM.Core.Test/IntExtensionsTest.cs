using HM.Core.Extensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.Core.Test;

public class IntExtensionsTest
{
    [Test]
    [TestCase(3, 6)]
    [TestCase(12, 479001600)]
    public void FactorialTest(int n, int result)
    {
        Assert.AreEqual(result, (int)n.Factorial());
    }

    [Test]
    [TestCase(3, 3, 6)]
    [TestCase(0, 0, 1)]
    public void PermutationTest(int n, int r, int result)
    {
        Assert.AreEqual(result, (int)n.Permutation(r));
    }

    [Test]
    [TestCase(3, 3, 1)]
    [TestCase(0, 0, 1)]
    public void CombinationTest(int n, int r, int result)
    {
        Assert.AreEqual(result, (int)n.Combination(r));
    }

    [Test]
    [TestCase(2, 4)]
    [TestCase(4, 64)]
    public void ScrabbleCountTest(int n, int result)
    {
        Assert.AreEqual(result, (int)n.ScrabbleCount());
    }

    [Test]
    [TestCase(2, 0, "2")]
    [TestCase(1000, 0, "1k")]
    [TestCase(1000000, 0, "1m")]
    [TestCase(1000000000, 0, "1g")]
    [TestCase(1500, 0, "1k")]
    [TestCase(1900, 0, "1k")]
    [TestCase(2000, 0, "2k")]
    [TestCase(int.MaxValue, 0, "2g")]
    [TestCase(int.MinValue, 0, null)] // OverflowException due to abs(n)
    [TestCase(int.MinValue + 1, 0, "-2g")]
    [TestCase(999, 0, "999")]
    [TestCase(-999, 0, "-999")]
    [TestCase(1001, 0, "1k")]
    [TestCase(-1001, 0, "-1k")]
    [TestCase(1099, 1, "1k")]
    [TestCase(1299, 1, "1.2k")]
    [TestCase(1599, 1, "1.5k")]
    [TestCase(1999, 1, "1.9k")]
    public void RoundTest(int n, int digits, string result)
    {
        if (result.IsNullOrEmpty())
        {
            Assert.Throws<OverflowException>(() => n.Round((uint)digits));
        }
        else
        {
            Assert.AreEqual(result, n.Round((uint)digits));
        }
    }

    [Test]
    [TestCase(0, 5, 0)]
    [TestCase(1, 5, 0)]
    [TestCase(4, 5, 0)]
    [TestCase(5, 5, 5)]
    [TestCase(6, 5, 5)]
    [TestCase(9, 5, 5)]
    [TestCase(10, 5, 10)]
    [TestCase(-1, 5, -5)]
    [TestCase(-4, 5, -5)]
    [TestCase(-5, 5, -10)]
    [TestCase(-6, 5, -10)]
    [TestCase(-9, 5, -10)]
    [TestCase(-10, 5, -15)]
    public void BinTest(int n, int binSize, int result)
    {
        Assert.AreEqual(result, n.Bin(binSize));
    }
}