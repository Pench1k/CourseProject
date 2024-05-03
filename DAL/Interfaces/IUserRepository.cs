using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {        
        Task<IdentityResult> Create(User user, string password);
        Task<IdentityResult> Delete(User user);
        Task<IEnumerable<User>> GetAll();
        User FindByName(string name);
        Task<User> LoginUser(string userName, string password);
        Task<User> Logout();
        Task<User> GetUserInfo(string id);
        Task<IList<string>> GetUserRole(User user);
        Task<IdentityResult> AddRoleToUser(User user, string roleName);

        Task<User> FindByIdAsync(string id);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> RemovePasswordAsync(User user);
        Task<IdentityResult> AddPasswordAsync(User user, string newPassword);
    }
}
