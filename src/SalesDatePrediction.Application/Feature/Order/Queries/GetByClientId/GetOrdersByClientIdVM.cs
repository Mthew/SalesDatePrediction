namespace SalesDatePrediction.Application.Feature.Order.Queries.GetByClientId
{
    public class GetOrdersByClientIdMV
    {
        public int Orderid { get; set; }
        public DateTime Requireddate { get; set; }
        public DateTime? Shippeddate { get; set; }
        public string Shipname { get; set; } = null!;
        public string Shipaddress { get; set; } = null!;
        public string Shipcity { get; set; } = null!;
    }
}
