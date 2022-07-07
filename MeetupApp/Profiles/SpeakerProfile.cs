using AutoMapper;
using Business.Models;
using MeetupApp.Request;
using MeetupApp.Response;

namespace MeetupApp.Profiles
{
    public class SpeakerProfile : Profile
    {
        public SpeakerProfile()
        {
            CreateMap<SpeakerModel, SpeakerResponse>();
            CreateMap<SpeakerModel, SpeakerResponseForEvent>();
            CreateMap<SpeakerRequest, SpeakerModel>();
        }


    }
}
