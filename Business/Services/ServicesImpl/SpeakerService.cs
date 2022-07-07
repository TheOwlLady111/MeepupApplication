using AutoMapper;
using Business.Exceptions;
using Business.Models;
using Data;
using Data.IRepositories;

namespace Business.Services
{
    public class SpeakerService : ISpeakerService<int>
    {
        private readonly IMapper _mapper;
        private readonly ISpeakerRepository _speakerRepository;

        public SpeakerService(IMapper mapper, ISpeakerRepository speakerRepository)
        {
            _mapper = mapper;
            _speakerRepository = speakerRepository;
        }
        public async Task CreateAsync(SpeakerModel createdSpeaker)
        {
            var speaker = await _speakerRepository.GetByNameAndSurname(createdSpeaker.Name, createdSpeaker.Surname);

            if (speaker != null)
            {
                throw new ArgumentException("This speaker is in db");
            }

            var entity = _mapper.Map<SpeakerModel, Speaker>(createdSpeaker);
            await _speakerRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _speakerRepository.GetAsync(id);
            if (entity == null)
            {
                throw new DbNotExistException($"There is not speaker with id {id} for deleting");
            }
            await _speakerRepository.DeleteAsync(entity);
        }

        public async Task<List<SpeakerModel>> GetAllAsync()
        {
            var entity = await _speakerRepository.GetAllAsync();
            return _mapper.Map<List<Speaker>, List<SpeakerModel>>(entity);
        }

        public async Task<SpeakerModel> GetAsync(int id)
        {
            var entity = await _speakerRepository.GetAsync(id);

            if (entity == null)
            {
                throw new DbNotExistException($"There is not speaker with id {id}");
            }

            return _mapper.Map<Speaker, SpeakerModel>(entity);
        }

        public async Task UpdateAsync(int id, SpeakerModel updatedSpeakerModel)
        {
            var entity = await _speakerRepository.GetAsync(id);

            if (entity == null)
            {
                throw new DbNotExistException($"There is not speaker with id {id} for updating");
            }

            var updatedSpeaker = _mapper.Map<SpeakerModel, Speaker>(updatedSpeakerModel);
            entity.Surname = updatedSpeaker.Surname;
            entity.Name = updatedSpeaker.Name;

            await _speakerRepository.UpdateAsync(entity);
        }
    }
}
