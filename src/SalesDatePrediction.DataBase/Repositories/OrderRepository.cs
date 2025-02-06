using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SalesDatePrediction.Application.Contracts.Persistence;
using SalesDatePrediction.Application.Feature.Order.Commands.Create;
using SalesDatePrediction.Domain;
using System.Data;

namespace SalesDatePrediction.Infrastructure.Repositories
{
    public class OrderRepository : AsyncRepository<Domain.Order>, IOrderRepository
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

        public async Task<int> CreateOrderWithDeatils(CreateOrderWithDetailsCommand command)
        {
            return await _context.Database.ExecuteSqlRawAsync($"exec [dbo].[sp_AddOrderWithDetails]   @Empid=@p1,  @Shipperid=@p2,  @Shipname=@p3,  @Shipaddress=@p4,  @Shipcity=@p5,  @Orderdate=@p6,  @Requireddate=@p7,  @Shippeddate=@p8,  @Freight=@p9,  @Shipcountry=@p10,  @DetailsJson=  @p11;", new SqlParameter[] {
                    new SqlParameter("@p1", SqlDbType.Int) { Value = command.Empid },
                    new SqlParameter("@p2", SqlDbType.Int) { Value = command.Shipperid },
                    new SqlParameter("@p3", SqlDbType.NVarChar, 80) { Value = command.Shipname },
                    new SqlParameter("@p4", SqlDbType.NVarChar, 120) { Value = command.Shipaddress },
                    new SqlParameter("@p5", SqlDbType.NVarChar, 30) { Value = command.Shipcity },
                    new SqlParameter("@p6", SqlDbType.DateTime) { Value = command.Orderdate },
                    new SqlParameter("@p7", SqlDbType.DateTime) { Value = command.Requireddate },
                    new SqlParameter("@p8", SqlDbType.DateTime) { Value = command.Shippeddate },
                    new SqlParameter("@p9", SqlDbType.Money) { Value = command.Freight },
                    new SqlParameter("@p10", SqlDbType.NVarChar, 30) { Value = command.Shipcountry },
                    new SqlParameter("@p11", SqlDbType.NVarChar, -1) { Value = command.DetailsJson }
                });
        }
    }
}
