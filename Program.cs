using System;
using System.Threading;

class GameOfLife
{
    static int rows = 20;
    static int cols = 40;
    static int[,] grid = new int[rows, cols];
    
    static void Main()
    {
        InitializeGrid();
        Console.Clear();

        while (true)
        {
            DisplayGrid();
            UpdateGrid();
            Thread.Sleep(180);
            Console.Clear();
        }
    }

    static void InitializeGrid()
    {
        Random random = new Random();

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                grid[i, j] = random.Next(2); 
            }
        }
    }

    static void DisplayGrid()
    {
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (grid[i, j] == 1)
                {
                    Console.Write("■ ");
                }
                else
                {
                    Console.Write("□ ");
                }
            }
            Console.WriteLine();
        }
    }

    static void UpdateGrid()
    {
        int[,] newGrid = new int[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                int neighbors = CountNeighbors(i, j);

                if (grid[i, j] == 1 && (neighbors < 2 || neighbors > 3))
                {
                    newGrid[i, j] = 0; 
                }
                else if (grid[i, j] == 0 && neighbors == 3)
                {
                    newGrid[i, j] = 1; 
                }
                else
                {
                    newGrid[i, j] = grid[i, j];
                }
            }
        }

        grid = newGrid;
    }

    static int CountNeighbors(int x, int y)
    {
        int count = 0;

        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                int row = (x + i + rows) % rows;
                int col = (y + j + cols) % cols;

                count += grid[row, col];
            }
        }

        count -= grid[x, y]; 

        return count;
    }
}
