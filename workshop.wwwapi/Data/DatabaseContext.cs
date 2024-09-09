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
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Dennis" },
                new Patient() { Id = 2, FullName = "Thomas" },
                new Patient() { Id = 3, FullName = "Ali" },
                new Patient() { Id = 4, FullName = "Melvin" }


                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Doctor Osmani" },
                new Doctor() { Id = 2, FullName = "Doctor Flier" }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(30), DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(60), DoctorId = 2, PatientId = 3 },
                new Appointment() { Booking = DateTime.UtcNow + TimeSpan.FromMinutes(45), DoctorId = 2, PatientId = 4 }
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
