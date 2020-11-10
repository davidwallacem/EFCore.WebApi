using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Infra.Repositorys
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly HeroiContext context;

        protected DbSet<T> Query { get; set; }

        public Repository(HeroiContext context)
        {
            this.context = context;
            Query = context.Set<T>();
        }

        #region Métodos

        public DbContext GetContext() 
            => context;

        public T Add(T entity) 
            => Query.Add(entity).Entity;

        public void Update(T entity)
            => context.Entry(entity).State = EntityState.Modified;

        public T Remove(T entity) 
            => Query.Remove(entity).Entity;

        public T GetById(int id) 
            => Query.Find(id);

        public T GetBy(Expression<Func<T, bool>> predicate) 
            => Query.Find(predicate);

        public T GetAsNoTracking(Expression<Func<T, bool>> predicate) 
            => Query.AsNoTracking().FirstOrDefault(predicate);

        public IEnumerable<T> GetList()
            => Query;

        public IEnumerable<T> GetListBy(Expression<Func<T, bool>> predicate) 
            => Query.Where(predicate);

        public bool Exist(Expression<Func<T, bool>> predicate)
        {
            return Query.Where(predicate).Any();
        }

        public long Count()
        {
            return Query.Count();
        }

        public long CountBy(Expression<Func<T, bool>> predicate)
        {
            return Query.Where(predicate).Count();
        }

        public bool SaveChanges() 
            => (context.SaveChanges()) > 0;

        #endregion

        #region Métodos Asincronas


        public async Task<T> GetByIdAsync(int id) 
            => await Query.FindAsync(id);

        public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate) 
            => await Query.FindAsync(predicate);

        public async Task<T> GetAsNoTrackingAsync(Expression<Func<T, bool>> predicate) 
            => await Query.AsNoTracking().FirstOrDefaultAsync(predicate);

        public async Task<IEnumerable<T>> GetListAsync()
            => await Query.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetListByAsync(Expression<Func<T, bool>> predicate)
            => await Query.Where(predicate).AsNoTracking().ToListAsync();

        public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
        {
            return await Query.Where(predicate).AsNoTracking().AnyAsync();
        }

        public async Task<long> CountAsync()
        {
            return await Query.AsNoTracking().CountAsync();
        }

        public async Task<long> CountByAsync(Expression<Func<T, bool>> predicate)
        {
            return await Query.Where(predicate).AsNoTracking().CountAsync();
        }

        public async Task<bool> SaveChangesAsync() 
            => (await context.SaveChangesAsync()) > 0;
        
        #endregion

        public void Dispose()
        {
            Query = null;
            GC.SuppressFinalize(this);
        }
    }
}
