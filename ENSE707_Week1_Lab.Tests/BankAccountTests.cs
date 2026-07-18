using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENSE707_Week1_Lab;

[TestClass]
public class BankAccountTests
{
    private int testMoney = 50; 
    private int testBalance = 150;
    
    // Test whether the correct amount $ subtracted from balance
    [TestMethod]        
    public void ValidWithdrawal()
    {       
        BankAccount account = new("Test User", testBalance);
        bool result = account.Withdraw(testMoney);
        Assert.IsTrue(result);
    }
    
    // Test whether user can withdrawn more money than they have
    [TestMethod]
    public void InvalidWithdrawal()
    {
        BankAccount account = new("Test user", testBalance);
        bool result = account.Withdraw(testBalance + testMoney);
        Assert.IsFalse(result);
    }

    // Test whether the correct amount $ added to balance 
    [TestMethod]
    public void ValidDeposit()
    {
        BankAccount account = new("Test user", testBalance);
        bool result = account.Deposit(testMoney);
        Assert.IsTrue(result);
    }
    
    // Test should not be able to deposit negative amount
    [TestMethod]
    public void InvalidDeposit()
    {
        BankAccount account = new("Test user", testBalance);
        bool result = account.Deposit(-testMoney);
        Assert.IsFalse(result);
    }

    // FAIL - User has negative opening balanance
    [TestMethod]
    public void InvalidOpeningBalance()
    {
        bool exceptionThrown = false;
        try {
            BankAccount account = new("Test user", -testBalance);
        } catch(ArgumentException){
            exceptionThrown = true;
        }

        Assert.IsTrue(exceptionThrown);
    }


}
