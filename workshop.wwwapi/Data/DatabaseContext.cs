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
            modelBuilder.Entity<Patient>().HasKey(e => new { e.Id});
            modelBuilder.Entity<Doctor>().HasKey(d => new { d.Id});
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.id, a.DoctorId, a.PatientId });


            //TODO: Seed Data Here

            modelBuilder.Entity<Patient>().HasData(
                new Patient{Id = 1, FullName = "Marcus" },
                new Patient{Id = 2, FullName = "Anna" },
                new Patient{Id = 3, FullName = "Pontus" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Victor" },
                new Doctor { Id = 2, FullName = "Oliver"},
                new Doctor { Id = 3, FullName = "James"}
            );
            DateTime dateTime = DateTime.Now.ToUniversalTime();
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { appointmentDate = dateTime, DoctorId = 1, PatientId = 1, id = 1 },
                new Appointment { appointmentDate = dateTime, DoctorId = 1, PatientId = 2, id = 2 },
                new Appointment { appointmentDate = dateTime, DoctorId = 2, PatientId = 3, id = 3 },
                new Appointment { appointmentDate = dateTime, DoctorId = 2, PatientId = 1, id = 4 },
                new Appointment { appointmentDate = dateTime, DoctorId = 3, PatientId = 2, id = 5 },
                new Appointment { appointmentDate = dateTime, DoctorId = 3, PatientId = 3, id = 6 }
            ); ;
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
