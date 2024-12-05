using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using advent_of_code_2024;

namespace advent_of_code_2024.Tests
{
    [TestClass()]
    public class Day4Tests
    {
        string Path = "4_test.txt";

        [TestMethod()]
        public void ReadInputTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(10, day4.Rows.Count);
            Assert.AreEqual("MMMSXXMASM", day4.Rows[0]);
            Assert.AreEqual("MSAMXMSMSA", day4.Rows[1]);
        }

        [TestMethod()]
        public void FindWordCountTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(18, day4.FindWordCount());
        }

        [TestMethod()]
        public void FindHorizontalForwardTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(1, day4.FindHorizontalForward("MMMSXXMASM"));
            Assert.AreEqual(0, day4.FindHorizontalForward("MSAMXMSMSA"));
        }

        [TestMethod()]
        public void FindHorizontalBackwardsTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(0, day4.FindHorizontalBackwards("MMMSXXMASM"));
            Assert.AreEqual(1, day4.FindHorizontalBackwards("MSAMXMSMSA"));
        }

        [TestMethod()]
        public void FindVerticalForwardTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(1, day4.FindVerticalForward());
        }

        [TestMethod()]
        public void FindVerticalBackwardsTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(2, day4.FindVerticalBackwards());
        }

        [TestMethod()]
        public void FindDiagonalDownForwardTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(1, day4.FindDiagonalDownForward());
        }

        [TestMethod()]
        public void FindDiagonalDownBackwardsTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(4, day4.FindDiagonalDownBackwards());
        }

        [TestMethod()]
        public void FindDiagonalUpForwardTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(1, day4.FindDiagonalUpForward());
        }

        [TestMethod()]
        public void FindDiagonalUpBackwardsTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(4, day4.FindDiagonalUpBackwards());
        }

        [TestMethod()]
        public void FindMasXTest()
        {
            Day4 day4 = new Day4(this.Path);

            Assert.AreEqual(9, day4.FindMasX());
        }
    }
}
