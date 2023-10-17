using MediatR;
using MediatRExample.Models;

namespace MediatRExample.Handlers.Requests
{
    public class GetCustomerRequest : IRequest<Customer> //Retorno
    {
        public Guid CustomerId { get; set; } //Parametro
    }
}
