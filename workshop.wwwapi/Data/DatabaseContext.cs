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
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<MedicinePrescription>()
                .HasKey(mp => new { mp.PrescriptionId, mp.MedicineId });

            modelBuilder.Entity<MedicinePrescription>()
                .HasOne(mp => mp.Prescription)
                .WithMany(p => p.MedicinePrescriptions)
                .HasForeignKey(mp => mp.PrescriptionId);

            modelBuilder.Entity<MedicinePrescription>()
                .HasOne(mp => mp.Medicine)
                .WithMany(m => m.MedicinePrescriptions)
                .HasForeignKey(mp => mp.MedicineId);

            modelBuilder.Entity<Prescription>().HasKey(p => p.Id);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(p => new { p.DoctorId, p.PatientId });
            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Dennis" },
                new Patient() { Id = 2, FullName = "Thomas" },
                new Patient() { Id = 3, FullName = "Ali" },
                new Patient() { Id = 4, FullName = "Melvin" }


                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Doctor Osmani" },
                new Doctor() { Id = 2, FullName = "Doctor Flier" }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(30), DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(60), DoctorId = 2, PatientId = 3 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(60), DoctorId = 2, PatientId = 1 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(60), DoctorId = 1, PatientId = 1 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(45), DoctorId = 2, PatientId = 4 }
                );

            modelBuilder.Entity<Medicine>().HasData(
                new Medicine() { Id = 1, Name = "Aspirin" },
                new Medicine() { Id = 2, Name = "Ibuprofen" }
                );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription() { Id = 1, DoctorId = 1, PatientId = 2 },
                new Prescription() { Id = 2, DoctorId = 2, PatientId = 1 }
                );

            modelBuilder.Entity<MedicinePrescription>().HasData(
                new MedicinePrescription() { MedicineId = 1, PrescriptionId = 1, Quantity = 10, Notes = "Take one daily" },
                new MedicinePrescription() { MedicineId = 2, PrescriptionId = 2, Quantity = 30, Notes = "Take three daily" }
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
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
