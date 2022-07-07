using AutoMapper;
using Business.Models;
using MeetupApp.Request;
using MeetupApp.Response;

namespace MeetupApp.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<EventModel, EventResponseForSpeaker>();
            CreateMap<EventModel, EventResponse>();
            CreateMap<EventRequest, EventModel>();
        }
    }
}
