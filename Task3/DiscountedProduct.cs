namespace Task3;

/// <summary>
/// Представляет товар со скидкой, наследующий от базового класса Product.
/// </summary>
public class DiscountedProduct : Product
{
    private int _discountPercentage;

    /// <summary>
    /// Размер скидки в процентах. Должен быть от 0 до 100.
    /// </summary>
    public int DiscountPercentage
    {
        get => _discountPercentage;
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(DiscountPercentage), "Discount percentage must be between 0 and 100.");
            }
            _discountPercentage = value;
        }
    }

    /// <summary>
    /// Акционная цена товара со скидкой.
    /// </summary>
    public decimal DiscountedPrice { get; set; }

    /// <summary>
    /// Возвращает строковое представление товара со скидкой.
    /// </summary>
    /// <returns>Строка с информацией о товаре со скидкой</returns>
    public override string ToString()
    {
        return $"Товар: {Name}, Производитель: {Manufacturer}, " +
               $"Обычная цена: {Price:C}, Скидка: {DiscountPercentage}%, " +
               $"Акционная цена: {DiscountedPrice:C}, " +
               $"Дата выпуска: {ReleaseDate:dd.MM.yyyy}, " +
               $"Срок годности: {ExpirationDate:dd.MM.yyyy}";
    }
}