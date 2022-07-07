namespace Data.IRepositories.RepositoriesImpl
{
    public class RoleRepository : BaseRepository<Role, byte>, IRoleRepository
    {
        public RoleRepository(MeetupAppDatabaseContext applicationContext)
           : base(applicationContext)
        {
        }
    }
}
