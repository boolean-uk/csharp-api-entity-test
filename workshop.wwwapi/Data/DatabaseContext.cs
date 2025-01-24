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


            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Dr. John Smith" },
                new Doctor { Id = 2, FullName = "Dr. Jane Doe" }
            );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Alice Johnson" },
                new Patient { Id = 2, FullName = "Bob Brown" }
            );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    DoctorId = 1,
                    PatientId = 1,
                    Booking = DateTime.SpecifyKind(new DateTime(2025, 1, 1, 9, 0, 0), DateTimeKind.Unspecified)
                },
                new Appointment
                {
                    DoctorId = 2,
                    PatientId = 2,
                    Booking = DateTime.SpecifyKind(new DateTime(2025, 1, 2, 10, 0, 0), DateTimeKind.Unspecified)
                }
            );

            base.OnModelCreating(modelBuilder);


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=your_db_name;Username=your_username;Password=your_password");
                optionsBuilder.LogTo(message => Debug.WriteLine(message));
            }

        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
