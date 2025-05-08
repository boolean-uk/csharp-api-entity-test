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
            //Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId, a.Booking });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Dagmar van den Berg" },
                new Patient { Id = 2, FullName = "Lieve van den Berg" },
                new Patient { Id = 3, FullName = "Daphne Lakmaker" },
                new Patient { Id = 4, FullName = "Amber Spoelstra" }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Fae Molenaar" },
                new Doctor { Id = 2, FullName = "Tobias Bockmann" },
                new Doctor { Id = 3, FullName = "Josephine Rademaker" },
                new Doctor { Id = 4, FullName = "Dylan Lusse" }
                );

            List<Appointment> appointments = new List<Appointment>()
            {
                new Appointment{DoctorId = 1, PatientId = 1, Booking = DateTime.Now.ToUniversalTime()},
                new Appointment{DoctorId = 2, PatientId = 1, Booking = DateTime.Now.ToUniversalTime()},
                new Appointment{DoctorId = 3, PatientId = 2, Booking = DateTime.Now.ToUniversalTime()},
                new Appointment{DoctorId = 4, PatientId = 1, Booking = DateTime.Now.ToUniversalTime()},
                new Appointment{DoctorId = 1, PatientId = 3, Booking = DateTime.Now.ToUniversalTime()},
                new Appointment{DoctorId = 2, PatientId = 4, Booking = DateTime.Now.ToUniversalTime()},
                new Appointment{DoctorId = 2, PatientId = 3, Booking = DateTime.Now.ToUniversalTime()},
            };
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
