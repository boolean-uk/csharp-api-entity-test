using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Data.Enums;
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


            //TODO: Seed Data Here
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Doctor>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Doctor)
                .HasForeignKey(x => x.DoctorId);

            modelBuilder.Entity<Patient>()
                .HasMany(x => x.Appointments)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasKey(x => new { x.PatientId, x.DoctorId });

            //TODO: Seed Data Here
            Patient firstPatient = new Patient
            {
                Id = 1,
                FullName = "Kristian Jo"
            };

            Patient secondPatient = new Patient
            {
                Id = 2,
                FullName = "Jens Anders"
            };

            Doctor firstDoctor = new Doctor
            {
                Id = 1,
                FullName = "Dr Fill"
            };

            Doctor secondDoctor = new Doctor
            {
                Id = 2,
                FullName = "Dr Jo"
            };

            Appointment firstAppointment = new Appointment
            {
                DoctorId = 1,
                PatientId = 2,
                Booking = DateTime.UtcNow.AddDays(1),
                AppointmentType = AppointmentType.Online
            };

            Appointment secondAppointment = new Appointment
            {
                DoctorId = 2,
                PatientId = 1,
                Booking = DateTime.UtcNow.AddDays(2),
                AppointmentType = AppointmentType.InPerson
            };

            modelBuilder.Entity<Patient>()
                .HasData(firstPatient, secondPatient);

            modelBuilder.Entity<Doctor>()
                .HasData(firstDoctor, secondDoctor);

            modelBuilder.Entity<Appointment>()
                .HasData(firstAppointment, secondAppointment);
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
