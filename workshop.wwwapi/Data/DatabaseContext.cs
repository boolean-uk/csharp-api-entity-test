using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>(
                "ConnectionStrings:DefaultConnectionString"
            )!;
            this.Database.EnsureCreated();
            this.Database.SetConnectionString(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Doctor>().HasKey(b => b.Id);
            modelBuilder
                .Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId);
            modelBuilder.Entity<Patient>().HasKey(p => p.Id);
            modelBuilder
                .Entity<Patient>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId);
            modelBuilder.Entity<Appointment>().HasKey(p => p.Id);
            ;
            //TODO: Seed Data Here
            modelBuilder
                .Entity<Doctor>()
                .HasData(
                    new List<Doctor>
                    {
                        new Doctor { Id = 1, FullName = "Bob Boberson" },
                        new Doctor { Id = 2, FullName = "Peter Pearson" },
                    }
                );
            modelBuilder
                .Entity<Patient>()
                .HasData(
                    new List<Patient>
                    {
                        new Patient { Id = 1, FullName = "Patient Boberson" },
                        new Patient { Id = 2, FullName = "Patient Pearson" },
                    }
                );

            modelBuilder
                .Entity<Appointment>()
                .HasData(
                    new List<Appointment>
                    {
                        new Appointment
                        {
                            Id = 1,
                            DoctorId = 1,
                            PatientId = 1,
                            Booking = DateTime.UtcNow,
                            AppointmentType = AppointmentType.Physical,
                        },
                        new Appointment
                        {
                            Id = 2,
                            DoctorId = 2,
                            PatientId = 1,
                            Booking = DateTime.UtcNow,
                            AppointmentType = AppointmentType.Digital,
                        },
                        new Appointment
                        {
                            Id = 3,
                            DoctorId = 1,
                            PatientId = 2,
                            Booking = DateTime.UtcNow,
                            AppointmentType = AppointmentType.Physical,
                        },
                        new Appointment
                        {
                            Id = 4,
                            DoctorId = 2,
                            PatientId = 2,
                            Booking = DateTime.UtcNow,
                            AppointmentType = AppointmentType.Digital,
                        },
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
