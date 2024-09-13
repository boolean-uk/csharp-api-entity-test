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
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<MedicineOnPrescription>().HasKey(p => new { p.MedicineId, p.PrescriptionId });
            
            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Brian Murphy" },
                new Patient() { Id = 2, FullName = "Emily Axford" },
                new Patient() { Id = 3, FullName = "Lou Wilson"}
                );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Ben Doyle" },
                new Doctor() { Id = 2, FullName = "Adam Chase" }
                );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { Id = 1, Booking = new DateTime(2024, 9, 15, 9, 15, 0, DateTimeKind.Utc), Type = AppointmentType.InPerson, DoctorId = 1, PatientId = 2 },
                new Appointment() { Id = 2, Booking = new DateTime(2024, 11, 1, 13, 0, 0, DateTimeKind.Utc), Type = AppointmentType.Online, DoctorId = 2, PatientId = 1 }
                );
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine() { Id = 1, Name = "Olanzapin" },
                new Medicine() { Id = 2, Name = "Aripiprazole" },
                new Medicine() { Id = 3, Name = "Kvetiapin" }
                );
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription() { Id = 1, AppointmentId = 1},
                new Prescription() { Id = 2, AppointmentId = 2}
                );
            modelBuilder.Entity<MedicineOnPrescription>().HasData(
                new MedicineOnPrescription() { MedicineId = 3, PrescriptionId = 1, DoseInMg = 25, Instruction = "PRN, maxium once a day" },
                new MedicineOnPrescription() { MedicineId = 2, PrescriptionId = 2, DoseInMg = 15, Instruction = "Take every morning, consult with doctor before ending treatment" }
                );

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
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicineOnPrescription> MedicineOnPrescriptions { get; set; }
    }
}
