using NUnit.Framework;
using SquareLib.Abstractions;
using SquareLib.Shapes;

namespace SquareLib.Tests;

public class CircleTest
{
    [TestCase(-1d)]
    [TestCase(0d)]
    [TestCase(double.MaxValue)]
    public void ValidationFailureTest(double radius)
    {
        Assert.Catch<ArgumentException>(() => new Circle(radius));
    }

    [Test]
    public void ValidationSuccessTest()
    {
        var radius = 3d;

        Assert.That(new Circle(radius), Is.TypeOf<Circle>());
    }

    [Test]
    public void CalculateSquareTest()
    {
        var radius = 10d;

        Shape shape = new Circle(radius);
        IOperation operations = shape.GetOperations();

        var expectedValue = Math.PI * Math.Pow(radius, 2d);

        var square = operations.CalculateSquare();

        Assert.That(square, Is.EqualTo(expectedValue));
    }
}