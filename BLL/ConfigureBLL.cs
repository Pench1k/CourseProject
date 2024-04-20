using BLL.Interfaces;
using BLL.Mappers;
using BLL.Service;
using DAL;
using Microsoft.Extensions.DependencyInjection;

namespace BLL
{
    public static class ConfigureBLL
    {
        public static void ConfigureBLLServices(this IServiceCollection services, string connString)
        {
            services.ConfigureDALServices(connString);

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IDepartmentsService, DepartmentsService>();
            services.AddScoped<IDisciplinesService, DisciplinesService>();
            services.AddScoped<IFacultyesService, FacultyesService>();
            services.AddScoped<IGroupsService, GroupsService>();
            services.AddScoped<IMarksService, MarksService>();
            services.AddScoped<IPairsService, PairsService>();
            services.AddScoped<ISchedulesService, SchedulesService>();
            services.AddScoped<ISlotsSchedulesService, SlotsSchedulesService>();
            services.AddScoped<ISlotsService, SlotsService>();
            services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<IWorkersService, WorkersService>();
            services.AddScoped<IUserService, UserService>();
        
        }
    }
}
