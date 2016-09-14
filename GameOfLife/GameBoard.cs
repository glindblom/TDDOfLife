using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GameBoard
    {
        private Cell[] _cells;
        private int _width, _height;

        public GameBoard(int width, int height)
        {
            _width = width;
            _height = height;

            Initialize();
        }

        public void Initialize()
        {
            _cells = GenerateBoard(_width, _height);
        }

        private Cell[] GenerateBoard(int width, int height)
        {
            Cell[] board = new Cell[width*height];
            for (int i = 0; i < width * height; i++)
                board[i] = new Cell();

            return board;
        }

        public Cell GetCell(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height) return null;

            return _cells[_width * x + y];
        }


        public void Clear()
        {
            _cells = _cells.Select(x => { x.Alive = false; return x; }).ToArray();
        }

        public void StepSimulation()
        {
            bool[] nextGen = new bool[_width * _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    Cell cell = GetCell(x, y);

                    int liveNeighbours = 0;
                    for (int dx = x - 1; dx < x + 2; dx++)
                    {
                        for (int dy = y - 1; dy < y + 2; dy++)
                        {
                            if (dx == x && dy == y)
                                continue;

                            var neighbour = GetCell(dx, dy);
                            if (neighbour == null) continue;
                            liveNeighbours += neighbour.Alive ? 1 : 0;
                        }
                    }

                    if (!cell.Alive && liveNeighbours == 3)
                    {
                        Console.WriteLine("Ping");
                    }

                    var newState = LifeRules.GetNewState(cell.Alive, liveNeighbours);
                    nextGen[_width * x + y] = newState;
                }
            }

            for (int i = 0; i < _cells.Length; i++)
                _cells[i].Alive = nextGen[i];
        }

        private bool CoordinatesWithinBoard(int x, int y)
        {
            if (x < 0 || x >= _width || y < 0 || y >= _height) return false;
            return true;
        }
    }
}
