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
}