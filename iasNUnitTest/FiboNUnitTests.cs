using NUnit.Framework;
using testCourse;

namespace iasNUnitTest;
[TestFixture]
public class FiboNUnitTests
{
    private Fibo _fibo;
    [SetUp]
    public void Setup()
    {
        _fibo = new Fibo();
    }

    [Test]
    public void GetFibo_Input1_ReturnFiboSeries()
    {
        List<int> expectedResult = new() { 0};

        _fibo.Range = 1;
        var result = _fibo.GetFiboSeries();
        Assert.That(result, Is.Not.Empty);
        Assert.That(result, Is.Ordered);
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetFibo_Input6_ReturnFiboSeries()
    {
        List<int> expectedResult = new() { 0, 1, 1, 2, 3, 5 };

        _fibo.Range = 6;
        var result = _fibo.GetFiboSeries();
        Assert.That(result, Does.Contain(3));
        Assert.That(result.Count, Is.EqualTo(6));
        Assert.That(result, Does.Not.Contain(4));
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }
}
