using Microsoft.EntityFrameworkCore;

namespace Data.IRepositories.RepositoriesImpl
{
    public class SpeakerRepository : BaseRepository<Speaker, int>, ISpeakerRepository
    {
        public SpeakerRepository(MeetupAppDatabaseContext applicationContext)
           : base(applicationContext)
        {
            applicationContext.Speakers.Include(s => s.Events).ToList();
        }

        public async Task<Speaker> GetByNameAndSurname(string name, string surname)
        {
            return await DbSet.FirstOrDefaultAsync(s => s.Name == name && s.Surname == surname);
        }
    }
}
