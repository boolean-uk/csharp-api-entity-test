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
            //this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            optionsBuilder.EnableSensitiveDataLogging();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId, a.Booking });

            //TODO: Seed Data Here
            List<Patient> patients = new List<Patient>()
            {
                new Patient() {Id=1, FirstName="John", LastName="Doe" },
                new Patient() {Id=2, FirstName="Jane", LastName="Dough" },
                new Patient() {Id=3, FirstName="Hughie", LastName="Dodson"}
            };

            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor() {Id=1, FirstName="Hannibal", LastName="Lecter"},
                new Doctor() {Id=2, FirstName="Henry", LastName="Jones Jr."},
                new Doctor() {Id=3, FirstName="Davy", LastName="Jones"}
            };

            DateTime date1 = new DateTime(2024, 09, 14, 14, 30, 00).ToUniversalTime();
            DateTime date2 = new DateTime(2024, 09, 14, 15, 30, 00).ToUniversalTime();
            DateTime date3 = new DateTime(2024, 09, 14, 16, 30, 00).ToUniversalTime();

            List<Appointment> appointments = new List<Appointment>()
            {
                new Appointment() {Booking=date1.ToUniversalTime(), DoctorId=1, PatientId=1},
                new Appointment() {Booking=date1.ToUniversalTime(), DoctorId=2, PatientId=2},
                new Appointment() {Booking=date1.ToUniversalTime(), DoctorId=3, PatientId=3},
                new Appointment() {Booking=date2.ToUniversalTime(), DoctorId=1, PatientId=3},
                new Appointment() {Booking=date2.ToUniversalTime(), DoctorId=2, PatientId=3},
                new Appointment() {Booking=date2.ToUniversalTime(), DoctorId=3, PatientId=1},
                new Appointment() {Booking=date3.ToUniversalTime(), DoctorId=1, PatientId=2},
                new Appointment() {Booking=date3.ToUniversalTime(), DoctorId=2, PatientId=1},
                new Appointment() {Booking=date3.ToUniversalTime(), DoctorId=3, PatientId=2},
            };

            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Appointment>().HasData(appointments);

        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
