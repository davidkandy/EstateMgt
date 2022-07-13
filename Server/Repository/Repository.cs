using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using Server.Data;
using Server.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private NativeDbSet<T> _dbSet;
        private EstateDBContext _dbContext;

        public Repository(NativeDbSet<T> dbSet, EstateDBContext dbContext)
        {
            _dbSet = dbSet;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            T entityToDelete = _dbSet.Find(id);
            _dbSet.Remove(entityToDelete);
        }
    }

    public class NativeDbSet<T> : DbSet<T> where T : class
    {
        readonly DbSet<T> _dbSet;

        #region Constructor
        public NativeDbSet(EstateDBContext context) => _dbSet = context.Set<T>();
        #endregion
        
        public override IEntityType EntityType => _dbSet.EntityType;
        public override EntityEntry<T> Add(T entity) => _dbSet.Add(entity);
        public override EntityEntry<T> Update(T entity) => _dbSet.Update(entity);
        public override ValueTask<T?> FindAsync(params object?[]? keyValues) => _dbSet.FindAsync(keyValues);
        public override EntityEntry<T> Remove(T entity) => _dbSet.Remove(entity);

    }
}