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
        DbSet<Students> Students { get; set; }
        DbSet<Workers> Workers { get; set; }
        DbSet<Disciplines> Disciplines { get; set; }
        DbSet<Schedules> Schedules { get; set; }
        DbSet<Slots> Slots { get; set; }
        DbSet<SlotsSchedules> SlotsSchedules { get;set;}
        DbSet<Pairs> Pairs { get; set; }
        DbSet<Marks> Marks { get; set; }
        
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
        }
    }
}
