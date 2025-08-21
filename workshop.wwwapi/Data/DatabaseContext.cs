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
            //modelBuilder.Entity<Appointment>().HasKey(a => a.Id);


            // Relationship
            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Patient)
            //    .WithMany(p => p.Appointments)
            //    .HasForeignKey(a => a.PatientId);

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Doctor)
            //    .WithMany(d => d.Appointments)
            //    .HasForeignKey(a => a.DoctorId);

            //TODO: Seed Data Here
            Patient patient = new Patient{ Id = 1, FullName = "Jonatan" };
            Patient patient2 = new Patient { Id = 2, FullName = "Hans" };
            Patient patient3 = new Patient { Id = 3, FullName = "Vegard" };
            Patient patient4 = new Patient { Id = 4, FullName = "Alfred" };

            Doctor doctor = new Doctor { Id = 1, FullName = "Roman" };
            Doctor doctor2 = new Doctor { Id = 2, FullName = "Timian" };

            Appointment appointment = new Appointment
            {
                Id = 1,
                Booking = DateTime.UtcNow.AddDays(2),
                PatientId = patient.Id,
                DoctorId = doctor.Id,
            };

            Appointment appointment2 = new Appointment
            {
                Id = 2,
                Booking = DateTime.UtcNow.AddDays(3),
                PatientId = patient2.Id,
                DoctorId = doctor2.Id,
            };

            modelBuilder.Entity<Patient>().HasData([patient, patient2, patient3, patient4]);
            modelBuilder.Entity<Doctor>().HasData([doctor, doctor2]);
            modelBuilder.Entity<Appointment>().HasData([appointment, appointment2]);
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
