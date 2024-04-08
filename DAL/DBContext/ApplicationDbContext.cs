using DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


namespace DAL.DbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        //    : base(options) 
        //{

        //}
        public ApplicationDbContext()
        {

        }

        DbSet<Faculty> Faculty { get; set; }
        DbSet<Department> Departments { get; set; }
        DbSet<Groups> Groups { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Worker> Workers { get; set; }
        DbSet<Disciplines> Disciplines { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<Slots> Slots { get; set; }
        DbSet<SlotsSchedules> SlotsShedules { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=ElectronicMagazineDataBasec;Database=ElectronicMagazineDataBasec;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Groups>().HasMany(x => x.Schedules).WithMany(x => x.Groups);         
            base.OnModelCreating(builder);
        }
    }
}
