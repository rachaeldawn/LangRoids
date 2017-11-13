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
        public void Assure_CallsExceptionOnNullAction() => Assert.ThrowsException<ArgumentException>(() => Assure<ArgumentException>(false, null));

        [TestMethod]
        public void Assure_CallsAction() {
            bool works = false;
            Assure<Exception>(false, () => works = true);
            Assert.IsTrue(works);
        }

        [TestMethod]
        public void Assure_ReturnsFalseAfterActionCall() 
            => Assert.IsFalse(Assure<Exception>(false, DoNothing));

        [TestMethod]
        public void Assure_ReturnsTrueIfTestTrue() 
            => Assert.IsTrue(Assure<Exception>(true, null));
    }
}
