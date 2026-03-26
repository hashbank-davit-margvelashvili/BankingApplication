using BankingApplication.Common;

namespace BankingApplication;

public static class AccountViewer
{
    public static void PrintAccount(Account account)
    {
        Console.WriteLine("=== HSP Account Viewer ===");

        Console.WriteLine($"  Account: {account.AccountNumber}");
        Console.WriteLine($"  Balance: {account.Balance:N2} {account.Currency}");
        Console.WriteLine($"  Status:  {(account.IsActive ? "Active" : "Inactive")}");
    }
}