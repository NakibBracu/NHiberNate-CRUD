using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHiberNate_CRUD.Domain.Entities;
using NHiberNate_CRUD.Domain.Repositories;

namespace NHiberNate_CRUD.Persistence
{
    public interface IRepository<TEntity, TKey> : IRepositoryBase<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IComparable
    {
        /*1*/
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
        /*2*/
        IList<TEntity> Get(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        /*3*/
        (IList<TEntity> data, int total, int totalDisplay) Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        /*4*/
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);
        /*5*/
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
        /*6*/
        Task<IEnumerable<TResult>> GetAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true, CancellationToken cancellationToken = default) where TResult : class;
        /*7*/
        Task<(IList<TEntity> data, int total, int totalDisplay)> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        /*8*/
        IList<TEntity> GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
        /*9*/
        (IList<TEntity> data, int total, int totalDisplay) GetDynamic(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        /*10*/
        Task<IList<TEntity>> GetDynamicAsync(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool isTrackingOff = false);
        /*11*/
        Task<(IList<TEntity> data, int total, int totalDisplay)> GetDynamicAsync(Expression<Func<TEntity, bool>> filter = null, string orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);

        /*12*/
        Task<TResult> SingleOrDefaultAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null, bool disableTracking = true);
    }
}
