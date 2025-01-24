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
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite key for Appointment
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId });

            // Define relationships for Appointment
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            // Seed data for Patients
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Smith" },
                new Patient { Id = 3, FullName = "Alice Johnson" }
            );

            // Seed data for Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Emily Carter" },
                new Doctor { Id = 2, FullName = "Dr. Michael Brown" }
            );

            // Seed data for Appointments
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { DoctorId = 1, PatientId = 1, Booking = new DateTime(2025, 1, 25, 10, 0, 0) },
                new Appointment { DoctorId = 1, PatientId = 2, Booking = new DateTime(2025, 1, 25, 11, 0, 0) },
                new Appointment { DoctorId = 2, PatientId = 3, Booking = new DateTime(2025, 1, 25, 12, 0, 0) },
                new Appointment { DoctorId = 2, PatientId = 1, Booking = new DateTime(2025, 1, 26, 9, 0, 0) },
                new Appointment { DoctorId = 1, PatientId = 3, Booking = new DateTime(2025, 1, 26, 10, 0, 0) }
            );
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured) { 
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            }
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
