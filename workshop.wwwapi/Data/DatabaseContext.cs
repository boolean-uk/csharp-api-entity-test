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
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            List<Patient> patients = new List<Patient>();
            patients.Add(new Patient()
            {
                Id = 1,
                FullName = "Ola Normann"
            });
            patients.Add(new Patient()
            {
                Id = 2,
                FullName = "Per Ola"
            });

            List<Doctor> doctors = new List<Doctor>();
            doctors.Add(new Doctor()
            {
                Id = 1,
                FullName = "Ola Doktor"
            });
            doctors.Add(new Doctor()
            {
                Id = 2,
                FullName = "Falsk Doktor"
            });
            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(
                new Appointment()
                {
                    DoctorId = 1,
                    PatientId = 2,
                    Booking = DateTime.UtcNow
                });
            appointments.Add(
                new Appointment()
                {
                    DoctorId = 2,
                    PatientId = 1,
                    Booking = DateTime.UtcNow
                });

            modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId });
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Appointment>().HasData(appointments);

            //TODO: Seed Data Here

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
