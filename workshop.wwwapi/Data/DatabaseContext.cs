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
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Appointment Key etc. Add Here
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId });

            // Seed Data Here
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Doofenschmirtz" },
                new Doctor { Id = 2, FullName = "Dr. Dre" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Gandalf The Gray" },
                new Patient { Id = 2, FullName = "Homer Simpson" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { DoctorId = 1, PatientId = 1, Booking = new DateTime(2024, 9, 7, 10, 0, 0) },
                new Appointment { DoctorId = 1, PatientId = 2, Booking = new DateTime(2024, 9, 8, 11, 0, 0) },
                new Appointment { DoctorId = 2, PatientId = 1, Booking = new DateTime(2024, 9, 7, 13, 30, 0) },
                new Appointment { DoctorId = 2, PatientId = 2, Booking = new DateTime(2024, 9, 8, 9, 0, 0) }
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
