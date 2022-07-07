using Business.Models;

namespace Business.Services
{
    public interface ISpeakerService<T>
    {
        Task<SpeakerModel> GetAsync(T id);
        Task<List<SpeakerModel>> GetAllAsync();
        Task UpdateAsync(T id, SpeakerModel updatedSpeaker);
        Task DeleteAsync(T id);
        Task CreateAsync(SpeakerModel createdSpeaker);
    }
}
