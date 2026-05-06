namespace BankingApplication.Common.Tests;

public class CustomerServiceTests
{
    [Fact]
    public void MakeCustomerVip_Should_Set_IsVip_To_True_For_Eligible_Customer()
    {
        // Arrange
        var inMemoryCustomerRepository = new InMemoryCustomerRepository();
        var fileCustomerRepository = new FileCustomerRepository("D:\\Apps\\POC\\BankingApplication\\BankingApplication.Common\\customer.json");

        var customerService = new CustomerService(inMemoryCustomerRepository);
        var customerService2 = new CustomerService(fileCustomerRepository);

        // Act
        customerService.MakeCustomerVip(1);
        customerService2.MakeCustomerVip(1);
    }
}