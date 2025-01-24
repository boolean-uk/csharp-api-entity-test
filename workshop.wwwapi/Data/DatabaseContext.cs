using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Id = 1,
                    PatientId = 1,
                    DoctorId = 1,
                    AppointmentDateTime = DateTime.SpecifyKind(new DateTime(2025, 2, 15, 9, 0, 0), DateTimeKind.Utc)
                },
                new Appointment
                {
                    Id = 2,
                    PatientId = 2,
                    DoctorId = 2,
                    AppointmentDateTime = DateTime.SpecifyKind(new DateTime(2025, 2, 16, 10, 30, 0), DateTimeKind.Utc)
                }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FirstName = "Alexander", LastName = "Solberg" },
                new Doctor { Id = 2, FirstName = "Hermine", LastName = "Aasheim" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FirstName = "Mattis", LastName = "Henriksen" },
                new Patient { Id = 2, FirstName = "Mathilde", LastName = "Larsen" }
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }

        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
    }
}
