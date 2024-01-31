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
            modelBuilder.Entity<Appointment>().HasKey(k => new { k.Booking, k.DoctorId, k.PatientId } );


            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Johan Johansson"},
                new Patient { Id = 2, FullName = "Sven Svensson"},
                new Patient { Id = 3, FullName = "Anders Andresson"},
                new Patient { Id = 4, FullName = "Erik Eriksson"},
                new Patient { Id = 5, FullName = "Emma Eriksson"},
                new Patient { Id = 6, FullName = "Knut Knutsson"},
                new Patient { Id = 7, FullName = "Bengt Bengtsson"},
                new Patient { Id = 8, FullName = "Jesper Jespersson"}
            );


            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Doktor Docktorsson"},
                new Doctor { Id = 2, FullName = "Jöran Jöransson"},
                new Doctor { Id = 3, FullName = "Filip Filipsson"}
            );

            List<Appointment> listOfAppointments =
            [
                new Appointment { Id = 1, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 3, PatientId = 1 },
                new Appointment { Id = 2, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 1, PatientId = 4 },
                new Appointment { Id = 3, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 3, PatientId = 2 },
                new Appointment { Id = 4, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 2, PatientId = 6 },
                new Appointment { Id = 5, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 3, PatientId = 3 },
                new Appointment { Id = 6, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 3, PatientId = 5 },
                new Appointment { Id = 7, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 2, PatientId = 7 },
                new Appointment { Id = 8, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 1, PatientId = 8 },
            ];

            modelBuilder.Entity<Appointment>().HasData( listOfAppointments );

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
