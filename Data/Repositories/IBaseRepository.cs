namespace Data.IRepositories
{
    public interface IBaseRepository<T, K> where T : Entity<K>
    {
        Task<T> GetAsync(K id);
        Task<List<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
