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
    public class CellTests
    {
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

            gameboard.GetCell(5, 5).Alive = true;

            Assert.AreEqual(true, eventFired);
            Assert.AreEqual(true, eventResult);
        }
    }
}
