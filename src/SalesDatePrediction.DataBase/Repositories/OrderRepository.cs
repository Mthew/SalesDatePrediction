using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Contracts.Persistence;
using SalesDatePrediction.Domain;

namespace SalesDatePrediction.Infrastructure.Repositories
{
    public class OrderRepository: AsyncRepository<Domain.Order>, IOrderRepository
    {
        private new readonly StoreSampleContext _context;

        public OrderRepository(StoreSampleContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Order>> GetByCustomerId(int customerId) => Task.FromResult(_context.Orders
                .Where(x => x.Custid == customerId).ToList());

        public async Task<List<SaleDatePredictionList>> GetSaleDatePredictions() =>
             await _context.SaleDatePredictionLists.FromSqlRaw($"[dbo].[sp_GetSalesDatePrediction]").ToListAsync();
    }
}
