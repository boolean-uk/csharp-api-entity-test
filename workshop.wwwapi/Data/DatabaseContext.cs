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
            // this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "George Banan" },
                new Patient { Id = 2, FullName = "Sir Donald Philipe" }
            );
            modelBuilder.Entity<Doctor>().HasData(

                new Doctor { Id = 1, FullName = "Britney Pears" },
                new Doctor { Id = 2, FullName = "Lady Toby" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 2, DoctorId = 2, PatientId = 2, Booking = DateTime.UtcNow, AppointmentType = AppointmentType.Person },
                new Appointment { Id = 3, DoctorId = 2, PatientId = 1, Booking = DateTime.SpecifyKind(new DateTime(2024, 5, 7, 8, 30, 0), DateTimeKind.Utc), AppointmentType = AppointmentType.Person },
                new Appointment { Id = 4, DoctorId = 1, PatientId = 2, Booking = DateTime.SpecifyKind(new DateTime(2024, 5, 7, 8, 30, 0), DateTimeKind.Utc), AppointmentType = AppointmentType.Online }
            );
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Paralgin forte" },
                new Medicine { Id = 2, Name = "Skinoren"}
            );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, MedicineId = 1, AppointmentId = 2, Note = "something" },
                new Prescription { Id = 2, MedicineId = 1, AppointmentId = 3, Note = "something" }
            );

            modelBuilder.Entity<Appointment>().Navigation(x => x.Patient).AutoInclude();
            modelBuilder.Entity<Appointment>().Navigation(x => x.Doctor).AutoInclude();
            modelBuilder.Entity<Prescription>().Navigation(x => x.Medicine).AutoInclude();
            modelBuilder.Entity<Prescription>().Navigation(x => x.Appointment).AutoInclude();

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
