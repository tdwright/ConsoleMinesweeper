using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMineSweeper
{
    public class Cell
    {
        public Enums.CellState CellState;

        public bool Flagged;

        public Cell ()
        {
            this.Flagged = false;
            this.CellState = Enums.CellState.Unchecked;
        }
    }
}
