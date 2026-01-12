using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //TODO: Seed Data Here - i have hardcoded two patients in the database
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Lionel Messi" },
                new Patient { Id = 2, FullName = "Cristiano Ronaldo" }
            );

            // Seed two doctors in the database
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Arsene Wenger" },
                new Doctor { Id = 2, FullName = "Dr. Alex Ferguson" }
            );

            // Seed 4 appointments in the database
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, PatientId = 1, DoctorId = 1, Booking = DateTime.UtcNow.AddDays(1) },
                new Appointment { Id = 2, PatientId = 1, DoctorId = 2, Booking = DateTime.UtcNow.AddDays(2) },
                new Appointment { Id = 3, PatientId = 2, DoctorId = 1, Booking = DateTime.UtcNow.AddDays(3) },
                new Appointment { Id = 4, PatientId = 2, DoctorId = 2, Booking = DateTime.UtcNow.AddDays(4) }
            );
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
