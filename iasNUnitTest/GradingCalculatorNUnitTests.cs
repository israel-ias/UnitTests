using NUnit.Framework;
using testCourse;

namespace iasNUnitTest;

[TestFixture]
public class GradingCalculatorNUnitTests
{
    private GradingCalculator _gradingCalculator;
    [SetUp]
    public void Setup()
    {
        _gradingCalculator = new GradingCalculator();
    }

    [Test]
    public void GetGrade_InputScore95Attendance90_GetAGrade()
    {
        _gradingCalculator.Score = 95;
        _gradingCalculator.AttendancePercentage = 90;
        var result = _gradingCalculator.GetGrade();

        Assert.AreEqual("A", result);
    }

    [Test]
    public void GetGrade_InputScore85Attendance90_GetBGrade()
    {
        _gradingCalculator.Score = 85;
        _gradingCalculator.AttendancePercentage = 90;
        var result = _gradingCalculator.GetGrade();

        Assert.AreEqual("B", result);
    }

    [Test]
    public void GetGrade_InputScore65Attendance90_GetCGrade()
    {
        _gradingCalculator.Score = 65;
        _gradingCalculator.AttendancePercentage = 90;
        var result = _gradingCalculator.GetGrade();

        Assert.AreEqual("C", result);
    }

    [Test]
    public void GetGrade_InputScore95Attendance65_GetBGrade()
    {
        _gradingCalculator.Score = 95;
        _gradingCalculator.AttendancePercentage = 65;
        var result = _gradingCalculator.GetGrade();

        Assert.AreEqual("B", result);
    }

    [Test]
    [TestCase(95,55)]
    [TestCase(65,55)]
    [TestCase(50,90)]
    public void GetGrade_InputMultiples_GetFGrade(int score, int attendance)
    {
        _gradingCalculator.Score = score;
        _gradingCalculator.AttendancePercentage = attendance;
        var result = _gradingCalculator.GetGrade();
        Assert.AreEqual("F", result);
    }

    [Test]
    [TestCase(95, 90, ExpectedResult = "A")]
    [TestCase(85, 90, ExpectedResult = "B")]
    [TestCase(65, 90, ExpectedResult = "C")]
    [TestCase(95, 65, ExpectedResult = "B")]
    [TestCase(95, 55, ExpectedResult = "F")]
    [TestCase(65, 55, ExpectedResult = "F")]
    [TestCase(50, 90, ExpectedResult = "F")]
    public string GetGrade_InputMultiples_GetCorrectGrade(int score, int attendance)
    {
        _gradingCalculator.Score = score;
        _gradingCalculator.AttendancePercentage = attendance;
        return _gradingCalculator.GetGrade();
    }
}
