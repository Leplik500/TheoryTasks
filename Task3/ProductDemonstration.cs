namespace Task3;

/// <summary>
/// Класс для демонстрации работы с товарами.
/// </summary>
public static class ProductDemonstration
{
    /// <summary>
    /// Запускает демонстрацию работы с товарами.
    /// </summary>
    public static void Run()
    {
        Console.WriteLine("=== ДЕМОНСТРАЦИЯ КЛАССА Product ===");
        Console.WriteLine();

        DemonstrateRegularProduct();
        Console.WriteLine();

        Console.WriteLine("=== ДЕМОНСТРАЦИЯ КЛАССА DiscountedProduct ===");
        Console.WriteLine();

        DemonstrateDiscountedProduct();
    }

    /// <summary>
    /// Демонстрирует работу с обычными товарами через ввод с консоли.
    /// </summary>
    private static void DemonstrateRegularProduct()
    {
        Console.WriteLine("Создание обычного товара:");
        Console.WriteLine();

        try
        {
            var product = CreateProductFromConsole();
            
            Console.WriteLine();
            Console.WriteLine("Созданный товар:");
            Console.WriteLine(product.ToString());
            Console.WriteLine();

            // Демонстрация изменения цены
            Console.Write("Хотите изменить цену? (y/n): ");
            var changePriceResponse = Console.ReadLine()?.ToLower();
            
            if (changePriceResponse == "y" || changePriceResponse == "да")
            {
                Console.Write("Введите новую цену: ");
                if (decimal.TryParse(Console.ReadLine(), out var newPrice))
                {
                    product.Price = newPrice;
                    Console.WriteLine("Товар после изменения цены:");
                    Console.WriteLine(product.ToString());
                }
                else
                {
                    Console.WriteLine("Неверный формат цены.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    /// <summary>
    /// Демонстрирует работу с товарами со скидкой через ввод с консоли.
    /// </summary>
    private static void DemonstrateDiscountedProduct()
    {
        Console.WriteLine("Создание товара со скидкой:");
        Console.WriteLine();

        try
        {
            var baseProduct = CreateProductFromConsole();
            
            Console.Write("Введите размер скидки (%): ");
            if (!int.TryParse(Console.ReadLine(), out var discountPercentage))
            {
                Console.WriteLine("Неверный формат скидки. Используется 0%.");
                discountPercentage = 0;
            }

            Console.Write("Введите акционную цену: ");
            if (!decimal.TryParse(Console.ReadLine(), out var discountedPrice))
            {
                Console.WriteLine("Неверный формат цены. Используется обычная цена.");
                discountedPrice = baseProduct.Price;
            }

            var discountedProduct = new DiscountedProduct
            {
                Name = baseProduct.Name,
                Manufacturer = baseProduct.Manufacturer,
                Price = baseProduct.Price,
                ReleaseDate = baseProduct.ReleaseDate,
                ExpirationDate = baseProduct.ExpirationDate,
                DiscountPercentage = discountPercentage,
                DiscountedPrice = discountedPrice
            };

            Console.WriteLine();
            Console.WriteLine("Созданный товар со скидкой:");
            Console.WriteLine(discountedProduct.ToString());
            Console.WriteLine();

            // Демонстрация изменения скидки
            Console.Write("Хотите изменить размер скидки? (y/n): ");
            var changeDiscountResponse = Console.ReadLine()?.ToLower();
            
            if (changeDiscountResponse == "y" || changeDiscountResponse == "да")
            {
                Console.Write("Введите новый размер скидки (%): ");
                if (int.TryParse(Console.ReadLine(), out var newDiscount))
                {
                    Console.Write("Введите новую акционную цену: ");
                    if (decimal.TryParse(Console.ReadLine(), out var newDiscountedPrice))
                    {
                        discountedProduct.DiscountPercentage = newDiscount;
                        discountedProduct.DiscountedPrice = newDiscountedPrice;
                        Console.WriteLine("Товар после изменения скидки:");
                        Console.WriteLine(discountedProduct.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("Неверный формат скидки.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    /// <summary>
    /// Создает товар на основе пользовательского ввода.
    /// </summary>
    /// <returns>Созданный товар</returns>
    private static Product CreateProductFromConsole()
    {
        Console.Write("Введите название товара: ");
        var name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Название товара не может быть пустым");
        }

        Console.Write("Введите производителя: ");
        var manufacturer = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(manufacturer))
        {
            throw new ArgumentException("Производитель не может быть пустым");
        }

        Console.Write("Введите цену: ");
        if (!decimal.TryParse(Console.ReadLine(), out var price))
        {
            throw new ArgumentException("Неверный формат цены");
        }

        Console.Write("Введите дату производства (дд.мм.гггг): ");
        if (!DateOnly.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", out var releaseDate))
        {
            throw new ArgumentException("Неверный формат даты производства");
        }

        Console.Write("Введите срок годности (дд.мм.гггг): ");
        if (!DateOnly.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", out var expirationDate))
        {
            throw new ArgumentException("Неверный формат срока годности");
        }

        return new Product
        {
            Name = name,
            Manufacturer = manufacturer,
            Price = price,
            ReleaseDate = releaseDate,
            ExpirationDate = expirationDate
        };
    }
}
