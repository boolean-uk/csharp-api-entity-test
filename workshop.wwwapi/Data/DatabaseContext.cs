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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(x => new { x.PatientId, x.DoctorId }).HasName("appointment_id");
            modelBuilder.Entity<Prescription>().HasKey(x => x.Id);
            modelBuilder.Entity<Medicine>().HasKey(x => x.Id);
            modelBuilder.Entity<MedicinePrescription>().HasKey(x => new { x.PrescriptionId, x.MedicineId }).HasName("medicine_prescription_id");

            modelBuilder.Entity<Patient>().HasMany(x => x.Appointments).WithOne(x => x.Patient).HasForeignKey(x => x.PatientId);
            modelBuilder.Entity<Doctor>().HasMany(x => x.Appointments).WithOne(x => x.Doctor).HasForeignKey(x => x.DoctorId);
            modelBuilder.Entity<Patient>().HasMany(x => x.Prescriptions).WithOne(x => x.Patient).HasForeignKey(x => x.PatientId);
            modelBuilder.Entity<Doctor>().HasMany(x => x.Prescriptions).WithOne(x => x.Doctor).HasForeignKey(x => x.DoctorId);

            modelBuilder.Entity<MedicinePrescription>().HasOne(x => x.Prescription).WithMany(x => x.Medicines).HasForeignKey(x => x.PrescriptionId);
            modelBuilder.Entity<MedicinePrescription>().HasOne(x => x.Medicine).WithMany(x => x.Prescriptions).HasForeignKey(x => x.MedicineId);

            //TODO: Seed Data Here
            Seeder seeder = new();
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
            modelBuilder.Entity<Medicine>().HasData(seeder.Medicines);
            modelBuilder.Entity<Prescription>().HasData(seeder.Prescriptions);
            modelBuilder.Entity<MedicinePrescription>().HasData(seeder.Mp);

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
        public DbSet<MedicinePrescription> Mp {  get; set; }
    }
}
