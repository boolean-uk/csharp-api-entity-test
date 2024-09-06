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
            modelBuilder.Entity<Appointment>().HasKey(k => new { k.DoctorId, k.PatientId });

            var patients = new List<Patient>()
            {
                new Patient() { Id = 1, FullName = "Tiger Woods" },
                new Patient() { Id = 2, FullName = "Jack Nicklaus" },
                new Patient() { Id = 3, FullName = "Arnold Palmer" }
            };
            var doctors = new List<Doctor>()
            {
                new Doctor() { Id = 1, FullName = "Usain Bolt" },
                new Doctor() { Id = 2, FullName = "Tyson Gay"}
            };
            var appointments = new List<Appointment>()
            {
                new Appointment() { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 1},
                new Appointment() { Booking = DateTime.Parse("2024/10/10").ToUniversalTime(), DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = DateTime.Parse("2024/10/20").ToUniversalTime(), DoctorId = 2, PatientId = 3 },
                new Appointment() { Booking = DateTime.Parse("2024/10/22").ToUniversalTime(), DoctorId = 2, PatientId = 1 },
            };
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Appointment>().HasData(appointments);
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
