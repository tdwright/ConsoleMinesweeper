using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleMineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                GridBuilder gb = new GridBuilder();
                Grid g = gb.BuildGrid(10, 5, 25);
                Console.WriteLine(g.ToString());
                for(int j=0;j<3;j++)
                {
                    Console.Write("X = ");
                    int X = int.Parse(Console.ReadKey().KeyChar.ToString());
                    Console.WriteLine();
                    Console.Write("Y = ");
                    int Y = int.Parse(Console.ReadKey().KeyChar.ToString());
                    Console.WriteLine();
                    Console.WriteLine(g.CheckCell(X, Y).ToString());
                }
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine();
            }
        }
    }
}
