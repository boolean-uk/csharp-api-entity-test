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
            modelBuilder.Entity<Appointment>()
                .HasKey(k => new { k.Id });

            
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);

            modelBuilder.Entity<Appointment>()
                .HasMany(a => a.Prescriptions)
                .WithOne(p => p.Appointment)
                .HasForeignKey(p => p.AppointmentId);
            
            //! Extension
            modelBuilder.Entity<PrescriptionMedicine>()
                .HasKey(pm => new { pm.PrescriptionId, pm.MedicineId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Johan Johansson"},
                new Patient { Id = 2, FullName = "Sven Svensson"},
                new Patient { Id = 3, FullName = "Anders Andresson"},
                new Patient { Id = 4, FullName = "Erik Eriksson"},
                new Patient { Id = 5, FullName = "Emma Eriksson"},
                new Patient { Id = 6, FullName = "Knut Knutsson"},
                new Patient { Id = 7, FullName = "Bengt Bengtsson"},
                new Patient { Id = 8, FullName = "Jesper Jespersson"}
            );


            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Doktor Docktorsson"},
                new Doctor { Id = 2, FullName = "Jöran Jöransson"},
                new Doctor { Id = 3, FullName = "Filip Filipsson"}
            );

            List<Appointment> listOfAppointments =
            [
                new Appointment { Id = 1, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 3, PatientId = 1 },
                new Appointment { Id = 2, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 1, PatientId = 4 },
                new Appointment { Id = 3, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 3, PatientId = 2 },
                new Appointment { Id = 4, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 2, PatientId = 6 },
                new Appointment { Id = 5, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 3, PatientId = 3 },
                new Appointment { Id = 6, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 3, PatientId = 5 },
                new Appointment { Id = 7, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 2, PatientId = 7 },
                new Appointment { Id = 8, Booking = DateTime.Now.ToString("yyyy-MM-dd"), DoctorId = 1, PatientId = 8 },
            ];

            modelBuilder.Entity<Appointment>().HasData( listOfAppointments );

            //! Extension: Seeding medicine and prescriptions
            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { MedicineId = 1, Name = "Medicine 1", Description = "Description 1" },
                new Medicine { MedicineId = 2, Name = "Medicine 2", Description = "Description 2" }
            );

            // Seed prescriptions associated with appointments
            modelBuilder.Entity<Prescription>().HasData(
                new Prescription { PrescriptionId = 1, AppointmentId = 1 },
                new Prescription { PrescriptionId = 2, AppointmentId = 2 }

            );

            modelBuilder.Entity<PrescriptionMedicine>().HasData(
                new PrescriptionMedicine { PrescriptionId = 1, MedicineId = 1, Quantity = 2, Notes = "Take with food" },
                new PrescriptionMedicine { PrescriptionId = 1, MedicineId = 2, Quantity = 1, Notes = "Before bedtime" },
                new PrescriptionMedicine { PrescriptionId = 2, MedicineId = 2, Quantity = 3, Notes = "Twice a day" }

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

        //! Extension
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionMedicine> PrescriptionMedicines { get; set; }

    }
}
