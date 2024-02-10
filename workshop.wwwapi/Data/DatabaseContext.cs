using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Loading the defaultconnectionstring value from the appsettings.json
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();
            _connectionString = configuration
                .GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Patients
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Joel Joelsson" },
                new Patient { Id = 2, FullName = "Patrik Patriksson" },
                new Patient { Id = 3, FullName = "Peter Petersson" },
                new Patient { Id = 4, FullName = "Gunnar Gunnarsson" }
            );

            //Doctors
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "DR. Olleson" },
                new Doctor { Id = 2, FullName = "DR. Andersson" },
                new Doctor { Id = 3, FullName = "DR. Eriksson" },
                new Doctor { Id = 4, FullName = "DR. Johnnyson" }
            );

            //Appointments, configuration
            modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<MedicinePrescription>()
            .HasKey(mp => new { mp.MedicineId, mp.PrescriptionId });

            //Appointments data
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Id = 1, AppointmentDate = DateTime.UtcNow, 
                    PatientId = 1, DoctorId = 1 },
                new Appointment { Id = 2, AppointmentDate = DateTime.UtcNow, 
                    PatientId = 2, DoctorId = 2 },
                new Appointment { Id = 3, AppointmentDate = DateTime.UtcNow, 
                    PatientId = 3, DoctorId = 3 },
                new Appointment { Id = 4, AppointmentDate = DateTime.UtcNow, 
                    PatientId = 4, DoctorId = 4 }
            );


            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Medicine1", quantity = 2, Notes = "note1" },
                new Medicine { Id = 2, Name = "Medicine2", quantity = 3, Notes = "note2" },
                new Medicine { Id = 3, Name = "Medicine3", quantity = 1, Notes = "note3" },
                new Medicine { Id = 4, Name = "Medicine4", quantity = 5, Notes = "note4" },
                new Medicine { Id = 5, Name = "Medicine5", quantity = 2, Notes = "note5" });

            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { Id = 1, Name = "Prescription1", AppointmentId = 1 },
                new Prescription { Id = 2, Name = "Prescription2", AppointmentId= 2 },
                new Prescription { Id = 3, Name = "Prescription3", AppointmentId = 3 });

            

            modelBuilder.Entity<MedicinePrescription>().HasData(
            new { MedicineId = 1, PrescriptionId = 1 },
            new { MedicineId = 1, PrescriptionId = 2 },
            new { MedicineId = 4, PrescriptionId = 3 },
            new { MedicineId = 5, PrescriptionId = 3 }
        );
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