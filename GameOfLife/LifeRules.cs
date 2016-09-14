using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class LifeRules
    {
        /// <summary>
        /// Calculates a cells new state given its current state and the amount
        /// of living neighbours the cell has.
        /// </summary>
        /// <param name="currentState">The cells current state, living or dead</param>
        /// <param name="liveNeighbours">The number of living neighbours the cell has</param>
        /// <returns>The new state of the cell</returns>
        public static bool GetNewState(bool currentState, int liveNeighbours)
        {
            // Living cell with less than two living neighbours dies
            if (currentState && liveNeighbours < 2)
                return false;
            // Living cell with two or three living neighbours lives
            else if (currentState && (liveNeighbours == 2 || liveNeighbours == 3))
                return true;
            // Living cell with more than three living neighbours dies
            else if (currentState && liveNeighbours > 3)
                return false;
            // Dead cell with exactly three living neighbours lives
            else if (!currentState && liveNeighbours == 3)
                return true;
            else
                return currentState;
        }
    }
}
