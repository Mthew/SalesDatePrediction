using SalesDatePrediction.Application.Feature.Order.Commands.Create;
using SalesDatePrediction.Domain;

namespace SalesDatePrediction.Application.Contracts.Persistence
{
    public interface  IOrderRepository: IAsyncRepository<Order>
    {
        Task<List<Order>> GetByCustomerId(int customerId);
        Task<List<SaleDatePredictionList>> GetSaleDatePredictions();
        Task<int> CreateOrderWithDeatils(CreateOrderWithDetailsCommand command);
    }
}
