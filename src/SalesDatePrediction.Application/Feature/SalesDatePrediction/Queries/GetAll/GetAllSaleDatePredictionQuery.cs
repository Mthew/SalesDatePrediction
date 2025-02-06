using MediatR;

namespace SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll
{
    public class GetAllSalesDatePredictionQuery : IRequest<List<GetAllSalesDatePredictionMV>>
    {
        public GetAllSalesDatePredictionQuery()
        {
        }
    }
}
