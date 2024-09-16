using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;

        // This constructor is used at runtime
        public DatabaseContext(IConfiguration configuration , DbContextOptions<DatabaseContext> options) : base(options)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // This constructor is used at design-time
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
   .HasKey(a => a.Id);


            modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = 1 , FullName = "John Doe" } ,
            new Patient { Id = 2 , FullName = "Jane Doe2" }
             );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1 , FullName = "Doctor 1" } ,
                new Doctor { Id = 2 , FullName = "Doctor 2" }
             );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1 , PatientId = 1 , DoctorId = 1 , Booking = DateTime.UtcNow } ,
                new Appointment { Id = 2 , PatientId = 2 , DoctorId = 1 , Booking = DateTime.UtcNow } ,
                new Appointment { Id = 3 , PatientId = 1 , DoctorId = 2 , Booking = DateTime.UtcNow } ,
                new Appointment { Id = 4 , PatientId = 2 , DoctorId = 2 , Booking = DateTime.UtcNow }
            );

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<PrescriptionMedicine> PrescriptionsMedicines { get; set; }
    }
}
