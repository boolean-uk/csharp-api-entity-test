using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
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
            modelBuilder.Entity<Doctor>().HasMany(k => k.Appointments);
            modelBuilder.Entity<Patient>().HasMany(k => k.Appointments);
            modelBuilder.Entity<Appointment>().HasKey(dp => new {dp.DoctorId, dp.PatientId});
            modelBuilder.Entity<Doctor>().HasKey(k => k.Id);
            modelBuilder.Entity<Patient>().HasKey(k => k.Id);

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new { Id = 1, FullName = "Ola Nordmann" },
                new { Id = 2, FullName = "Kari Nordmann"},
                new { Id = 3, FullName = "Mikolaj Baran"} // for testing
            );

            modelBuilder.Entity<Doctor>().HasData(
                new { Id = 1, FullName = "Dr House" },
                new { Id = 2, FullName = "Dr Who" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new { Booking = DateTime.UtcNow, DoctorId = 1, DoctorName = "Dr House", PatientId = 1, PatientName = "Ola Nordmann", Type = AppointmentType.InPerson },
                new { Booking = DateTime.UtcNow, DoctorId = 1, DoctorName = "Dr House", PatientId = 2, PatientName = "Kari Nordmann", Type = AppointmentType.InPerson },
                new { Booking = DateTime.UtcNow, DoctorId = 2, DoctorName = "Dr Who", PatientId = 1, PatientName = "Ola Nordmann", Type = AppointmentType.Online },
                new { Booking = DateTime.UtcNow, DoctorId = 2, DoctorName = "Dr Who", PatientId = 2, PatientName = "Kari Nordmann", Type = AppointmentType.Online }
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
