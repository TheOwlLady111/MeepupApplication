using AutoMapper;
using Business.Models;
using MeetupApp.Request;
using MeetupApp.Response;

namespace MeetupApp.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserResponse>()
                .ForMember(x => x.RoleName, y => y.MapFrom(e => e.Role.Name));

            CreateMap<UserRequest, UserModel>();
            CreateMap<LoginRequest, LoginModel>();
            CreateMap<LoginSuccessModel, LoginResponse>();
        }
    }
}
