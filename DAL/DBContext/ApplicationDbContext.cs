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
        }
    }
}
