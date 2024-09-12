using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection.Metadata;
using workshop.wwwapi.Models.DatabaseModels;

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
                .HasKey(a => new { a.DoctorId, a.PatientId, a.Booking})
                .HasName("PK_appoitment_doctor_patient_booking");
            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointments)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId);
            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Appointments)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasKey(a => new { a.MedicineId, a.PrescriptionId })
                .HasName("PK_medicine_prescription");
            modelBuilder.Entity<Prescription>()
                .HasMany(e => e.PrescriptionMedicine)
                .WithOne(e => e.Prescription)
                .HasForeignKey(e => e.PrescriptionId);
            modelBuilder.Entity<Medicine>()
                .HasMany(e => e.PrescriptionMedicine)
                .WithOne(e => e.Medicine)
                .HasForeignKey(e => e.MedicineId);

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Prescriptions)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);

            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Prescriptions)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId);
            //TODO: Seed Data Here
            Seeder seeder = new Seeder();

            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            //modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Booking = new DateTime(2022, 04, 07).ToUniversalTime(),
                    DoctorId = 1,  // Assign the doctor's Id
                    PatientId = 1   // Assign the patient's Id
                },
                new Appointment
                {
                    Booking = new DateTime(2023, 05, 08).ToUniversalTime(),
                    DoctorId = 1,  // Assign the doctor's Id
                    PatientId = 2   // Assign the patient's Id
                },
                new Appointment
                {
                    Booking = new DateTime(2024, 06, 09).ToUniversalTime(),
                    DoctorId = 2,  // Assign the doctor's Id
                    PatientId = 1   // Assign the patient's Id
                }
            );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine
                {
                    Id = 1,
                    Name = "Pain killers"
                },
                new Medicine
                {
                    Id = 2,
                    Name = "Asthma medicine"
                }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription
                {
                    Id = 1,
                    DoctorId = 1,
                    PatientId = 1
                },
                new Prescription
                {
                    Id = 2,
                    DoctorId = 2,
                    PatientId = 1
                }
            );

            modelBuilder.Entity<PrescriptionMedicine>().HasData(
                new PrescriptionMedicine
                {
                    MedicineId = 1,
                    PrescriptionId = 1,
                    Quantity = 20,
                    Notes = "One a day"
                },
                new PrescriptionMedicine
                {
                    MedicineId = 2,
                    PrescriptionId = 1,
                    Quantity = 5,
                    Notes = "Use when short of breath"
                },
                new PrescriptionMedicine
                {
                    MedicineId = 2,
                    PrescriptionId = 2,
                    Quantity = 2,
                    Notes = "Use when short off breath"
                }
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
        public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}