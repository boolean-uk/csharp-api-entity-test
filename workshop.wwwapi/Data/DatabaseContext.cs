using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using workshop.wwwapi.Models.Types;

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
            modelBuilder.Entity<MedicinePrescription>().HasKey(x => new { x.MedicineId, x.PrescriptionId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(new List<Patient>() {
                new Patient() { Id = 1, FullName = "Sick Guy" },
                new Patient() { Id = 2, FullName = "Local Junkie" },
            });
            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
            {
                new Doctor() { Id = 1, FullName = "Bob Builder" },
            });
            modelBuilder.Entity<Medicine>().HasData(new List<Medicine>()
            {
                new Medicine() { Id = 1, Name="Weed" },
            });
            modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
            {
                new Prescription() { Id = 1, Name = "painrelief for local junkie" },
                new Prescription() { Id = 2, Name = "painrelief for local junkie" },
            });
            modelBuilder.Entity<MedicinePrescription>().HasData(new List<MedicinePrescription>()
            {
                new MedicinePrescription() { MedicineId = 1, PrescriptionId = 1, Quantity = 1, Instructions = "This is all you get for this month!"},
                new MedicinePrescription() { MedicineId = 1, PrescriptionId = 2, Quantity = 3, Instructions = "Try not to smoke it all in onw day!"},
            });
            modelBuilder.Entity<Appointment>().HasData(new List<Appointment>()
            {
                new Appointment() { Id = 1, DoctorId = 1, PatientId = 1, PrescriptionId = null, Booking = DateTime.SpecifyKind(new DateTime(2024, 7, 14, 12, 45, 0), DateTimeKind.Utc)},
                new Appointment() { Id = 2, DoctorId = 1, PatientId = 2, PrescriptionId = 1, Booking = DateTime.SpecifyKind(new DateTime(2024, 4, 21, 9, 5, 0), DateTimeKind.Utc)},
                new Appointment() { Id = 3, DoctorId = 1, PatientId = 2, PrescriptionId = 2, Booking = DateTime.SpecifyKind(new DateTime(2024, 3, 15, 8, 30, 0), DateTimeKind.Utc)},
            });


            /*
            Seeder seeder = new Seeder();

            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
            */

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
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
