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
            modelBuilder.Entity<Appointment>().HasKey(e => new { e.Booking, e.PatientId, e.DoctorId, e.PrescriptionId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Klara Andersson" },
                new Patient { Id = 2, FullName = "Peter Andersson" },
                new Patient { Id = 3, FullName = "Arvid Andersson" }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Jane Pettersson" },
                new Doctor { Id = 2, FullName = "Daniella Hoff" },
                new Doctor { Id = 3, FullName = "Emelie Hogstedt" }
                );

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, Name = "Head ache" },
                new Prescription { Id = 2, Name = "Stomach" },
                new Prescription { Id = 3, Name = "Sking" }
                );

            List<Appointment> appList = new List<Appointment>();
            appList.Add(new Appointment { Booking = "Now", DoctorId = 1, PatientId = 2, PrescriptionId = 3 });
            appList.Add(new Appointment { Booking = "Today", DoctorId = 2, PatientId = 1, PrescriptionId = 1 });
            appList.Add(new Appointment { Booking = "Tomorrow", DoctorId = 3, PatientId = 3, PrescriptionId = 2 });

            modelBuilder.Entity<Appointment>().HasData(appList);
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
        public DbSet<Prescription> Prescriptions { get; set; }
    }
}
