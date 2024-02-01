using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed Patients Data
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Doe" }
            );

            // modelBuilder.Entity<Appointment>().HasKey(a => a.AppointmentId);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }

        public DbSet<Patient> Patients { get; set; }
        //public DbSet<Doctor> Doctors { get; set; }
        //public DbSet<Appointment> Appointments { get; set; }
    }
}
