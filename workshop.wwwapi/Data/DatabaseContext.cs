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

            modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId });
            modelBuilder.Entity<PrescriptionMedicine>().HasKey(p => new { p.PrescriptionId, p.MedicineId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(new List<Patient>()
            {
                new Patient(){ Id = 1, FullName = "Sebastian Engan"},
                new Patient(){ Id = 2, FullName = "Nigel Sips"}
            });
            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
            {
                new Doctor(){ Id = 1, FullName = "Gudbrand Dynna"},
                new Doctor(){ Id = 2, FullName = "Louis Shresta"}
            });
            modelBuilder.Entity<Appointment>().HasData(new List<Appointment>()
            {
                new Appointment(){ DoctorId = 1, PatientId = 1, DateTime = DateTime.UtcNow },
                new Appointment(){ DoctorId = 1, PatientId = 2, DateTime = DateTime.UtcNow },
                new Appointment(){ DoctorId = 2, PatientId = 1, DateTime = DateTime.UtcNow }
            });
            modelBuilder.Entity<Medicine>().HasData(new List<Medicine>()
            {
                new Medicine(){ Id = 1, Name = "Sugar", Instructions = "Eat regularly to prevent diabetes."}, 
                new Medicine(){ Id = 2, Name = "Ibuxprofen", Instructions = "Eat to prevent headaches."}
            });
            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
            {
                new Prescription(){ Id = 1, DoctorId = 1, PatientId = 1, Description = "Limit intake to 1 per day."}
            });
            modelBuilder.Entity<PrescriptionMedicine>().HasData(new List<PrescriptionMedicine>()
            {
                new PrescriptionMedicine(){ MedicineId = 1, PrescriptionId = 1 },
                new PrescriptionMedicine(){ MedicineId = 2, PrescriptionId = 1 }
            });

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
        public DbSet<PrescriptionMedicine> PrescriptionsMedicines { get; set; }
    }
}
