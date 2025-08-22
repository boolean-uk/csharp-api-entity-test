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


            //TODO: Seed Data Here

            modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = 1,
                FullName = "Trym Berger"
            },
            new Patient
            {
                Id = 2,
                FullName = "Mathew Walker"
            }
        );
            modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = 1,
                FullName = "Jan-Erik Berger"
            },
            new Doctor
            {
                Id = 2,
                FullName = "Mette Skurtveit"
            }
        );
            modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                Id = 5,
                PatientID = 1,
                DoctorID = 3,
                Booking = DateTime.Now.ToUniversalTime(),
                Type = Enums.AppointmentType.InPerson
            },
            new Appointment
            {
                Id = 6,
                PatientID = 2,
                DoctorID = 2,
                Booking = DateTime.Now.ToUniversalTime(),
                Type = Enums.AppointmentType.Online
            }
        );
            modelBuilder.Entity<Medicine>().HasData(
            new Medicine
            {
                Id = 1,
                Name = "Liviostin",
                Notes = "Take 1 each morning",
                PrescriptionId = 1,
                Quantity = 50
            },
            new Medicine
            {
                Id = 2,
                Name = "Fent",
                Notes = "Take 100 10 times a day",
                PrescriptionId = 2,
                Quantity = 100000000

            }
        );
            modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                Id = 1,
                MedicineId = 1,
                AppointmentId = 1
            },
            new Prescription
            {
                Id = 2,
                MedicineId = 2,
                AppointmentId = 2
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
    }
}
