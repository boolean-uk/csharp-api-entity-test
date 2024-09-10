using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Dtoes;
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
            modelBuilder.Entity<Patient>().HasKey(p => p.PatientId);
            modelBuilder.Entity<Doctor>().HasKey(d => d.DoctorId);
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId });

            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);
            //.HasPrincipalKey(d => d.DoctorId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);
                //.HasPrincipalKey(p => p.PatientId);

            //TODO: Seed Data Here

            List<Patient> patientList = new List<Patient>();
            List<Doctor> doctorList = new List<Doctor>();
            List<Appointment> appointments = new List<Appointment>();

            Patient patient1 = new Patient();
            patient1.PatientId = 1;
            patient1.FirstName = "Anders";
            patient1.LastName = "Ottersland";

            Patient patient2 = new Patient();
            patient2.PatientId = 2;
            patient2.FirstName = "Per";
            patient2.LastName = "Kristian";

            Doctor doctor1 = new Doctor();
            doctor1.DoctorId = 1;
            doctor1.FullName = "Lea Gonzales";

            Doctor doctor2 = new Doctor();
            doctor2.DoctorId = 2;
            doctor2.FullName = "Miah Hagen";

            Appointment appointment1 = new Appointment();
            appointment1.Booking = DateTime.UtcNow;
            appointment1.DoctorId = doctor1.DoctorId;
            appointment1.PatientId = patient1.PatientId;

            Appointment appointment2 = new Appointment();
            appointment2.Booking = DateTime.UtcNow;
            appointment2.DoctorId = doctor2.DoctorId;
            appointment2.PatientId = patient2.PatientId;

            patientList.Add(patient1);
            patientList.Add(patient2);
            doctorList.Add(doctor1);
            doctorList.Add(doctor2);
            appointments.Add(appointment1);
            appointments.Add(appointment2);

            modelBuilder.Entity<Patient>().HasData(patientList);
            modelBuilder.Entity<Doctor>().HasData(doctorList);
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
