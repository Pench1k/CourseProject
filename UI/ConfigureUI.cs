using BLL;
using DAL.DbContext;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace UI
{
    public static class ConfigureUI
    {
        public static void ConfigureUIService(this IServiceCollection services, string connString)
        {
            services.ConfigureBLLServices(connString);
            
            

            services.AddIdentity<User, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<SignInManager<User>>();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("StudentPolicy", policy => policy.RequireRole("Студент"));
                options.AddPolicy("TeacherPolicy", policy => policy.RequireRole("Преподаватель"));
                options.AddPolicy("DekanPolicy", policy => policy.RequireRole("Секретарь"));
                options.AddPolicy("DeputyPolicy", policy => policy.RequireRole("Заместитель кафедры"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Home/Login";
                options.AccessDeniedPath = "/Home/Index";
                options.SlidingExpiration = true;
                options.ReturnUrlParameter = string.Empty;
            });

            
        }
    }
}

            //var serviceProvider = services.BuildServiceProvider();
            //var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            //string[] roleNames = { "Студент", "Преподаватель", "Декан", "Заместитель кафедры" };
            //IdentityResult roleResult;
            //foreach (var roleName in roleNames)
            //{
            //    var roleExist = await roleManager.RoleExistsAsync(roleName);
            //    if (!roleExist)
            //    {
            //        roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
            //    }
            //}

            //List<User> usersTeachers = new List<User> {
            //    new User { Surname = "Бородина", Name = "Наталья", MiddleName = "Николаевна", UserName = "borodina228"},
            //    new User { Surname = "Громыко", Name = "Юлия", MiddleName = "Генадьевна", UserName = "grom228"},
            //    new User { Surname = "Денисовский", Name = "Влад", MiddleName = "Григорьевич", UserName = "denis228"},
            //    new User { Surname = "Кибаленко", Name = "Матвей", MiddleName = "Иванович", UserName = "kibalenko228"},
            //    new User { Surname = "Котковец", Name = "Максим", MiddleName = "Николаевич", UserName = "kot228"},
            //    new User { Surname = "Лысенков", Name = "Николай", MiddleName = "Николаевич", UserName = "kolay228"},
            //    new User { Surname = "Мачкарин", Name = "Егор", MiddleName = "Денисович", UserName = "egor228"},
            //    new User { Surname = "Наумович", Name = "Александр", MiddleName = "Генадьевич", UserName = "naym228"},                
            //};

            //services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(connString));

            //IdentityResult userResult;
            //IWorkersService workerService = new WorkersService(new WorkersSQLRepository(new ApplicationDbContext()),
            //    new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new BLL.Mappers.MappingProfile())).CreateMapper());
            //var serviceProvider = services.BuildServiceProvider();
            //var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            //foreach (var user in usersTeachers)
            //{
            //    var userExist = await userManager.FindByNameAsync(user.UserName);
            //    if (userExist == null)
            //    {
            //        userResult = await userManager.CreateAsync(user, "Nata@228");
            //        if (userResult.Succeeded)
            //        {
            //            userResult = await userManager.AddToRoleAsync(user, "Студент");
            //            if(userResult.Succeeded)
            //            {
            //                Students workers = new Students 
            //                {
            //                    UserId = user.Id,
            //                    GroupsId = 1
            //                };
            //                using (var scope = services.BuildServiceProvider().CreateScope())
            //                {
            //                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            //                    dbContext.Students.Add(workers);
            //                    dbContext.SaveChanges();
            //                }
                                                   
            //            }
            //        }
            //    }
            //}
