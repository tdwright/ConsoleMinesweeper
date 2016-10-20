using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMineSweeper
{
    public interface IGrid
    {
        Cell[,] Cells { get; }

        Enums.CellState CheckCell(int X, int Y);

    }
}
