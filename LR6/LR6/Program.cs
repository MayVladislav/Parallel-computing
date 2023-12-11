using System;
using System.Threading;

class Program
{
    static void Main()
    {
        int[] arr1 = new int[1000];
        int[] arr2 = new int[1000];

        // заполняем оба массива случайными числами от 0 до 999
        Random rnd = new Random();
        for (int i = 0; i < arr1.Length; i++)
        {
            arr1[i] = rnd.Next(1000);
            arr2[i] = rnd.Next(1000);
        }

        // создаем два параметризированных потока, каждый из которых будет
        // обрабатывать один из массивов
        ParameterizedThreadStart start = new ParameterizedThreadStart(CountMatches);
        Thread t1 = new Thread(start);
        Thread t2 = new Thread(start);

        // запускаем потоки с параметрами - соответствующими массивами
        t1.Start(arr1);
        t2.Start(arr2);

        // ожидаем завершения потоков
        t1.Join();
        t2.Join();
    }

    static void CountMatches(object obj)
    {
        int[] arr = (int[])obj;

        // создаем хэш-таблицу, чтобы быстро искать элементы в другом массиве
        var hash = new System.Collections.Hashtable();
        foreach (int i in arr)
        {
            hash[i] = true;
        }

        // ищем совпадения в другом массиве и выводим их количество
        int count = 0;
        foreach (int i in arr)
        {
            if (hash.ContainsKey(i))
            {
                count++;
            }
        }
        Console.WriteLine("Matches found in this array: {0}", count);
        Console.ReadKey();
    }
}
