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
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.Example.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.PatientId, a.DoctorId, a.Booking })
                .HasName("PK_appointment_doc_patient_booking");

            modelBuilder.Entity<Doctor>()
                .HasMany(e => e.Appointments)
                .WithOne(e => e.Doctor)
                .HasForeignKey(e => e.DoctorId);

            //TODO: Seed Data Here
            Seeder seeder = new Seeder();
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment
                {
                    Booking = new DateTime(2001, 01, 02).ToUniversalTime(),
                    DoctorId = 3,
                    PatientId = 1
                },
                new Appointment
                {
                    Booking = new DateTime(2002, 01, 03).ToUniversalTime(),
                    DoctorId = 2,
                    PatientId = 3
                },
                new Appointment
                {
                    Booking = new DateTime(2002, 02, 03).ToUniversalTime(),
                    DoctorId = 4,
                    PatientId = 5
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
