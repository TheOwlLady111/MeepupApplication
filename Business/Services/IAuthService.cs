using Business.Models;

namespace Business.Services
{
    public interface IAuthService
    {
        Task RegisterUserAsync(RegistrationModel registrationModel);
        Task<LoginSuccessModel> LoginUserAsync(LoginModel loginModel);
    }
}
