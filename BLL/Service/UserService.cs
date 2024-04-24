

using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.ViewModel;
using DAL.Interfaces;
using DAL.Models;
using DAL.SQLRepository;
using System.Xml.Linq;

namespace BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IStudentsRepository _studentsRepository;
        private readonly IGroupsRepository _groupsReporitory;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IFacultyesRepository _facultyesRepository;
        private readonly IWorkersRepository _workersRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, 
            IMapper mapper, 
            IStudentsRepository studentsRepository, 
            IGroupsRepository groupsReporitory, 
            IDepartmentRepository departmentRepository,
            IFacultyesRepository facultyesRepository,
            IWorkersRepository workersRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _studentsRepository = studentsRepository;
            _groupsReporitory = groupsReporitory;
            _departmentRepository = departmentRepository;
            _facultyesRepository = facultyesRepository;
            _workersRepository = workersRepository;

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

        public async Task LogoutUser()
        {
           
            await _userRepository.Logout();
        }

        public async Task<UserView> GetUserInfo(string id)
        {
            var user = await _userRepository.GetUserInfo(id);
            var role = await _userRepository.GetUserRole(user); 
            UserView userView = new UserView
            {
                User = user,
                Role = role,
            };
            if (role[0].Equals("Студент"))
            {
                GetStudentInfo(userView);
            }
            else
            {
                GetWorkerInfo(userView);
            }
            return userView;
        }

        private void GetStudentInfo(UserView userView)
        {
            var student = _studentsRepository.Find(student => student.UserId == userView.User.Id);
            if (student != null)
            {
                userView.Students = student;
                userView.Groups = _groupsReporitory.Find(group => group.Id == userView.Students.GroupsId);
                userView.Departments = _departmentRepository.Get(userView.Groups.DepartmentId);
                userView.Facultyes = _facultyesRepository.Get(userView.Departments.FacultyesId);
            }
        }
        private void GetWorkerInfo(UserView userView)
        {
            var worker = _workersRepository.Find(x => x.UserId == userView.User.Id);
            if (worker != null)
            {
                userView.Workers = worker;
                userView.Departments = _departmentRepository.Get(userView.Workers.DepartmentId);
                userView.Facultyes = _facultyesRepository.Get(userView.Departments.FacultyesId);
            }
        }
    }
}
