using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMineSweeper
{
    public class GridBuilder : IGridBuilder
    {
        private int _width;
        private int _height;
        private int _mines;
        private int _cellCount {  get { return _width * _height; } }
        private Cell[,] _cells;

        public Grid BuildGrid(int Width, int Height, int Mines)
        {
            _width = Width;
            _height = Height;
            _mines = Mines;

            CheckParameter();
            BuildCellArray();
            PopulateWithMines();

            return new Grid(_cells);
        }

        private void PopulateWithMines()
        {
            int minesPlaced = 0;
            Random rng = new Random();
            while (minesPlaced < _mines)
            {
                int index = rng.Next(0, _cellCount - 1);
                if (TryToPlaceMine(GetXfromIndex(index), GetYfromIndex(index))) minesPlaced++;
            }
        }

        private int GetYfromIndex(int index)
        {
            return (int)Math.Floor((double)index / (double)_width);
        }

        private int GetXfromIndex(int Index)
        {
            return Index % _width;
        }

        private bool TryToPlaceMine(int X, int Y)
        {
            if (_cells[X, Y].CellState == Enums.CellState.Mine)
                return false;
            _cells[X, Y].CellState = Enums.CellState.Mine;
            return true;
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

        private void CheckParameter()
        {
            if (_cellCount == 0)
                throw new ArgumentException(String.Format("Invalid dimensions: cannot build a grid with width of {0} and a height of {1}", _width, _height));

            if (_mines < 1)
                throw new ArgumentException("Zero mines: Minesweeper is boring without mines");

            if (_mines > _cellCount)
                throw new ArgumentException(String.Format("Too many mines: cannot put {0} mines in {1} cells", _mines, _cellCount));
        }
    }
}
