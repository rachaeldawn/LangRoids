﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LangRoids;

namespace langroids_tests
{
    [TestClass]
    [TestCategory("Throwing")]
    public class Throwing_Tests
    {
        [TestMethod]
        public void DoOrThrow_DoesAction() {
            bool works = false;
            DoOrThrow<Exception>(() => works = true);
            Assert.IsTrue(works, "Did not call Action instead of Exception");
        }
        [TestMethod]
        public void DoOrThrow_ThrowsException() 
            => Assert.ThrowsException<Exception>(() => DoOrThrow<Exception>(null));
    }
}
