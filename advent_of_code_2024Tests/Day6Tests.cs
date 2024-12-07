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
    public class Day6Tests
    {
        string Path = "6_test.txt";

        [TestMethod()]
        public void ReadInputAndCreateGridTest()
        {
            Day6 day6 = new Day6(this.Path);

            Assert.AreEqual(10, day6.Grid.Count);
            Assert.AreEqual(10, day6.Grid[0].Count);
            Assert.AreEqual('.', day6.Grid[0][0]);
            Assert.AreEqual('^', day6.Grid[6][4]);
        }

        [TestMethod()]
        public void FindGuardTest()
        {
            Day6 day6 = new Day6(this.Path);
            int[] pos = day6.FindGuard();

            Assert.AreEqual(6, pos[0]);
            Assert.AreEqual(4, pos[1]);
            Assert.AreEqual('^', day6.GuardDir);
        }

        [TestMethod()]
        public void AddDistinctPositionTest()
        {
            Day6 day6 = new Day6(this.Path);
            day6.AddDistinctPosition([0, 1]);
            day6.AddDistinctPosition([0, 1]);

            Assert.AreEqual(1, day6.DistinctPositions.Count);
        }

        [TestMethod()]
        public void FindObstaclesTest()
        {
            Day6 day6 = new Day6(this.Path);

            Assert.AreEqual(8, day6.Obstacles.Count);
            Assert.AreEqual(0, day6.Obstacles[0][0]);
            Assert.AreEqual(4, day6.Obstacles[0][1]);
        }

        [TestMethod()]
        public void IsObstacleTest()
        {
            Day6 day6 = new Day6(this.Path);

            Assert.IsTrue(day6.IsObstacle([0, 4]));
            Assert.IsFalse(day6.IsObstacle([0, 0]));
        }

        [TestMethod()]
        public void IsOffscreenTest()
        {
            Day6 day6 = new Day6(this.Path);

            Assert.IsTrue(day6.IsOffscreen([-1, 0]));
            Assert.IsTrue(day6.IsOffscreen([11, 0]));
            Assert.IsTrue(day6.IsOffscreen([0, -1]));
            Assert.IsTrue(day6.IsOffscreen([0, 11]));
            Assert.IsFalse(day6.IsOffscreen([0, 0]));
        }

        [TestMethod()]
        public void FindNextPositionTest()
        {
            Day6 day6 = new Day6(this.Path);
            int[] nextPos = day6.FindNextPosition();

            Assert.AreEqual(5, nextPos[0]);
            Assert.AreEqual(4, nextPos[1]);
        }

        [TestMethod()]
        public void MoveTest()
        {
            Day6 day6 = new Day6(this.Path);

            Assert.AreEqual(41, day6.Move());
        }

        [TestMethod()]
        public void IsALoopTest()
        {
            Day6 day6 = new Day6(this.Path);

            Assert.IsTrue(day6.IsALoop([6, 3]));
        }

        [TestMethod()]
        public void AddObstaclesTest()
        {
            Day6 day6 = new Day6(this.Path);

            Assert.AreEqual(6, day6.AddObstacles());
        }
    }
}