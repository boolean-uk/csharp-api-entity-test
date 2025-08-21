using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
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
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(aKey => new {aKey.PatientId, aKey.DoctorId});
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Ola Nordmann" },
                new Patient { Id = 2, FullName = "Kari Nordmann" });
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Kari Doctor" },
                new Doctor { Id = 2, FullName = "Jens Doctor" }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Booking = DateTime.Parse("2025-08-20 14:21:37").ToUniversalTime(), DoctorId = 1, PatientId = 1},
                new Appointment { Booking = DateTime.Parse("2025-08-20 14:21:37").ToUniversalTime(), DoctorId = 2, PatientId = 1 },
                new Appointment { Booking = DateTime.Parse("2025-08-20 14:21:37").ToUniversalTime(), DoctorId = 2, PatientId = 2 });

            //TODO: Seed Data Here

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
