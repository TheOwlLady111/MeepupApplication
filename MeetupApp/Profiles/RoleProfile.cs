using AutoMapper;
using Business.Models;
using MeetupApp.Request;

namespace MeetupApp.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleRequest, RoleModel>();
        }
    }
}
