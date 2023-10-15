using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = new int[10]; // создание массива из 10 элементов
        Random rnd = new Random();

        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(1, 101); // заполнение массива случайными числами от 1 до 100
        }

        Console.WriteLine("Исходный массив: ");
        Console.WriteLine(string.Join(", ", arr)); // вывод исходного массива на консоль

        Func<int[], int[]> getEvenSubset = (inputArr) => {
            return inputArr.Where(x => x % 2 == 0).ToArray(); // лямбда-выражение для выбора четных элементов массива
        };

        int[] evenSubset = getEvenSubset(arr); // получение подмножества четных элементов исходного массива

        Console.WriteLine("Подмножество четных элементов: ");
        Console.WriteLine(string.Join(", ", evenSubset)); // вывод подмножества на консоль
        Console.ReadKey();
    }
}
