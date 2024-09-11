using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
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
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.Id);

            // Composite key for Appointment
            modelBuilder.Entity<Appointment>()
                .HasAlternateKey(a => new { a.PatientId, a.DoctorId });
            
            //Configure appointment patient relation
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            //Configure appointment doctor relation
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.DoctorId);

            //Configure prescription relations
            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.Medicines)
                .WithMany(m => m.Prescriptions)
                .UsingEntity(j => j.ToTable("PrescriptionMedicine"));

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(p => p.AppointmentId);

            //TODO: Seed Data Here
            var patient1Id = Guid.NewGuid();
            var patient2Id = Guid.NewGuid();

            var doctor1Id = Guid.NewGuid();
            var doctor2Id = Guid.NewGuid();

            var appointment1Id = Guid.NewGuid();
            var appointment2Id = Guid.NewGuid();
            var appointment3Id = Guid.NewGuid();


            // Seed Patients
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = patient1Id, FullName = "John Doe" },
                new Patient { Id = patient2Id, FullName = "Jane Smith" }
            );

            // Seed Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = doctor1Id, FullName = "Dr. Alice Johnson" },
                new Doctor { Id = doctor2Id, FullName = "Dr. Bob Smith" }
            );

            // Seed Appointments 
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = appointment1Id, AppointmentType = Enums.AppointmentType.Online, PatientId = patient1Id, DoctorId = doctor1Id, AppointmentDate = new DateTime(2024, 10, 1, 10, 0, 0, DateTimeKind.Utc) },
                new Appointment { Id = appointment2Id , AppointmentType = Enums.AppointmentType.InPerson, PatientId = patient2Id, DoctorId = doctor2Id, AppointmentDate = new DateTime(2024, 10, 2, 11, 0, 0, DateTimeKind.Utc) },
                new Appointment { Id = appointment3Id , AppointmentType = Enums.AppointmentType.Online, PatientId = patient2Id, DoctorId = doctor1Id, AppointmentDate = new DateTime(2024, 11, 5, 11, 0, 0, DateTimeKind.Utc) }
            );

            // Seed Medicine 
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = Guid.NewGuid(), Name = "Aspirin", Quantity = 5, Notes = "Take one tablet daily." },
                new Medicine { Id = Guid.NewGuid(), Name = "Ibuprofen", Quantity = 20, Notes = "Take one tablet every 6 hours as needed." },
                new Medicine { Id = Guid.NewGuid(), Name = "Paracetamol", Quantity = 50, Notes = "Take one or two tablets every 4-6 hours as needed." }
            );

            // Seed Prescriptions 
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = Guid.NewGuid(), AppointmentId = appointment1Id },
                new Prescription { Id = Guid.NewGuid(), AppointmentId = appointment2Id } 
            );




            base.OnModelCreating(modelBuilder);
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
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
    }
}
