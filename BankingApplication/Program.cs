// See https://aka.ms/new-console-template for more information

using BankingApplication;
using BankingApplication.Common;

// row 1
var myAccount = new Account()
{
    AccountNumber = "GE01HS0101010101"
};

// row 2
var myAccount2 = new Account
{
    AccountNumber = "GE01HS1010101010"
};

myAccount.Credit(50);
AccountViewer.PrintAccount(myAccount);

myAccount.Credit(60);
AccountViewer.PrintAccount(myAccount);

myAccount.Debit(100);
AccountViewer.PrintAccount(myAccount);