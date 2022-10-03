using acme.sistemas.compracoletiva.domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using acme.sistemas.compracoletiva.core.Base;

namespace acme.sistemas.compracoletiva.service.Interfaces.Service
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<bool> UnitOfWork { get; }
        Task AddAsync(TEntity entity);
        void Add(TEntity entity);
        void AddMultiple(IEnumerable<TEntity> entities);
        Task AddMultipleAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveMultiple(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateMultiple(IEnumerable<TEntity> entities);
        Task<Entity> GetByIdAsync<TEntityRecover, Entity>(Guid id) where TEntityRecover : IAggregateRoot where Entity : BaseEntity;
        Entity GetById<TEntityRecover, Entity>(Guid id) where TEntityRecover : class where Entity : BaseEntity;
        IQueryable<Entity> GetAll<TEntityRecover, Entity>() where TEntityRecover : class where Entity : BaseEntity;
        Task<IQueryable<Entity>> GetAllAsync<TEntityRecover, Entity>() where TEntityRecover : class where Entity : BaseEntity;

        Task<List<Entity>> GetListAsync<TEntityRecover, Entity>() where TEntityRecover : class where Entity : BaseEntity;
    }
}
