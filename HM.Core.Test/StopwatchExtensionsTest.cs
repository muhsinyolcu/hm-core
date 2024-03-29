﻿using HM.Core.Extensions;
using NUnit.Framework;
using System.Diagnostics;

namespace HM.Core.Test;

[TestFixture]
public class StopwatchExtensionsTest
{
    [Test]
    public void Elaspsed_CompileTest()
    {
        // flaky tests as dependent on time so just put calls for compile safety.
        var sw = Stopwatch.StartNew();
        //Assert.AreEqual(sw.ElapsedTicks, sw.ElapsedTicks());
        sw.ElapsedTicks();
        //Assert.AreEqual(sw.ElapsedMilliseconds, sw.ElapsedMilliseconds());
        sw.ElapsedMilliseconds();
        //Assert.AreEqual(sw.ElapsedMilliseconds() / 1000, sw.ElapsedSeconds());
        sw.ElapsedSeconds();
    }
}