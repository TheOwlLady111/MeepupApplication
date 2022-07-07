using Business.Models;

namespace Business.Services
{
    public interface IUserService<T>
    {
        Task<UserModel> GetAsync(T id);
        Task<List<UserModel>> GetAllAsync();
        Task UpdateAsync(T id, UserModel updatedUser);
        Task DeleteAsync(T id);
        Task CreateAsync(UserModel createdUser);
    }
}
