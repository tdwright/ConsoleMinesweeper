using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleMineSweeper;
using NUnit.Framework;

namespace ConsoleMineSweeperTests.ObjectsTests
{
    [TestFixture]
    class GridTests
    {
        private Grid GetDummyGrid(char FakeGridType)
        {
            Fakes.FakeGridBuilder fgb = new Fakes.FakeGridBuilder();
            Grid g = fgb.BuildFakeGrid(FakeGridType);
            return g;
        }

        [TestCase('a', 0, 0, Enums.CellState.Mine, TestName = "Grid_CheckMineCellState_ReturnsMine")]
        [TestCase('a', 3, 3, Enums.CellState.Clear, TestName = "Grid_CheckClearCellState_ReturnsClear")]
        [TestCase('a', 1, 3, Enums.CellState.Num1, TestName = "Grid_CheckAdjacentCellState_ReturnsOne")]
        public void Grid_CheckCellState_ReturnsCorrectState(char FakeGridType, int X, int Y, Enums.CellState ExpectedState)
        {
            Grid g = GetDummyGrid(FakeGridType);
            Enums.CellState ActualState = g.CheckCell(X, Y);
            Assert.That(ActualState == ExpectedState);
        }
    }
}
