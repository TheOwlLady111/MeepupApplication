using Microsoft.EntityFrameworkCore;

namespace Data.IRepositories.RepositoriesImpl
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(MeetupAppDatabaseContext applicationContext)
            : base(applicationContext)
        {
            applicationContext.Users.Include(x => x.Role).ToList();
        }

        public async Task<User> GetByLoginAsync(string login)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Login == login);
        }

        public async Task<User> GetByLoginAndPasswordAsync(string login, string password)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Login == login && x.Password == password);
        }
    }
}
