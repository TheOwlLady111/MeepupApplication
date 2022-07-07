using AutoMapper;
using Business.Additional;
using Business.Exceptions;
using Business.Models;
using Data;
using Data.IRepositories;

namespace Business.Services
{
    public class UserService : IUserService<int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly PasswordHasher _hasher;

        public UserService(IMapper mapper, IUserRepository userRepository, PasswordHasher hasher)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _hasher = hasher;
        }
        public async Task CreateAsync(UserModel createdUser)
        {
            var entity = await _userRepository.GetByLoginAsync(createdUser.Login);

            if (entity != null)
            {
                throw new ArgumentException("This user has already existed");
            }

            var usersRole = _mapper.Map<RoleModel, Role>(createdUser.Role);

            var user = new User();
            user.Login = createdUser.Login;
            user.Password = _hasher.GeneratePasswordHash(createdUser.Password);
            user.Name = createdUser.Name;
            user.Surname = createdUser.Surname;
            user.RoleId = createdUser.RoleId;

            await _userRepository.CreateAsync(user);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _userRepository.GetAsync(id);
            if (entity == null)
            {
                throw new DbNotExistException($"There is not user with id {id} for deleting");
            }

            await _userRepository.DeleteAsync(entity);
        }

        public async Task<List<UserModel>> GetAllAsync()
        {
            var entity = await _userRepository.GetAllAsync();
            if (entity == null)
            {
                throw new DbNotExistException($"There are nor users in db");
            }
            return _mapper.Map<List<User>, List<UserModel>>(entity);
        }

        public async Task<UserModel> GetAsync(int id)
        {
            var entity = await _userRepository.GetAsync(id);
            if (entity == null)
            {
                throw new DbNotExistException($"There is not user with id {id}");
            }
            return _mapper.Map<User, UserModel>(entity);
        }

        public async Task UpdateAsync(int id, UserModel updatedUser)
        {
            var entity = await _userRepository.GetAsync(id);

            if (entity == null)
            {
                throw new DbNotExistException($"There is not user with id {id} for updating");
            }

            entity.Login = updatedUser.Login;
            entity.Name = updatedUser.Name;
            entity.Surname = updatedUser.Surname;

            await _userRepository.UpdateAsync(entity);
        }
    }
}
