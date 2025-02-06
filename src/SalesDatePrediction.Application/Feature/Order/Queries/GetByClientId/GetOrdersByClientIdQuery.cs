using MediatR;

namespace SalesDatePrediction.Application.Feature.Order.Queries.GetByClientId
{
    public class GetOrdersByClientIdQuery : IRequest<List<GetOrdersByClientIdMV>>
    {
        public int ClientId { get; set; }

        public GetOrdersByClientIdQuery(int clienteId)
        {
            ClientId = clienteId;
        }
    }
}
