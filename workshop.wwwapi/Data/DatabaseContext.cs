using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
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
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            // Composite key for Appointment
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId });

            //Configure appointment patient relation
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            //Configure appointment doctor relation
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.DoctorId);



            //TODO: Seed Data Here

            modelBuilder.Entity<Patient>().HasData(
               new Patient { Id = 1, FullName = "John Doe" },
               new Patient {  Id = 2, FullName = "Jane Smith" }
            );

            modelBuilder.Entity<Doctor>().HasData(
                 new Doctor { Id = 1, FullName = "Dr. Alice Johnson" },
                 new Doctor { Id = 2, FullName = "Dr. Bob Smith" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { PatientId = 1, DoctorId = 1, AppointmentDate = new DateTime(2024, 10, 1, 10, 0, 0, DateTimeKind.Utc) },
                new Appointment { PatientId = 2, DoctorId = 2, AppointmentDate = new DateTime(2024, 10, 2, 11, 0, 0, DateTimeKind.Utc) },
                new Appointment { PatientId = 2, DoctorId = 1, AppointmentDate = new DateTime(2024, 11, 5, 11, 0, 0, DateTimeKind.Utc) }
            );

            base.OnModelCreating(modelBuilder);
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
