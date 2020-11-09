using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        T Remove(T entity);

        T GetById(int id);

        T GetBy(Expression<Func<T, bool>> predicate);

        T GetAsNoTracking(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetList();

        IEnumerable<T> GetListBy(Expression<Func<T, bool>> predicate);

        bool Exist(Expression<Func<T, bool>> predicate);

        long Count();

        long CountBy(Expression<Func<T, bool>> predicate);

        bool SaveChanges();

        #endregion

        #region Assinaturas dos Métodos Asincronas

        Task<T> GetByIdAsync(int id);

        Task<T> GetByAsync(Expression<Func<T, bool>> predicate);

        Task<T> GetAsNoTrackingAsync(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetListAsync();

        Task<IEnumerable<T>> GetListByAsync(Expression<Func<T, bool>> predicate);

        Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);

        Task<long> CountAsync();

        Task<long> CountByAsync(Expression<Func<T, bool>> predicate);

        Task<bool> SaveChangesAsync();

        #endregion
    }
}
