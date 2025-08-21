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
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here

            //modelBuilder.Entity<Appointment>().HasKey(a => new { a.AppointmentDate, a.DoctorId, a.PatientId });

            // Build in the relationships (not if decorated in the model classes)

            //TODO: Seed Data Here

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Elisabeth Røysland" },
                new Patient { Id = 2, FullName = "Hanna Olsen" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. John Smith" },
                new Doctor { Id = 2, FullName = "Dr. Jane Doe" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, AppointmentDate = DateTime.SpecifyKind(new DateTime(2025, 10, 1, 10, 0, 0), DateTimeKind.Utc), DoctorId = 1, PatientId = 1 },
                new Appointment { Id = 2, AppointmentDate = DateTime.SpecifyKind(new DateTime(2025, 10, 2, 11, 0, 0), DateTimeKind.Utc), DoctorId = 1, PatientId = 1 },
                new Appointment { Id = 3, AppointmentDate = DateTime.SpecifyKind(new DateTime(2025, 10, 1, 10, 0, 0), DateTimeKind.Utc), DoctorId = 2, PatientId = 2 },
                new Appointment { Id = 4, AppointmentDate = DateTime.SpecifyKind(new DateTime(2025, 10, 3, 12, 0, 0), DateTimeKind.Utc), DoctorId = 2, PatientId = 1 }
            );
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
