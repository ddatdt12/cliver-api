using System.Linq.Expressions;

namespace CliverApi.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll ();
        Task<T> FindById<TId>(TId id);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");
        Task<bool> Add(T entity);
        Task<bool> Upsert(T entity);
        Task<bool> Delete<TId>(TId id);
        void Delete(T entityToDelete);
    }
}
