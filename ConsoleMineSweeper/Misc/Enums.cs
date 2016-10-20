using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMineSweeper
{
    public class Enums
    {
        public enum CellState
        {
            Unchecked = -1,
            Mine = 9,
            Clear = 0,
            Num1 = 1,
            Num2 = 2,
            Num3 = 3,
            Num4 = 4,
            Num5 = 5,
            Num6 = 6,
            Num7 = 7,
            Num8 = 8
        }
    }
}
