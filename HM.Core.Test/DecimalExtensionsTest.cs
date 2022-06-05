using HM.Core.Extensions;
using NUnit.Framework;

namespace HM.Core.Test;

public class DecimalExtensionsTest
{
    [Test]
    public void TruncateToTest()
    {
        Assert.AreEqual(-11m, (-11.999m).TruncateTo(0));
    }
}

