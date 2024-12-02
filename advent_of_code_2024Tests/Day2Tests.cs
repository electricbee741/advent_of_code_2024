using Microsoft.VisualStudio.TestTools.UnitTesting;
using advent_of_code_2024;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advent_of_code_2024Tests
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
            Assert.AreEqual(day2.Reports.Count, 6);
            Assert.AreEqual(day2.Reports[0][0], 7);
            Assert.AreEqual(day2.Reports[1][1], 2);
        }

        [TestMethod()]
        public void IsLevelSafeTest()
        {
            Day2 day2 = new Day2(Path);

            Assert.AreEqual(day2.IsLevelSafe(day2.Reports[0]), true);
            Assert.AreEqual(day2.IsLevelSafe(day2.Reports[1]), false);
            Assert.AreEqual(day2.IsLevelSafe(day2.Reports[2]), false);
            Assert.AreEqual(day2.IsLevelSafe(day2.Reports[3]), false);
            Assert.AreEqual(day2.IsLevelSafe(day2.Reports[4]), false);
            Assert.AreEqual(day2.IsLevelSafe(day2.Reports[5]), true);
        }
    }
}