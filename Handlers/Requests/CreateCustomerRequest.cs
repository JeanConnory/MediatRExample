using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Handlers.Requests
{
    public class CreateCustomerRequest : IRequest<Guid> //Retorno
    {
        public Customer? Customer { get; set; } //Parametro
    }
}
