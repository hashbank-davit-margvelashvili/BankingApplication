namespace BankingApplication.Common.Tests;

public class FinancialProductTests
{
    [Fact]
    public void FinancialProductCreate()
    {
        var depositAccount = new DepositAccount
        {
            CCY = "USD",
            MaturityDate = DateTime.Now.AddYears(1),
            InterestRate = 2.5m,
            CustomerId = 10,
            Id = 2,
        };

        LoanAccount loanAccount = new LoanAccount
        {
            CCY = "USD",
            RemainingDebt = 10000,
            InterestRate = 5.5m,
            CustomerId = 10,
            Id = 1
        };

        FinancialProduct product = loanAccount;

        var depoText = depositAccount.Display();
        var loanText = loanAccount.Display();

        Print(depositAccount);
        Print(loanAccount);

        FindObject("5678");
    }

    public void Print(FinancialProduct product)
    {
        var text = product.Display();
        Console.WriteLine(text);
    }

    public int FindObject(string id)
    {
        if (id == "1234")
        {
            return 10;
        }

        throw new ObjectNotFoundException(id);
    }
}

public class DomainException : Exception
{
    public DomainException(string message) : base(message)
    {
    }
}

public class ObjectNotFoundException : DomainException
{
    public ObjectNotFoundException(string id) : base($"Object with ID {id} not found")
    {
    }
}