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
            modelBuilder.Entity<Appointment>().HasKey(c => new { c.Booking, c.DoctorId });
            List<Appointment> appointmentlist = new List<Appointment>()
            {
                new Appointment() { Booking = new DateTime(2024, 06, 06, 0, 0, 0, DateTimeKind.Utc ), DoctorId = 1, PatientId = 1 },
                new Appointment() { Booking = new DateTime(2024, 06, 06, 0, 0, 0, DateTimeKind.Utc ), DoctorId = 2, PatientId = 2 },
                new Appointment() { Booking = new DateTime(2024, 07, 07, 0, 0, 0, DateTimeKind.Utc ), DoctorId = 2, PatientId = 3 }


            };

            modelBuilder.Entity<Doctor>().HasKey(c => new { c.Id });
            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor() { Id = 1, FullName = "T1000" },
                new Doctor() { Id = 2, FullName ="Dave" }
            };

            modelBuilder.Entity<Patient>().HasKey(c => new { c.Id });
            List<Patient> patientlist = new List<Patient>()
            {
                new Patient() { Id = 1, FullName = "P1"},
                new Patient() { Id = 2, FullName = "P2"},
                new Patient() { Id = 3, FullName = "P3"}
            };

            modelBuilder.Entity<Appointment>().HasData(appointmentlist);
            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Patient>().HasData(patientlist);


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
