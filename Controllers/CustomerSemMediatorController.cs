using MediatRExample.Models;
using MediatRExample.Repositories;
using MediatRExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediatRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSemMediatorController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidationService _validaService;

        public CustomerSemMediatorController(ICustomerRepository customerRepository, IValidationService validaService)
        {
            _customerRepository = customerRepository;
            _validaService = validaService;
        }

        [HttpGet("get-customer/{customerId:Guid}")]
        public async Task<Customer> GetCustomer(Guid customerId)
        {
            _validaService.Validate(customerId);
            return await _customerRepository.GetCustomer(customerId);
        }

        [HttpPost("create-customer")]
        public async Task<Guid> CreateCustomer([FromBody] Customer newCustomer)
        {
            _validaService.Validate<Customer>(newCustomer);

            var customer = new Customer
            {
                Name = newCustomer.Name,
            };

            return await _customerRepository.CreateCustomer(customer);
        }
    }
}
