using AutoMapper;
using MediatR;
using SalesDatePrediction.Application.Contracts.Persistence;

namespace SalesDatePrediction.Application.Feature.Product.Queries.GetAll
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductQuery, List<GetAllProductVM>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllProductHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllProductVM>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var records = await _unitOfWork.Repository<Domain.Product>().GetAllAsync();
            return _mapper.Map<List<GetAllProductVM>>(records);
        }
    }
}