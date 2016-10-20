using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMineSweeper;

namespace ConsoleMineSweeperTests.Fakes
{
    public class FakeGridBuilder : IGridBuilder
    {
        private int _width;
        private int _height;
        private int _mines;
        private int _cellCount { get { return _width * _height; } }
        private Cell[,] _cells;

        public Grid BuildFakeGrid(char FakeGridType)
        {
            Grid g;
            switch (FakeGridType)
            {
                case 'a':
                default:
                    g = BuildGrid(5, 5, 3);
                    g = SetCell(g, 0, 0);
                    g = SetCell(g, 0, 1);
                    g = SetCell(g, 0, 2);
                    break;
            }
            return g;
        }
        public Grid BuildGrid(int Width, int Height, int Mines)
        {
            _width = Width;
            _height = Height;
            _mines = Mines;

            BuildCellArray();

            return new Grid(_cells);
        }

        private void BuildCellArray()
        {
            _cells = new Cell[_width, _height];

            for (int x = 0; x < _width; x++)
            {
                for (int y = 0; y < _height; y++)
                {
                    _cells[x, y] = new Cell();
                }
            }
        }

        private Grid SetCell(Grid g, int x, int y)
        {
            g.Cells[x, y].CellState = Enums.CellState.Mine;
            return g;
        }
    }
}
