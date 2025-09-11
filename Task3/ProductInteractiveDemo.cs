namespace Task3;

/// <summary>
/// Демонстрация работы с товарами.
/// </summary>
public static class ProductInteractiveDemo
{
    /// <summary>
    /// Запускает демонстрацию.
    /// </summary>
    public static void Run()
    {
        while (true)
        {
            ShowMenu();
            var choice = GetMenuChoice();

            switch (choice)
            {
                case 1:
                    CreateRegularProduct();
                    break;
                case 2:
                    CreateDiscountedProduct();
                    break;
                case 3:
                    Console.WriteLine("Выход из программы...");
                    return;
            }

            Console.WriteLine();
            Console.WriteLine("Нажмите Enter для продолжения...");
            Console.ReadLine();
            Console.Clear();
        }
    }

    /// <summary>
    /// Показывает главное меню.
    /// </summary>
    private static void ShowMenu()
    {
        Console.WriteLine("Выберите тип товара:");
        Console.WriteLine("1. Обычный товар");
        Console.WriteLine("2. Товар со скидкой");
        Console.WriteLine("3. Выход");
        Console.Write("Ваш выбор: ");
    }

    /// <summary>
    /// Получает выбор пользователя из меню.
    /// </summary>
    /// <returns>Номер выбранного пункта меню</returns>
    private static int GetMenuChoice()
    {
        while (true)
        {
            var input = Console.ReadLine();
            
            if (int.TryParse(input, out var choice) && choice is >= 1 and <= 3)
            {
                return choice;
            }
            
            Console.WriteLine("Неверный выбор! Пожалуйста, введите число от 1 до 3.");
            Console.Write("Ваш выбор: ");
        }
    }

    /// <summary>
    /// Создает обычный товар на основе пользовательского ввода.
    /// </summary>
    private static void CreateRegularProduct()
    {
        Console.WriteLine();
        Console.WriteLine("=== СОЗДАНИЕ ОБЫЧНОГО ТОВАРА ===");

        try
        {
            var name = GetStringInput("Введите название товара: ");
            var manufacturer = GetStringInput("Введите производителя: ");
            var price = GetDecimalInput("Введите цену товара: ");
            
            var releaseDate = GetDateInput("Введите дату производства (дд.мм.гггг): ");
            
            var expirationDate = GetExpirationDate("Введите срок годности (дд.мм.гггг): ", releaseDate);

            var product = new Product
            {
                Name = name,
                Manufacturer = manufacturer,
                Price = price,
                ReleaseDate = releaseDate,
                ExpirationDate = expirationDate
            };

            Console.WriteLine();
            Console.WriteLine("=== СОЗДАННЫЙ ТОВАР ===");
            Console.WriteLine(product.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании товара: {ex.Message}");
        }
    }

    /// <summary>
    /// Создает товар со скидкой на основе пользовательского ввода.
    /// </summary>
    private static void CreateDiscountedProduct()
    {
        Console.WriteLine();
        Console.WriteLine("=== СОЗДАНИЕ ТОВАРА СО СКИДКОЙ ===");

        try
        {
            var name = GetStringInput("Введите название товара: ");
            var manufacturer = GetStringInput("Введите производителя: ");
            var price = GetDecimalInput("Введите цену товара: ");
            
            var releaseDate = GetDateInput("Введите дату производства (дд.мм.гггг): ");
            
            var expirationDate = GetExpirationDate("Введите срок годности (дд.мм.гггг): ", releaseDate);
            
            var discountPercentage = GetIntInput("Введите размер скидки (%): ", 0, 100);

            var discountedPrice = price * (100 - discountPercentage) / 100;

            var discountedProduct = new DiscountedProduct
            {
                Name = name,
                Manufacturer = manufacturer,
                Price = price,
                ReleaseDate = releaseDate,
                ExpirationDate = expirationDate,
                DiscountPercentage = discountPercentage,
                DiscountedPrice = discountedPrice
            };

            Console.WriteLine();
            Console.WriteLine("=== СОЗДАННЫЙ ТОВАР СО СКИДКОЙ ===");
            Console.WriteLine(discountedProduct.ToString());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании товара: {ex.Message}");
        }
    }

    /// <summary>
    /// Получает строковый ввод от пользователя.
    /// </summary>
    /// <param name="prompt">Подсказка для пользователя</param>
    /// <returns>Введенная строка</returns>
    private static string GetStringInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }
            
            Console.WriteLine("Значение не может быть пустым! Попробуйте еще раз.");
        }
    }

    /// <summary>
    /// Получает десятичное число от пользователя.
    /// </summary>
    /// <param name="prompt">Подсказка для пользователя</param>
    /// <returns>Введенное число</returns>
    private static decimal GetDecimalInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            
            if (decimal.TryParse(input, out var value) && value >= 0)
            {
                return value;
            }
            
            Console.WriteLine("Введите корректное неотрицательное число!");
        }
    }

    /// <summary>
    /// Получает целое число от пользователя в заданном диапазоне.
    /// </summary>
    /// <param name="prompt">Подсказка для пользователя</param>
    /// <param name="min">Минимальное значение</param>
    /// <param name="max">Максимальное значение</param>
    /// <returns>Введенное число</returns>
    private static int GetIntInput(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            
            if (int.TryParse(input, out var value) && value >= min && value <= max)
            {
                return value;
            }
            
            Console.WriteLine($"Введите число от {min} до {max}!");
        }
    }

    /// <summary>
    /// Получает дату от пользователя.
    /// </summary>
    /// <param name="prompt">Подсказка для пользователя</param>
    /// <returns>Введенная дата</returns>
    private static DateOnly GetDateInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            
            if (DateOnly.TryParseExact(input, "dd.MM.yyyy", out var date))
            {
                return date;
            }
            
            Console.WriteLine("Введите дату в формате дд.мм.гггг (например, 15.09.2025)!");
        }
    }

    /// <summary>
    /// Получает дату истечения срока годности с проверкой на корректность относительно даты производства.
    /// </summary>
    /// <param name="prompt">Подсказка для пользователя</param>
    /// <param name="releaseDate">Дата производства для сравнения</param>
    /// <returns>Введенная дата истечения срока годности</returns>
    private static DateOnly GetExpirationDate(string prompt, DateOnly releaseDate)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            
            if (DateOnly.TryParseExact(input, "dd.MM.yyyy", out var date))
            {
                if (date >= releaseDate)
                {
                    return date;
                }
                
                Console.WriteLine($"Срок годности не может быть раньше даты производства ({releaseDate:dd.MM.yyyy})!");
                continue;
            }
            
            Console.WriteLine("Введите дату в формате дд.мм.гггг (например, 15.09.2025)!");
        }
    }
}
