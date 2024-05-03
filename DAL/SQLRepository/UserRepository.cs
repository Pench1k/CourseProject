using DAL.DbContext;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.SQLRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationDbContext _context;
        public UserRepository(UserManager<User> userMeneger, SignInManager<User> signInManager, ApplicationDbContext context)
        {
            _userManager = userMeneger;
            _signInManager = signInManager;
            _context = context;
        }


        public async Task<IdentityResult> Create(User user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                var errors = string.Join(", ", result.Errors);
                throw new InvalidOperationException($"Ошибка добавления пользователя: {errors}");
            }
            return result;
        }

        public async Task<IdentityResult> Delete(User user)
        {
            var result = await _userManager.DeleteAsync(user);
            return result;
        }

        public User? FindByName(string name)
        {
            return _userManager.Users.FirstOrDefault(u => u.UserName == name);
        }


        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.FromResult(_userManager.Users);
        }

        public async Task<User> LoginUser(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
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
            var user = await _userManager.FindByIdAsync(id);
            return user;
        }

        public async Task<IList<string>> GetUserRole(User user)
        {
            try
            {
                var role = await _userManager.GetRolesAsync(user);
                return role;
            }
            catch (Exception ex)
            {
                // Записать информацию об исключении в логи
                Console.WriteLine(ex);
                throw; // Повторное возбуждение исключения для передачи его наружу
            }
        }
        public async Task<IdentityResult> AddRoleToUser(User user, string roleName)
        {
            return await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<User> FindByIdAsync(string id)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IdentityResult> UpdateAsync(User user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(x => x.Id == user.Id);

            if (userToUpdate == null)
            {
                // Если пользователь не найден, возвращаем ошибку
                return IdentityResult.Failed(new IdentityError { Description = "Пользователь не найден." });
            }

            // Обновляем свойства пользователя
            userToUpdate.UserName = user.UserName;
            userToUpdate.Surname = user.Surname;
            userToUpdate.MiddleName = user.MiddleName;
            userToUpdate.Name = user.Name;

            try
            {
                // Сохраняем изменения в базе данных
                await _context.SaveChangesAsync();
                return IdentityResult.Success;
            }
            catch (DbUpdateException ex)
            {
                // Если произошла ошибка при сохранении, возвращаем сообщение об ошибке
                return IdentityResult.Failed(new IdentityError { Description = $"Ошибка при сохранении изменений: {ex.Message}" });
            }
        }

        public async Task<IdentityResult> RemovePasswordAsync(User user)
        {
            var userForPasswordChange = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userForPasswordChange == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Пользователь не найден." });
            }

            // Выполняем операцию удаления пароля
            var result = await _userManager.RemovePasswordAsync(userForPasswordChange);
            return result;
        }

        public async Task<IdentityResult> AddPasswordAsync(User user, string newPassword)
        {
            var userForPasswordChange = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id);
            if (userForPasswordChange == null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Пользователь не найден." });
            }

            // Выполняем операцию добавления пароля
            var result = await _userManager.AddPasswordAsync(userForPasswordChange, newPassword);
            return result;
        }
    }
}
