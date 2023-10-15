using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        int numRows = 3;
        int numCols = 3;

        int[,] matrix = new int[numRows, numCols];

        Random rand = new Random();

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                matrix[i, j] = rand.Next(1, 10);
            }
        }

        Console.WriteLine("Original Matrix:");
        PrintMatrix(matrix);

        // Create a new thread to transform the matrix
        Thread transformThread = new Thread(() =>
        {
            for (int i = 0; i < numRows; i++)
            {
                for (int j = 0; j < numCols; j++)
                {
                    if (matrix[i, j] % 2 == 0)
                    {
                        double sin = Math.Sin(matrix[i, j]);
                        double cos = Math.Cos(matrix[i, j]);
                        matrix[i, j] = (int)(sin + cos);
                    }
                }
            }
        });

        transformThread.Start();
        transformThread.Join();

        Console.WriteLine("Transformed Matrix:");
        PrintMatrix(matrix);
        Console.ReadKey();
    }

    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
