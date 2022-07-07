using AutoMapper;
using Business.Models;
using Data;

namespace Business.Profiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Role, RoleModel>().ReverseMap();
        }
    }
}
