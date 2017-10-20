using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LangRoids;
namespace langroids_tests
{
    [TestClass]
    [TestCategory("Looping")]
    public class Looping_Tests
    {
        [TestMethod]
        public void RepeatsProperAmount() {
            int i = 0;
            Repeat(10, () => i += 1);
            Assert.IsTrue(i == 10);
        }

        [TestMethod]
        public void Repeat_PassesInIndex() {
            int iterExpected = 0;
            Repeat(10, i => {
                Assert.IsTrue(i == iterExpected);
                iterExpected += 1;
            });
        }

        [TestMethod]
        public void Repeat_StartsAtProperIndex() => Repeat(1, 5, i => Assert.IsTrue(i == 5));

        [TestMethod]
        public void Repeat_RepeatsProperAmountOfTimesWithProvidedIndex() {
            int index = 0;
            int repCount = 0;
            Repeat(10, 5, i => {
                Assert.IsTrue(i == repCount + 5, $"Expected i to be repCount + 5, actually {i}, (Repcount = {repCount})");
                repCount += 1;
                index = i;
            });
            Assert.IsTrue(index == 14, $"Expected index to be 14, actually {index}");            
        }

        [TestMethod]
        public void ForEach_LoopsAll() {
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int iter = 0;
            ForEach(nums, i => {
                iter += 1;
                Assert.IsTrue(iter == i);
            });
            Assert.IsTrue(iter == 9, "Did not end on proper index");
        }

    }
}
