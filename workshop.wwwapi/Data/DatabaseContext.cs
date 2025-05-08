using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here

            // Define composite primary keys
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasKey(pm => new { pm.PrescriptionId, pm.MedicineId });

            // Define relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithOne(a => a.Prescription)
                .HasForeignKey<Prescription>(p => new { p.PatientId, p.DoctorId }) 
                .HasPrincipalKey<Appointment>(a => new { a.PatientId, a.DoctorId }); 


            modelBuilder.Entity<PrescriptionMedicine>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicines)
                .HasForeignKey(pm => pm.PrescriptionId);

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasOne(pm => pm.Medicine)
                .WithMany(m => m.PrescriptionMedicines)
                .HasForeignKey(pm => pm.MedicineId);

            //TODO: Seed Data Here

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Smith" },
                new Patient { Id = 3, FullName = "Alice Johnson" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. House" },
                new Doctor { Id = 2, FullName = "Dr. Grey" },
                new Doctor { Id = 3, FullName = "Dr. Wilson" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { PatientId = 1, DoctorId = 1, Booking = new DateTime(2024, 1, 1, 10, 0, 0, DateTimeKind.Utc), AppointmentType = AppointmentType.InPerson },
                new Appointment { PatientId = 2, DoctorId = 2, Booking = new DateTime(2024, 1, 2, 14, 0, 0, DateTimeKind.Utc), AppointmentType = AppointmentType.Online },
                new Appointment { PatientId = 3, DoctorId = 3, Booking = new DateTime(2024, 1, 3, 9, 30, 0, DateTimeKind.Utc), AppointmentType = AppointmentType.InPerson }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, PatientId = 1, DoctorId = 1 },
                new Prescription { Id = 2, PatientId = 2, DoctorId = 2 },
                new Prescription { Id = 3, PatientId = 3, DoctorId = 3 }
            );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Paracetamol", Description = "Pain relief" },
                new Medicine { Id = 2, Name = "Ibuprofen", Description = "Anti-inflammatory" },
                new Medicine { Id = 3, Name = "Amoxicillin", Description = "Antibiotic" }
            );

            modelBuilder.Entity<PrescriptionMedicine>().HasData(
                new PrescriptionMedicine { PrescriptionId = 1, MedicineId = 1, Quantity = 2, Notes = "Take with food" },
                new PrescriptionMedicine { PrescriptionId = 1, MedicineId = 2, Quantity = 1, Notes = "Take once daily" },
                new PrescriptionMedicine { PrescriptionId = 2, MedicineId = 3, Quantity = 3, Notes = "Finish entire course" },
                new PrescriptionMedicine { PrescriptionId = 3, MedicineId = 2, Quantity = 1, Notes = "Take every 8 hours" } // ✅ Fix: Ensure All Prescription IDs Exist
            );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
