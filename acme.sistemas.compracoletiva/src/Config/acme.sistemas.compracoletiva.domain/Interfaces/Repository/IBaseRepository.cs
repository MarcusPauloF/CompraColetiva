using acme.sistemas.compracoletiva.domain.Entity;
using acme.sistemas.compracoletiva.core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace acme.sistemas.compracoletiva.domain.Interfaces.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        void AddMultiple(IEnumerable<TEntity> entities);
        Task AddMultipleAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveMultiple(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateMultiple(IEnumerable<TEntity> entities);
        Task<Entity> GetByIdAsync<Entity>(Guid id) where Entity : BaseEntity;
        Entity GetById<Entity>(Guid id) where Entity : BaseEntity;
        IQueryable<Entity> GetAll<Entity>() where Entity : BaseEntity;
        Task<IQueryable<Entity>> GetAllAsync<Entity>() where Entity : BaseEntity;
        List<Entity> GetList<Entity>() where Entity : BaseEntity;
        Task<List<Entity>> GetListAsync<Entity>() where Entity : BaseEntity;
        Task<bool> UnitOfWork { get; }
    }
}
