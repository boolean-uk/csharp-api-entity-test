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
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasKey(a => new { a.DoctorId, a.PatientId });

                entity.HasOne(a => a.Doctor)
                    .WithMany(d => d.Appointments)
                    .HasForeignKey(a => a.DoctorId);

                entity.HasOne(a => a.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(a => a.PatientId);
            });

            //TODO: Seed Data Here

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. Jane Doe" },
                new Doctor { Id = 2, FullName = "Dr. Perry Cox Dorian" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Private Brian Dancer" },
                new Patient { Id = 2, FullName = "Ben Sullivan" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    DoctorId = 1,
                    PatientId = 1,
                    Booking = DateTime.SpecifyKind(new DateTime(2025, 1, 25, 11, 30, 0), DateTimeKind.Utc)
                },
                new Appointment
                {
                    DoctorId = 2,
                    PatientId = 2,
                    Booking = DateTime.SpecifyKind(new DateTime(2025, 1, 25, 11, 30, 0), DateTimeKind.Utc)
                }
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
        public DbSet<AppointmentDTO> Appointments { get; set; }
    }
}
