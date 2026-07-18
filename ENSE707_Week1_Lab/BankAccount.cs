namespace ENSE707_Week1_Lab;

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
