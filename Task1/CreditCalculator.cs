using System.Text;

namespace Task1;
/// <summary>
/// Статический класс для расчета кредитных операций.
/// </summary>
public static class CreditCalculator
{
    /// <summary>
    /// Формирует строку с расчетом сложных процентов по годам.
    /// </summary>
    /// <param name="initialDeposit">Начальный вклад (положительное число)</param>
    /// <param name="years">Количество лет (положительное целое число)</param>
    /// <param name="interestRate">Годовая процентная ставка (положительное число)</param>
    /// <returns>Строка с расчетом накоплений по годам</returns>
    public static string CalculateComplexInterest(double initialDeposit, int years, double interestRate)
    {
        var stringBuilder = new StringBuilder();
        var previousYearSum = initialDeposit;
    
        for (var i = 1; i <= years; i++)
        {
            var currentYearSum = previousYearSum * (1 + interestRate / 100);
            stringBuilder.Append($"Год {i}: {currentYearSum:F2} руб.\n");
            previousYearSum = currentYearSum;
        }
    
        return stringBuilder.ToString();
    }

}