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
    public class Day2Tests
    {
        string Path = "2_test.txt";

        [TestMethod()]
        public void ReadFileAndCreateReportsTest()
        {
            Day2 day2 = new Day2(Path);

            Assert.IsNotNull(day2.Reports);
            Assert.AreEqual(6, day2.Reports.Count);
            Assert.AreEqual(7, day2.Reports[0][0]);
            Assert.AreEqual(2, day2.Reports[1][1]);
        }

        [TestMethod()]
        public void IsLevelSafeTest()
        {
            Day2 day2 = new Day2(Path);

            Assert.AreEqual(true, day2.IsLevelSafe(day2.Reports[0]));
            Assert.AreEqual(false, day2.IsLevelSafe(day2.Reports[1]));
            Assert.AreEqual(false, day2.IsLevelSafe(day2.Reports[2]));
            Assert.AreEqual(false, day2.IsLevelSafe(day2.Reports[3]));
            Assert.AreEqual(false, day2.IsLevelSafe(day2.Reports[4]));
            Assert.AreEqual(true, day2.IsLevelSafe(day2.Reports[5]));
        }

        [TestMethod()]
        public void GetNumberOfSafeReportsTest()
        {
            Day2 day2 = new Day2(Path);

            Assert.AreEqual(2, day2.GetNumberOfSafeReports());
        }

        [TestMethod()]
        public void GetNumberOfSafeReportsUsingDampnerTest()
        {
            Day2 day2 = new Day2(Path);

            Assert.AreEqual(4, day2.GetNumberOfSafeReportsUsingDampner());
        }
    }
}