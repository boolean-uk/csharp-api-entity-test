using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId });
            modelBuilder.Entity<MedicinePrescription>().HasKey(mp => new { mp.MedicineId, mp.PrescriptionId });


            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(new Patient { Id = 1, FullName = "John Doe" });
            modelBuilder.Entity<Patient>().HasData(new Patient { Id = 2, FullName = "Jane Doe" });

            modelBuilder.Entity<Doctor>().HasData(new Doctor { Id = 1, FullName = "Dr. John Doe" });
            modelBuilder.Entity<Doctor>().HasData(new Doctor { Id = 2, FullName = "Dr. Jane Doe" });
            modelBuilder.Entity<Doctor>().HasData(new Doctor { Id = 3, FullName = "Nigel" });

            modelBuilder.Entity<Medicine>().HasData(new Medicine { Id = 1, Name = "Paracetamol" });
            modelBuilder.Entity<Medicine>().HasData(new Medicine { Id = 2, Name = "Ibuprofen" });

            modelBuilder.Entity<Prescription>().HasData(new Prescription { Id = 1, AppointmentDoctorId = 1, AppointmentPatientId = 1 });
            modelBuilder.Entity<Prescription>().HasData(new Prescription { Id = 2, AppointmentDoctorId = 2, AppointmentPatientId = 1 });

            modelBuilder.Entity<MedicinePrescription>().HasData(new MedicinePrescription { MedicineId = 1, PrescriptionId = 1, Quantity = 4, Usage = "Once a day" });
            modelBuilder.Entity<MedicinePrescription>().HasData(new MedicinePrescription { MedicineId = 2, PrescriptionId = 1, Quantity = 2, Usage = "Twice a day" });
            modelBuilder.Entity<MedicinePrescription>().HasData(new MedicinePrescription { MedicineId = 1, PrescriptionId = 2, Quantity = 3, Usage = "Once a day" });
            modelBuilder.Entity<MedicinePrescription>().HasData(new MedicinePrescription { MedicineId = 2, PrescriptionId = 2, Quantity = 1, Usage = "Twice a day" });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { DoctorId = 1, PatientId = 1, AppointmentDate = DateTime.UtcNow, Type = AppointmentType.Online });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { DoctorId = 1, PatientId = 2, AppointmentDate = DateTime.UtcNow, Type = AppointmentType.Onsite });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { DoctorId = 2, PatientId = 1, AppointmentDate = DateTime.UtcNow, Type = AppointmentType.Onsite });
            modelBuilder.Entity<Appointment>().HasData(new Appointment { DoctorId = 2, PatientId = 2, AppointmentDate = DateTime.UtcNow, Type = AppointmentType.Onsite });
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
