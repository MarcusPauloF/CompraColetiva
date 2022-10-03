using acme.sistemas.compracoletiva.core.Base;
using acme.sistemas.compracoletiva.domain.Interfaces.Repository;
using acme.sistemas.compracoletiva.infra.Config;
using Microsoft.EntityFrameworkCore;

namespace acme.sistemas.compracoletiva.repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Context _db;

        public BaseRepository(Context db)
        {
            _db = db;
        }

        public Task<bool> UnitOfWork => _db.Commit();

        public void Add(TEntity entity) => _db.Add(entity);

        public async Task AddAsync(TEntity entity) => await _db.AddAsync(entity);

        public void AddMultiple(IEnumerable<TEntity> entities) => _db.AddRange(entities);

        public Task AddMultipleAsync(IEnumerable<TEntity> entities) => _db.AddRangeAsync(entities);

        public virtual IQueryable<Entity> GetAll<Entity>() where Entity : BaseEntity
        {
            var dbSet = _db.Set<Entity>();
            var result = dbSet.AsQueryable<Entity>();
            return (result);
        }

        public async Task<IQueryable<Entity>> GetAllAsync<Entity>() where Entity : BaseEntity
        {
            var dbSet = _db.Set<Entity>();
            var result = dbSet.AsQueryable<Entity>();
            return await Task.FromResult(result);
        }

        public Entity GetById<Entity>(Guid id) where Entity : BaseEntity => _db.Set<Entity>().Where(t => t.Id.Equals(id)).FirstOrDefault();

        public async Task<Entity> GetByIdAsync<Entity>(Guid id) where Entity : BaseEntity => await _db.Set<Entity>().Where(t => t.Id.Equals(id)).FirstOrDefaultAsync();

        public List<Entity> GetList<Entity>() where Entity : BaseEntity => GetAll<Entity>().ToList();


        public Task<List<Entity>> GetListAsync<Entity>() where Entity : BaseEntity => _db.Set<Entity>().ToListAsync();

        public void Remove(TEntity entity) => _db.Remove(entity);


        public void RemoveMultiple(IEnumerable<TEntity> entities) => _db.RemoveRange(entities);


        public void Update(TEntity entity) => _db.Update(entity);


        public void UpdateMultiple(IEnumerable<TEntity> entities) => _db.UpdateRange(entities);

    }


}
