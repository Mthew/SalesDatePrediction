namespace SalesDatePrediction.Domain;

public partial class SaleDatePredictionList
{
    public SaleDatePredictionList() { }
    public int Custid { get; set; }
    public string CustomerName { get; set; }
    public DateTime LastOrderDate { get; set; }
    public DateTime NextPredictedOrder { get; set; }
}
