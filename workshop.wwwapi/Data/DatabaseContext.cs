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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite key
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.Booking, a.DoctorId, a.PatientId });
            

            //Seed Doctors data
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. John Doe" },
                new Doctor { Id = 2, FullName = "Dr. Max Larsson" }
            );

            // Seed Patients data
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Mattias Eriksson" },
                new Patient { Id = 2, FullName = "Erik Jokabsson" }
            );

            DateTime utc = DateTime.Now.ToUniversalTime();
            // Seed Appointments data
            var appointments = new Appointment[]
            {
                new Appointment { Booking = utc, DoctorId = 1, PatientId = 1 },
                new Appointment { Booking = utc, DoctorId = 1, PatientId = 2 },
                new Appointment { Booking = utc, DoctorId = 2, PatientId = 1 },
                new Appointment { Booking = utc, DoctorId = 2, PatientId = 2 }
            };

            modelBuilder.Entity<Appointment>().HasData(appointments);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
