using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LangRoids;

namespace langroids_tests
{
    class ComposeArgClass {
        public double A {
            get; set;
        }
        public string B {
            get; set;
        }
        public ComposeArgClass(double a, string b) {
            A = a;
            B = b;
        }
    }
    [TestClass]
    [TestCategory("Compose")]
    public class Compose_Tests
    {
        static int composecounter = 1;
        [TestMethod]
        public void Compose_RunsAll() => Compose(
            () => composecounter += 1,
            () => composecounter *= 2,
            () => Assert.IsTrue(composecounter == 4),
            () => composecounter = 1
            );

        static ComposeArgClass composearg_val = new ComposeArgClass(0, "");

        void Add2(ComposeArgClass val) => val.A += 2;
        void AddHi(ComposeArgClass val) => val.B += "hi";

        [TestMethod]
        public void ComposeArg_ManipulatesObject() => Compose(composearg_val,
            Add2, AddHi,
            final => Assert.IsTrue(final.A == 2 && final.B == "hi", $"Expected a to be 2, actually {final.A}\nExpected b to be hi, actually{final.B}"));
    }
}
