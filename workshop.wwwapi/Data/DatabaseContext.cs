using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection.Metadata;
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
            modelBuilder.Entity<Patient>(); //.HasMany(e => e.Prescriptions).WithOne(e => e.Patient).HasForeignKey(e => e.PatientId);
            modelBuilder.Entity<Doctor>(); //.HasMany(e => e.Prescriptions).WithOne(e => e.Doctor).HasForeignKey(e => e.DoctorId);

            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<PrescriptionMedicine>().HasKey(pm => new { pm.PrescriptionId, pm.MedicineId });




            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(new Patient { Id = 1, FullName = "Donald Trump" });
            modelBuilder.Entity<Patient>().HasData(new Patient { Id = 2, FullName = "Homer Simpson" });

            modelBuilder.Entity<Doctor>().HasData(new Doctor { Id = 1, FullName = "Do Little" });
            modelBuilder.Entity<Doctor>().HasData(new Doctor { Id = 2, FullName = "Manhatten" });

            modelBuilder.Entity<Appointment>().HasData(new Appointment { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 1});
            modelBuilder.Entity<Appointment>().HasData(new Appointment { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 2});
            modelBuilder.Entity<Appointment>().HasData(new Appointment { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2});
            modelBuilder.Entity<Appointment>().HasData(new Appointment { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 1});

            modelBuilder.Entity<Medicine>().HasData(new Medicine {  Id = 1, Name = "Aduvanz"});
            modelBuilder.Entity<Medicine>().HasData(new Medicine {  Id = 2, Name = "M&M"});

            modelBuilder.Entity<Prescription>().HasData(new Prescription { Id = 1, DoctorId = 1, PatientId = 1 });
            modelBuilder.Entity<Prescription>().HasData(new Prescription { Id = 2, DoctorId = 2, PatientId = 2});
            modelBuilder.Entity<Prescription>().HasData(new Prescription { Id = 3, DoctorId = 2, PatientId = 1});

            modelBuilder.Entity<PrescriptionMedicine>().HasData(new PrescriptionMedicine { Id = 1, Instruction = "Take each morning", MedicineId = 1, Quantity = 100, PrescriptionId = 1});
            modelBuilder.Entity<PrescriptionMedicine>().HasData(new PrescriptionMedicine { Id = 2, Instruction = "Take each morning", MedicineId = 1, Quantity = 20, PrescriptionId = 2});
            modelBuilder.Entity<PrescriptionMedicine>().HasData(new PrescriptionMedicine { Id = 3, Instruction = "Take each morning", MedicineId = 2, Quantity = 50, PrescriptionId = 1});

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
        public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }
    }
}
