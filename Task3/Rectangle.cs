namespace Task3;

/// <summary>
/// Представляет прямоугольник с заданными координатами левого верхнего угла, шириной и высотой.
/// </summary>
public class Rectangle
{
    private int _width;
    private int _height;

    /// <summary>
    /// Координаты левого верхнего угла прямоугольника.
    /// </summary>
    public required Coordinate TopLeft { get; set; }

    /// <summary>
    /// Ширина прямоугольника. Должна быть неотрицательной.
    /// </summary>
    public int Width
    {
        get => _width;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Width), "Width must be greater than or equal to 0.");
            }
            _width = value;
        }
    }

    /// <summary>
    /// Высота прямоугольника. Должна быть неотрицательной.
    /// </summary>
    public int Height
    {
        get => _height;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(Height), "Height must be greater than or equal to 0.");
            }
            _height = value;
        }
    }

    /// <summary>
    /// Площадь прямоугольника.
    /// </summary>
    public int Area
    {
        get => Width * Height;
    }

    /// <summary>
    /// Периметр прямоугольника.
    /// </summary>
    public int Perimeter
    {
        get => 2 * (Width + Height);
    }
}