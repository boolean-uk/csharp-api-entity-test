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
            /*
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
            */
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here

            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId });


            modelBuilder.Entity<Doctor>()
                .HasMany(a => a.Appointments)
                .WithOne(d => d.Doctor)
                .HasForeignKey(d => d.DoctorId);

            modelBuilder.Entity<Patient>()
                .HasMany(a => a.Appointments)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);


            //TODO: Seed Data Here


            modelBuilder.Entity<Doctor>().HasData(
                 new Doctor { Id = 1, FullName = "Dr. John Doe" },
                 new Doctor { Id = 2, FullName = "Dr. Jane Doe" }
             );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Alice" },
                new Patient { Id = 2, FullName = "Bob" }
             );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Booking = new DateTime(2025, 1, 25, 10, 0, 0), DoctorId = 1, PatientId = 1 },
                new Appointment { Booking = new DateTime(2025, 1, 15, 10, 0, 0), DoctorId = 1, PatientId = 2 },
                new Appointment { Booking = new DateTime(2025, 1, 21, 10, 0, 0), DoctorId = 2, PatientId = 2 }
             );


            base.OnModelCreating(modelBuilder);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_connectionString);
                optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            }
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
