namespace Task4;

/// <summary>
/// Класс для демонстрации работы со SmartStack.
/// </summary>
public static class SmartStackDemonstration
{
    /// <summary>
    /// Запускает демонстрацию работы со SmartStack.
    /// </summary>
    public static void Run()
    {
        DemonstrateConstructors();
        Console.WriteLine();

        DemonstratePushAndPop();
        Console.WriteLine();

        DemonstratePushRange();
        Console.WriteLine();

        DemonstrateIndexer();
        Console.WriteLine();

        DemonstrateEnumeration();
        Console.WriteLine();

        DemonstrateExceptions();
    }

    /// <summary>
    /// Демонстрирует различные конструкторы.
    /// </summary>
    private static void DemonstrateConstructors()
    {
        Console.WriteLine("=== КОНСТРУКТОРЫ ===");

        var stack1 = new SmartStack<int>();
        Console.WriteLine($"Конструктор по умолчанию - Capacity: {stack1.Capacity}, Count: {stack1.Count}");

        var stack2 = new SmartStack<int>(10);
        Console.WriteLine($"Конструктор с емкостью 10 - Capacity: {stack2.Capacity}, Count: {stack2.Count}");

        var collection = new List<int> { 1, 2, 3, 4, 5 };
        var stack3 = new SmartStack<int>(collection);
        Console.WriteLine($"Конструктор с коллекцией - Capacity: {stack3.Capacity}, Count: {stack3.Count}");
        Console.Write("Элементы (от вершины к основанию): ");
        foreach (var item in stack3)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Демонстрирует методы Push и Pop.
    /// </summary>
    private static void DemonstratePushAndPop()
    {
        Console.WriteLine("=== PUSH И POP ===");

        var stack = new SmartStack<string>();

        stack.Push("Первый");
        stack.Push("Второй");
        stack.Push("Третий");
        Console.WriteLine($"После добавления 3 элементов - Count: {stack.Count}");

        stack.Push("Четвертый");
        stack.Push("Пятый");
        Console.WriteLine($"После добавления 5 элементов - Capacity: {stack.Capacity}, Count: {stack.Count}");

        Console.WriteLine($"Peek: {stack.Peek()}");
        Console.WriteLine($"Count после Peek: {stack.Count}");

        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Pop: {stack.Pop()}");
        Console.WriteLine($"Count после Pop: {stack.Count}");
    }

    /// <summary>
    /// Демонстрирует метод PushRange.
    /// </summary>
    private static void DemonstratePushRange()
    {
        Console.WriteLine("=== PUSH RANGE ===");

        var stack = new SmartStack<int>();
        stack.Push(1);
        stack.Push(2);

        Console.WriteLine("Исходный стек:");
        foreach (var item in stack)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();

        var newItems = new List<int> { 10, 20, 30 };
        stack.PushRange(newItems);

        Console.WriteLine("После PushRange([10, 20, 30]):");
        foreach (var item in stack)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
        Console.WriteLine($"Count: {stack.Count}, Capacity: {stack.Capacity}");
    }

    /// <summary>
    /// Демонстрирует работу индексатора.
    /// </summary>
    private static void DemonstrateIndexer()
    {
        Console.WriteLine("=== ИНДЕКСАТОР ===");

        var stack = new SmartStack<char>(['A', 'B', 'C', 'D']);

        Console.WriteLine("Доступ к элементам через индексатор:");
        for (var i = 0; i < stack.Count; i++)
        {
            Console.WriteLine($"Индекс {i} (глубина {i}): {stack[i]}");
        }

        // Изменение элемента через индексатор
        stack[1] = 'X';
        Console.WriteLine("После изменения stack[1] = 'X':");
        foreach (var item in stack)
        {
            Console.Write($"{item} ");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Демонстрирует перечисление элементов.
    /// </summary>
    private static void DemonstrateEnumeration()
    {
        Console.WriteLine("=== ПЕРЕЧИСЛЕНИЕ ===");

        var stack = new SmartStack<double>();
        stack.Push(1.1);
        stack.Push(2.2);
        stack.Push(3.3);
        stack.Push(4.4);

        Console.WriteLine("Элементы стека (от вершины к основанию):");
        foreach (var item in stack)
        {
            Console.WriteLine($"  {item}");
        }

        Console.WriteLine($"Содержит 2.2? {stack.Contains(2.2)}");
        Console.WriteLine($"Содержит 5.5? {stack.Contains(5.5)}");
    }

    /// <summary>
    /// Демонстрирует обработку исключений.
    /// </summary>
    private static void DemonstrateExceptions()
    {
        Console.WriteLine("=== ОБРАБОТКА ИСКЛЮЧЕНИЙ ===");

        var stack = new SmartStack<int>();

        try
        {
            Console.WriteLine("Попытка Pop из пустого стека:");
            stack.Pop();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            Console.WriteLine("Попытка Peek из пустого стека:");
            stack.Peek();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            stack.Push(1);
            Console.WriteLine("Попытка доступа к несуществующему индексу:");
            var value = stack[5];
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        try
        {
            Console.WriteLine("Попытка создать стек с отрицательной емкостью:");
            var invalidStack = new SmartStack<int>(-1);
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
