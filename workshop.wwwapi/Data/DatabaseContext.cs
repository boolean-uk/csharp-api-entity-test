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
            modelBuilder.Entity<Appointment>().HasKey(e => new  { e.DoctorId, e.PatientId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Doe" },
                new Patient { Id = 3, FullName = "John Smith" }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Doctor 1" },
                new Doctor { Id = 2, FullName = "Doctor 2" },
                new Doctor { Id = 3, FullName = "Doctor 3" }
                );


            // one line
            DateTime utc = DateTime.Now.ToUniversalTime();
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Booking = utc, DoctorId = 1, PatientId = 1 },
                new Appointment { Booking = utc, DoctorId = 1, PatientId = 2 },
                new Appointment { Booking = utc, DoctorId = 2, PatientId = 3 }
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
