using Task3;

while (true)
{
    Console.WriteLine("Выберите демонстрацию:");
    Console.WriteLine("1. Прямоугольники");
    Console.WriteLine("2. Товары");
    Console.WriteLine("3. Выход");
    Console.Write("Ваш выбор: ");
    
    var input = Console.ReadLine();
    
    if (!int.TryParse(input, out var choice) || choice < 1 || choice > 3)
    {
        Console.WriteLine("Неверный выбор! Пожалуйста, введите число от 1 до 3.");
        Console.WriteLine();
        continue;
    }
    
    Console.Clear();
    
    switch (choice)
    {
        case 1:
            RectangleDemonstration.Run();
            Console.WriteLine();
            Console.WriteLine("Нажмите Enter для возврата в главное меню...");
            Console.ReadLine();
            Console.Clear();
            break;
        case 2:
            ProductInteractiveDemo.Run();
            break;
        case 3:
            Console.WriteLine("До свидания!");
            return;
    }
}