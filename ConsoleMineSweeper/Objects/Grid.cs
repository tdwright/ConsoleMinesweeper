using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMineSweeper
{
    public class Grid: IGrid
    {
        public Cell[,] Cells { get; private set; }

        public Grid (Cell[,] cells)
        {
            this.Cells = cells;
        }

        public Enums.CellState CheckCell(int X, int Y)
        {
            if (OutOfBounds(X, Y))
                throw new ArgumentException("Requested cell out of bound");

            if ((Cells[X, Y].CellState != Enums.CellState.Unchecked)) return Cells[X, Y].CellState;

            return (Enums.CellState)NeighbouringMines(X, Y);
        }

        private bool OutOfBounds(int X, int Y)
        {
            return (
                X<0
                ||
                Y<0
                ||
                X >= this.GetWidth()
                ||
                Y >= this.GetHeight()
            );
        }

        private int NeighbouringMines (int X, int Y)
        {
            int acc = 0;
            for (int i = 0; i < 9; i++)
            {
                int dX = (i % 3) - 1;
                int dY = (int)Math.Floor((double)i / 3d) - 1;
                if (dX == 0 && dY == 0) continue;
                if (IsNeighbourMine(X + dX, Y + dY)) acc++;
            }
            return acc;
        }

        private bool IsNeighbourMine(int X, int Y)
        {
            if (OutOfBounds(X, Y))
                return false;

            return (Cells[X, Y].CellState == Enums.CellState.Mine);

        } 

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < this.GetHeight(); y++)
            {
                if (y > 0) sb.AppendLine();
                for (int x=0;x<this.GetWidth();x++)
                {
                    string c = (Cells[x, y].CellState == Enums.CellState.Mine) ? " * " : " - ";
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}
