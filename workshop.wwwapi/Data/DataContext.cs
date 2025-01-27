using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicinePrescription>().HasKey(mp => new { mp.MedicineId, mp.PrescriptionId });
            modelBuilder.Entity<Medicine>().HasMany(x => x.Prescriptions).WithMany(x => x.Medicines).UsingEntity<MedicinePrescription>();

            modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId });
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(p => new { p.AppointmentDoctorId, p.AppointmentPatientId })
                .OnDelete(DeleteBehavior.Cascade);

            //TODO: Seed Data Here
            Seeder seeder = new Seeder();
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
            modelBuilder.Entity<Medicine>().HasData(seeder.Medicines);
            modelBuilder.Entity<Prescription>().HasData(seeder.Prescriptions);
            modelBuilder.Entity<MedicinePrescription>().HasData(seeder.MedicinePrescriptions);
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
