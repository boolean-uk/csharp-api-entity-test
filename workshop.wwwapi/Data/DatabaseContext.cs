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
          
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Doctor doctor2 = new Doctor { Id = 2, FullName = "Dr. Jane Doe" };
            Patient patient2 = new Patient { Id = 2, FullName = "John Doe" };
            Doctor doctor = new Doctor { Id = 1, FullName = "Dr. John Doe" };
            Patient patient = new Patient { Id = 1, FullName = "Jane Doe" };
            Appointment appointment = new Appointment { Id = 1, Booking = DateTime.UtcNow, DoctorId = doctor.Id, PatientId = patient.Id };
            Appointment appointment2 = new Appointment { Id = 2, Booking = DateTime.UtcNow, DoctorId = doctor2.Id, PatientId = patient2.Id };

            modelBuilder.Entity<Doctor>().HasData(doctor, doctor2);
            modelBuilder.Entity<Patient>().HasData(patient, patient2);  
            modelBuilder.Entity<Appointment>().HasData(appointment, appointment2);


        }
   


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
