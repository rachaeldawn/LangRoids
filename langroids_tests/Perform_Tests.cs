using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LangRoids;

namespace langroids_tests
{
    [TestClass]
    [TestCategory("Perform")]
    public class Perform_Tests
    {
        [TestMethod]
        public void PerformIfBool_PerformsIfTrue() {
            bool works = true;
            Perform(works, () => works = false);
            Assert.IsFalse(works, "Did not modify works, must not have called function");
        }
        [TestMethod]
        public void PerformIfBool_DoesNothingIfFalse() {
            bool works = false;
            Perform(works, () => works = true);
            Assert.IsFalse(works, "Modified works. Should not have.");
        }
        [TestMethod]
        public void PerformIfDelegate_PerformsIfTrue() {
            bool works = false;
            Perform(() => true, () => works = true);
            Assert.IsTrue(works, "Did not modify works, and should have");
        }
        [TestMethod]
        public void PerformIfDelegate_DoesNothingIfFalse() {
            bool works = true;
            Perform(() => false, () => works = false);
            Assert.IsTrue(works, "Modified works and should not have");
        }
        
        private static bool simplePerformTest = true;
        [TestMethod]
        public void PerformIf_ExpressionBodyIsSimple() => Perform(true, () => {
            simplePerformTest = false;
            Assert.IsFalse(simplePerformTest);
        });
        [TestMethod]
        public void Perform_UsesAssurances() {
            bool works = false;
            Perform(new Assurance<Exception>(false, () => works = true), DoNothing);
            Assert.IsTrue(works);
        }
    }
}
