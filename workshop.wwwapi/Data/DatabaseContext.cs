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
            //modelBuilder.Entity<Appointment>().HasKey(a => a.Id);


            // Relationship
            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Patient)
            //    .WithMany(p => p.Appointments)
            //    .HasForeignKey(a => a.PatientId);

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Doctor)
            //    .WithMany(d => d.Appointments)
            //    .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasKey(pm => new { pm.PrescriptionId, pm.MedicineId });

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasOne(pm => pm.Medicine)
                .WithMany(m => m.PrescriptionMedicines)
                .HasForeignKey(pm => pm.MedicineId);

            modelBuilder.Entity<PrescriptionMedicine>()
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicines)
                .HasForeignKey(pm => pm.PrescriptionId);

            modelBuilder.Entity<Prescription>()
                .HasOne(p => p.Appointment)
                .WithMany(a => a.Prescriptions)
                .HasForeignKey(x => x.AppointmentId);



            //TODO: Seed Data Here
            Patient patient = new Patient{ Id = 1, FullName = "Jonatan" };
            Patient patient2 = new Patient { Id = 2, FullName = "Hans" };
            Patient patient3 = new Patient { Id = 3, FullName = "Vegard" };
            Patient patient4 = new Patient { Id = 4, FullName = "Alfred" };

            Doctor doctor = new Doctor { Id = 1, FullName = "Roman" };
            Doctor doctor2 = new Doctor { Id = 2, FullName = "Timian" };

            Appointment appointment = new Appointment
            {
                Id = 1,
                Booking = DateTime.UtcNow.AddDays(2),
                PatientId = patient2.Id,
                DoctorId = doctor.Id,
            };

            Appointment appointment2 = new Appointment
            {
                Id = 2,
                Booking = DateTime.UtcNow.AddDays(3),
                PatientId = patient.Id,
                DoctorId = doctor2.Id,
            };

            Medicine medicine = new Medicine { Id = 1, Name = "Pinex Forte" };
            Medicine medicine2 = new Medicine { Id = 2, Name = "Zyrtec" };
            Medicine medicine3 = new Medicine { Id = 3, Name = "Loratadine" };

            Prescription prescription = new Prescription { Id = 1, Name = "Pollenallergi", AppointmentId = appointment2.Id };
            Prescription prescription2 = new Prescription { Id = 2, Name = "Brukket Kragebein", AppointmentId = appointment.Id };

            PrescriptionMedicine pm = new PrescriptionMedicine
            {
                MedicineId = medicine.Id,
                PrescriptionId = prescription2.Id,
                Quantity = 20,
                Notes = "Ta ved plagende smerter. Maks 2 hver 24. time."
            };

            PrescriptionMedicine pm2 = new PrescriptionMedicine
            {
                MedicineId = medicine2.Id,
                PrescriptionId = prescription.Id,
                Quantity = 15,
                Notes = "En tablett hver kveld."
            };

            PrescriptionMedicine pm3 = new PrescriptionMedicine
            {
                MedicineId = medicine3.Id,
                PrescriptionId = prescription.Id,
                Quantity = 10,
                Notes = "En hver morgen og kveld. 2 om dagen."
            };

            modelBuilder.Entity<Patient>().HasData([patient, patient2, patient3, patient4]);
            modelBuilder.Entity<Doctor>().HasData([doctor, doctor2]);
            modelBuilder.Entity<Appointment>().HasData([appointment, appointment2]);
            modelBuilder.Entity<Medicine>().HasData([medicine, medicine2, medicine3]);
            modelBuilder.Entity<Prescription>().HasData([prescription, prescription2]);
            modelBuilder.Entity<PrescriptionMedicine>().HasData([pm, pm2, pm3]);
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
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicine> PrescriptionsMedicines { get; set; }
    }
}
