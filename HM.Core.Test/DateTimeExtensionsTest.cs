using HM.Core.Extensions;
using NUnit.Framework;
using System;

namespace HM.Core.Test;

public class DateTimeExtensionsTest
{
    [Test]
    public void ToUtcFormatStringTest()
    {
        var date = new DateTime(1992, 03, 02, 15, 40, 10, DateTimeKind.Utc);
        Assert.AreEqual("1992-03-02T15:40:10.000Z", date.ToUtcFormatString());
    }
}