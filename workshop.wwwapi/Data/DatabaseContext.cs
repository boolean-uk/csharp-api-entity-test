using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Globalization;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().
                HasKey(p => new { p.PatientId, p.DoctorId });
            
            modelBuilder.Entity<Prescription>().
                HasKey(p => new { p.Id });

            modelBuilder.Entity <MedicinesInPrescription>().
                HasKey(p => new { p.MedicineId, p.PrescriptionId});

            modelBuilder.Entity<Appointment>(). // Entity is Appointment
                //HasOne<Doctor>().             // Note: if no navigation properties are used: Define relation type with generic
                HasOne(p => p.Doctor).          // Each Entry has exactly One Doctor
                WithMany(p => p.Appointments).  // where the Doctor has a list of Appointments
                HasForeignKey(p => p.DoctorId); // Each of the Doctors Appointments stores a foreign key that references the Doctor

            
            modelBuilder.Entity<Appointment>().
                HasOne(p => p.Patient).
                WithMany(pa => pa.Appointments).
                HasForeignKey(ap => ap.PatientId);

            modelBuilder.Entity<Prescription>().
                HasOne(p => p.Patient).
                WithMany(p => p.Prescriptions).
                HasForeignKey(p => p.PatientId);
            
            modelBuilder.Entity<Prescription>().
                HasOne(p => p.Doctor).
                WithMany(p => p.Prescriptions).
                HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<Prescription>().
                HasMany(p => p.MedicinesInPrescription).
                WithOne(p => p.Prescription).
                HasForeignKey(p => p.MedicineId);
            
            modelBuilder.Entity<Prescription>().
                HasMany(p => p.MedicinesInPrescription).
                WithOne(p => p.Prescription).
                HasForeignKey(p => p.PrescriptionId);

            modelBuilder.Entity<MedicinesInPrescription>().
                HasOne(p => p.Medicine).
                WithMany(p => p.MedicinesInPrescriptions).
                HasForeignKey(p => p.MedicineId);
            
            modelBuilder.Entity<MedicinesInPrescription>().
                HasOne(p => p.Prescription).
                WithMany(p => p.MedicinesInPrescription).
                HasForeignKey(p => p.PrescriptionId);

            //Seed Data Here
            var seeder = new Seeder(false);
            modelBuilder.Entity<Patient>().
                HasData(seeder.Patients);

            modelBuilder.Entity<Doctor>().
                HasData(seeder.Doctors);

            modelBuilder.Entity<Appointment>().
                HasData(seeder.Appointments);
            
            modelBuilder.Entity<Prescription>().
                HasData(seeder.Prescriptions);

            modelBuilder.Entity<MedicinesInPrescription>().
                HasData(seeder.Medicines_in_presccription);

            modelBuilder.Entity <Medicine>().
                HasData(seeder.Medicines);

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
