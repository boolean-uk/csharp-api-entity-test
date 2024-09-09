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
                new Patient() { Id = 3, FullName = "Melvin" },
                new Patient() { Id = 4, FullName = "Nigel" },
                new Patient() { Id = 5, FullName = "Danil" }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Doctor Osmani" },
                new Doctor() { Id = 2, FullName = "Doctor Flier" },
                new Doctor() { Id = 3, FullName = "Doctor John" },
                new Doctor() { Id = 4, FullName = "Doctor Jonas" },
                new Doctor() { Id = 5, FullName = "Doctor Julia" },
                new Doctor() { Id = 6, FullName = "Doctor Muath" }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { ApointementDate = DateTime.UtcNow, DoctorId = 1, PatientId = 2 },
                new Appointment() { ApointementDate = DateTime.UtcNow + TimeSpan.FromMinutes(30), DoctorId = 2, PatientId = 1 },
                new Appointment() { ApointementDate = DateTime.UtcNow + TimeSpan.FromMinutes(60), DoctorId = 4, PatientId = 3 },
                new Appointment() { ApointementDate = DateTime.UtcNow + TimeSpan.FromMinutes(45), DoctorId = 5, PatientId = 2 },
                new Appointment() { ApointementDate = DateTime.UtcNow + TimeSpan.FromMinutes(90), DoctorId = 6, PatientId = 5 },
                new Appointment() { ApointementDate = DateTime.UtcNow + TimeSpan.FromMinutes(20), DoctorId = 3, PatientId = 4 }
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
