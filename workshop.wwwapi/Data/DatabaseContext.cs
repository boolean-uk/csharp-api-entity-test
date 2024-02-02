using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Intermediaries;

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
            // Patient
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Doe" }
            );

            // Doctor
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Smith" },
                new Doctor { Id = 2, FullName = "Dr. Johnson" }
            );

            // Appointment
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { PatientId = 1, DoctorId = 1, Booking = DateTime.UtcNow },
                new Appointment { PatientId = 2, DoctorId = 1, Booking = DateTime.UtcNow.AddDays(1) },
                new Appointment { PatientId = 1, DoctorId = 2, Booking = DateTime.UtcNow.AddDays(2) },
                new Appointment { PatientId = 2, DoctorId = 2, Booking = DateTime.UtcNow.AddDays(3) }
            );

            // Prescription and Medication
            modelBuilder.Entity<PrescriptionMedicine>()
                .HasKey(pm => new { pm.PrescriptionId, pm.MedicineId });

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicines)
                .HasForeignKey(pm => pm.PrescriptionId);

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasOne(pm => pm.Medicine)
                .WithMany(m => m.PrescriptionMedicines)
                .HasForeignKey(pm => pm.MedicineId);

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Medicine A", Quantity = 10, Notes = "Take once daily" },
                new Medicine { Id = 2, Name = "Medicine B", Quantity = 20, Notes = "Take twice daily" }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, AppointmentId = 1 },
                new Prescription { Id = 2, AppointmentId = 2 }
            );

            modelBuilder.Entity<PrescriptionMedicine>().HasData(
                new PrescriptionMedicine { PrescriptionId = 1, MedicineId = 1 },
                new PrescriptionMedicine { PrescriptionId = 1, MedicineId = 2 },
                new PrescriptionMedicine { PrescriptionId = 2, MedicineId = 1 }
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
