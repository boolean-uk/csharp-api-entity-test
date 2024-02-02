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
            //TODO: Appointment Key etc.. Add Herei
            modelBuilder.Entity<Appointment>().HasKey(x => new { x.PatientId, x.DoctorId });

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
             .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
               new Patient { Id = 1, FullName = "A Patient" },
               new Patient { Id = 2, FullName = "Another Patient" }
                );

            modelBuilder.Entity<Doctor>().HasData(
        new Doctor { Id = 1, FullName = "Dr. Doctor" },
        new Doctor { Id = 2, FullName = "Dr. AlsoDoctor" }
    );

            
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { PatientId = 1, DoctorId = 1, Booking = DateTime.UtcNow.AddDays(1) },
                new Appointment { PatientId = 2, DoctorId = 1, Booking = DateTime.UtcNow.AddDays(2) },
                new Appointment { PatientId = 1, DoctorId = 2, Booking = DateTime.UtcNow.AddDays(3) }
           
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
