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

            modelBuilder.Entity<Appointment>().HasKey(pc => new { pc.AppointmentId, pc.DoctorId });

            List<Patient> patients = new List<Patient>()
            {
                new Patient() {Id = 1, FullName= "Joe"},
                new Patient() {Id = 2, FullName= "Mark"}
            };

            Doctor doctor = new Doctor() { Id = 1, FullName = "Adrian" };

            List<Appointment> appointments = new List<Appointment>() {

                new Appointment() { AppointmentId = 1, DoctorId = 1, PatientId = 1},
                new Appointment() { AppointmentId = 2, DoctorId = 1, PatientId = 2}
            };

            modelBuilder.Entity<Doctor>().HasData(doctor);
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
