using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class GOL
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to game of life");
            Console.WriteLine("Set the number of iterations you want");
            int iterationsCount = Convert.ToInt32(Console.ReadLine());

            // Mainitaing two grids
            Grid grid = new Grid();
            Grid backUpGrid = new Grid();

            //Generating a random grid view
            var cells = grid.GetRandomValuesCells();

            //Display the rand grid
            Console.WriteLine();
            Console.WriteLine("We have created a random grid and here it is: ");
            grid.DisplayGrid(cells);

            //Display Game of life in every step
            if(iterationsCount > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Level 0 Reperesentaion: ");
                backUpGrid.Cells = grid.SetGridNextLevelState(grid.Cells);
                grid.DisplayGrid(backUpGrid.Cells);
            }

            for(int i = 1; i < iterationsCount; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Level " + i + " Representation: ");
                backUpGrid.Cells = grid.SetGridNextLevelState(backUpGrid.Cells);
                grid.DisplayGrid(backUpGrid.Cells);
            }
        }
    }
}
