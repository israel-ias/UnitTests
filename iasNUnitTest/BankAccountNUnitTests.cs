using Moq;
using NUnit.Framework;
using testCourse;

namespace iasNUnitTest;

[TestFixture]
public class BankAccountNUnitTests
{
    private BankAccount _bankAccount;

    [SetUp]
    public void SetUp()
    {
    }

    
    [Test]
    public void BankDeposit_Add100_ReturnTrue()
    {
        var logMock = new Mock<ILogBook>();

        BankAccount bankAccount = new(logMock.Object);
        var result = bankAccount.Deposit(100);
        Assert.IsTrue(result);
        Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
    }

    [Test]
    [TestCase(200, 100)]
    [TestCase(200, 150)]
    public void BankWithdraw_Withdraw100with200Balance_returnTrue(int balance, int withdraw)
    {
        var logMock = new Mock<ILogBook>();
        logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x>0))).Returns(true);

        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(balance);
        var result = bankAccount.Withdraw(withdraw);
        Assert.IsTrue(result);

    }

    [Test]
    public void BankWithdraw_Withdraw300with200Balance_returnFalse()
    {
        var logMock = new Mock<ILogBook>();
        logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
        logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

        BankAccount bankAccount = new(logMock.Object);
        bankAccount.Deposit(200);
        var result = bankAccount.Withdraw(300);
        Assert.IsFalse(result);

    }
}