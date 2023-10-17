using MediatR;
using MediatRExample.Handlers.Requests;
using MediatRExample.Models;
using MediatRExample.Repositories;
using MediatRExample.Services;

namespace MediatRExample.Handlers
{
    public class GetCustomerHandler : IRequestHandler<GetCustomerRequest, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidationService _validaService;

        public GetCustomerHandler(ICustomerRepository customerRepository, IValidationService validaService)
        {
            _customerRepository = customerRepository;
            _validaService = validaService;
        }

        public async Task<Customer> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            _validaService.Validate<Guid>(request.CustomerId);
            return await _customerRepository.GetCustomer(request.CustomerId);
        }
    }
}
