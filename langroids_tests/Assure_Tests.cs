using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LangRoids;
namespace langroids_tests {
    [TestClass]
    [TestCategory("Assure")]
    public class Assure_Tests {
        [TestMethod]
        public void Assure_CallsExceptionOnNullAction() => Assert.ThrowsException<ArgumentException>(() => Assure(false, null, new ArgumentException( )));

        [TestMethod]
        public void Assure_CallsAction() {
            bool works = false;
            Assure(false, () => works = true, null);
            Assert.IsTrue(works);
        }

        [TestMethod]
        public void Assure_ReturnsFalseAfterActionCall() => Assert.IsFalse(Assure(false, DoNothing, null));

        [TestMethod]
        public void Assure_ReturnsTrueIfTestTrue() => Assert.IsTrue(Assure(true, null, null));
    }
}
