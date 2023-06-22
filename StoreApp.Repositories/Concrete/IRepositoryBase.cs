namespace StoreApp.Repositories
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool asNoTracking);
    }
}