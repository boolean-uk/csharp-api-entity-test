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
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(e => new { e.PatientId, e.DoctorId });


            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Klas Bengtsson" },
                new Patient { Id = 2, FullName = "Kerstin Gunnarsson" }
            );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr.Johanna" },
                new Doctor { Id = 2, FullName = "Dr.Jon" }
            );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 1 },
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 2 },
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 1 },
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2 }
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
