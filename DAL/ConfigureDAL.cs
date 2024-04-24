using DAL.DbContext;
using DAL.Interfaces;
using DAL.SQLRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace DAL
{
    public static class ConfigureDAL
    {
        public static void ConfigureDALServices(this IServiceCollection services, string connString)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connString));

            

            services.AddScoped<IDepartmentRepository, DepartmentSQLReporistory>();
            services.AddScoped<IDisciplinesRepository, DisciplinesSQLRepository>();
            services.AddScoped<IFacultyesRepository, FacultyesSQLRepository>();
            services.AddScoped<IGroupsRepository, GroupsSQLRepository>();
            services.AddScoped<IMarksRepository, MarksSQLRepository>();
            services.AddScoped<IPairsRepository, PairsSQLRepository>();
            services.AddScoped<ISchedulesRepository, SchedulesSQLRepository>();
            services.AddScoped<ISlotsRepository, SlotsSQLRepository>();
            services.AddScoped<ISlotsSchedulesRepository, SlotsSchedulesSQLRepository>();
            services.AddScoped<IStudentsRepository, StudentsRepository>();
            services.AddScoped<IWorkersRepository, WorkersSQLRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IGroupsSchedulesRepository, GroupsSchedulesSQLRepository>();
        }
    }
}
