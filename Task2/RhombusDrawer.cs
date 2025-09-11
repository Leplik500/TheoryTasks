namespace Task2;

/// <summary>
/// Класс для рисования ромба из символов.
/// </summary>
public static class RhombusDrawer
{
    /// <summary>
    /// Выводит на экран ромб из символов X с пустым центром.
    /// </summary>
    /// <param name="diagonalLength">Длина диагонали (положительное нечётное число)</param>
    public static void Draw(int diagonalLength)
    {
        if (diagonalLength % 2 == 0)
        {
            Console.WriteLine("Diagonal length must be not even");
            return;
        }
        
        var middle = diagonalLength / 2;
        
        // Верхняя половина ромба
        for (var i = 0; i <= middle; i++)
        {
            var spaces = middle - i;
            
            if (i == 0)
            {
                // Верхняя точка
                Console.WriteLine(new string(' ', spaces) + "X");
            }
            else if (i == middle && diagonalLength > 1)
            {
                // Средняя строка с пустым центром
                Console.WriteLine(new string(' ', spaces) + "X" + new string(' ', 2 * i - 1) + "X");
            }
            else if (diagonalLength == 1)
            {
                Console.WriteLine("X");
            }
            else
            {
                // Боковые строки с полой серединой
                Console.WriteLine(new string(' ', spaces) + "X" + new string(' ', 2 * i - 1) + "X");
            }
        }
        
        // Нижняя половина ромба
        for (var i = middle - 1; i >= 0; i--)
        {
            var spaces = middle - i;
            
            if (i == 0)
            {
                // Нижняя точка
                Console.WriteLine(new string(' ', spaces) + "X");
            }
            else
            {
                // Боковые строки
                Console.WriteLine(new string(' ', spaces) + "X" + new string(' ', 2 * i - 1) + "X");
            }
        }
    }
}