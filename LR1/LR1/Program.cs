using System;

class Program
{
    static int CustomDelegateMethod(Action<string, int> action, int value1, int value2)
    {
        // Вызываем переданный метод Action
        action("Вызван CustomDelegateMethod с параметрами", value1 + value2);

        // Возвращаем результат, равный сумме параметров
        return value1 + value2;
    }

    static void Main(string[] args)
    {
        // Создаем экземпляр делегата Action, который выводит сообщение в консоль
        Action<string, int> actionDelegate = (message, resurlt) =>
        {
            Console.WriteLine($"{message}: {resurlt}");
        };

        // Создаем экземпляр делегата CustomDelegateMethod
        Func<Action<string, int>, int, int, int> funcDelegate = CustomDelegateMethod;

        // Вызываем Func с созданными делегатами и параметрами
        int result = funcDelegate(actionDelegate, 10, 20);

        Console.WriteLine($"Результат: {result}");
        Console.ReadKey();
    }
}

