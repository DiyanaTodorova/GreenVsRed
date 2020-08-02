using System;
using System.Linq;

namespace GreenVsRed
{
    class Program
    {
        static void FillGrid(Grid grid)
        {
            for (int row = 0; row < grid.Rows; row++)
            {
                string line = Console.ReadLine();

                for (int col = 0; col < grid.Cols; col++)
                {
                    if (line[col] == '1')
                    {
                        grid.FillCell(true, row, col);
                    }
                    else
                    {
                        grid.FillCell(false, row, col);
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int[] dimentions = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Grid grid = new Grid(dimentions[0], dimentions[1]);
            FillGrid(grid);

            

            int[] coordinatesAndGenerationCount = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int rowCoordinate = coordinatesAndGenerationCount[1];
            int colCoordinate = coordinatesAndGenerationCount[0];
            int generationsCount = coordinatesAndGenerationCount[2];

            int greenCellCounter = 0;


            for (int gen = 0; gen <= generationsCount; gen++)
            {
                if (grid.Values[rowCoordinate, colCoordinate].Value)
                {
                    greenCellCounter++;
                }
                grid.GenerateNextGeneration();


            }

            Console.WriteLine(greenCellCounter);
        }
    }
}
