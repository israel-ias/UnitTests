using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testCourse;
public interface ILogBook
{
    void Message(string message);
    bool LogToDb(string message);
    bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal);
    string MessageWithReturnStr(string message);
    bool LogWithOutputReturn(string message, out string outputStr);
}

public class LogBook : ILogBook
{
    public bool LogBalanceAfterWithdrawal(int balanceAfterWithdrawal)
    {
        if(balanceAfterWithdrawal >= 0)
        {
            Console.WriteLine("Success");
            return true;
        }
            Console.WriteLine("FAilure");
        return false;
    }

    public bool LogToDb(string message)
    {
        Console.WriteLine(message);
        return true;
    }

    public bool LogWithOutputReturn(string message, out string outputStr)
    {
        outputStr = "Hello " + message;
        return true;
    }

    public void Message(string message)
    {
        Console.WriteLine(message);
    }

    public string MessageWithReturnStr(string message)
    {
        Console.WriteLine(message);
        return message;
    }
}

