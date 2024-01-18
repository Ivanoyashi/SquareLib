using SquareLib.Abstractions;

namespace SquareLib.Operations;

/// <summary>
/// Операции над треугольником
/// </summary>
public class TriangleOperation : IOperation
{
    private readonly double _edgeA;
    private readonly double _edgeB;
    private readonly double _edgeC;

    public TriangleOperation(double edgeA, double edgeB, double edgeC)
    {
        _edgeA = edgeA;
        _edgeB = edgeB;
        _edgeC = edgeC;
    }

    public double CalculateSquare()
    {
        var halfPerimeter = (_edgeA + _edgeB + _edgeC) / 2d;

        var square = Math.Sqrt(halfPerimeter
            * (halfPerimeter - _edgeA)
            * (halfPerimeter - _edgeB)
            * (halfPerimeter - _edgeC)
        );

        return square;
    }

    /// <summary>
    /// Проверка, является ли треугольник прямоугольным
    /// </summary>
    /// <returns></returns>
    public bool CheckIsRectangular()
    {
        double maxEdge = _edgeA, b = _edgeB, c = _edgeC;

        if (b - maxEdge >= 0d)
        {
            maxEdge = b;
            b = _edgeA;

            if (c - maxEdge >= 0d)
            {
                maxEdge = c;
                c = _edgeB;
            }
        }

        if (Math.Pow(maxEdge, 2) == Math.Pow(b, 2) + Math.Pow(c, 2))
            return true;
        else
            return false;
    }
}