using AutoMapper;
using Business.Additional;
using Business.Exceptions;
using Business.Models;
using Data;
using Data.IRepositories;
using System.Security.Claims;

namespace Business.Services.ServicesImpl
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly ITokenService _tokenService;
        private readonly PasswordHasher _hasher;

        public AuthService(IRoleRepository roleRepository, IUserRepository userRepository,
            ITokenService tokenService, PasswordHasher hasher)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;
            _tokenService = tokenService;
            _hasher = hasher;
        }

        public async Task<LoginSuccessModel> LoginUserAsync(LoginModel loginModel)
        {
            var user = await _userRepository.GetByLoginAndPasswordAsync(loginModel.Login, _hasher.GeneratePasswordHash(loginModel.Password));

            if (user == null)
            {
                throw new DbNotExistException($"There is not user in db with login {loginModel.Login}");
            }

            var claims = GetClaims(user);
            var token = _tokenService.GenerateJwt(claims);

            var successLogin = new LoginSuccessModel();
            successLogin.Jwt = token;

            return successLogin;
        }

        public async Task RegisterUserAsync(RegistrationModel registrationModel)
        {
            var entity = await _userRepository.GetByLoginAsync(registrationModel.Login);
            if (entity != null)
            {
                throw new ArgumentException("This user has already existed");
            }

            var roleList = await _roleRepository.GetAllAsync();
            var userRole = roleList.Find(x => x.Name == Policy.ForUserOnly);

            User user = new User();
            user.Login = registrationModel.Login;
            user.Password = _hasher.GeneratePasswordHash(registrationModel.Password);
            user.Surname = registrationModel.Surname;
            user.Name = registrationModel.Name;
            user.RoleId = userRole.Id;

            await _userRepository.CreateAsync(user);
        }

        private IEnumerable<Claim> GetClaims(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("Name", user.Name),
                new Claim("Surname", user.Surname),
                new Claim("Login", user.Login),
                new Claim(ClaimTypes.Role, user.Role.Name)
            };

            return claims;
        }


    }
}
