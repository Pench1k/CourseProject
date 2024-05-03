using BLL.DTO;
using BLL.ViewModel;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUser(UserDTO user, string password);
        Task<IdentityResult> DeleteUser(UserDTO user);
        UserDTO GetUserByName(string name);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> LoginUser(string userName, string password);
        Task LogoutUser();
        Task<UserView> GetUserInfo(string id);
        Task<IdentityResult> AddRoleToUser(string userId, string roleName);
        Task<UserDTO> FindByIdAsync(string id);
        Task<IdentityResult> UpdateAsync(UserDTO user);
        Task<IdentityResult> RemovePasswordAsync(UserDTO user);

        Task<IdentityResult> AddPasswordAsync(UserDTO user, string newPassword);
    }
}
