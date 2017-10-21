using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LangRoids;

namespace langroids_tests
{
    [TestClass]
    [TestCategory("Collections")]
    public class Collections_Tests
    {
        [TestMethod]
        public void Filter_FiltersAll() {
            List<int> nums = new List<int>( );
            Repeat(100, nums.Add);
            ForEach(nums.Filter(i => i >= 50), num => Assert.IsTrue(num >= 50, $"Did not strip {num}"));
        }
    }
}
