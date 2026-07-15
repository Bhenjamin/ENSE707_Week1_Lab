using Microsoft.VisualStudio.TestTools.UnitTesting;
using ENSE707_Week1_Lab;

[TestClass]
public class BankAccountTests
{
    private testMoney = 50; 
    private testBalance = 150;
    
    // Test whether the correct amount $ subtracted from balance
    [TestMethod]        
    public void ValidWithdrawal()
    {       
       BankAccount account = new("Test User", testBalance);
       account.Withdraw(testMoney);
       int correctBalance = testBalance - testMoney;
       assert.AreEqual(account.balance, correctBalance);
    }
    
    // Test whether user can withdrawn more money than they have
    [TestMethod]
    public void InvalidWithdrawal()
    {
        BankAccount account = new("Test user", testBalance);
        account.Withdraw(testBalance + testMoney);
        assert.AreEqual(account.balance, testBalance);
    }

    // Test whether the correct amount $ added to balance 
    [TestMethod]
    public void ValidDeposit()
    {
        BankAccount account = new("Test user", testBalance);
        account.Deposit(testMoney);
        int correctBalance = testBalance + testMoney;
        assert.AreEqual(account.balance, correctBalance);
    }
    
    // Test should not be able to deposit negative amount
    [TestMethod]
    public void InvalidDeposit()
    {
        BankAccount account = new("Test user", testBalance);
        account.Deposit(-testMoney);
        assertAreEqual(account.balanace, testBalance);
    }

    // FAIL - User has negative opening balanance
    [TestMethod]
    public void InvalidOpeningBalance)
    {
        BankAccount account = new("Test user", -testBalance);
        assertAreEqual(account.balance, 0);
    }

}
