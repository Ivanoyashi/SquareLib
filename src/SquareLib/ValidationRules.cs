namespace SquareLib;

/// <summary>
/// Набор правил валидации
/// </summary>
internal static class ValidationRules
{
    /// <summary>
    /// Является ли число слишком большим
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool ValueIsHuge(double value)
    {
        if (value >= double.MaxValue)
            return true;
        return false;
    }

    /// <summary>
    /// Является ли число отрицательным или нулем
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool ValueIsNegativeOrZero(double value)
    {
        if (value <= 0d)
            return true;
        return false;
    }
}