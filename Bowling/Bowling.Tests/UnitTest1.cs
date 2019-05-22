using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Bowling.Tests
{
    public class UnitTest1
    {
        [Test]
        public void TestOneRoll()
        {
            var scoreBoard = new Scoreboard();
            scoreBoard.PlayerScores(2);
            Assert.AreEqual(2, scoreBoard.GetPoints());
        }

        [TestCase(15, 2, 5, 3, 5)]
        [TestCase(22, 2, 5, 3, 5, 4, 2, 0, 1)]
        [TestCase(37, 1, 2, 3, 4, 5, 4, 6, 3, 7, 2)]
        public void TestMoreRollsWithoutStrike(int expected, params int[] points)
        {
            testScore(expected, points);
        }

        [TestCase(25, 2, 8, 5, 5)]
        [TestCase(28, 2, 8, 5, 5, 1, 1)]
        public void TestSpare(int expected, params int[] points)
        {
            testScore(expected, points);
        }

        [TestCase(24, 10, 5, 2)]
        [TestCase(12, 10, 0, 0, 2)]
        [TestCase(16, 10, 2, 0, 2)]
        [TestCase(16, 10, 0, 2, 2)]
        public void TestStrike(int expected, params int[] points)
        {
            testScore(expected, points);
        }
        
        [TestCase(37, 10, 5, 2, 8, 2, 1, 1)]
        [TestCase(51, 10, 5, 5, 8, 2, 1, 1)]
        [TestCase(53, 5, 5, 10, 8, 2, 1, 1)]
        public void TestStrikeAndSpare(int expected, params int[] points)
        {
            testScore(expected, points);
        }
        
        [TestCase(50, 10, 10, 5, 1, 2, 1)]
        [TestCase(300, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10)]
        [TestCase(285, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5, 5)]
        [TestCase(260, 5, 0, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5, 5)]
        [TestCase(275, 5, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5, 5)]
        [TestCase(247, 5, 5, 10, 10, 10, 2, 8, 10, 10, 10, 10, 10, 5, 5)]
        [TestCase(225, 5, 5, 10, 10, 10, 2, 2, 10, 10, 10, 10, 10, 5, 5)]
        public void TestDoubleStrike(int expected, params int[] points)
        {
            testScore(expected, points);
        }

        private void testScore(int expected, params int[] points)
        {
            var scoreBoard = new Scoreboard();
            foreach (var point in points)
            {
                scoreBoard.PlayerScores(point);
            }
            Assert.AreEqual(expected, scoreBoard.GetPoints());
        }
    }
}