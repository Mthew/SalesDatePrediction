using AutoMapper;
using MediatR;
using SalesDatePrediction.Application.Contracts.Persistence;
using SalesDatePrediction.Domain;

namespace SalesDatePrediction.Application.Feature.Employee.Queries.GetAll
{
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, List<GetAllEmployeeVM>>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllEmployeeHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<GetAllEmployeeVM>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
        {
            var records = await _unitOfWork.Repository<Domain.Employee>().GetAllAsync();
            return _mapper.Map<List<GetAllEmployeeVM>>(records);
        }
    }
}