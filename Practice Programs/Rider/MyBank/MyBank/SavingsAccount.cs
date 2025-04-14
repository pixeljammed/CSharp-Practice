namespace MyBank;

public class SavingsAccount : BankAccount
{
    private double interest;

    public SavingsAccount(string holder, int number, double balance, double interest) : base(holder, number, balance)
    {
        this.interest = interest;
        Console.WriteLine("Savings account created!");
    }

    public override void Withdraw(double amount)
    {
        if (amount > accountBalance)
        {
            Console.WriteLine("Withdraw not allowed - you are withdrawing more than your current balance");
        }
        else
        {
            accountBalance -= amount;
        }
    }

    public void ApplyInetrest()
    {
        accountBalance = accountBalance * interest / 100;
    }

    public override string ToString()
    {
        return base.ToString() + $"Interest: (interest)";
    }
}