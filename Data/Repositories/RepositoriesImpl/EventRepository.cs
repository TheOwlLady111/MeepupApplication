using Microsoft.EntityFrameworkCore;

namespace Data.IRepositories.RepositoriesImpl
{
    public class EventRepository : BaseRepository<Event, int>, IEventRepository
    {
        public EventRepository(MeetupAppDatabaseContext applicationContext)
           : base(applicationContext)
        {
            applicationContext.Events.Include(e => e.Speakers).ToList();
        }
    }
}
