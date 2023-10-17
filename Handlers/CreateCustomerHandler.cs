using MediatR;
using MediatRExample.Handlers.Requests;
using MediatRExample.Models;
using MediatRExample.Repositories;
using MediatRExample.Services;

namespace MediatRExample.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, Guid>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidationService _validaService;

        public CreateCustomerHandler(ICustomerRepository customerRepository, IValidationService validaService)
        {
            _customerRepository = customerRepository;
            _validaService = validaService;
        }

        public async Task<Guid> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            _validaService.Validate<Customer>(request.Customer);
            return await _customerRepository.CreateCustomer(request.Customer);
        }
    }
}
