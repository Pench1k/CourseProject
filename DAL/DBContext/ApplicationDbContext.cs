using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace DAL.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
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
        public DbSet<GroupsSchedules> GroupsSchedules { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=ElectronicMagazineDataBasec;Database=ElectronicMagazineDataBasec;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Workers>()
            .HasMany(w => w.Schedules)
            .WithOne(s => s.Worker)
            .HasForeignKey(s => s.WorkerId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<GroupsSchedules>().HasKey(g => new { g.GroupsId, g.SchedulesId});
          

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

            Slots slot11 = new Slots {Id = 1, Start = new TimeSpan(8, 20, 0), End = new TimeSpan(9, 40, 0), DayOfTheWeek = 1};
            Slots slot12 = new Slots { Id = 2, Start = new TimeSpan(10, 0, 0), End = new TimeSpan(11, 25, 0), DayOfTheWeek = 1 };
            Slots slot13 = new Slots { Id = 3, Start = new TimeSpan(11, 35, 0), End = new TimeSpan(13, 00, 0), DayOfTheWeek = 1 };
            Slots slot14 = new Slots { Id = 4, Start = new TimeSpan(13, 30, 0), End = new TimeSpan(14, 55, 0), DayOfTheWeek = 1 };
            Slots slot15 = new Slots { Id = 5, Start = new TimeSpan(15, 05, 0), End = new TimeSpan(16, 30, 0), DayOfTheWeek = 1 };

            Slots slot21 = new Slots { Id = 6, Start = new TimeSpan(8, 20, 0), End = new TimeSpan(9, 40, 0), DayOfTheWeek = 2 };
            Slots slot22 = new Slots { Id = 7, Start = new TimeSpan(10, 0, 0), End = new TimeSpan(11, 25, 0), DayOfTheWeek = 2 };
            Slots slot23 = new Slots { Id = 8, Start = new TimeSpan(11, 35, 0), End = new TimeSpan(13, 00, 0), DayOfTheWeek = 2 };
            Slots slot24 = new Slots { Id = 9, Start = new TimeSpan(13, 30, 0), End = new TimeSpan(14, 55, 0), DayOfTheWeek = 2 };
            Slots slot25 = new Slots { Id = 10, Start = new TimeSpan(15, 05, 0), End = new TimeSpan(16, 30, 0), DayOfTheWeek = 2 };

            Slots slot31 = new Slots { Id = 11, Start = new TimeSpan(8, 20, 0), End = new TimeSpan(9, 40, 0), DayOfTheWeek = 3 };
            Slots slot32 = new Slots { Id = 12, Start = new TimeSpan(10, 0, 0), End = new TimeSpan(11, 25, 0), DayOfTheWeek = 3 };
            Slots slot33 = new Slots { Id = 13, Start = new TimeSpan(11, 35, 0), End = new TimeSpan(13, 00, 0), DayOfTheWeek = 3 };
            Slots slot34 = new Slots { Id = 14, Start = new TimeSpan(13, 30, 0), End = new TimeSpan(14, 55, 0), DayOfTheWeek = 3 };
            Slots slot35 = new Slots { Id = 15, Start = new TimeSpan(15, 05, 0), End = new TimeSpan(16, 30, 0), DayOfTheWeek = 3 };

            Slots slot41 = new Slots { Id = 16, Start = new TimeSpan(8, 20, 0), End = new TimeSpan(9, 40, 0), DayOfTheWeek = 4 };
            Slots slot42 = new Slots { Id = 17, Start = new TimeSpan(10, 0, 0), End = new TimeSpan(11, 25, 0), DayOfTheWeek = 4 };
            Slots slot43 = new Slots { Id = 18, Start = new TimeSpan(11, 35, 0), End = new TimeSpan(13, 00, 0), DayOfTheWeek = 4 };
            Slots slot44 = new Slots { Id = 19, Start = new TimeSpan(13, 30, 0), End = new TimeSpan(14, 55, 0), DayOfTheWeek = 4 };
            Slots slot45 = new Slots { Id = 20, Start = new TimeSpan(15, 05, 0), End = new TimeSpan(16, 30, 0), DayOfTheWeek = 4 };

            Slots slot51 = new Slots { Id = 21, Start = new TimeSpan(8, 20, 0), End = new TimeSpan(9, 40, 0), DayOfTheWeek = 5 };
            Slots slot52 = new Slots { Id = 22, Start = new TimeSpan(10, 0, 0), End = new TimeSpan(11, 25, 0), DayOfTheWeek = 5 };
            Slots slot53 = new Slots { Id = 23, Start = new TimeSpan(11, 35, 0), End = new TimeSpan(13, 00, 0), DayOfTheWeek = 5 };
            Slots slot54 = new Slots { Id = 24, Start = new TimeSpan(13, 30, 0), End = new TimeSpan(14, 55, 0), DayOfTheWeek = 5 };
            Slots slot55 = new Slots { Id = 25, Start = new TimeSpan(15, 05, 0), End = new TimeSpan(16, 30, 0), DayOfTheWeek = 5 };

            Schedules schedules1 = new Schedules { Id = 1, WorkerId = 1, DisciplinesId = 1, TypeSchedule = TypeSchedule.Лекция};
            Schedules schedules2 = new Schedules { Id = 2, WorkerId = 2, DisciplinesId = 2, TypeSchedule = TypeSchedule.Практика};
            Schedules schedules3 = new Schedules { Id = 3, WorkerId = 1, DisciplinesId = 3, TypeSchedule = TypeSchedule.Практика };
            Schedules schedules4 = new Schedules { Id = 4, WorkerId = 1, DisciplinesId = 1, TypeSchedule = TypeSchedule.Практика };
            Schedules schedules5 = new Schedules { Id = 5, WorkerId = 1, DisciplinesId = 4, TypeSchedule = TypeSchedule.Лекция };
            Schedules schedules6 = new Schedules { Id = 6, WorkerId = 1, DisciplinesId = 4, TypeSchedule = TypeSchedule.Практика };
            Schedules schedules7 = new Schedules { Id = 7, WorkerId = 1, DisciplinesId = 5, TypeSchedule = TypeSchedule.Практика };
            Schedules schedules8 = new Schedules { Id = 8, WorkerId = 1, DisciplinesId = 9, TypeSchedule = TypeSchedule.Лекция };
            Schedules schedules9 = new Schedules { Id = 9, WorkerId = 1, DisciplinesId = 7, TypeSchedule = TypeSchedule.Практика };
            Schedules schedules10 = new Schedules { Id = 10, WorkerId = 1, DisciplinesId = 6, TypeSchedule = TypeSchedule.Практика };
            Schedules schedules11 = new Schedules { Id = 11, WorkerId = 1, DisciplinesId = 3, TypeSchedule = TypeSchedule.Лекция };
            Schedules schedules12 = new Schedules { Id = 12, WorkerId = 1, DisciplinesId = 5, TypeSchedule = TypeSchedule.Лекция };
            Schedules schedules13 = new Schedules { Id = 13, WorkerId = 1, DisciplinesId = 8, TypeSchedule = TypeSchedule.Практика };
            Schedules schedules14 = new Schedules { Id = 14, WorkerId = 1, DisciplinesId = 9, TypeSchedule = TypeSchedule.Практика };
            Schedules schedules15 = new Schedules { Id = 15, WorkerId = 1, DisciplinesId = 2, TypeSchedule = TypeSchedule.Лекция };
            Schedules schedules16 = new Schedules { Id = 16, WorkerId = 1, DisciplinesId = 8, TypeSchedule = TypeSchedule.Лекция };
            Schedules schedules17 = new Schedules { Id = 17, WorkerId = 1, DisciplinesId = 6, TypeSchedule = TypeSchedule.Лекция };

            //ПН
            GroupsSchedules groupsSchedules11 = new GroupsSchedules { GroupsId = 1, SchedulesId = 1};
            GroupsSchedules groupsSchedules12 = new GroupsSchedules { GroupsId = 1, SchedulesId = 2};
            GroupsSchedules groupsSchedules13 = new GroupsSchedules { GroupsId = 1, SchedulesId = 3};
            GroupsSchedules groupsSchedules14 = new GroupsSchedules { GroupsId = 1, SchedulesId = 4};

            //ВТ
            GroupsSchedules groupsSchedules15 = new GroupsSchedules { GroupsId = 1, SchedulesId = 5};
            GroupsSchedules groupsSchedules16 = new GroupsSchedules { GroupsId = 1, SchedulesId = 6};
            GroupsSchedules groupsSchedules17 = new GroupsSchedules { GroupsId = 1, SchedulesId = 8};
            GroupsSchedules groupsSchedules18 = new GroupsSchedules { GroupsId = 1, SchedulesId = 9};

            //CР
            GroupsSchedules groupsSchedules19 = new GroupsSchedules { GroupsId = 1, SchedulesId = 10};
            GroupsSchedules groupsSchedules20 = new GroupsSchedules { GroupsId = 1, SchedulesId = 11};
            GroupsSchedules groupsSchedules21 = new GroupsSchedules { GroupsId = 1, SchedulesId = 12};

            //ЧТ
            GroupsSchedules groupsSchedules22 = new GroupsSchedules { GroupsId = 1, SchedulesId = 13 };
            GroupsSchedules groupsSchedules23 = new GroupsSchedules { GroupsId = 1, SchedulesId = 14 };
            GroupsSchedules groupsSchedules24 = new GroupsSchedules { GroupsId = 1, SchedulesId = 15 };
            GroupsSchedules groupsSchedules25 = new GroupsSchedules { GroupsId = 1, SchedulesId = 7 };

            //ПТ
            GroupsSchedules groupsSchedules26 = new GroupsSchedules { GroupsId = 1, SchedulesId = 16 };
            GroupsSchedules groupsSchedules27 = new GroupsSchedules { GroupsId = 1, SchedulesId = 17 };


            //ПН
            SlotsSchedules slotsSchedules12 = new SlotsSchedules { Id = 1, SlotsId = 2, SchedulesId = 1 };
            SlotsSchedules slotsSchedules13 = new SlotsSchedules { Id = 2, SlotsId = 3, SchedulesId = 2 };
            SlotsSchedules slotsSchedules14 = new SlotsSchedules { Id = 3, SlotsId = 4, SchedulesId = 3 };
            SlotsSchedules slotsSchedules15 = new SlotsSchedules { Id = 4, SlotsId = 5, SchedulesId = 4 };

            //ВТ
            SlotsSchedules slotsSchedules21 = new SlotsSchedules { Id = 5, SlotsId = 6, SchedulesId = 5 };
            SlotsSchedules slotsSchedules22 = new SlotsSchedules { Id = 6, SlotsId = 7, SchedulesId = 6 };
            SlotsSchedules slotsSchedules23 = new SlotsSchedules { Id = 7, SlotsId = 8, SchedulesId = 8 };
            SlotsSchedules slotsSchedules24 = new SlotsSchedules { Id = 8, SlotsId = 9, SchedulesId = 9 };

            //СР
            SlotsSchedules slotsSchedules32 = new SlotsSchedules { Id = 9, SlotsId = 12, SchedulesId = 10 };
            SlotsSchedules slotsSchedules33 = new SlotsSchedules { Id = 10, SlotsId = 13, SchedulesId = 11 };
            SlotsSchedules slotsSchedules34 = new SlotsSchedules { Id = 11, SlotsId = 14, SchedulesId = 12 };

            //ЧТ
            SlotsSchedules slotsSchedules41 = new SlotsSchedules { Id = 12, SlotsId = 16, SchedulesId = 13 };
            SlotsSchedules slotsSchedules42 = new SlotsSchedules { Id = 13, SlotsId = 17, SchedulesId = 14 };
            SlotsSchedules slotsSchedules43 = new SlotsSchedules { Id = 14, SlotsId = 18, SchedulesId = 15 };
            SlotsSchedules slotsSchedules44 = new SlotsSchedules { Id = 15, SlotsId = 19, SchedulesId = 9 };
            SlotsSchedules slotsSchedules45 = new SlotsSchedules { Id = 16, SlotsId = 20, SchedulesId = 7 };

            //ПТ
            SlotsSchedules slotsSchedules51 = new SlotsSchedules { Id = 17, SlotsId = 21, SchedulesId = 16 };
            SlotsSchedules slotsSchedules52 = new SlotsSchedules { Id = 18, SlotsId = 22, SchedulesId = 17 };


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

            builder.Entity<Slots>().HasData(slot11, slot12, slot13, slot14, slot15,
                                            slot21, slot22, slot23, slot24, slot25,
                                            slot31, slot32, slot33, slot34, slot35,
                                            slot41, slot42, slot43, slot44, slot45,
                                            slot51, slot52, slot53, slot54, slot55);
            builder.Entity<Schedules>().HasData(schedules1, schedules2, schedules3, schedules4, schedules5, schedules6, schedules7, schedules8, schedules9, schedules10,
                schedules11, schedules12, schedules13, schedules14, schedules15, schedules16, schedules17);

            builder.Entity<GroupsSchedules>().HasData(groupsSchedules11, groupsSchedules12, groupsSchedules13, groupsSchedules14, groupsSchedules15
                , groupsSchedules16, groupsSchedules17, groupsSchedules18, groupsSchedules19, groupsSchedules20, groupsSchedules21, groupsSchedules22
                , groupsSchedules23, groupsSchedules24, groupsSchedules25, groupsSchedules26, groupsSchedules27);

            builder.Entity<SlotsSchedules>().HasData(
                slotsSchedules12, slotsSchedules13, slotsSchedules14,slotsSchedules15, 
                slotsSchedules21, slotsSchedules22, slotsSchedules23, slotsSchedules24,
                slotsSchedules32, slotsSchedules33, slotsSchedules34, 
                slotsSchedules41, slotsSchedules42, slotsSchedules43, slotsSchedules44, slotsSchedules45,
                slotsSchedules51, slotsSchedules52);
        }
    }
}
