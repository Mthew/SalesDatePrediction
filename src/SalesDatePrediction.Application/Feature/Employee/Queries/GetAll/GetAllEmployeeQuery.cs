using MediatR;

namespace SalesDatePrediction.Application.Feature.Employee.Queries.GetAll
{
    public class GetAllEmployeeQuery : IRequest<List<GetAllEmployeeVM>>
    {
        public GetAllEmployeeQuery()
        {
     
        }
    }
}
