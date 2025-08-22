using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Numerics;
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
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);

            // Relationships
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient).WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany(d => d.Appointments).HasForeignKey(a => a.DoctorId);

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(new List<Patient> { new Patient { Id = 1, FullName = "Ola Larsen" }, new Patient { Id = 2, FullName = "Marie Hansen" } });
            modelBuilder.Entity<Doctor>().HasData(new List<Doctor> { new Doctor { Id = 1, FullName = "Kari Andersen" }, new Doctor { Id = 2, FullName = "Nora Amundsen" } });
            modelBuilder.Entity<Appointment>().HasData(new List<Appointment> {
                new Appointment
                {
                Id = 1,
                Booking = new DateTime(2025, 8, 28, 10, 30, 0),
                PatientId = 1,
                DoctorId = 1,
                },
                new Appointment
                {
                Id = 2,
                Booking = new DateTime(2025, 8, 25, 9, 30, 0),
                PatientId = 2,
                DoctorId = 2,
                } });
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
