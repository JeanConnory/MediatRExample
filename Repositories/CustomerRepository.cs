using MediatRExample.Models;

namespace MediatRExample.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<Customer> GetCustomer(Guid customerId)
        {
            Customer customer = new Customer
            {
                CustomerId = customerId,
                Name = "Jean Michael"
            };
            return customer;
        }

        public async Task<Guid> CreateCustomer(Customer customer)
        {
            return Guid.NewGuid();
        }
    }
}
