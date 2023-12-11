using System;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите размер массива: ");
        int size = int.Parse(Console.ReadLine());

        int[] array = GenerateRandomArray(size);

        Task<int> sumTask = Task.Run(() => SumOfOddDivisibleBySeven(array));
        Task<int> maxTask = Task.Run(() => MaxElement(array));
        Task printTask = Task.Run(() => PrintArray(array));

        Task continuationTask = Task.WhenAll(sumTask, maxTask, printTask)
            .ContinueWith(_ =>
            {
                Console.WriteLine($"Сумма нечетных элементов, делящихся на 7: {sumTask.Result}");
                Console.WriteLine($"Максимальный элемент: {maxTask.Result}");
            });

        continuationTask.Wait();
        Console.ReadKey();
    }

    static int[] GenerateRandomArray(int size)
    {
        int[] array = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(100);
        }
        return array;
    }

    static int SumOfOddDivisibleBySeven(int[] array)
    {
        int sum = 0;
        foreach (int num in array)
        {
            if (num % 2 != 0 && num % 7 == 0)
            {
                sum += num;
            }
        }
        return sum;
    }

    static int MaxElement(int[] array)
    {
        int max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    static void PrintArray(int[] array)
    {
        Console.WriteLine("Массив:");
        foreach (int num in array)
        {
            Console.Write($"{num} ");
        }
        Console.WriteLine();
    }
}
