namespace SalesDatePrediction.Application.Feature.Employee.Queries.GetAll
{
    public class GetAllEmployeeVM
    {
        public int Empid { get; set; }
        public string Lastname { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string FullName => $"{this.Firstname} {this.Lastname}";
    }
}
