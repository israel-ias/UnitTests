using NUnit.Framework;
using testCourse;

namespace iasNUnitTest;
public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void AddNumbers_InputTwoIntegeres_GetTheSum()
    {
        Calculator calc = new();

        int result = calc.AddNumbers(10, 20);

        Assert.AreEqual(30, result);
    }

    [Test]
    public void IsOddNumber_InputOddInteger_GetTrue()
    {
        Calculator calc = new();

        bool result = calc.IsOddNumber(7);

        Assert.IsTrue(result);
    }

    [Test]
    public void IsOddNumber_InputEvenInteger_GetFalse()
    {
        Calculator calc = new();

        bool result = calc.IsOddNumber(4);

        Assert.IsFalse(result);

    }

    [Test]
    [TestCase(10, ExpectedResult = false)]
    [TestCase(13, ExpectedResult = true)]
    public bool IsOddNumber_InputNumber_ReturnTrueIfOdd(int a)
    {
        Calculator calc = new();

        return calc.IsOddNumber(a);
    }

    [Test]
    [TestCase(5.4, 10.5)] //15.9
    [TestCase(5.43, 10.53)] // 15.93
    [TestCase(5.49, 10.59)] // 16.08
    public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
    {
        //Arrange
        Calculator calc = new();

        //Act
        double result = calc.AddNumbersDouble(a, b);


        //Assert
        Assert.AreEqual(15.9, result, .2);
        //15.7-16.1
    }


    [Test]
    public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
    {
        Calculator calc = new();
        List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10

        //act
        List<int> result = calc.GetOddRange(5, 10);

        //Assert
        Assert.That(result, Is.EquivalentTo(expectedOddRange));
        //Assert.AreEqual( expectedOddRange, result);
        //Assert.Contains(7, result);
        Assert.That(result, Does.Contain(7));
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result, Has.No.Member(6));
        Assert.That(result, Is.Ordered);
        Assert.That(result, Is.Unique);
    }
}