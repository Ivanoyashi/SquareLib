using SquareLib.Abstractions;
using SquareLib.Operations;

namespace SquareLib.Shapes;

public class Circle : Shape
{
    public Circle(double radius)
    {
        Validate(radius);

        Radius = radius;
    }

    public double Radius { get; }

    public override IOperation GetOperations()
    {
        return new CircleOperation(Radius);
    }

    private void Validate(double radius)
    {
        if (ValidationRules.ValueIsHuge(radius))
            throw new ArgumentException("Значение слишком большое", nameof(radius));

        if (ValidationRules.ValueIsNegativeOrZero(radius))
            throw new ArgumentException("Значение должно быть положительным", nameof(radius));
    }
}
