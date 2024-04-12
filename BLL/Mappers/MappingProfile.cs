using AutoMapper;
using BLL.DTO;
using DAL.Models;

namespace BLL.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Departments, DepartmentsDTO>().ReverseMap();
            CreateMap<Disciplines, DisciplinesDTO>().ReverseMap();
            CreateMap<Facultyes, FacultyesDTO>().ReverseMap();
            CreateMap<Groups, GroupsDTO>().ReverseMap();
            CreateMap<Marks, MarksDTO>().ReverseMap();
            CreateMap<Pairs, PairsDTO>().ReverseMap();
            CreateMap<Schedules, SchedulesDTO>().ReverseMap();
            CreateMap<Slots, SlotsDTO>().ReverseMap();
            CreateMap<SlotsSchedules, SlotsSchedulesDTO>().ReverseMap();
            CreateMap<Students, StudentsDTO>().ReverseMap();
            CreateMap<Workers, WorkersDTO>().ReverseMap();
        }
    }
}
