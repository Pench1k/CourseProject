using BLL.DTO;
using BLL.ViewModel;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        Task CreateUser(UserDTO user, string password);
        Task DeleteUser(UserDTO user);
        Task<UserDTO> GetUserByEmail(string email);
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO> LoginUser(string userName, string password);
        Task LogoutUser();
        Task<UserView> GetUserInfo(string id);
    }
}
