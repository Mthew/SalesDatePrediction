using MediatR;

namespace SalesDatePrediction.Application.Feature.Shipper.Queries.GetAll
{
    public class GetAllShipperQuery : IRequest<List<GetAllShipperVM>>
    {
        public GetAllShipperQuery()
        {
     
        }
    }
}