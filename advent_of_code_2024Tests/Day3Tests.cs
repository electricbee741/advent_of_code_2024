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
    public class Day3Tests
    {
        string Path = "3_test.txt";
        string Path2 = "3_test_2.txt";

        [TestMethod()]
        public void ReadInputTest()
        {
            Day3 day3 = new Day3(this.Path);

            Assert.AreEqual("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))", day3.CorruptedInput);
        }

        [TestMethod()]
        public void CleanInputTest()
        {
            Day3 day3 = new Day3(this.Path2);

            Assert.AreEqual(6, day3.Functions.Count);
            Assert.AreEqual(@"mul(2,4)", day3.Functions[0]);
        }

        [TestMethod()]
        public void MulTest()
        {
            Day3 day3 = new Day3(this.Path);

            Assert.AreEqual(8, day3.Mul(day3.Functions[0]));
            Assert.AreEqual(25, day3.Mul(day3.Functions[1]));
            Assert.AreEqual(88, day3.Mul(day3.Functions[2]));
            Assert.AreEqual(40, day3.Mul(day3.Functions[3]));
        }

        [TestMethod()]
        public void FindSumTest()
        {
            Day3 day3 = new Day3(this.Path);

            Assert.AreEqual(161, day3.FindSum());
        }

        [TestMethod()]
        public void FindSumWithConditionalsTest()
        {
            Day3 day3 = new Day3(this.Path2);

            Assert.AreEqual(48, day3.FindSumWithConditionals());
        }
    }
}
