using MediatR;

namespace SalesDatePrediction.Application.Feature.Product.Queries.GetAll
{
    public class GetAllProductQuery : IRequest<List<GetAllProductVM>>
    {
        public GetAllProductQuery()
        {
     
        }
    }
}