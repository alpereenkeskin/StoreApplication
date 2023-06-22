using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
namespace StoreApp.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T>
    where T : class, new()
    {
        protected readonly RepositoryDbContext _context;

        public RepositoryBase(RepositoryDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll(bool asNoTracking)
        {
            return asNoTracking ?
            _context.Set<T>() :
            _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool asNoTracking)
        {
            return asNoTracking ?
            _context.Set<T>().Where(expression).FirstOrDefault()
            :
            _context.Set<T>().Where(expression).AsNoTracking().FirstOrDefault();
        }
    }

}