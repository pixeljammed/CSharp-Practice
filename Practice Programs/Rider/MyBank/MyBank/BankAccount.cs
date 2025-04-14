namespace MyBank;

public class BankAccount
{
    private string accountHolder;
    private int accountNumber;
    protected double accountBalance;

    public BankAccount(string holder, int number, double balance)
    {
        accountHolder = holder;
        accountNumber = number;
        accountBalance = balance;
    }

    public void Deposit(double amount)
    {
        accountBalance += amount;
    }

    public virtual void Withdraw(double amount)
    {
        accountBalance -= amount;
    }

    public double GetBalance()
    {
        return accountBalance;
    }

    public int GetAccountNumber()
    {
        return accountNumber;
    }

    public string GetAccountHolder()
    {
        return accountHolder;
    }

    public override string ToString()
    {
        return $"Account Number: {accountNumber} \tAccount Holder: {accountHolder} \tBalance: {accountBalance}";
    }
}