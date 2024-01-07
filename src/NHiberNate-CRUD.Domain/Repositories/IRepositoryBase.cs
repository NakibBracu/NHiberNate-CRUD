using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHiberNate_CRUD.Domain.Entities;

namespace NHiberNate_CRUD.Domain.Repositories
{
    public interface IRepositoryBase<TEntity, TKey> where TEntity : class, IEntity<TKey> where TKey : IComparable
    {
        /*1*/
        void Add(TEntity entity);
        /*2*/
        Task AddAsync(TEntity entity);

        /*3*/
        void Edit(TEntity entityToUpdate);
        /*4*/
        Task EditAsync(TEntity entityToUpdate);

        /*5*/
        IList<TEntity> GetAll();
        /*6*/
        Task<IList<TEntity>> GetAllAsync();

        /*7*/
        TEntity GetById(TKey id);
        /*8*/
        Task<TEntity> GetByIdAsync(TKey id);

        /*9*/
        int GetCount(Expression<Func<TEntity, bool>> filter = null);
        /*10*/
        Task<int> GetCountAsync(Expression<Func<TEntity, bool>> filter = null);

        /*11*/
        void Remove(Expression<Func<TEntity, bool>> filter);
        /*12*/
        void Remove(TEntity entityToDelete);
        /*13*/
        void Remove(TKey id);
        /*14*/
        Task RemoveAsync(Expression<Func<TEntity, bool>> entityToDelete);
        /*15*/
        Task RemoveAsync(TEntity entityToDelete);
        /*16*/
        Task RemoveAsync(TKey id);
    }
}
