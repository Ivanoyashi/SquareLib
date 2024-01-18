namespace SquareLib.Abstractions;

public abstract class Shape
{
    // Применил паттерн Factory Method,
    // для вычисления площади фигуры без знания типа фигуры в compile-time
    /// <summary>
    /// Получение возможности производить операции над фигурами
    /// </summary>
    /// <returns></returns>
    public abstract IOperation GetOperations();
}
