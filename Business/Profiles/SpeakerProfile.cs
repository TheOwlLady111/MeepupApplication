using AutoMapper;
using Business.Models;
using Data;

namespace Business.Profiles
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            CreateMap<Speaker, SpeakerModel>().ReverseMap();
        }
    }
}
