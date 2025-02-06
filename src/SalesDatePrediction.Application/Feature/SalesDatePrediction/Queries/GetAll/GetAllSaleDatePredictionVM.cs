using MediatR;
using SalesDatePrediction.Domain;
using System;
namespace SalesDatePrediction.Application.Feature.SalesDatePrediction.Queries.GetAll
{
    public class GetAllSalesDatePredictionMV
    {        
        public int Custid { get; set; }
        public string CustomerName { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextPredictedOrder { get; set; }
    }
}
