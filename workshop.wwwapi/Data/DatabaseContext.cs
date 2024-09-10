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
            modelBuilder.Entity<Doctor>().HasKey(x => x.Id);
            modelBuilder.Entity<Patient>().HasKey(x => x.Id);
            //modelBuilder.Entity<Appointment>().HasKey(pc => pc.DoctorId);
            //modelBuilder.Entity<Appointment>().HasKey(pc => new { pc.Booking, pc.DoctorId });

            //TODO: Seed Data Here
            //Seeder seeder = new Seeder();
            //modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            //modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            //modelBuilder.Entity<Appointment>().Property(b => b.Booking).ValueGeneratedOnAdd();
            //modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);

            modelBuilder.Entity<Appointment>().HasKey(pc => new { pc.PatientId, pc.DoctorId });



            List<Patient> patients = new List<Patient>()
            {
                new Patient() {Id = 1, FullName= "Joe"},
                new Patient() {Id = 2, FullName= "Mark"},
                new Patient() {Id = 3, FullName= "Jeff"},
                new Patient() {Id = 4, FullName= "Rolf"},
                new Patient() {Id = 5, FullName= "Gabe"},
                new Patient() {Id = 6, FullName= "Jesus"}
            };

            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor() { Id = 1, FullName = "Adrian" },
                new Doctor() { Id = 2, FullName = "Jake" }
            };

            List<Appointment> appointments = new List<Appointment>() {
                 new Appointment() { Booking = new DateTime(2024, 06, 06, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 1 },
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 2},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 5},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 4},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 3},
                 //new Appointment() { Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 6 },
             };

            //this.Appointments.Where(a => a.DoctorId == 1).ExecuteUpdate(a => a.SetProperty(p => p.doctor, doctors.FirstOrDefault(x => x.Id == 1)));
            //this.Appointments.Where(a => a.DoctorId == 2).ExecuteUpdate(a => a.SetProperty(p => p.doctor, doctors.FirstOrDefault(x => x.Id == 2)));

            //appointments.ForEach(appointment =>
            //{
            //    appointment.doctor = doctors.FirstOrDefault(x => x.Id == appointment.DoctorId);
            //    appointment.patient = patients.FirstOrDefault(x => x.Id == appointment.PatientId);
            //});

            //Seeder seeder = new Seeder(this);

            //modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            //modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            //modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);

            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Patient>().HasData(patients);
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
