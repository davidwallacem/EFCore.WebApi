using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EFCore.Infra.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        #region Assinaturas dos Métodos

        DbContext GetContext();
        T Add(T entity);
        void Update(T entity);
        T Delete(T entity);
        T FindById(int id);
        T FindBy(Expression<Func<T, bool>> predicate);
        T Tracking(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
        bool SaveChanges();

        #endregion


        #region Assinaturas dos Métodos Asincronas

        Task<T> FindAsyncById(int id);

        Task<T> FindAsyncBy(Expression<Func<T, bool>> predicate);

        Task<T> TrackingAsync(Expression<Func<T, bool>> predicate);

        Task<bool> SaveChangesAsync();

        #endregion
    }
}
