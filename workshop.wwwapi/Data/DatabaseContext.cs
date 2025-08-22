using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
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
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);

            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient)
                .WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments).HasForeignKey(a => a.DoctorId);

            //Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Bob Bobbington" },
                new Patient { Id = 2, FullName = "Super Man" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "" },
                new Doctor { Id = 2, FullName = " " }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { PatientId = 1, DoctorId = 1, Booking = DateTime.Now, Type = AppointmentType.Person },
                new Appointment { PatientId = 2, DoctorId = 2, Booking = DateTime.Now.AddDays(1), Type = AppointmentType.Online }
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
