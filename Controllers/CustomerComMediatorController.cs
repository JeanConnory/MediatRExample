using MediatR;
using MediatRExample.Handlers.Requests;
using MediatRExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediatRExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerComMediatorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerComMediatorController(IMediator mediator) => _mediator = mediator; //Construtor

        [HttpGet("get-customer/{customerId:Guid}")]
        public async Task<Customer> GetCustomer(Guid customerId) =>
            await _mediator.Send(new GetCustomerRequest {  CustomerId = customerId });

        [HttpPost("create-customer")]
        public async Task<Guid> CreateCustomer(Customer customer) =>
            await _mediator.Send(new CreateCustomerRequest { Customer = customer });
    }
}
