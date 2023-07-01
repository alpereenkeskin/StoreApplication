using System.Linq.Expressions;
namespace StoreApp.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool asNoTracking);
        T? FindByCondition(Expression<Func<T, bool>> expression, bool asNoTracking);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}