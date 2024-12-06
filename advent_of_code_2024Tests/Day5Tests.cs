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
    public class Day5Tests
    {
        string Path = "5_test.txt";

        [TestMethod()]
        public void ParseRuleTest()
        {
            Day5 day5 = new Day5();
            day5.ParseRule("47|53");

            Assert.AreEqual(47, day5.Rules[0][0]);
            Assert.AreEqual(53, day5.Rules[0][1]);
        }

        [TestMethod()]
        public void ParsePagesToPrintTest()
        {
            Day5 day5 = new Day5();
            day5.ParsePagesToPrint("75,47,61,53,29");

            Assert.AreEqual(5, day5.PagesToPrint[0].Count);
            Assert.AreEqual(75, day5.PagesToPrint[0][0]);
            Assert.AreEqual(47, day5.PagesToPrint[0][1]);
            Assert.AreEqual(61, day5.PagesToPrint[0][2]);
            Assert.AreEqual(53, day5.PagesToPrint[0][3]);
            Assert.AreEqual(29, day5.PagesToPrint[0][4]);
        }

        [TestMethod()]
        public void ReadFileAndParseTest()
        {
            Day5 day5 = new Day5(this.Path);

            Assert.AreEqual(21, day5.Rules.Count);
            Assert.AreEqual(6, day5.PagesToPrint.Count);
            Assert.AreEqual(53, day5.Rules[0][1]);
            Assert.AreEqual(13, day5.Rules[20][1]);
            Assert.AreEqual(5, day5.PagesToPrint[0].Count);
            Assert.AreEqual(53, day5.PagesToPrint[0][3]);
            Assert.AreEqual(47, day5.PagesToPrint[5][4]);
        }

        [TestMethod()]
        public void ArePagesValidTest()
        {
            Day5 day5 = new Day5(this.Path);

            Assert.IsTrue(day5.ArePagesValid(day5.PagesToPrint[0]));
            Assert.IsTrue(day5.ArePagesValid(day5.PagesToPrint[1]));
            Assert.IsTrue(day5.ArePagesValid(day5.PagesToPrint[2]));
            Assert.IsFalse(day5.ArePagesValid(day5.PagesToPrint[3]));
            Assert.IsFalse(day5.ArePagesValid(day5.PagesToPrint[4]));
            Assert.IsFalse(day5.ArePagesValid(day5.PagesToPrint[5]));
        }

        [TestMethod()]
        public void FindSumOfValidMiddlePagesTest()
        {
            Day5 day5 = new Day5(this.Path);

            Assert.AreEqual(143, day5.FindSumOfValidMiddlePages());
        }

        [TestMethod()]
        public void FixPagesToBePrintedRecursionTest()
        {
            Day5 day5 = new Day5(this.Path);
            List<int> fixedList = day5.FixPagesToBePrintedRecursion(day5.PagesToPrint[3]);

            //97,75,47,61,53
            Assert.AreEqual(5, fixedList.Count);
            Assert.AreEqual(97, fixedList[0]);
            Assert.AreEqual(75, fixedList[1]);
            Assert.AreEqual(47, fixedList[2]);
            Assert.AreEqual(61, fixedList[3]);
            Assert.AreEqual(53, fixedList[4]);
        }

        //[TestMethod()]
        //public void FindSumOfInvalidMiddlePagesRecursionTest()
        //{
        //    Day5 day5 = new Day5(this.Path);

        //    Assert.AreEqual(123, day5.FindSumOfInvalidMiddlePagesRecursion());
        //}

        [TestMethod()]
        public void FixPagesToBePrintedTest()
        {
            Day5 day5 = new Day5(this.Path);
            List<int> fixedList = day5.FixPagesToBePrinted(day5.PagesToPrint[3]);

            //97,75,47,61,53
            Assert.AreEqual(5, fixedList.Count);
            Assert.AreEqual(97, fixedList[0]);
            Assert.AreEqual(75, fixedList[1]);
            Assert.AreEqual(47, fixedList[2]);
            Assert.AreEqual(61, fixedList[3]);
            Assert.AreEqual(53, fixedList[4]);
        }

        [TestMethod()]
        public void FindSumOfInvalidMiddlePagesTest()
        {
            Day5 day5 = new Day5(this.Path);

            Assert.AreEqual(123, day5.FindSumOfInvalidMiddlePages());
        }
    }
}