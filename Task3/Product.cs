namespace Task3;

/// <summary>
/// Представляет товар с основными характеристиками.
/// </summary>
public class Product
{
    private decimal _price;
    private DateOnly _releaseDate;
    private DateOnly _expirationDate;

    /// <summary>
    /// Название товара.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Производитель товара.
    /// </summary>
    public required string Manufacturer { get; set; }

    /// <summary>
    /// Цена товара. Должна быть неотрицательной.
    /// </summary>
    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Price must be greater than or equal to 0.");
            }
            _price = value;
        }
    }

    /// <summary>
    /// Дата выпуска товара.
    /// </summary>
    public DateOnly ReleaseDate
    {
        get => _releaseDate;
        set
        {
            if (_expirationDate != default && value > _expirationDate)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Release date cannot be later than expiration date.");
            }
            _releaseDate = value;
        }
    }

    /// <summary>
    /// Дата истечения срока годности товара.
    /// </summary>
    public DateOnly ExpirationDate
    {
        get => _expirationDate;
        set
        {
            if (_releaseDate != default && value < _releaseDate)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Expiration date cannot be earlier than release date.");
            }
            _expirationDate = value;
        }
    }

    /// <summary>
    /// Возвращает строковое представление товара.
    /// </summary>
    /// <returns>Строка с информацией о товаре</returns>
    public override string ToString()
    {
        return $"Товар: {Name}, Производитель: {Manufacturer}, " +
               $"Цена: {Price:C}, Дата выпуска: {ReleaseDate:dd.MM.yyyy}, " +
               $"Срок годности: {ExpirationDate:dd.MM.yyyy}";
    }
}
