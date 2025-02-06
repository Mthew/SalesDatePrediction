using MediatR;

namespace SalesDatePrediction.Application.Feature.Order.Commands.Create
{
    public class CreateOrderWithDetailsCommand : IRequest<int>
    {
        public int Empid { get; set; }
        public int Shipperid { get; set; }
        public string Shipname { get; set; }
        public string Shipaddress { get; set; }
        public string Shipcity { get; set; }
        public DateTime Orderdate { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime Shippeddate { get; set; }
        public decimal Freight { get; set; }
        public string Shipcountry { get; set; }
        public string DetailsJson { get; set; }
    }
}
