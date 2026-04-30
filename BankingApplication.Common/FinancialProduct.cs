namespace BankingApplication.Common;

public class FinancialProduct
{
    public long Id { get; set; }
    public int CustomerId { get; set; }
    public string CCY { get; set; }
    public decimal Balance { get; protected set; }
    public DateTime CreateTime { get; }

    public virtual string Display()
    {
        return $"ID: {Id}, Customer ID: {CustomerId}, CCY: {CCY}, Balance: {Balance}, Create Time: {CreateTime}";
    }
}

public class DepositAccount : FinancialProduct
{
    public decimal InterestRate { get; set; }
    public DateTime MaturityDate { get; set; }

    public override string Display()
    {
        if (InterestRate == 0 && MaturityDate == default)
        {
            return base.Display();
        }
        var baseText = base.Display();
        return baseText + $" Interest Rate: {InterestRate}, Maturity Date: {MaturityDate}";

        DataReader reader = new FileDataReader("D:\\Apps\\POC\\BankingApplication\\BankingApplication.Common.Tests\\FinancialProductTests.cs");
    }
}

public class LoanAccount : FinancialProduct
{
    public decimal InterestRate { get; set; }
    public decimal RemainingDebt { get; set; }

    public override string Display()
    {
        return base.Display() + $" Interest Rate: {InterestRate}, Remaining Debt: {RemainingDebt}";
    }
}

public abstract class DataReader
{
    public abstract byte[] ReadData();
}

public class FileDataReader : DataReader
{
    private string _path;

    public FileDataReader(string path)
    {
        _path = path;
    }

    public override byte[] ReadData()
    {
        return File.ReadAllBytes(_path);
    }
}

public class NetworkDataReader : DataReader
{
    public override byte[] ReadData()
    {
        throw new NotImplementedException();
    }
}