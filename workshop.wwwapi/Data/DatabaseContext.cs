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


            //TODO: Seed Data Here

            Seeder seed = new Seeder();

            modelBuilder.Entity<Patient>().HasData(seed.Patients);
            modelBuilder.Entity<Doctor>().HasData(seed.Doctors);

            modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId });
            modelBuilder.Entity<Appointment>().HasData(seed.Appointments);


            modelBuilder.Entity<Medicine>().HasData(seed.Medicines);
            modelBuilder.Entity<Prescription>().HasData(seed.Prescriptions);
            modelBuilder.Entity<MedicinePrescription>().HasKey(a => new { a.MedId, a.PrescriptionId });
            modelBuilder.Entity<MedicinePrescription>().HasData(seed.MedicinePrescriptions);


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
        public DbSet<MedicinePrescription> MedPrescription { get; set; }
    }
}
