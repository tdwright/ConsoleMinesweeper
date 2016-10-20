using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMineSweeper
{
    public static class GridExtensions
    {
        public static int GetWidth(this IGrid Grid)
        {
            return Grid.Cells.GetLength(0);
        }

        public static int GetHeight(this IGrid Grid)
        {
            return Grid.Cells.GetLength(1);
        }
    }
}
