using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.MedicineModels;
using workshop.wwwapi.Models.PatientModels;
using workshop.wwwapi.Models.PrescriptionMedicineModels;
using workshop.wwwapi.Models.PrescriptionModels;

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
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.Booking, a.DoctorId, a.PatientId });
            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany(d => d.Appointments).HasForeignKey(a => a.DoctorId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient).WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId);
            modelBuilder.Entity<PrescriptionMedicine>().HasKey(pm => new { pm.PrescriptionId, pm.MedicineId });
            modelBuilder.Entity<PrescriptionMedicine>().HasOne(pm => pm.Prescription).WithMany(p => p.PrescriptionMedicines).HasForeignKey(pm => pm.PrescriptionId);
            modelBuilder.Entity<PrescriptionMedicine>().HasOne(pm => pm.Medicine).WithMany(m => m.PrescriptionMedicines).HasForeignKey(pm => pm.MedicineId);


            Seeder seeder = new Seeder();

            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
            modelBuilder.Entity<Prescription>().HasData(seeder.Prescriptions);
            modelBuilder.Entity<Medicine>().HasData(seeder.Medicines);
            modelBuilder.Entity<PrescriptionMedicine>().HasData(seeder.PrescriptionMedicines);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.EnableSensitiveDataLogging().LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

        public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
