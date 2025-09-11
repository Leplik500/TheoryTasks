namespace Task3;

/// <summary>
/// Класс для демонстрации работы с прямоугольниками.
/// </summary>
public static class RectangleDemonstration
{
    /// <summary>
    /// Запускает демонстрацию работы с прямоугольниками.
    /// </summary>
    public static void Run()
    {
        try
        {
            var rectangle1 = new Rectangle
            {
                TopLeft = new Coordinate(10, 20),
                Width = 15,
                Height = 8
            };

            Console.WriteLine("Прямоугольник 1:");
            Console.WriteLine($"Левый верхний угол: ({rectangle1.TopLeft.X}, {rectangle1.TopLeft.Y})");
            Console.WriteLine($"Ширина: {rectangle1.Width}");
            Console.WriteLine($"Высота: {rectangle1.Height}");
            Console.WriteLine($"Площадь: {rectangle1.Area}");
            Console.WriteLine($"Периметр: {rectangle1.Perimeter}");
            Console.WriteLine();

            var rectangle2 = new Rectangle
            {
                TopLeft = new Coordinate(0, 0),
                Width = 0,
                Height = 0
            };

            Console.WriteLine("Прямоугольник 2 (вырожденный):");
            Console.WriteLine($"Левый верхний угол: ({rectangle2.TopLeft.X}, {rectangle2.TopLeft.Y})");
            Console.WriteLine($"Ширина: {rectangle2.Width}");
            Console.WriteLine($"Высота: {rectangle2.Height}");
            Console.WriteLine($"Площадь: {rectangle2.Area}");
            Console.WriteLine($"Периметр: {rectangle2.Perimeter}");
            Console.WriteLine();

            Console.WriteLine("Изменение размеров прямоугольника 1:");
            rectangle1.Width = 25;
            rectangle1.Height = 12;
            Console.WriteLine($"Новая ширина: {rectangle1.Width}");
            Console.WriteLine($"Новая высота: {rectangle1.Height}");
            Console.WriteLine($"Новая площадь: {rectangle1.Area}");
            Console.WriteLine($"Новый периметр: {rectangle1.Perimeter}");
            Console.WriteLine();

            Console.WriteLine("Попытка установить отрицательную ширину:");
            rectangle1.Width = -5;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }

        Console.WriteLine();

        try
        {
            Console.WriteLine("Попытка установить отрицательную высоту:");
            var rectangle3 = new Rectangle
            {
                TopLeft = new Coordinate(5, 10),
                Width = 10,
                Height = -3
            };
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
