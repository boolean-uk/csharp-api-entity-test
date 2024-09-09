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
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.Booking, a.PatientId, a.DoctorId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.Medicines)
                .WithMany(m => m.Prescriptions)
                .UsingEntity(mp => mp.ToTable("medicinePrescription"));

            modelBuilder.Entity<Medicine>()
                .HasMany(m => m.Prescriptions)
                .WithMany(p => p.Medicines)
                .UsingEntity(mp => mp.ToTable("medicinePrescription"));

            modelBuilder.Entity<MedicinePrescription>()
                .HasKey(mp => mp.Id);

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Nigel" },
                new Patient() { Id = 2, FullName = "Jonas" }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Doctor Jekyll" },
                new Doctor() { Id = 2, FullName = "Doctor Hyde" }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(30), DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(60), DoctorId = 2, PatientId = 1 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(45), DoctorId = 2, PatientId = 1 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(90), DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(20), DoctorId = 2, PatientId = 1 }
                );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine() { Id = 1, Name = "Paracetamol", Quantity = 25, Instructions = "Take up to two times a day",
                    Prescriptions = MedicinesPrescriptions.Where(mp => mp.MedicineId == 1).SelectMany(mp => Prescriptions.Where(p => p.Id == mp.PrescriptionId)).ToList() },
                new Medicine() { Id = 2, Name = "Ibux", Quantity = 5, Instructions = "Take one a day",
                    Prescriptions = MedicinesPrescriptions.Where(mp => mp.MedicineId == 2).SelectMany(mp => Prescriptions.Where(p => p.Id == mp.PrescriptionId)).ToList() }
                );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription() { Id = 1 },
                new Prescription() { Id = 2 }
                );

            modelBuilder.Entity<MedicinePrescription>().HasData(
                new MedicinePrescription() { Id = 1, MedicineId =, PrescriptionId = },
                new MedicinePrescription() { Id = 2, MedicineId =, PrescriptionId = }
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
        public DbSet<MedicinePrescription> MedicinesPrescriptions { get; set; }
    }
}
