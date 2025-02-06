using SalesDatePrediction.Application.Contracts.Persistence;
using SalesDatePrediction.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesDatePrediction.Infrastructure.Repositories
{
    public class OrderRepository: AsyncRepository<Domain.Order>, IOrderRepository
    {
        private new readonly StoreSampleContext _context;

        public OrderRepository(StoreSampleContext context) : base(context)
        {
            _context = context;
        }

        public Task<List<Order>> GetByCustomerId(int customerId)
        {
            return Task.FromResult(_context.Orders
                .Where(x => x.Custid == customerId).ToList());
        }
    }
}
