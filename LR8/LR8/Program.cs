using System;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        int rows = 3;
        int cols = 3;

        // Создаем две матрицы размера rows x cols
        int[,] matrix1 = new int[rows, cols];
        int[,] matrix2 = new int[rows, cols];

        // Заполняем матрицы случайными числами
        Random rnd = new Random();
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                matrix1[i, j] = rnd.Next(1, 10);
                matrix2[i, j] = rnd.Next(1, 10);
            }
        }

        // Выводим матрицы на консоль
        Console.WriteLine("Matrix 1:");
        PrintMatrix(matrix1);

        Console.WriteLine("Matrix 2:");
        PrintMatrix(matrix2);

        // Создаем новую матрицу для записи результата
        int[,] result = new int[rows, cols];

        // Вычисляем сумму двух матриц с использованием класса Task
        Task t = Task.Run(() =>
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
        });

        // Ожидаем завершения вычислений
        t.Wait();

        // Выводим результат на консоль
        Console.WriteLine("Result:");
        PrintMatrix(result);

        Console.ReadKey();
    }

    static void PrintMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write("{0} ", matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}
