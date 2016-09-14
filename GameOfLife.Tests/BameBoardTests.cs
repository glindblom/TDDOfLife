using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfLife;

namespace GameOfLife.Tests
{
    [TestClass]
    public class BameBoardTests
    {
        [TestMethod]
        public void GameBoardShouldSetAndGetCellsProperly()
        {
            var gameboard = new GameBoard(10, 10);

            // Check boundaries
            var result1 = gameboard.SetCell(-1, 5, true);
            var result2 = gameboard.SetCell(5, -1, true);
            var result3 = gameboard.SetCell(15, 5, true);
            var result4 = gameboard.SetCell(5, 15, true);

            // Cell tests
            var result5 = gameboard.SetCell(5, 5, true);
            var result6 = gameboard.GetCell(5, 5);
            var result7 = gameboard.GetCell(6, 6);
            var result8 = gameboard.GetCell(-1, -1);

            // Asserts
            Assert.AreEqual(false, result1);
            Assert.AreEqual(false, result2);
            Assert.AreEqual(false, result3);
            Assert.AreEqual(false, result4);

            Assert.AreEqual(true, result5);
            Assert.AreEqual(true, result6.Alive);
            Assert.AreEqual(false, result7.Alive);
            Assert.AreEqual(null, result8);
        }

        [TestMethod]
        public void CellsShouldNotifyWhenStateChanged()
        {
            var gameboard = new GameBoard(10, 10);
            bool eventFired = false;
            bool eventResult = false;

            gameboard.GetCell(5, 5).PropertyChanged += (e, a) =>
            {
                if (!(e is Cell) || a.PropertyName != "Alive") return;

                eventResult = (e as Cell).Alive;
                eventFired = true;
            };

            gameboard.SetCell(5, 5, true);

            Assert.AreEqual(true, eventFired);
            Assert.AreEqual(true, eventResult);
        }
    }
}
