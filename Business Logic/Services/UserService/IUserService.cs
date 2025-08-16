using Domain;

namespace Business_Logic.Services.UserService
{
    public interface IUserService
    {
        Task<ApplicationUser?> GetByIdAsync(string id);
        Task<ApplicationUser?> GetByEmailAsync(string email);
        Task<IEnumerable<ApplicationUser>> GetAllAsync();
        Task UpdateUserAsync(ApplicationUser user);
        Task DeleteUserAsync(string id);
    }
}
