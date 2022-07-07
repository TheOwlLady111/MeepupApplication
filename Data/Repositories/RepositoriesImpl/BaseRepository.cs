using Microsoft.EntityFrameworkCore;

namespace Data.IRepositories.RepositoriesImpl
{
    public abstract class BaseRepository<T, K>
       where T : Entity<K>
    {

        private readonly MeetupAppDatabaseContext _applicationContext;

        protected BaseRepository(MeetupAppDatabaseContext applicationContext)
        {
            _applicationContext = applicationContext;
            DbSet = _applicationContext.Set<T>();
        }

        protected readonly DbSet<T> DbSet;

        public virtual async Task<T> GetAsync(K id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            var createdEntity = DbSet.Add(entity);

            await _applicationContext.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var updatedEntity = DbSet.Update(entity).Entity;

            await _applicationContext.SaveChangesAsync();

            return updatedEntity;
        }

        public async Task DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            await _applicationContext.SaveChangesAsync();
        }
    }
}
