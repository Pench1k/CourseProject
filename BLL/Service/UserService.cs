

using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using DAL.SQLRepository;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task CreateUser(UserDTO user, string password)
        {
            await _userRepository.Create(_mapper.Map<User>(user), password);
        }

        public async Task DeleteUser(UserDTO user)
        {
            await _userRepository.Delete(_mapper.Map<User>(user));
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            return (await _userRepository.GetAll()).Select(u => _mapper.Map<UserDTO>(u));
        }

        public async Task<UserDTO> GetUserByEmail(string email)
        {
            return _mapper.Map<UserDTO>(await _userRepository.FindByEmailAsync(email));
        }
        public async Task<UserDTO> LoginUser(string userName, string password)
        {
            return _mapper.Map<UserDTO>(await _userRepository.LoginUser(userName, password));
        }
    }
}
