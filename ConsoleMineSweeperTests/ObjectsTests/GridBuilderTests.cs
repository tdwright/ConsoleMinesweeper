using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ConsoleMineSweeper;

namespace ConsoleMineSweeperTests.ObjectsTests
{
    [TestFixture]
    class GridBuilderTests
    {

        [TestCase(5,5,0,"Zero mines", TestName = "GridBuilder_ZeroMines_Throws")]
        [TestCase(1, 0, 1, "Invalid dimensions", TestName = "GridBuilder_OneByZeroGrid_Throws")]
        [TestCase(0, 1, 1, "Invalid dimensions", TestName = "GridBuilder_ZeroByOneGrid_Throws")]
        [TestCase(1, 1, 2, "Too many mines", TestName = "GridBuilder_TwoMinesInOneCells_Throws")]
        [TestCase(10, 10, 101, "Too many mines", TestName = "GridBuilder_101MinesIn100_Throws")]
        public void GridBuilder_InvalidGrid_Throws(int Width, int Height, int Mines, string ExceptionPattern)
        {
            GridBuilder gb = new GridBuilder();

            var ex = Assert.Catch(() => gb.BuildGrid(Width, Height, Mines));

            StringAssert.Contains(ExceptionPattern, ex.Message);
        }

        [TestCase(1, 1, 1, TestName = "GridBuilder_OneByOneGrid_DoesNotThrow")]
        [TestCase(10, 10,1, TestName = "GridBuilder_TenByTenGrid_DoesNotThrow")]
        [TestCase(2, 2, 1, TestName = "GridBuilder_OneMineInFourCells_DoesNotThrow")]
        [TestCase(20, 20, 10, TestName = "GridBuilder_TenMineInFourCells_DoesNotThrow")]
        public void GridBuilder_ValidGrid_DoesNotThrow(int Width, int Height, int Mines)
        {
            GridBuilder gb = new GridBuilder();

            Assert.DoesNotThrow(() => gb.BuildGrid(Width, Height, Mines));
        }

        private Grid UseGridBuilder(int Width, int Height, int Mines)
        {
            GridBuilder gb = new GridBuilder();
            Grid g = gb.BuildGrid(Width, Height, Mines);
            return g;
        }

        [Test]
        public void GridBuilder_BuildsCellArray_WidthMatches()
        {
            Grid g = UseGridBuilder(5, 5, 3);
            Assert.That(g.GetWidth() == 5);
        }

        [Test]
        public void GridBuilder_BuildsCellArray_HeightMatches()
        {
            Grid g = UseGridBuilder(5, 5, 3);
            Assert.That(g.GetHeight() == 5);
        }

        [Test]
        public void GridBuilder_BuildsCellArray_MinesPresent()
        {
            Grid g = UseGridBuilder(5, 5, 3);
            var mineCells = from Cell c in g.Cells where (c.CellState == Enums.CellState.Mine) select c;
            int mineCount = mineCells.Count();
            Assert.That(mineCount == 3);
        }
    }
}
