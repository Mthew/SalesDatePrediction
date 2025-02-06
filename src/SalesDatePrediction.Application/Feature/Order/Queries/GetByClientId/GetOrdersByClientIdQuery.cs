using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
