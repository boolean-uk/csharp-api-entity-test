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
            // this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<Prescription>()
                .HasMany(e => e.Medicines)
                .WithMany(e => e.Prescriptions)
                .UsingEntity<MedicinePrescription>();

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FirstName = "Saul", LastName = "Hudson" },
                new Patient() { Id = 2, FirstName = "Axl", LastName = "Rose" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, Name = "Dr. House" },
                new Doctor() { Id = 2, Name = "Dr. Phil" }
            );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine() { Id = 1, Name = "Paracetamol", Instruction = "1-2 pills maximum every day", Quantity = 10 },
                new Medicine() { Id = 2, Name = "Ibuprofen", Instruction = "2 pills maximum every day", Quantity = 5 }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription() { Id = 1 },
                new Prescription() { Id = 2 }
            );

            modelBuilder.Entity<MedicinePrescription>().HasData(
                new MedicinePrescription() { MedicineId = 2, PrescriptionId = 1 },
                new MedicinePrescription() { MedicineId = 1, PrescriptionId = 1 },
                new MedicinePrescription() { MedicineId = 1, PrescriptionId = 2 }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment()
                {
                    AppointmentDate = DateTime.Parse("2024/10/12"),
                    DoctorId = 1,
                    PatientId = 1,
                    PrescriptionId = 1,
                    AppointmentType = AppointmentType.Digital
                },
                new Appointment()
                {
                    AppointmentDate = DateTime.Parse("2024/10/14"),
                    DoctorId = 2,
                    PatientId = 2,
                    PrescriptionId = 2,
                    AppointmentType = AppointmentType.Physical
                }
            );
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
