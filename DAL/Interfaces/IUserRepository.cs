using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {        
        Task Create(User user, string password);
        Task Delete(User user);
        Task<IEnumerable<User>> GetAll();
        Task<User> FindByEmailAsync(string email);
        Task<User> LoginUser(string userName, string password);
        Task<User> Logout();
    }
}
