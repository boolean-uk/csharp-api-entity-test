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

            modelBuilder.Entity<Appointment>().HasKey(e => new { e.PatientId, e.DoctorId });
          
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "May Doe" },
                new Patient { Id = 2, FullName = "John Smith" },
                new Patient { Id = 3, FullName = "Henry Johnson"});

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Mr. Dentist" },
                new Doctor { Id = 2, FullName = "Mrs. Cardiologist" });

            List<Appointment> appointments = new List<Appointment>();

            appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 1, DoctorId = 1 });
            appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 2 });
            appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 3, DoctorId = 2 });
            appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 1 });

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
