using Microsoft.EntityFrameworkCore;
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
            // this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FirstName = "Saul", LastName = "Hudson" },
                new Patient() { Id = 2, FirstName = "Axl", LastName = "Rose" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, Name = "Dr. House" },
                new Doctor() { Id = 2, Name = "Dr. Phil" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment()
                {
                    AppointmentDate = DateTime.Parse("2024/10/12 12:00:00"),
                    DoctorId = 1,
                    PatientId = 1
                },
                new Appointment()
                {
                    AppointmentDate = DateTime.Parse("2024/10/12 16:00:00"),
                    DoctorId = 2,
                    PatientId = 2
                }
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
