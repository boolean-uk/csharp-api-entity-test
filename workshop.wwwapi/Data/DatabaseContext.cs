using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection.Metadata;
using workshop.wwwapi.Models.DatabaseModels;

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
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId })
                .HasName("PJ_appoitment_doctor_patient");
            modelBuilder.Entity<Patient>()
                .HasMany(e => e.Appointments)
                .WithOne(e => e.Patient)
                .HasForeignKey(e => e.PatientId);
            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Appointments)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);

            //TODO: Seed Data Here

            Seeder seeder = new Seeder();

            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            //modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Booking = new DateTimeOffset(DateTime.Now.AddDays(1)),  // Example date for the first appointment
                    DoctorId = 1,  // Assign the doctor's Id
                    PatientId = 1   // Assign the patient's Id
                },
                new Appointment
                {
                    Booking = new DateTimeOffset(DateTime.Now.AddDays(5)),  // Example date for the first appointment
                    DoctorId = 1,  // Assign the doctor's Id
                    PatientId = 2   // Assign the patient's Id
                },
                new Appointment
                {
                    Booking = new DateTimeOffset(DateTime.Now.AddMonths(3)),  // Example date for the first appointment
                    DoctorId = 2,  // Assign the doctor's Id
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