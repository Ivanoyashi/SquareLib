using SquareLib.Abstractions;
using SquareLib.Operations;

namespace SquareLib.Shapes;

public class Triangle : Shape
{
    public Triangle(double edgeA, double edgeB, double edgeC)
    {
        Validate(
            (nameof(edgeA), edgeA),
            (nameof(edgeB), edgeB),
            (nameof(edgeC), edgeC));

        EdgeA = edgeA;
        EdgeB = edgeB;
        EdgeC = edgeC;
    }

    public double EdgeA { get; }

    public double EdgeB { get; }

    public double EdgeC { get; }

    public override IOperation GetOperations()
    {
        return new TriangleOperation(EdgeA, EdgeB, EdgeC);
    }

    private void Validate(params (string name, double value)[] edges)
    {
        var maxEdge = 0d;

        foreach (var edge in edges)
        {
            if (ValidationRules.ValueIsHuge(edge.value))
                throw new ArgumentException("Значение слишком большое", edge.name);

            if (ValidationRules.ValueIsNegativeOrZero(edge.value))
                throw new ArgumentException("Значение должно быть положительным", edge.name);

            if (edge.value >= maxEdge)
                maxEdge = edge.value;
        }

        var perimeter = edges.Select(x => x.value).Sum();

        if (perimeter - maxEdge * 2 <= 0d)
            throw new ArgumentException("Cумма двух сторон должна быть больше третьей стороны");
    }
}
