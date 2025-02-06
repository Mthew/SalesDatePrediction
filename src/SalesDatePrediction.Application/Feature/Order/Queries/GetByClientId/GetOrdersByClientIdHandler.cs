using AutoMapper;
using MediatR;
using SalesDatePrediction.Application.Contracts.Persistence;
using SalesDatePrediction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Application.Feature.Order.Queries.GetByClientId
{
    public class GetOrdersByClientIdHandler : IRequestHandler<GetOrdersByClientIdQuery, List<GetOrdersByClientIdMV>>
    {

        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByClientIdHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<GetOrdersByClientIdMV>> Handle(GetOrdersByClientIdQuery request, CancellationToken cancellationToken)
        {
            var ordersByCustomer = await _orderRepository.GetByCustomerId(request.ClientId);
            return _mapper.Map<List<GetOrdersByClientIdMV>>(ordersByCustomer);
        }
    }
}
