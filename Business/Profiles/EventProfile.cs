using AutoMapper;
using Business.Models;
using Data;

namespace Business.Profiles
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Event, EventModel>().ReverseMap();
        }
    }
}
