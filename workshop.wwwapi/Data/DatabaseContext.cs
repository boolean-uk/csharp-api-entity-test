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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relations:
            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.PrescribedMedicineList)
                .WithOne(pm => pm.Prescription)
                .HasForeignKey(pm => pm.PrescriptionId);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Doctor)
                .WithMany()
                .HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Patient)
                .WithMany()
                .HasForeignKey(p => p.PatientId);

            // PK's
            modelBuilder.Entity<Prescription>().HasKey(p => p.Id);
            modelBuilder.Entity<Medicine>().HasKey(m => m.Id);
            modelBuilder.Entity<PrescribedMedicine>().HasKey(pm => pm.Id);
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId, a.Booking });

            //TODO: Seed Data Here
            List<Medicine> medicines = new List<Medicine>
            {
                new Medicine { Id = 1, Name = "Bugfixol", Quantity = 50, Mg = 10 },
                new Medicine { Id = 2, Name = "Patchorix", Quantity = 90, Mg = 30 },
                new Medicine { Id = 3, Name = "Syntaxol", Quantity = 100, Mg = 15 },
                new Medicine { Id = 4, Name = "Compilex", Quantity = 20, Mg = 500 },
                new Medicine { Id = 5, Name = "PolyMorphix", Quantity = 40, Mg = 5 },
                new Medicine { Id = 6, Name = "LambdaRelief", Quantity = 90, Mg = 32 },
                new Medicine { Id = 7, Name = "Inheritex", Quantity = 60, Mg = 100 },
                new Medicine { Id = 8, Name = "Reactabool Forte", Quantity = 10, Mg = 1000 }
             };

            List<Patient> patients = new List<Patient>
            {
                new Patient { Id = 1, FirstName = "John", LastName = "Doe" },
                new Patient { Id = 2, FirstName = "Jane", LastName = "Dough" },
                new Patient { Id = 3, FirstName = "Hughie", LastName = "Dodson" }
            };

            List<Doctor> doctors = new List<Doctor>
            {
                new Doctor { Id = 1, FirstName = "Hannibal", LastName = "Lecter" },
                new Doctor { Id = 2, FirstName = "Henry", LastName = "Jones Jr." },
                new Doctor { Id = 3, FirstName = "Davy", LastName = "Jones" }
            };

            List<Appointment> appointments = new List<Appointment>
            {
                new Appointment { Booking = new DateTime(2024, 09, 14, 14, 30, 00).ToUniversalTime(), DoctorId = 1, PatientId = 1 },
                new Appointment { Booking = new DateTime(2024, 09, 14, 15, 30, 00).ToUniversalTime(), DoctorId = 2, PatientId = 2 },
                new Appointment { Booking = new DateTime(2024, 09, 14, 16, 30, 00).ToUniversalTime(), DoctorId = 3, PatientId = 3 },
                new Appointment { Booking = new DateTime(2024, 09, 14, 15, 30, 00).ToUniversalTime(), DoctorId = 1, PatientId = 3 },
                new Appointment { Booking = new DateTime(2024, 09, 14, 15, 30, 00).ToUniversalTime(), DoctorId = 2, PatientId = 3 },
                new Appointment { Booking = new DateTime(2024, 09, 14, 16, 30, 00).ToUniversalTime(), DoctorId = 3, PatientId = 1 },
                new Appointment { Booking = new DateTime(2024, 09, 14, 16, 30, 00).ToUniversalTime(), DoctorId = 1, PatientId = 2 },
                new Appointment { Booking = new DateTime(2024, 09, 14, 16, 30, 00).ToUniversalTime(), DoctorId = 2, PatientId = 1 },
                new Appointment { Booking = new DateTime(2024, 09, 14, 16, 30, 00).ToUniversalTime(), DoctorId = 3, PatientId = 2 }
            };

            // Seeding
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Appointment>().HasData(appointments);
            modelBuilder.Entity<Medicine>().HasData(medicines);


            modelBuilder.Entity<PrescribedMedicine>().HasData(
                new PrescribedMedicine { Id = 1, MedicineName = "Patchorix", Instructions = "Take 1 before each TestRun", Amount = 2, PrescriptionId = 1 },
                new PrescribedMedicine { Id = 2, MedicineName = "Syntaxol", Instructions = "Take 2 before and 5 after deploying patch. Double amount if its friday", Amount = 1, PrescriptionId = 1 },
                new PrescribedMedicine { Id = 3, MedicineName = "Compilex", Instructions = "Take as needed", Amount = 1, PrescriptionId = 1 },

                new PrescribedMedicine { Id = 4, MedicineName = "Bugfixol", Instructions = "Take 1 after deployment", Amount = 1, PrescriptionId = 2 },
                new PrescribedMedicine { Id = 5, MedicineName = "Patchorix", Instructions = "Take 1 daily", Amount = 1, PrescriptionId = 2 },
                new PrescribedMedicine { Id = 6, MedicineName = "LambdaRelief", Instructions = "Take as reward when writing lambda functions", Amount = 2, PrescriptionId = 2 },

                new PrescribedMedicine { Id = 7, MedicineName = "Syntaxol", Instructions = "Take 1 when forgetting LINQ syntax", Amount = 1, PrescriptionId = 3 },
                new PrescribedMedicine { Id = 8, MedicineName = "Compilex", Instructions = "Take 2 when compiling fails", Amount = 2, PrescriptionId = 3 },
                new PrescribedMedicine { Id = 9, MedicineName = "PolyMorphix", Instructions = "Take with food, or drink, or rub on skin", Amount = 1, PrescriptionId = 3 },

                new PrescribedMedicine { Id = 10, MedicineName = "LambdaRelief", Instructions = "Take as reward when writing lambda functions", Amount = 1, PrescriptionId = 4 },
                new PrescribedMedicine { Id = 11, MedicineName = "Inheritex", Instructions = "Take 2 when using abstract classes", Amount = 2, PrescriptionId = 4 },
                new PrescribedMedicine { Id = 12, MedicineName = "Reactabool Forte", Instructions = "Take 1 and brace for frontend week!", Amount = 1, PrescriptionId = 4 }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, DoctorId = 1, PatientId = 2 },
                new Prescription { Id = 2, DoctorId = 1, PatientId = 1 },
                new Prescription { Id = 3, DoctorId = 1, PatientId = 3 },
                new Prescription { Id = 4, DoctorId = 2, PatientId = 1 }
            );

        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescribedMedicine> PrescribedMedicines { get; set; }
    }
}
