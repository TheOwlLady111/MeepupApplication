using AutoMapper;
using Business.Models;
using MeetupApp.Request;

namespace MeetupApp.Profiles
{
    public class RegistrationProfile : Profile
    {
        public RegistrationProfile()
        {
            CreateMap<RegistrationModel, RegistrationRequest>().ReverseMap();
        }
    }
}
