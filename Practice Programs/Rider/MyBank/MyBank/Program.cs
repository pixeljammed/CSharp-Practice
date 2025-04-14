namespace MyBank;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account1 = new BankAccount("SAM", 1, 5.50);
        Console.WriteLine(account1.ToString());
    }
}