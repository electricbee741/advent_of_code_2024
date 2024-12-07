using Microsoft.VisualStudio.TestTools.UnitTesting;
using advent_of_code_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024.Tests
{
    [TestClass()]
    public class Day7Tests
    {
        string Path = "7_test.txt";

        [TestMethod()]
        public void SplitLineTest()
        {
            Day7 day7 = new Day7(Path);
            day7.SplitLine("190: 10 19");

            Assert.AreEqual(10, day7.Solutions.Count);
            Assert.AreEqual(2, day7.Values[0].Count);
            Assert.AreEqual(190, day7.Solutions[0]);
            Assert.AreEqual(10, day7.Values[0][0]);
            Assert.AreEqual(19, day7.Values[0][1]);
        }

        [TestMethod()]
        public void ReadInputAndCreateListsTest()
        {
            Day7 day7 = new Day7(Path);

            Assert.AreEqual(9, day7.Solutions.Count);
            Assert.AreEqual(4, day7.Values[7].Count);
            Assert.AreEqual(190, day7.Solutions[0]);
            Assert.AreEqual(10, day7.Values[0][0]);
            Assert.AreEqual(19, day7.Values[0][1]);
        }

        [TestMethod()]
        public void GeneratePossibleOperatorsTest()
        {
            Day7 day7 = new Day7(Path);
            List<List<string>> possibleOperators = day7.GeneratePossibleOperators(3);

            Assert.AreEqual(27, possibleOperators.Count);
        }

        [TestMethod()]
        public void EvaluateLineTest()
        {
            Day7 day7 = new Day7(Path);
            long solution = day7.EvaluateLine(["*", "||", "*"], [6, 8, 6, 15]);

            Assert.AreEqual(7290, solution);
        }

        [TestMethod()]
        public void CouldBeTrueTest()
        {
            Day7 day7 = new Day7(Path);

            Assert.IsTrue(day7.CouldBeTrue(day7.Solutions[0], day7.Values[0]));
            Assert.IsTrue(day7.CouldBeTrue(day7.Solutions[1], day7.Values[1]));
            Assert.IsFalse(day7.CouldBeTrue(day7.Solutions[2], day7.Values[2]));
            Assert.IsTrue(day7.CouldBeTrue(day7.Solutions[3], day7.Values[3]));
            Assert.IsTrue(day7.CouldBeTrue(day7.Solutions[4], day7.Values[4]));
            Assert.IsFalse(day7.CouldBeTrue(day7.Solutions[5], day7.Values[5]));
            Assert.IsTrue(day7.CouldBeTrue(day7.Solutions[6], day7.Values[6]));
            Assert.IsFalse(day7.CouldBeTrue(day7.Solutions[7], day7.Values[7]));
            Assert.IsTrue(day7.CouldBeTrue(day7.Solutions[8], day7.Values[8]));

        }

        [TestMethod()]
        public void FindTotalCalibrationTest()
        {
            Day7 day7 = new Day7(Path);

            Assert.AreEqual(11387, day7.FindTotalCalibration());
        }
    }
}
