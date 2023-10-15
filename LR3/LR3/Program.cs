using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        int n = 3, m = 4; // размеры матриц
        var rand = new Random();

        // Создаем две случайные матрицы
        int[,] matrix1 = new int[n, m];
        int[,] matrix2 = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix1[i, j] = rand.Next(10);
                matrix2[i, j] = rand.Next(10);
            }
        }

        // Лямбда-выражение для суммирования матриц
        Func<int[,], int[,], int[,]> sumMatrices = (a, b) =>
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            {
                throw new ArgumentException("Матрицы разных размеров");
            }

            int[,] result = new int[a.GetLength(0), a.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }

            return result;
        };

        // Асинхронно суммируем матрицы с помощью лямбда-выражения
        var task = Task.Run(() => sumMatrices(matrix1, matrix2));

        // Ждем выполнения задачи с помощью тайм-аута
        if (await Task.WhenAny(task, Task.Delay(5000)) == task)
        {
            // Задача завершилась успешно
            int[,] sumMatrix = await task;

            // Выводим результат
            Console.WriteLine("Первая матрица:");
            PrintMatrix(matrix1);

            Console.WriteLine("Вторая матрица:");
            PrintMatrix(matrix2);

            Console.WriteLine("Сумма матриц:");
            PrintMatrix(sumMatrix);
        }
        else
        {
            // Задача не завершилась за 5 секунд
            Console.WriteLine("Превышен интервал ожидания.");
        }
        Console.ReadKey();
    }

    // Метод для вывода матрицы на экран
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
