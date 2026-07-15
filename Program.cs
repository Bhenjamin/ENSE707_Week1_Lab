using ENSE707_Week1_Lab;

BankAccount account1 = new BankAccount("Student User", 100);

account1.Deposit(50);
account1.Withdraw(30);

Console.WriteLine($"Account Holder: {account1.AccountHolder}");
Console.WriteLine($"Current Balance: {account1.Balance}");
Console.WriteLine($"Fee on $100 transaction {account1.CalculateTransactionFee(100)}");

