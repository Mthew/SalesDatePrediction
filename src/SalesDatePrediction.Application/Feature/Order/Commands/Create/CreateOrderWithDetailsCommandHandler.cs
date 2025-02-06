using AutoMapper;
using MediatR;
using SalesDatePrediction.Application.Contracts.Persistence;

namespace SalesDatePrediction.Application.Feature.Order.Commands.Create
{
    public class CreateOrderWithDetailsCommandHandler : IRequestHandler<CreateOrderWithDetailsCommand, int>
    {

        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderWithDetailsCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderWithDetailsCommand request, CancellationToken cancellationToken) =>
            await _orderRepository.CreateOrderWithDeatils(request);
    }
}
