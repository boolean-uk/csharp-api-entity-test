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
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            //modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId } );

            //TODO: Seed Data Here
            // Patients:
            Patient patient1 = new Patient() { Id = 1, FullName = "Bob John" };
            Patient patient2 = new Patient() { Id = 2, FullName = "John Bob" };
            Patient patient3 = new Patient() { Id = 3, FullName = "Walter White" };
            List<Patient> patients = new List<Patient>() { patient1, patient2, patient3 };
            modelBuilder.Entity<Patient>().HasData(patients);

            //Doctors
            Doctor doctor1 = new Doctor() { Id = 1, FullName = "Nigel" };
            Doctor doctor2 = new Doctor() { Id = 2, FullName = "Dave" };
            List<Doctor> doctors = new List<Doctor>() { doctor1, doctor2 };
            modelBuilder.Entity<Doctor>().HasData(doctors);

            // Appointments
            Appointment appointment1 = new Appointment() { AppointmentId = 1, DoctorId = 1, PatientId = 1, AppointmentDate = DateTime.UtcNow };
            Appointment appointment2 = new Appointment() { AppointmentId = 2, DoctorId = 1, PatientId = 2, AppointmentDate = DateTime.UtcNow };
            Appointment appointment3 = new Appointment() { AppointmentId = 3, DoctorId = 2, PatientId = 3, AppointmentDate = DateTime.UtcNow };
            List<Appointment> appointments = new List<Appointment>() { appointment1, appointment2, appointment3};
            modelBuilder.Entity<Appointment>().HasData(appointments);

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
