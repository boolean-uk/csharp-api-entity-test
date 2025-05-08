using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Prescriptions;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fill database with test data
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Jack Peterson" },
                new Patient() { Id = 2, FullName = "Dave Davidson"  }
            );
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Dr. Jason Bourne" },
                new Doctor() { Id = 2, FullName = "Dr. Mats Anderson" }
            );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() {
                    Id = 1,
                    Booking = DateTime.SpecifyKind(new DateTime(2024, 6, 2, 15, 0, 0), DateTimeKind.Utc), 
                    DoctorIdFK = 1, 
                    PatientIdFK = 2 
                },
                new Appointment()
                {
                    Id = 2,
                    Booking = DateTime.SpecifyKind(new DateTime(2024, 2, 6, 15, 0, 0), DateTimeKind.Utc),
                    DoctorIdFK = 2,
                    PatientIdFK = 1
                },
                new Appointment()
                {
                    Id = 3,
                    Booking = DateTime.SpecifyKind(new DateTime(2023, 2, 6, 15, 0, 0), DateTimeKind.Utc),
                    DoctorIdFK = 1,
                    PatientIdFK = 1
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