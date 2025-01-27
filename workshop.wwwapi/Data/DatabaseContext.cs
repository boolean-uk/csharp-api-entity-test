using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.DoctorId);


            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Tom" },
                new Patient() { Id = 2, FullName = "Jerry" }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Dr. House" },
                new Doctor() { Id = 2, FullName = "Dr. Grey" }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { Booking = DateTime.UtcNow.AddDays(1), DoctorId = 1, PatientId = 1 },
                new Appointment() { Booking = DateTime.UtcNow.AddDays(2), DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = DateTime.UtcNow.AddDays(3), DoctorId = 2, PatientId = 1 }
                );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console

            optionsBuilder.ConfigureWarnings(warnings =>
                warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
