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
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here


            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Java Script" },
                new Patient() { Id = 2, FullName = "C Sharp" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Doctor Who" },
                new Doctor() { Id = 2, FullName = "Doctor Why" }
            );
            Appointment a1 = new Appointment() { BookingTime = DateTime.UtcNow, DoctorId = 1, PatientId = 1, Type = AppointmentType.Online };
            Appointment a2 = new Appointment() { BookingTime = DateTime.UtcNow, DoctorId = 2, PatientId = 2 };
            modelBuilder.Entity<Appointment>().HasData(
                a1,
                a2
            );
            modelBuilder
                .Entity<Appointment>()
                .Property(e => e.Type)
                .HasConversion(
                    v => v.ToString(),
                    v => (AppointmentType)Enum.Parse(typeof(AppointmentType), v)
                );
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine() { Id = 1, Name = "Full revive", Notes = "Eat it or something idk" },
                new Medicine() { Id = 2, Name = "Max potion", Notes = "Drink it or something idk" }
                );
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription() { Id = 1, Quantity = 2, AppointmentDoctorId = 1, AppointmentPatientId = 1 },
                new Prescription() { Id = 2, Quantity = 4, AppointmentDoctorId = 2, AppointmentPatientId = 2 }
                );
            modelBuilder.Entity<PrescriptionMedicine>().HasData(
                new PrescriptionMedicine() { MedicineId = 1, PrescriptionId = 1 },
                new PrescriptionMedicine() { MedicineId = 2, PrescriptionId = 2 },
                new PrescriptionMedicine() { MedicineId = 2, PrescriptionId = 1 }
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
        public DbSet<PrescriptionMedicine> PrescriptionsMedicines { get; set; }
    }
}
