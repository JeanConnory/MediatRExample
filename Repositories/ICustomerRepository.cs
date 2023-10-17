using MediatRExample.Models;

namespace MediatRExample.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomer(Guid customerId);

        Task<Guid> CreateCustomer(Customer customer);
    }
}
