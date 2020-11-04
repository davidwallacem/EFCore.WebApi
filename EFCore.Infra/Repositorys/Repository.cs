using EFCore.Infra.Data.Configuration;
using EFCore.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public DbContext GetContext() => context;

        public T Add(T entity) => Query.Add(entity).Entity;

        public void Update(T entity) => context.Entry(entity).State = EntityState.Modified;

        public T Delete(T entity) => Query.Remove(entity).Entity;

        public virtual T FindById(int id) => Query.Find(id);

        public virtual T FindBy(Expression<Func<T, bool>> predicate) => Query.Find(predicate);

        public virtual T Tracking(Expression<Func<T, bool>> predicate) => Query.AsNoTracking().FirstOrDefault(predicate);

        public virtual IQueryable<T> GetAll() => Query;

        public virtual IQueryable<T> GetBy(Expression<Func<T, bool>> predicate) => Query.Where(predicate);

        public bool SaveChanges() => (context.SaveChanges()) > 0;

        #endregion

        #region Métodos Asincronas

        public async Task<T> FindAsyncById(int id) => await Query.FindAsync(id);

        public async Task<T> FindAsyncBy(Expression<Func<T, bool>> predicate) => await Query.FindAsync(predicate);

        public virtual async Task<T> TrackingAsync(Expression<Func<T, bool>> predicate) => await Query.AsNoTracking().FirstOrDefaultAsync(predicate);

        public async Task<bool> SaveChangesAsync() => (await context.SaveChangesAsync()) > 0;
        
        #endregion

        public void Dispose()
        {
            Query = null;
            GC.SuppressFinalize(this);
        }
    }
}
