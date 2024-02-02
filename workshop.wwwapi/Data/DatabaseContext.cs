using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection.Metadata;
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
            // Appointment entity with composite key
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId })
                .HasName("PK_appointment_doctor_patient");

            // MedicinePrescription entity with composite key
            modelBuilder.Entity<MedicinePrescription>()
                .HasKey(a => new { a.PrescriptionId, a.MedicineId })
                .HasName("PK_medicineprescription_prescription_medicine");

            // Define foreign key relationship between Appointment and Prescription using Appointment.PrescriptionId
            modelBuilder.Entity<Appointment>()
                .HasOne<Prescription>()
                .WithMany()
                .HasForeignKey(a => a.PrescriptionId);

            // Seeded data
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Smith" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Heinz Doofenshmirtz" },
                new Doctor { Id = 2, FullName = "Dr Johnny" }
            );
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine {Id = 1, Name = "Paracetamol" },
                new Medicine {Id = 2, Name = "SleepEase Xtra" },
                new Medicine {Id = 3, Name = "Energix Boost" },
                new Medicine {Id = 4, Name = "FocusPlus Capsules" },
                new Medicine { Id = 5, Name = "Calmify Syrup",  },
                new Medicine { Id = 6, Name = "JointFlex Gel",}
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1 },
                new Prescription { Id = 2 },
                new Prescription { Id = 3 }
            
                );
            modelBuilder.Entity<MedicinePrescription>().HasData(
                new MedicinePrescription { MedicineId = 1, PrescriptionId = 1, Notes = "two a day", Quantity = 8 },
                new MedicinePrescription { MedicineId = 2, PrescriptionId = 1, Notes = "before bedtime", Quantity = 15 },
                new MedicinePrescription { MedicineId = 3, PrescriptionId = 2, Notes = "one tablet daily", Quantity = 30 },
                new MedicinePrescription { MedicineId = 4, PrescriptionId = 2, Notes = "morning with water", Quantity = 20 },
                new MedicinePrescription { MedicineId = 5, PrescriptionId = 3, Notes = "5ml twice daily", Quantity = 25 },
                new MedicinePrescription { MedicineId = 6, PrescriptionId = 3, Notes = "apply to joints as needed", Quantity = 40 }
            );


            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Booking = new DateTimeOffset(DateTime.Now.AddDays(1)),  // Example date for the first appointment
                    DoctorId = 1,  // Assign the doctor's Id
                    PatientId = 1,   // Assign the patient's Id
                    PrescriptionId= 1 // Assign the Prescription Id
                },
                new Appointment
                {
                    Booking = new DateTimeOffset(DateTime.Now.AddDays(5)),  // Example date for the first appointment
                    DoctorId = 1,  // Assign the doctor's Id
                    PatientId = 2,   // Assign the patient's Id
                    PrescriptionId = 2 // Assign the Prescription Id
                },
                new Appointment
                {
                    Booking = new DateTimeOffset(DateTime.Now.AddMonths(3)),  // Example date for the first appointment
                    DoctorId = 2,  // Assign the doctor's Id
                    PatientId = 1,   // Assign the patient's Id
                    PrescriptionId = 3 // Assign the Prescription Id
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
    }
}
