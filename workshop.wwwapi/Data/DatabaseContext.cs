using exercise.webapi.Data;
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


            List<Doctor> Doctors = new List<Doctor>();
            List<Patient> Patients = new List<Patient>();
            List<Appointment> Appointments = new List<Appointment>();

            Patient patient = new Patient() { Id = 1, FullName = "Øyvind Onarheim" };
            Patient patient2 = new Patient() { Id = 2, FullName = "Not sick patient" };

            Patients.Add(patient);
            Patients.Add(patient2);

            Doctor doctor = new Doctor() { Id = 1, FullName = "Doktor doktoresen" };
            Doctor doctor2 = new Doctor() { Id = 2, FullName = "Fake doktor" };

            Doctors.Add(doctor);
            Doctors.Add(doctor2);

            Appointment appointment = new Appointment() { Booking = DateTime.UtcNow, PatientId = patient.Id, DoctorId = doctor.Id };
            Appointment appointment2 = new Appointment() { Booking = DateTime.UtcNow, PatientId = patient2.Id, DoctorId = patient2.Id };

            Appointments.Add(appointment);
            Appointments.Add(appointment2);


            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId });
            modelBuilder.Entity<Patient>().HasData(Patients);
            modelBuilder.Entity<Doctor>().HasData(Doctors);
            modelBuilder.Entity<Appointment>().HasData(Appointments);

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
