using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.DTOs.Extension;
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
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here

            modelBuilder.Entity<Appointment>()
                        .HasOne(app => app.Doctor)
                        .WithMany(doctor => doctor.Appointments)
                        .HasForeignKey(app => app.DoctorId);

            modelBuilder.Entity<Appointment>()
                        .HasOne(app => app.Patient)
                        .WithMany(patient => patient.Appointments)
                        .HasForeignKey(app => app.PatientId);
                         
            modelBuilder.Entity<MedicinePrescription>()
                        .HasOne(pm => pm.Prescription)
                        .WithMany(p => p.MedicinePrescriptions)
                        .HasForeignKey(pm => pm.PrescriptionId);

            modelBuilder.Entity<MedicinePrescription>()
                        .HasOne(pm => pm.Medicine)
                        .WithMany(m => m.MedicinePrescriptions)
                        .HasForeignKey(pm => pm.MedicineId);


            //TODO: Seed Data Here
            Seeder seeder = new Seeder();
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
            modelBuilder.Entity<Medicine>().HasData(seeder.Medicines);
            modelBuilder.Entity<Prescription>().HasData(seeder.Prescriptions);
            modelBuilder.Entity<MedicinePrescriptionDTO>().HasData(seeder.MedicinePrescriptions);
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
