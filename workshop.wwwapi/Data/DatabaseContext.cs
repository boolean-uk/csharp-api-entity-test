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
            // this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Patient>();
            modelBuilder.Entity<Doctor>();
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Restrict);

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "George Banan" },
                new Patient { Id = 2, FullName = "Sir Donald Philipe" }
            );
            modelBuilder.Entity<Doctor>().HasData(

                new Doctor { Id = 1, FullName = "Britney Pears" },
                new Doctor { Id = 2, FullName = "Lady Toby" }
            );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, DoctorId = 1, PatientId = 1, Booking = DateTime.UtcNow },
                new Appointment { Id = 2, DoctorId = 2, PatientId = 2, Booking = DateTime.UtcNow },
                new Appointment { Id = 3, DoctorId = 2, PatientId = 1, Booking = DateTime.SpecifyKind(new DateTime(2024, 5, 7, 8, 30, 0), DateTimeKind.Utc) },
                new Appointment { Id = 4, DoctorId = 1, PatientId = 2, Booking = DateTime.SpecifyKind(new DateTime(2024, 5, 7, 8, 30, 0), DateTimeKind.Utc) }
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
