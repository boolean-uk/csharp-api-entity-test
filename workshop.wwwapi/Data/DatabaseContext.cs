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
            modelBuilder.Entity<Appointment>().HasKey(k => new {k.DoctorId, k.PatientId, k.Booking});

            modelBuilder.Entity<Doctor>()
                .HasData(
                    new Doctor { Id = 1, FullName = "Ulf Liljenberg" },
                    new Doctor { Id = 2, FullName = "Phillip McGraw" },
                    new Doctor { Id = 3, FullName = "Ken Jeong" }
                );

            modelBuilder.Entity<Patient>()
                .HasData(
                    new Patient { Id = 1, FullName = "Elias Soprani" },
                    new Patient { Id = 2, FullName = "Olga Alm" },
                    new Patient { Id = 3, FullName = "Oskar Damkilde" },
                    new Patient { Id = 4, FullName = "Gabriel Letell" },
                    new Patient { Id = 5, FullName = "Samuel Vacha" },
                    new Patient { Id = 6, FullName = "Theodor Johansson" }
                );

                modelBuilder.Entity<Appointment>()
                    .HasData(
                        new Appointment { DoctorId = 1, PatientId = 1, Booking = new DateTime(2024, 1, 11, 11, 0, 0, DateTimeKind.Utc) },
                        new Appointment { DoctorId = 1, PatientId = 1, Booking = new DateTime(2024, 2, 2, 14, 0, 0, DateTimeKind.Utc) },
                        new Appointment { DoctorId = 2, PatientId = 2, Booking = new DateTime(2024, 1, 17, 13, 0, 0, DateTimeKind.Utc) },
                        new Appointment { DoctorId = 1, PatientId = 3, Booking = new DateTime(2024, 5, 29, 13, 0, 0, DateTimeKind.Utc) },
                        new Appointment { DoctorId = 3, PatientId = 2, Booking = new DateTime(2024, 1, 6, 12, 0, 0, DateTimeKind.Utc) },
                        new Appointment { DoctorId = 1, PatientId = 4, Booking = new DateTime(2024, 3, 13, 10, 0, 0, DateTimeKind.Utc) },
                        new Appointment { DoctorId = 2, PatientId = 5, Booking = new DateTime(2024, 2, 16, 9, 0, 0, DateTimeKind.Utc) },
                        new Appointment { DoctorId = 3, PatientId = 6, Booking = new DateTime(2024, 4, 15, 8, 0, 0, DateTimeKind.Utc) }
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
