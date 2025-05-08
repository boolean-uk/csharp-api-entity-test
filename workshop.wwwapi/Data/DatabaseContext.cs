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
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Patient
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Doe" }
            );

            // Doctor
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Smith" },
                new Doctor { Id = 2, FullName = "Dr. Johnson" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, PatientId = 1, DoctorId = 1, Booking = DateTime.UtcNow, Type=AppointmentType.Online },
                new Appointment { Id = 2, PatientId = 2, DoctorId = 1, Booking = DateTime.UtcNow.AddDays(1), Type = AppointmentType.Online },
                new Appointment { Id = 3, PatientId = 1, DoctorId = 2, Booking = DateTime.UtcNow.AddDays(2), Type = AppointmentType.InPerson },
                new Appointment { Id = 4, PatientId = 2, DoctorId = 2, Booking = DateTime.UtcNow.AddDays(3), Type = AppointmentType.InPerson }
            );

            // Prescription and Medication
            modelBuilder.Entity<Medicine>()
                .HasMany(m => m.Prescriptions)
                .WithMany(p => p.Medicines);
                
            modelBuilder.Entity<Prescription>()
                .HasMany(p => p.Medicines)
                .WithMany(m => m.Prescriptions);

            modelBuilder.Entity<Appointment>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithOne(a => a.Prescription)
                .HasForeignKey<Prescription>(p => p.AppointmentId);


            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Aspirin", Quantity = 100, Notes = "For pain relief" },
                new Medicine { Id = 2, Name = "Penicillin", Quantity = 50, Notes = "Antibiotic" }
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, AppointmentId = 1 },
                new Prescription { Id = 2, AppointmentId = 2 }
            );

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
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
