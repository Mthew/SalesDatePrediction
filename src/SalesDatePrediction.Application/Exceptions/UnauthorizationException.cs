namespace SalesDatePrediction.Application.Exceptions
{
    public class UnauthorizationException : ApplicationException
    {
        public UnauthorizationException(string? message) : base(message)
        {
        }
    }
}
