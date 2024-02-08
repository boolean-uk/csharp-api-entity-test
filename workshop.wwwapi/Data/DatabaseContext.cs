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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here

            modelBuilder.Entity<Appointment>().HasAlternateKey(e => new { e.Booking, e.PatientId, e.DoctorId });
            if(false)
            {
                modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Prescription)
                .WithOne(p => p.Appointment)
                .HasForeignKey<Prescription>(p => p.AppointmentId);
            }

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Joe" },
                new Patient() { Id = 2, FullName = "Jane" }

                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Doctor Bob" },
                new Doctor() { Id = 2, FullName = "Doctor Lisa" }

                );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() {Id= 1, Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 2 },
                new Appointment() {Id = 2,  Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 1 },
                new Appointment() {Id = 3, Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2 }

                );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription() { Id = 1, AppointmentId = 1 },
                new Prescription() { Id = 2, AppointmentId = 2 },
                new Prescription() { Id = 3, AppointmentId = 3 }

                );


            modelBuilder.Entity<Medicine>().HasData(
            new Medicine() { Id = 1, Name = "Ibuprofen", Note = "Against Pain, take twice", Quantity = 5 },
            new Medicine() { Id = 2, Name = "Melatonin", Note = "For sleep, take 2 hour before bed", Quantity = 100 },
            new Medicine() { Id = 3, Name = "Treo", Note = "For fever and pain, take every 4-6 hours", Quantity = 50 },
            new Medicine() { Id = 4, Name = "Pencillin", Note = "Antibiotic for infection, take three times a day", Quantity = 30 }



            );

            modelBuilder.Entity<Medicine>()
                .HasMany(p => p.Prescriptions)
                .WithMany(p => p.Medicines)
                .UsingEntity(j => j.HasData(
                    new {PrescriptionsId = 1, MedicinesId=1},
                    new {PrescriptionsId = 1, MedicinesId=2},
                    new {PrescriptionsId = 1, MedicinesId=4},
                    new {PrescriptionsId = 2, MedicinesId=3},
                    new {PrescriptionsId = 2, MedicinesId=1},
                    new {PrescriptionsId = 3, MedicinesId=2}
                    ));
            

            //TODO: Seed Data Here
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}