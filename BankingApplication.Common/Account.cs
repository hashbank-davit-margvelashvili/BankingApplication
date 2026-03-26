namespace BankingApplication.Common;

public class Account
{
    private static int _nextId = 1;

    public int Id { get; private set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; private set; }
    public string Currency { get; private set; }
    public bool IsActive { get; private set; }

    public Account()
    {
        Id = _nextId;
        _nextId += 1;
        Currency = "GEL";
    }

    public void Debit(decimal amount)
    {
        if (amount > Balance)
            throw new Exception("Insufficient funds");

        Balance -= amount;
    }

    public void Credit(decimal amount)
    {
        Balance += amount;
    }
}