
***
#### **Activity One:**

1. Why does regular committing support software quality?
	
	It means that if something goes wrong and you need to rollback a version you won't be losing as much progress, as there would be a more recent version to rollback to.
	
2. How can Git history provide evidence of individual progress?
	
	Git history shows who committed something, when and what changed, therefore you can see a particular persons contributions to a project.  

***
#### **Activity Two:**

`See Repo for Code`

***
#### **Activity Three:**

1. What happens if the opening balance is negative?

	If the balance is negative then anything added to it will have to be greater than the negative opening value to break even.  
	
	If negatives balances are not allowed then this could break the Functional Suitability characteristic from the ISO Quality Model, as the system is allowing an invalid account state.  

2. What happens if a deposit amount is negative

	If the deposit amount is negative value then it is withdrawn from the balance instead of adding money.  This violates the Functional Suitability characteristic from the ISO Quality Model, as the intended outcome of this function is to add money to the account.  
		

3. What happens if a withdrawal amount is greater than the balance?

	If the withdrawal amount is greater than the balance then the balance goes to a negative balance.  Which would also violate the Functional Suitability characteristic as typically in a bank you can't withdraw more money than you have.  It also becomes a security risk if someone is able to take out more money than they own.  

4. Is the transaction fee calculation clearly documented?

	No there a no comments, but it is a very simple class and the name clearly explains what it does "CalculateTransactionFee()".
	
	If this functional was more complex then in order to meet the Maintainability characteristic it would need comments make it easier to understand for new developers coming into the project. 

5. Is the class easy to test?
 
	Yes as it it is all numeric values and the classes a fairly simple, it should be easy to test.


6. What functional requirements are missing?

	- The system must be able to display a users' current balance
	- The system must be able to display a users' all past transactions
	- The system must allow users to setup automatic payments
	- The system must prevent an opening balance being negative
	- The system must prevent users' from withdrawing more money they have
	- The system must prevent deposits of a negative amount of money

	
7. What non-functional quality attributes are relevant?
	- The system must provide an intuitive and easy to use GUI for users to interact with (Usability)
	- The system must prevent unwanted access to accounts (Security)
	- The system must be compatible with a range of devices & operating systems (Compatibility & Portability)
	- The system must be able to perform essential tasks such as (deposits, withdrawals, interest calculations, etc) without failure (Reliability)
	- The system must be able to process a deposit/withdrawal in less than 5 seconds (Performance Efficiency)

***

#### **Activity Four:**

###### **QA vs QC**
Quality Assurance (QA) is process-oriented process that focuses on preventing issues before they occur.  Whereas Quality Control (QC) is a product-oriented process that focuses on identifying issues currently in a software product.

1. Writing coding standards for money calculations

	This is an example of QA this creates a precedent for maintainability by having a set standard that everyone understands and adheres to when writing code for money calculations.  
	
2. Running unit tests for withdrawal behaviour

	This is an example of QC as this would be done after the code for withdrawal has be written to ensure that it functions correctly.

3. Reviewing requirements for ambiguity
	
	This is an example of QA as this will help to prevent future incidents by ensuring that the requirements are clear and won't be misinterpreted.

4. Analysing repeated transaction defects

	This example is QA as the issue has already occurred and we are trying to identify the transaction defects to prevent them from reoccurring.    

5. Reporting a failed test case

	This is an example of QC as the failed test reveals a current problem in the software.  

6. Creating a checklist for financial validation rules

	This is an example of QA as it helps to prevent mistakes from by creating quality standards for someone to follow after creating something financially related.

7. Retesting after fixing withdrawal logic

	This is an example of QC as the software is being tested after a change has been made to ensure that the issue has been fixed correctly.

***
#### **Activity Five:**

Test Cases:

Valid: Withdrawal: The amount of money withdrawn should correctly subtracted from the users' balance
Invalid: Withdrawal - User should not be able to withdrawal more money than they have in there account
Valid: Deposit - The amount of money deposited should be correctly added to users' balance
Invalid: Deposit - User should not be able to deposit a negative amount of money
Invalid: Opening Balance - User should not be able to have a starting balance of a negative value

***
#### **Activity Six:**

Test Cases:

**``BankAccountTests.cs``**
```cs
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
        account.Withdraw(testMoney);
        int correctBalance = testBalance - testMoney;
        Assert.AreEqual(account.Balance, correctBalance);
    }

    // Test whether user can withdrawn more money than they have
    [TestMethod]
    public void InvalidWithdrawal()
    {
        BankAccount account = new("Test user", testBalance);
        account.Withdraw(testBalance + testMoney);
        Assert.AreEqual(account.Balance, testBalance);
    }

    // Test whether the correct amount $ added to balance
    [TestMethod]
    public void ValidDeposit()
    {
        BankAccount account = new("Test user", testBalance);
        account.Deposit(testMoney);
        int correctBalance = testBalance + testMoney;
        Assert.AreEqual(account.Balance, correctBalance);
    }

    // Test should not be able to deposit negative amount
    [TestMethod]
    public void InvalidDeposit()
    {
        BankAccount account = new("Test user", testBalance);
        account.Deposit(-testMoney);
        Assert.AreEqual(account.Balance, testBalance);
    }

    // FAIL - User has negative opening balanance
    [TestMethod]
    public void InvalidOpeningBalance()
    {
        BankAccount account = new("Test user", -testBalance);
        Assert.AreEqual(account.Balance, 0);
    }

}
```

***
#### **Activity Seven**

Improving the code to pass the test cases
Also had to adjust test cases as I wanted to try multiple ways of testing
- True/False
- Catching an Argument Exception

**These improved these changes improved the Quality Attributes:**
- Reliability - Code is less likely to fail as errors are caught or will prevent the code from failing.
- Security - Cannot withdraw more money than you own or deposit negative amounts. 
- Maintainability - The test class allows for my tests cases to be added easily in future.

**`BankAccount.cs`**
```cs
public class BankAccount
{

    public string AccountHolder { get; set; }
    public decimal Balance { get; private set; }


    public BankAccount(String accountHolder, decimal openingBalance)
    {
        if(openingBalance < 0){
            throw new ArgumentException("Starting balance must be positive");
        }

        AccountHolder = accountHolder;
        Balance = openingBalance;
    }

    public bool Deposit(decimal amount)
    {
        if(amount <= 0) {
            return false;
        }

        Balance += amount;
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if(amount > Balance || amount <= 0) {
            return false;
        }

        Balance -= amount;
        return true;
    }

    public decimal CalculateTransactionFee(decimal amount)
    {
        return amount * 0.02m;
    }
}
```

**``BankAccountTests.cs``**
```cs
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
```

***
#### **Activity Eight:**

`Have six test cases in total`

***

#### **Activity Nine:**

1. Who are the stakeholders for this small banking system
	Customers
	Bank Employees
	Bank Managers
	IT Team/Software Engineers at the Bank
	
2. What does quality mean to each stakeholder
	**Customer:** Having there money secure, easy to access and tasks such as withdrawals and deposits to be completed without error.  
	
	**Bank Employees:** Being able to lookup and check customer details and transactions
	
	**Bank Managers:** Want to see an overview and statistics to make important decisions.  

	**Software Engineers:** Want the code to be maintainable, compatible, and understandable, to make it easy to make updates.  

3. Which defects were detected during testing
	- The opening balance could be negative
	- Customers could withdraw more money than they had
	- Customers could deposit negative amounts of money or 0
	- Customers could withdraw nothing

4. Which defects could have been prevented through QA activities

	By having a detailed requirements and test cases setup up earlier, it would have been easier to prevent all of the defects from occurring.    

5. How did Copilot help?
	- It helped teach me how to setup my repo, csproj files and linking my test project
	- Gave me a syntax guide for writing MSTests.

6. What Copilot suggestion did you reject or modify, and why?

	I decided to come up with my own test cases, as find that I don't learn as well if I am given the answers.  

7. What is the difference between QA and QC in this lab?

	QA are methods you put in place to prevent defects from occurring, while QC focuses on what to if there are existing defects and how to deal with them.    

	This lab focused more on QC but by adding test cases it sets a precedent for QA as now all the code in future must meet those standards.

***
