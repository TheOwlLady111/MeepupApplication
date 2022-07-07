using Business.Models;

namespace Business.Services
{
    public interface IEventService<T>
    {
        Task<EventModel> GetAsync(T id);
        Task<List<EventModel>> GetAllAsync();
        Task UpdateAsync(T id, EventModel updatedEvent);
        Task DeleteAsync(T id);
        Task CreateAsync(EventModel createdEvent);
    }
}
