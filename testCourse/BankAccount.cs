namespace testCourse;
public class BankAccount
{
    private int _balance {  get; set; }
    private readonly ILogBook _logBoook;
    

    public BankAccount(ILogBook logBook)
    {
        _logBoook = logBook;
        _balance = 0;
    }

    public bool Deposit(int amount)
    {
        _logBoook.Message("Deposit invoked");
        _balance += amount;
        return true;
    }

    public bool Withdraw(int amount)
    {
        if (amount <= _balance)
        {
            _logBoook.LogToDb("Withdrawal Amount: " + amount);
            _balance -= amount;
            return _logBoook.LogBalanceAfterWithdrawal(_balance);
        }
        return _logBoook.LogBalanceAfterWithdrawal(_balance - amount);
    }

    public int GetBalance()
    {
        return _balance;
    }
}

