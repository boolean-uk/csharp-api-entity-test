using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private string _connectionString;
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(a => new {a.PatientId, a.DoctorId});

            Patient patient1 = new Patient() { Id = 1, FullName = "Johnny Lever" };
            Patient patient2 = new Patient() { Id = 2, FullName = "John Doe" };

            Doctor doctor1 = new Doctor() { Id = 1, FullName = "Dr. John Levert" };
            Doctor doctor2 = new Doctor() { Id = 2, FullName = "Dr. Johnny Bashir" };

            Appointment appointment1 = new Appointment()
            {
                Booking = DateTime.UtcNow,
                DoctorId = doctor1.Id,
                PatientId = patient1.Id,
            };

            Appointment appointment2 = new Appointment()
            {
                Booking = DateTime.UtcNow,
                DoctorId = doctor2.Id,
                PatientId = patient2.Id,
            };


            modelBuilder.Entity<Patient>().HasData(patient1, patient2);
            modelBuilder.Entity<Doctor>().HasData(doctor1, doctor2);
            modelBuilder.Entity<Appointment>().HasData(appointment1, appointment2);

            base.OnModelCreating(modelBuilder);

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
