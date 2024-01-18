using NUnit.Framework;
using NUnit.Framework.Internal;
using SquareLib.Abstractions;
using SquareLib.Operations;
using SquareLib.Shapes;

namespace SquareLib.Tests;

public class TriangleTest
{
    [TestCase(1d, 1d, 4d)]

    [TestCase(-1d, 1d, 1d)]
    [TestCase(1d, -1d, 1d)]
    [TestCase(1d, 1d, -1d)]
    [TestCase(0d, 0d, 0d)]
    public void ValidationFailureTest(double a, double b, double c)
    {
        Assert.Catch<ArgumentException>(() => new Triangle(a, b, c));
    }

    [TestCase(7d, 7d, 7d)]
    [TestCase(3d, 4d, 5d)]
    public void ValidationSuccessTest(double a, double b, double c)
    {
        Assert.That(new Triangle(a, b, c), Is.TypeOf<Triangle>());
    }

    [Test]
    public void CalculateSquareTest()
    {
        double a = 3d, b = 4d, c = 5d;
        double expectedValue = 6d;

        Shape shape = new Triangle(a, b, c);
        IOperation operations = shape.GetOperations();

        var square = operations.CalculateSquare();

        Assert.That(square, Is.EqualTo(expectedValue));
    }

    [TestCase(3, 4, 5, ExpectedResult = true)]
    [TestCase(3, 4, 3, ExpectedResult = false)]
    public bool TriangleIsRectangularTest(double a, double b, double c)
    {
        Shape shape = new Triangle(a, b, c);
        IOperation operations = shape.GetOperations();

        var isRectangular = ((TriangleOperation)operations).CheckIsRectangular();

        return isRectangular;
    }
}