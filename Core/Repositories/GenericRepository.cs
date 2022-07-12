using CliverApi.Core.IRepositories;
using CliverApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CliverApi.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>  where T : class
    {
        internal DataContext _context;
        internal DbSet<T> dbSet;
        public readonly ILogger _logger;
        public GenericRepository(DataContext context, ILogger logger)
        {
            _context = context;
            dbSet = context.Set<T>();
            _logger=logger;
        }


        public Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await dbSet.ToListAsync();
        }
        public virtual async Task<T> GetById<TId>(TId id)
        {
            return await dbSet.FindAsync(id);
        }


        public virtual async Task<IEnumerable<T>> Get(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual async Task<bool> Delete<TId>(TId id)
        {
            T? entityToDelete = await dbSet.FindAsync(id);
            if (entityToDelete != null)
            {
                Delete(entityToDelete);
            }
            return true;
        }

        public virtual void Delete(T entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public async virtual Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }
        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }


    }
}
