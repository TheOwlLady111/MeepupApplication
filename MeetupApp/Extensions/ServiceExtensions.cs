using Business.Additional;
using Business.Services;
using Business.Services.ServicesImpl;
using Data.IRepositories;
using Data.IRepositories.RepositoriesImpl;

namespace MeetupApp.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ISpeakerRepository, SpeakerRepository>();
            services.AddScoped<IEventRepository, EventRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService<int>, UserService>();
            services.AddScoped<ISpeakerService<int>, SpeakerService>();
            services.AddScoped<IEventService<int>, EventService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }

        public static IServiceCollection AddPasswordHasher(this IServiceCollection services)
        {
            return services.AddScoped<PasswordHasher>();
        }
    }
}
