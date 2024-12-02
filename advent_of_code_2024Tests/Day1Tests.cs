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
    public class Day1Tests
    {
        string Path = "1_test.txt";

        [TestMethod()]
        public void ReadFileAndCreateListsTest()
        {
            Day1 day1 = new Day1(this.Path);

            Assert.AreEqual(day1.FirstColumn[0], 3);
            Assert.AreEqual(day1.SecondColumn[0], 4);
            Assert.AreEqual(day1.FirstColumn.Count, 6);
            Assert.AreEqual(day1.SecondColumn.Count, 6);
        }

        [TestMethod()]
        public void FindDifferencesTest()
        {
            Day1 day1 = new Day1(this.Path);
            int sum = day1.FindDifferences();

            Assert.AreEqual(day1.Differences[0], 2);
            Assert.AreEqual(day1.Differences[1], 1);
            Assert.AreEqual(day1.Differences[2], 0);
            Assert.AreEqual(day1.Differences[3], 1);
            Assert.AreEqual(day1.Differences[4], 2);
            Assert.AreEqual(day1.Differences[5], 5);
            Assert.AreEqual(sum, 11);
        }

        [TestMethod()]
        public void FindSimilarityScoreTest()
        {
            Day1 day1 = new Day1(this.Path);

            Assert.AreEqual(day1.FindSimilarityScore(), 31);
        }
    }
}