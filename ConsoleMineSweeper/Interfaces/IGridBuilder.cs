﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMineSweeper
{
    public interface IGridBuilder
    {
        Grid BuildGrid(int Width, int Height, int Mines);
    }
}
