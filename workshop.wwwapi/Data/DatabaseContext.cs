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
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Doctor entity with primary key
            //modelBuilder.Entity<Doctor>()
            //    .HasKey(b => b.Id)
            //    .HasName("PK_doctor_id");

            //// Patient entity with primary key
            //modelBuilder.Entity<Patient>()
            //    .HasKey(b => b.Id)
            //    .HasName("PK_patient_id");

            // Appointment entity with composite key
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId })
                .HasName("PK_appointment_doctor_patient");

            // Seeded data
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Smith" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Heinz Doofenshmirtz" },
                new Doctor { Id = 2, FullName = "Dr Johnny" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Booking = new DateTimeOffset(DateTime.Now.AddDays(1)),  // Example date for the first appointment
                    DoctorId = 1,  // Assign the doctor's Id
                    PatientId = 1   // Assign the patient's Id
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
