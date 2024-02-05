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

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Loading the defaultconnectionstring value from the appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            _connectionString = configuration
                .GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Patients
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Joel Joelsson" },
                new Patient { Id = 2, FullName = "Patrik Patriksson" },
                new Patient { Id = 3, FullName = "Peter Petersson" },
                new Patient { Id = 4, FullName = "Gunnar Gunnarsson" }
            );

            //Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Olle Olleson" },
                new Doctor { Id = 2, FullName = "Anders Andersson" },
                new Doctor { Id = 3, FullName = "Erik Eriksson" },
                new Doctor { Id = 4, FullName = "Johnny Johnnyson" }
            );

            //Appointments, configuration
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, 
                a.DoctorId });
            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId);

            //Appointments data
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { AppointmentDate = DateTime.UtcNow, 
                    PatientId = 1, DoctorId = 1 },
                new Appointment { AppointmentDate = DateTime.UtcNow, 
                    PatientId = 2, DoctorId = 2 },
                new Appointment { AppointmentDate = DateTime.UtcNow, 
                    PatientId = 3, DoctorId = 3 },
                new Appointment { AppointmentDate = DateTime.UtcNow, 
                    PatientId = 4, DoctorId = 4 }
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