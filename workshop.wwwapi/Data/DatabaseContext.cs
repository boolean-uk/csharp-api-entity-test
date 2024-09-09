using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                var connectionString = configuration.GetConnectionString("DefaultConnectionString");
                optionsBuilder.UseNpgsql(connectionString);
                optionsBuilder.LogTo(message => Debug.WriteLine(message));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.Id });

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "John Doe" },
                new Doctor { Id = 2, FullName = "Jane Doe" },
                new Doctor { Id = 3, FullName = "John Smith" },
                new Doctor { Id = 4, FullName = "Jane Smith" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Anna Drijver", Email = "annadrijver.nl", Gender = "A" },
                new Patient { Id = 2, FullName = "Tom Cruise", Email = "tomcruise.nl", Gender = "A" },
                new Patient { Id = 3, FullName = "Gerogina Verbaan", Email = "georginaverbaan.nl", Gender = "A" },
                new Patient { Id = 4, FullName = "Daan Schuurmans", Email = "daanschuurmans.nl", Gender = "A" }
            );


            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 1 },
                new Appointment { Id = 2, Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2 },
                new Appointment { Id = 3, Booking = DateTime.UtcNow, DoctorId = 3, PatientId = 3 },
                new Appointment { Id = 4, Booking = DateTime.UtcNow, DoctorId = 4, PatientId = 4 },
                new Appointment { Id = 5, Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 4 },
                new Appointment { Id = 6, Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 3 },
                new Appointment { Id = 7, Booking = DateTime.UtcNow, DoctorId = 3, PatientId = 2 },
                new Appointment { Id = 8, Booking = DateTime.UtcNow, DoctorId = 4, PatientId = 1 }
            );
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
