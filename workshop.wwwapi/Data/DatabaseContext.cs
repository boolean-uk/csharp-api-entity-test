using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;

        private DateTime _createdDateTime;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Loading the defaultconnectionstring value from the appsettings.json
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Example.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.Booking, a.DoctorId, a.PatientId });
            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Joel Eriksson" },
                new Patient { Id = 2, FullName = "Patrik Patriksson" },
                new Patient { Id = 3, FullName = "Peter Petersson" },
                new Patient { Id = 4, FullName = "Gunnar Gunnarsson" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Olle Olleson" },
                new Doctor { Id = 2, FullName = "Anders Andersson" },
                new Doctor { Id = 3, FullName = "Erik Eriksson" },
                new Doctor { Id = 4, FullName = "Johnny Johnnyson" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Booking = _createdDateTime, PatientId = 1, DoctorId = 1 },
                new Appointment { Booking = _createdDateTime, PatientId = 2, DoctorId = 2 },
                new Appointment { Booking = _createdDateTime, PatientId = 3, DoctorId = 3 },
                new Appointment { Booking = _createdDateTime, PatientId = 4, DoctorId = 4 }
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
