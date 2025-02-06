using AutoMapper;
using MediatR;
using SalesDatePrediction.Application.Contracts.Persistence;

namespace SalesDatePrediction.Application.Feature.Shipper.Queries.GetAll
{
    public class GetAllShipperHandler : IRequestHandler<GetAllShipperQuery, List<GetAllShipperVM>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllShipperHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllShipperVM>> Handle(GetAllShipperQuery request, CancellationToken cancellationToken)
        {
            var records = await _unitOfWork.Repository<Domain.Shipper>().GetAllAsync();
            return _mapper.Map<List<GetAllShipperVM>>(records);
        }
    }
}