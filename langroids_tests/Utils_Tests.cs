using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LangRoids;
namespace langroids_tests
{
    [TestClass]
    [TestCategory("Utilities")]
    public class Utils_Tests
    {
        [TestMethod]
        public void ContainsAll_IsTrueWhenAllContained() {
            List<int> obj = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            List<int> reqs = new List<int> { 5, 7, 9 };
            Assert.IsTrue(obj.ContainsAll(reqs));
        }
        [TestMethod]
        public void ContainsAll_IsFalseWhenNotAllContained() {
            List<int> obj = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
            List<int> reqs = new List<int> { 5, 7, 9, 101 };
            Assert.IsFalse(obj.ContainsAll(reqs));
        }
        // This will simply not compile if Nothing does not work as expected
        [TestMethod]
        public void Nothing_ReturnsDefaultForTypes() {
            Dictionary<object, object> Tests = new Dictionary<object, object> {
                { (int)3, Nothing<int>() },
                { (double)3.0, Nothing<double>() },
                { (float)3.0f, Nothing<float>() },
                { (char)'a', Nothing<char>() },
                { ((double, string))(3.0, "Hello"), Nothing<(double, string)>() }
            };
        }

        [TestMethod]
        public void Nullify_Nullifies() {
            int x = 3;
            Nullify(ref x);
            Assert.IsTrue(x == default(int));
        }
    }
}
