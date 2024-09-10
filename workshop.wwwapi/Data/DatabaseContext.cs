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
            Seeder seeder = new Seeder();

            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.Booking, a.PatientId, a.DoctorId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            //modelBuilder.Entity<Appointment>()
            //    .HasOne(a => a.Prescription)
            //    .WithOne(p => p.Appointment)
            //    .HasForeignKey<Appointment>(a => a.PrescriptionId);

            //modelBuilder.Entity<Prescription>()
            //    .HasMany(p => p.Medicines)
            //    .WithMany(m => m.Prescriptions)
            //    .UsingEntity(mp => mp.ToTable("medicinePrescription"));

            //modelBuilder.Entity<Medicine>()
            //    .HasMany(m => m.Prescriptions)
            //    .WithMany(p => p.Medicines)
            //    .UsingEntity(mp => mp.ToTable("medicinePrescription"));

            //modelBuilder.Entity<MedicinePrescription>()
            //    .HasKey(mp => mp.Id);

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
            //modelBuilder.Entity<Medicine>().HasData(seeder.Medicines);
            //modelBuilder.Entity<Prescription>().HasData(seeder.Prescriptions);
            //modelBuilder.Entity<MedicinePrescription>().HasData(seeder.MedicinesPrescriptions);
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
        public DbSet<MedicinePrescription> MedicinesPrescriptions { get; set; }
    }
}
