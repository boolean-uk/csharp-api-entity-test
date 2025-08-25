using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection.Emit;
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

            List<Patient> patients = new List<Patient>();
            Patient patient1 = new Patient()
            {
                Id = 1,
                FullName = "Patient1"
            };
            Patient patient2 = new Patient()
            {
                Id = 2,
                FullName = "Patient2"
            };
            patients.Add(patient1);
            patients.Add(patient2);

            List<Doctor> doctors = new List<Doctor>();
            Doctor doctor1 = new Doctor()
            {
                Id = 1,
                FullName = "doctor1"
            };
            Doctor doctor2 = new Doctor()
            {
                Id = 2,
                FullName = "doctor2"
            };
            doctors.Add(doctor1);
            doctors.Add(doctor2);


            List<Appointment> appointments = new List<Appointment>();
            Appointment appointment1 = new Appointment()
            {
                Id = 1,
                Booking = new DateTime(2025, 8, 21, 13, 30, 0, DateTimeKind.Utc),
                DoctorId = 1,
                PatientId = 2
            };
            Appointment appointment2 = new Appointment()
            {
                Id = 2,
                Booking = new DateTime(2025, 8, 21, 14, 30, 0, DateTimeKind.Utc),
                DoctorId = 2,
                PatientId = 1
            };

            appointments.Add(appointment1);
            appointments.Add(appointment2);


            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Doctor>().HasData(doctors);
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
