using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace DAL.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        //    : base(options) 
        //{

        //}
        public ApplicationDbContext()
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Facultyes> Facultyes { get; set; }
        public DbSet<Departments> Departments { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Disciplines> Disciplines { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Slots> Slots { get; set; }
        public DbSet<SlotsSchedules> SlotsSchedules { get;set;}
        public DbSet<Pairs> Pairs { get; set; }
        public DbSet<Marks> Marks { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=ElectronicMagazineDataBasec;Database=ElectronicMagazineDataBasec;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Workers>()
            .HasMany(w => w.Schedules)
            .WithOne(s => s.Worker)
            .HasForeignKey(s => s.WorkerId)
            .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);

            Disciplines kis = new Disciplines { Id = 1, DisciplineName = "КИС" };
            Disciplines rpi = new Disciplines { Id = 2, DisciplineName = "РПИ" };
            Disciplines osisp = new Disciplines { Id = 3, DisciplineName = "ОСиСП" };
            Disciplines oyis = new Disciplines { Id = 4, DisciplineName = "ОУИС" };
            Disciplines pmp = new Disciplines { Id = 5, DisciplineName = "ПМП" };
            Disciplines bjch = new Disciplines { Id = 6, DisciplineName = "БЖЧ" };
            Disciplines fizKylt = new Disciplines { Id = 7, DisciplineName = "ФизКульт" };
            Disciplines ekonomeka = new Disciplines { Id = 8, DisciplineName = "Экономика" };
            Disciplines mmcc = new Disciplines { Id = 9, DisciplineName = "ММСС" };

           
            Facultyes fais = new Facultyes { Id = 1, NameFaculty = "ФАИС"};
            Departments ip = new Departments { Id = 1, FacultyesId = 1, NameDepartment = "ИП"};

            Groups groups = new Groups {Id = 1, Course = 3, NumberGroup = 2, DepartmentId = 1, NameGroup = "ИП"};
            Groups groups2 = new Groups { Id = 2, Course = 3, NumberGroup = 1, DepartmentId = 1, NameGroup = "ИП" };


            IdentityRole identityRole1 = new IdentityRole { Name = "Студент" };
            IdentityRole identityRole2 = new IdentityRole { Name = "Преподаватель" };
            IdentityRole identityRole3 = new IdentityRole { Name = "Декан" };
            IdentityRole identityRole4 = new IdentityRole { Name = "ЗамКафедры" };

            User user1 = new User { Surname = "Иванов", Name = "Иван", MiddleName = "Иванович", };
            User user2 = new User { Surname = "Егоров", Name = "Егор", MiddleName = "Егорович" };
            User user3 = new User { Surname = "Владислов", Name = "Влад", MiddleName = "Владиславович" };


            User user4 = new User { Surname = "Иванов", Name = "Иван", MiddleName = "Иванович", };
            User user5 = new User { Surname = "Егоров", Name = "Егор", MiddleName = "Егорович" };
            User user6 = new User { Surname = "Владислов", Name = "Влад", MiddleName = "Владиславович" };

            IdentityUserRole<string> identityUserRole1 = new IdentityUserRole<string> { RoleId = identityRole1.Id, UserId = user1.Id };
            IdentityUserRole<string> identityUserRole2 = new IdentityUserRole<string> { RoleId = identityRole1.Id, UserId = user2.Id };
            IdentityUserRole<string> identityUserRole3 = new IdentityUserRole<string> { RoleId = identityRole1.Id, UserId = user3.Id };

            IdentityUserRole<string> identityUserRole4 = new IdentityUserRole<string> { RoleId = identityRole2.Id, UserId = user4.Id };
            IdentityUserRole<string> identityUserRole5 = new IdentityUserRole<string> { RoleId = identityRole2.Id, UserId = user5.Id };
            IdentityUserRole<string> identityUserRole6 = new IdentityUserRole<string> { RoleId = identityRole2.Id, UserId = user6.Id };

            Students student1 = new Students { Id = 1, UserId = user1.Id,  CardNumber = "8252", GroupsId = groups.Id };
            Students student2 = new Students { Id = 2, UserId = user2.Id,  CardNumber = "2209", GroupsId = groups.Id };
            Students student3 = new Students { Id = 3, UserId = user3.Id,  CardNumber = "3924", GroupsId = groups.Id };

            Workers workers1 = new Workers { Id = 1, UserId = user4.Id, DepartmentId = ip.Id };
            Workers workers2 = new Workers { Id = 2, UserId = user5.Id, DepartmentId = ip.Id };
            Workers workers3 = new Workers { Id = 3, UserId = user4.Id, DepartmentId = ip.Id };

            


            builder.Entity<IdentityRole>().HasData(identityRole1, identityRole2, identityRole3, identityRole4);
            builder.Entity<Disciplines>().HasData(kis, rpi, osisp, oyis, pmp, 
                bjch, fizKylt, ekonomeka, mmcc);
            builder.Entity<Facultyes>().HasData(fais);
            builder.Entity<Departments>().HasData(ip);
            builder.Entity<Groups>().HasData(groups, groups2);
            builder.Entity<User>().HasData(user1, user2, user3, user4, user5, user6);
            builder.Entity<Students>().HasData(student1, student2, student3);
            builder.Entity<IdentityUserRole<string>>().HasData(identityUserRole1, identityUserRole2, identityUserRole3,
                identityUserRole4, identityUserRole5, identityUserRole6);
            builder.Entity<Workers>().HasData(workers1, workers2, workers3);
        }
    }
}
