using System;
using System.Threading;

class RandomMatrixPair
{
    private int[,] matrix1;
    private int[,] matrix2;
    private readonly int rows;
    private readonly int columns;
    private readonly Random rand = new Random();

    public RandomMatrixPair(int rows, int columns)
    {
        this.rows = rows;
        this.columns = columns;
        this.matrix1 = GenerateRandomMatrix(rows, columns);
        this.matrix2 = GenerateRandomMatrix(rows, columns);
    }

    public int[,] Matrix1
    {
        get { return matrix1; }
    }

    public int[,] Matrix2
    {
        get { return matrix2; }
    }

    private int[,] GenerateRandomMatrix(int rows, int columns)
    {
        int[,] matrix = new int[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = rand.Next(10);
            }
        }
        return matrix;
    }
}
class MatrixAddition
{
    public static void AddMatricesWithSleep(int[,] matrix1, int[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int columns = matrix1.GetLength(1);

        int[,] resultMatrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                resultMatrix[i, j] = matrix1[i, j] + matrix2[i, j];
                Thread.Sleep(100); // здесь задержка в 100 миллисекунд
            }
        }

        Console.WriteLine("Result Matrix:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(resultMatrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}


class Program
{
    static void Main()
    {
        RandomMatrixPair randomMatrixPair = new RandomMatrixPair(3, 3);

        Console.WriteLine("Matrix 1:");
        PrintMatrix(randomMatrixPair.Matrix1);

        Console.WriteLine("Matrix 2:");
        PrintMatrix(randomMatrixPair.Matrix2);

        MatrixAddition.AddMatricesWithSleep(randomMatrixPair.Matrix1, randomMatrixPair.Matrix2);

        Console.ReadKey();
    }

    private static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}

