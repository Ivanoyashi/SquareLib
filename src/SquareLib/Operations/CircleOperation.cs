using SquareLib.Abstractions;

namespace SquareLib.Operations;

/// <summary>
/// Операции над кругом
/// </summary>
public class CircleOperation : IOperation
{
    private readonly double _radius;

    public CircleOperation(double radius)
    {
        _radius = radius;
    }

    public double CalculateSquare()
    {
        return Math.PI * Math.Pow(_radius, 2);
    }
}