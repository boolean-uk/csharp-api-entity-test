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
            modelBuilder.Entity<Appointment>().HasOne(a => a.Prescription)
                .WithOne(p => p.Appointment);
            modelBuilder.Entity<Prescription>().HasOne(a => a.Appointment)
                .WithOne(p => p.Prescription);

            //TODO: Seed Data Here

            //Lists
            List<Patient> patientList = new List<Patient>();
            List<Doctor> doctorList = new List<Doctor>();
            List<Appointment> appointments = new List<Appointment>();
            List<Medicin> medicins = new List<Medicin>();
            List<MedicinOnPrescription> medicinOnPrescriptions = new List<MedicinOnPrescription>();
            List<Prescription> prescriptions = new List<Prescription>();

            //Patients
            Patient patient1 = new Patient();
            patient1.PatientId = 1;
            patient1.FirstName = "Anders";
            patient1.LastName = "Ottersland";

            Patient patient2 = new Patient();
            patient2.PatientId = 2;
            patient2.FirstName = "Per";
            patient2.LastName = "Kristian";

            //Doctors
            Doctor doctor1 = new Doctor();
            doctor1.DoctorId = 1;
            doctor1.FullName = "Lea Gonzales";

            Doctor doctor2 = new Doctor();
            doctor2.DoctorId = 2;
            doctor2.FullName = "Miah Hagen";

            //Prescription
            Prescription prescription1 = new Prescription();
            prescription1.Id = 1;

            Prescription prescription2 = new Prescription();
            prescription2.Id = 2;

            //Appointments
            Appointment appointment1 = new Appointment();
            appointment1.Booking = DateTime.UtcNow;
            appointment1.DoctorId = doctor1.DoctorId;
            appointment1.PatientId = patient1.PatientId;
            appointment1.PrescriptionId = prescription1.Id;

            Appointment appointment2 = new Appointment();
            appointment2.Booking = DateTime.UtcNow;
            appointment2.DoctorId = doctor2.DoctorId;
            appointment2.PatientId = patient2.PatientId;
            appointment2.PrescriptionId = prescription2.Id;

            //Medicin
            Medicin medicin1 = new Medicin();
            medicin1.Id = 1;
            medicin1.Name = "Parecet";

            Medicin medicin2 = new Medicin();
            medicin2.Id = 2;
            medicin2.Name = "Biotics";

            //MedicinOnPrescription
            MedicinOnPrescription MOD1 = new MedicinOnPrescription();
            MOD1.MedicinId = 1;
            MOD1.PrescriptionId = 1;
            MOD1.Cuantity = 3;
            MOD1.Notes = "Swallow them, not more than 4 daily";

            MedicinOnPrescription MOD2 = new MedicinOnPrescription();
            MOD2.MedicinId = 2;
            MOD2.PrescriptionId = 1;
            MOD2.Cuantity = 1;
            MOD2.Notes = "Take 1 each hour";

            MedicinOnPrescription MOD3 = new MedicinOnPrescription();
            MOD3.MedicinId = 2;
            MOD3.PrescriptionId = 2;
            MOD3.Cuantity = 2;
            MOD3.Notes = "Take 1 each hour";

            //Add to lists
            patientList.Add(patient1);
            patientList.Add(patient2);

            doctorList.Add(doctor1);
            doctorList.Add(doctor2);

            appointments.Add(appointment1);
            appointments.Add(appointment2);

            medicins.Add(medicin1);
            medicins.Add(medicin2);

            prescriptions.Add(prescription1);
            prescriptions.Add(prescription2);

            medicinOnPrescriptions.Add(MOD1);
            medicinOnPrescriptions.Add(MOD2);
            medicinOnPrescriptions.Add(MOD3);

            modelBuilder.Entity<Patient>().HasData(patientList);
            modelBuilder.Entity<Doctor>().HasData(doctorList);
            modelBuilder.Entity<Appointment>().HasData(appointments);
            modelBuilder.Entity<Medicin>().HasData(medicins);
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
            modelBuilder.Entity<MedicinOnPrescription>().HasData(medicinOnPrescriptions);
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
