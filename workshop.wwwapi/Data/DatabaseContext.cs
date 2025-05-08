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
            modelBuilder.Entity<Appointment>().HasKey(e => new { e.Booking, e.PatientId, e.DoctorId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor {Id = 1, FullName = "Bruno Fernandes"},
                new Doctor {Id = 2, FullName = "Henrik Rosenkilde"},
                new Doctor {Id = 3, FullName = "Ada Hegerberg"});

            modelBuilder.Entity<Patient>().HasData(
                new Patient {Id = 1, FullName = "Cristiano Ronaldo"},
                new Patient {Id = 2, FullName = "Lionel Messi"},
                new Patient {Id = 3, FullName = "Erling Braut Haaland"});

          /*  List<Appointment> appointments = new List<Appointment>();

                appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 1, DoctorId = 1, Type = AppointmentType.Online});
                appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 1, Type = AppointmentType.InPerson});
                appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 3, DoctorId = 2, Type = AppointmentType.Online});
          */
             modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 1, DoctorId = 1, Type = AppointmentType.Online },
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 2, DoctorId = 1, Type = AppointmentType.InPerson },
                new Appointment { Booking = DateTime.Now.ToUniversalTime(), PatientId = 3, DoctorId = 2, Type = AppointmentType.Online });
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
