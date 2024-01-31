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
            modelBuilder.Entity<Patient>().HasKey(e => new {e.Id});
            modelBuilder.Entity<Doctor>().HasKey(e => new { e.Id});
            modelBuilder.Entity<Appointment>().HasKey(e => new { e.Booking, e.PatientId, e.DoctorId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Victor Adamson"},
                new Patient { Id = 2, FullName = "Name Namesson"},
                new Patient { Id = 3, FullName = "John Smith"},
                new Patient { Id = 4, FullName = "Person MacPersonface"},
                new Patient { Id = 5, FullName = "Phill Collins"}
            );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Old Beardo"},
                new Doctor { Id = 2, FullName = "Dr Strangelove"},
                new Doctor { Id = 3, FullName = "Krieger"}
            );
            DateTime utc = DateTime.Now.ToUniversalTime();
            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(new Appointment { Booking = utc, DoctorId = 1, PatientId = 1 });
            appointments.Add(new Appointment { Booking = utc, DoctorId = 3, PatientId = 4 });

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
