using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;

namespace DAL.SQLRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserRepository(UserManager<User> userMeneger, SignInManager<User> signInManager)
        {
            _userManager = userMeneger;
            _signInManager = signInManager;
        }


        public async Task Create(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if(!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors);
                throw new InvalidOperationException($"Ошибка добавления пользователя: {errors}");
            }
        }

        public async Task Delete(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors);
                throw new InvalidOperationException($"Ошибка удаления пользователя: {errors}");
            }
        }

        public async Task<User> FindByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);


        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.FromResult(_userManager.Users);
        }

        public async Task<User> LoginUser(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if(user == null)
            {
                return null;
            }
            var result = await _signInManager.PasswordSignInAsync(userName, password, false, lockoutOnFailure: false);
            if (result.Succeeded)
                return user;
            else
                return null;
        }

        public async Task<User> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
            }
            catch
            {

            }
            return null;
        }
        public async Task<User> GetUserInfo(string id)
        {        
           var user =  await _userManager.FindByIdAsync(id);          
           return user;
        }

        public async Task<IList<string>> GetUserRole(User user)
        {
            var role = await _userManager.GetRolesAsync(user);
            return role;

        }

    }
}
