using System.Collections;
using SalesDatePrediction.Application.Contracts.Persistence;

namespace SalesDatePrediction.Infrastructure.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable? _repositories;
        private readonly StoreSampleContext _context;

        public UnitOfWork(StoreSampleContext context)
        {
            _context = context;
        }

        public async Task<int> Complete()
        {
            int result = 0;
            using var dbContextTransaction = _context.Database.BeginTransaction();
            try
            {
                result = await _context.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();

            }
            catch (Exception)
            {
                dbContextTransaction.Rollback();
            }
            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                Type reporitoryType = typeof(AsyncRepository<>);
                var repositoryInstance = Activator.CreateInstance(reporitoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (IAsyncRepository<TEntity>)_repositories[type]!;
        }
    }
}
