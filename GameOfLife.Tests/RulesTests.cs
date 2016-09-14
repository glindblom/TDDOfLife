using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameOfLife.Tests
{
    [TestClass]
    public class RulesTests
    {
        // Living cell with less than two living neighbours dies
        // Living cell with two or three living neighbours lives
        // Living cell with more than three living neighbours dies
        // Dead cell with exactly three living neighbours lives

        [TestMethod]
        public void LiveCell_LessThanTwoLiveNeighbours_Dies()
        {
            // Arrange
            bool alive = true;
            int liveNeighbours = 1;

            // Act
            bool result = LifeRules.GetNewState(alive, liveNeighbours);

            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void LiveCell_TwoOrThreeLiveNeighbours_Lives()
        {
            // Arrange
            bool alive = true;
            int liveNeighbours1 = 2;
            int liveNeighbours2 = 3;

            // Act
            bool result1 = LifeRules.GetNewState(alive, liveNeighbours1);
            bool result2 = LifeRules.GetNewState(alive, liveNeighbours2);

            // Assert
            Assert.AreEqual(true, result1);
            Assert.AreEqual(true, result2);
        }

        [TestMethod]
        public void LiveCell_MoreThanThreeLiveNeighbours_Dies()
        {
            // Arrange
            bool alive = true;
            int liveNeighbours = 4;

            // Act
            bool result = LifeRules.GetNewState(alive, liveNeighbours);
            
            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void DeadCell_ExactlyThreeLiveNeighbours_Lives()
        {
            // Arrange
            bool alive = false;
            int liveNeighbours = 3;

            // Act
            bool result = LifeRules.GetNewState(alive, liveNeighbours);

            // Assert
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void DeadCell_NotExactlyThreeLiveNeighbours_Dies()
        {
            bool alive = false;
            int liveNeighbours1 = 2;
            int liveNeighbours2 = 4;

            // Act
            bool result1 = LifeRules.GetNewState(alive, liveNeighbours1);
            bool result2 = LifeRules.GetNewState(alive, liveNeighbours2);

            // Assert
            Assert.AreEqual(false, result1);
            Assert.AreEqual(false, result2);
        }
    }
}
