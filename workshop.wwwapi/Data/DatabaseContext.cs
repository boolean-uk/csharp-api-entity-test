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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); 
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define composite key
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.Booking, a.DoctorId, a.PatientId });
            modelBuilder.Entity<MedicinePrescription>().HasKey(mp => new { mp.MedicineId, mp.PrescriptionId });
            modelBuilder.Entity<Prescription>().HasMany(p => p.Appointments).WithOne(a => a.Prescription).HasForeignKey(a => a.PrescriptionId);
            

            //Seed Doctors data
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. John Doe" },
                new Doctor { Id = 2, FullName = "Dr. Max Larsson" }
            );

            // Seed Patients data
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Mattias Eriksson" },
                new Patient { Id = 2, FullName = "Erik Jokabsson" }
            );

            DateTime utc = DateTime.Now.ToUniversalTime();
            // Seed Appointments data
            var appointments = new Appointment[]
            {
                new Appointment { Booking = utc, Type = "Checkup", DoctorId = 1, PatientId = 1, PrescriptionId = 1 },
                new Appointment { Booking = utc, Type = "Online", DoctorId = 2, PatientId = 2, PrescriptionId = 2 }
            };

            // Seed Prescriptions data
            var prescriptions = new Prescription[]
            {
                new Prescription { Id = 1, Quantity = 10, Notes = "Take 1 pill every 8 hours" },
                new Prescription { Id = 2, Quantity = 20, Notes = "Take 1 pill every 12 hours" }
            };

            // Seed Medicines data
            var medicines = new Medicine[]
            {
                new Medicine { Id = 1, Name = "Paracetamol" },
                new Medicine { Id = 2, Name = "Ibuprofen" }
            };

            // Seed MedicinePrescriptions data
            var medicinePrescriptions = new MedicinePrescription[]
            {
                new MedicinePrescription { Id = 1, MedicineId = 1, PrescriptionId = 1 },
                new MedicinePrescription { Id = 2, MedicineId = 2, PrescriptionId = 2 }
            };

            modelBuilder.Entity<Prescription>().HasData(prescriptions);

            modelBuilder.Entity<Medicine>().HasData(medicines);

            modelBuilder.Entity<Appointment>().HasData(appointments);

            modelBuilder.Entity<MedicinePrescription>().HasData(medicinePrescriptions);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
