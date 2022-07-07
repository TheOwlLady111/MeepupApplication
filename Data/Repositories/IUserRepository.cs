namespace Data.IRepositories
{
    public interface IUserRepository : IBaseRepository<User, int>
    {
        Task<User> GetByLoginAsync(string login);
        Task<User> GetByLoginAndPasswordAsync(string login, string password);
    }
}
