using AutoMapper;
using Business.Exceptions;
using Business.Models;
using Data;
using Data.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Business.Services
{
    public class EventService : IEventService<int>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly ISpeakerRepository _speakerRepository;
        private readonly MeetupAppDatabaseContext _databaseContext;

        public EventService(IMapper mapper, IEventRepository eventRepository,
            ISpeakerRepository speakerRepository, MeetupAppDatabaseContext databaseContext)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _speakerRepository = speakerRepository;
            _databaseContext = databaseContext;
        }
        public async Task CreateAsync(EventModel createdEvent)
        {
            await using var transaction = await _databaseContext.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var speakersOfCreatedEvent = _mapper.Map<List<SpeakerModel>, List<Speaker>>(createdEvent.Speakers.ToList());
                var existingSpeakers = await _speakerRepository.GetAllAsync();
                List<(string, string)> namesAndSurnamesExisting = existingSpeakers.Select(s => (s.Name, s.Surname)).ToList();
                var listToEvent = new List<Speaker>();
                var created = _mapper.Map<EventModel, Event>(createdEvent);

                foreach (var speaker in speakersOfCreatedEvent)
                {
                    if (!namesAndSurnamesExisting.Contains((speaker.Name, speaker.Surname)))
                    {
                        await _speakerRepository.CreateAsync(speaker);
                        listToEvent.Add(speaker);

                    }
                    else
                    {
                        var entity = existingSpeakers.Find(s => s.Name == speaker.Name && s.Surname == speaker.Surname);
                        listToEvent.Add(entity);
                    }
                }

                created.Speakers = listToEvent;

                await _eventRepository.CreateAsync(created);
                await transaction.CommitAsync();

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new Exception("Transaction is canceled!");
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entityToDelete = await _eventRepository.GetAsync(id);
            if (entityToDelete == null)
            {
                throw new DbNotExistException($"Event with id {id} does not exist in db");
            }

            await _eventRepository.DeleteAsync(entityToDelete);
        }

        public async Task<List<EventModel>> GetAllAsync()
        {
            var entity = await _eventRepository.GetAllAsync();
            if (entity == null)
            {
                throw new DbNotExistException($"There are not records in db");
            }
            return _mapper.Map<List<Event>, List<EventModel>>(entity);
        }

        public async Task<EventModel> GetAsync(int id)
        {
            var entity = await _eventRepository.GetAsync(id);
            if (entity == null)
            {
                throw new DbNotExistException($"Event with id {id} does not exist in db");
            }

            return _mapper.Map<Event, EventModel>(entity);
        }

        public async Task UpdateAsync(int id, EventModel updatedEventModel)
        {
            await using var transaction = await _databaseContext.Database.BeginTransactionAsync(IsolationLevel.Serializable);
            try
            {
                var entity = await _eventRepository.GetAsync(id);

                if (entity == null)
                {
                    throw new DbNotExistException($"Event with id {id} does not exist in db");
                }

                var speakersOfUpdatedEvent = _mapper.Map<List<SpeakerModel>, List<Speaker>>(updatedEventModel.Speakers.ToList());
                var existingSpeakers = await _speakerRepository.GetAllAsync();
                List<(string, string)> namesAndSurnamesExisting = existingSpeakers.Select(s => (s.Name, s.Surname)).ToList();
                var listToEvent = new List<Speaker>();



                foreach (var speaker in speakersOfUpdatedEvent)
                {
                    if (!namesAndSurnamesExisting.Contains((speaker.Name, speaker.Surname)))
                    {
                        await _speakerRepository.CreateAsync(speaker);
                        listToEvent.Add(speaker);

                    }
                    else
                    {
                        var entity1 = existingSpeakers.Find(s => s.Name == speaker.Name && s.Surname == speaker.Surname);
                        listToEvent.Add(entity1);
                    }
                }

                entity.Name = updatedEventModel.Name;
                entity.Description = updatedEventModel.Description;
                entity.Plan = updatedEventModel.Plan;
                entity.Place = updatedEventModel.Place;
                entity.Organizer = updatedEventModel.Organizer;
                entity.DateOfEvent = updatedEventModel.DateOfEvent;
                entity.Speakers = listToEvent;

                await _eventRepository.UpdateAsync(entity);
                await transaction.CommitAsync();

            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw new Exception("Transaction is canceled!");
            }

        }
    }
}
