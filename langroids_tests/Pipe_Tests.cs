using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LangRoids;

namespace langroids_tests
{
    [TestClass]
    [TestCategory("Pipe")]
    public class Pipe_Tests
    {
        private int PipeAddOne(int x) => x + 1;
        private int PipeMultiTwo(int x) => x * 2;
        private int PipeOp(int num) => Pipe(num, PipeAddOne, PipeMultiTwo);

        [TestMethod]
        public void Pipe_ModifiesValueEachTime() {
            int x = 1;
            x = PipeOp(x);
            Assert.IsTrue(x == 4, $"Did not perform pipe operation properly. Expected 4, actually {x}");
        }
    }
}
