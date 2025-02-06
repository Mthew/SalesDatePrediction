using AutoMapper;
using MediatR;
using SalesDatePrediction.Application.Contracts.Persistence;

namespace SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll
{
    public class GetOrdersByClientIdHandler : IRequestHandler<GetAllSalesDatePredictionQuery, List<GetAllSalesDatePredictionMV>>
    {

        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByClientIdHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<List<GetAllSalesDatePredictionMV>> Handle(GetAllSalesDatePredictionQuery request, CancellationToken cancellationToken)
        {
            var saleDatePrediction = await _orderRepository.GetSaleDatePredictions();
            return _mapper.Map<List<GetAllSalesDatePredictionMV>>(saleDatePrediction);
        }
    }
}
