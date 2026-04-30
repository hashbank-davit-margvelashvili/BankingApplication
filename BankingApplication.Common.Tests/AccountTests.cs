namespace BankingApplication.Common.Tests;

public class AccountTests
{
    [Fact]
    public void Debit_WhenAmountIsValid_ShouldDecreaseBalance()
    {
        // Arrange
        var myAccount = new Account
        {
            AccountNumber = "GE01HS0101010101",
        };
        myAccount.Credit(70);

        // Act
        myAccount.Debit(50);

        // Assert
        Assert.Equal(20, myAccount.Balance);
    }

    [Fact]
    public void Debit_WhenAmountIsLessThanBalance_Should()
    {
        // Arrange

        var myAccount = new Account
        {
            AccountNumber = "GE01HS0101010101",
        };

        // Act Assert
        var error = Assert.Throws<Exception>(() => myAccount.Debit(50));
        Assert.Equal("Insufficient funds", error.Message);
    }

    [Fact]
    public void Test()
    {
        if (int.TryParse("0", out var number))
        {
            Assert.Equal(30, number);
        }
    }

    private void Add10(string numberText, out int number)
    {
        if (numberText.All(char.IsDigit))
            number = int.Parse(numberText);

        number = 0;
    }

    [Fact]
    public void AccountTest()
    {
        Function();

        var salaries = new decimal[1000];

        for (int i = 0; i < salaries.Length; i++)
        {
            salaries[i] = i * 1000;
        }
    }

    private void Function()
    {
        var account = new Account
        {
            AccountNumber = "1234"
        };

        var account2 = account;

        account2.AccountNumber = "5678";

        IncreateAccountBalance(account, 100);
    }

    private void IncreateAccountBalance(Account account, decimal amount)
    {
        account.Balance += amount;

        account = new Account
        {
            AccountNumber = "7890",
        };
    }
}