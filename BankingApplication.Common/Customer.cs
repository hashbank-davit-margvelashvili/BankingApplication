using System.Text.Json;

namespace BankingApplication.Common;

public class Customer
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public DateTime BirthDate { get; set; }
    public bool IsVip { get; set; }
}

public interface ICustomerRepository
{
    Customer GetCustomerById(long id);

    void SaveCustomer(Customer customer);
}

public class InMemoryCustomerRepository : ICustomerRepository
{
    public Customer GetCustomerById(long id)
    {
        return new Customer
        {
            Id = id,
            Name = "John",
            Surname = "Doe",
            BirthDate = new DateTime(1990, 1, 1),
            IsVip = false
        };
    }

    public void SaveCustomer(Customer customer)
    {
    }
}

public class FileCustomerRepository : ICustomerRepository
{
    private readonly string _filePath;

    public FileCustomerRepository(string filePath)
    {
        _filePath = filePath;
    }

    public Customer GetCustomerById(long id)
    {
        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<Customer>(json);
    }

    public void SaveCustomer(Customer customer)
    {
        var json = JsonSerializer.Serialize(customer);
        File.WriteAllText(_filePath, json);
    }
}

public class CustomerService
{
    private ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public void MakeCustomerVip(long id)
    {
        var customer = _customerRepository.GetCustomerById(id);

        if (!customer.IsVip && DateTime.Now.Subtract(customer.BirthDate).TotalDays / 365 > 18)
        {
            customer.IsVip = true;
        }

        _customerRepository.SaveCustomer(customer);
    }
}