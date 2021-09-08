using Microsoft.VisualStudio.TestTools.UnitTesting;
using testCourse;

namespace iasMSTest;
[TestClass]
public class CalculatorMSTests
{
    [TestMethod]
    public void AddNumbers_InputTwoIntegeres_GetTheSum()
    {
        Calculator calc = new();

        int result = calc.AddNumbers(10, 20);

        Assert.AreEqual(30, result);
    }

    [TestMethod]
    public void IsOddNumber_InputOddInteger_GetTrue()
    {
        Calculator calc = new();

        bool result = calc.IsOddNumber(7);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void IsOddNumber_InputEvenInteger_GetFalse()
    {
        Calculator calc = new();

        bool result = calc.IsOddNumber(4);

        Assert.IsFalse(result);

    }
}