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
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId });

            //TODO: Seed Data Here
            List<Patient> patients = new List<Patient>()
            {
                new Patient { Id = 1, FullName = "Espen Luna" },
                new Patient { Id = 2, FullName = "Eyvind Malde" },
                new Patient { Id = 3, FullName = "Øyvind Onarheim" },
            };

            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor { Id = 1, FullName = "Doctor Daniel"},
                new Doctor { Id = 2, FullName = "Doctor Silje"}
            };

            List<Appointment> appointments = new List<Appointment>()
            {
                new Appointment { Booking = new DateTime(2024, 9 , 9, 12, 30, 0), DoctorId = 1, PatientId = 1 },
                new Appointment { Booking = new DateTime(2024, 9 , 9, 13, 0, 0), DoctorId = 1, PatientId = 2 },
                new Appointment { Booking = new DateTime(2024, 9 , 9, 12, 30, 0), DoctorId = 2, PatientId = 3 },
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
