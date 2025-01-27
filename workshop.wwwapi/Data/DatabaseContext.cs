using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId });

            modelBuilder.Entity<Prescription>()
            .HasOne(p => p.appointment) 
            .WithOne()
            .HasForeignKey<Prescription>(p => new { p.PatientId, p.DoctorId });

            modelBuilder.Entity<Appointment>()
            .HasMany(a => a.prescriptions) 
            .WithOne(p => p.appointment) 
            .HasForeignKey(p => new { p.PatientId, p.DoctorId });

            modelBuilder.Entity<MedicinePrescription>()
            .HasKey(mp => new { mp.PrescriptionId, mp.MedicineId });


            //TODO: Seed Data Here
            modelBuilder.Entity<MedicinePrescription>().HasData(
             new MedicinePrescription { PrescriptionId = 1, MedicineId = 1, Quantity = 10, Notes = "Take with water", Name = "Vitamin 190X" },
             new MedicinePrescription { PrescriptionId = 2, MedicineId = 2, Quantity = 20, Notes = "Take after meals", Name = "Aspirin" },
             new MedicinePrescription { PrescriptionId = 3, MedicineId = 1, Quantity = 10, Notes = "Take with water" , Name = "Vitamin 190X" },
             new MedicinePrescription { PrescriptionId = 4, MedicineId = 2, Quantity = 20, Notes = "Take after meals", Name = "Aspirin" },
             new MedicinePrescription { PrescriptionId = 5, MedicineId = 1, Quantity = 10, Notes = "Take with water", Name = "Vitamin 190X" },
             new MedicinePrescription { PrescriptionId = 6, MedicineId = 2, Quantity = 20, Notes = "Take after meals", Name = "Aspirin" }
   );
            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "Axel" },
                new Patient { Id = 2, FullName = "Rob" },
                new Patient { Id = 3, FullName = "Nick" }
    );
            modelBuilder.Entity<Doctor>().HasData(
               new Doctor { Id = 1, FullName = "Kris" },
               new Doctor { Id = 2, FullName = "Coke" },
               new Doctor { Id = 3, FullName = "Pope" });

            modelBuilder.Entity<Prescription>().HasData(
             new Prescription { PrescriptionId = 1, PatientId = 2, DoctorId = 1, AppointmentId = 1 },  
             new Prescription { PrescriptionId = 2, PatientId = 3, DoctorId = 1, AppointmentId = 2 },  
             new Prescription { PrescriptionId = 3, PatientId = 2, DoctorId = 2, AppointmentId = 3 },  
             new Prescription { PrescriptionId = 4, PatientId = 3, DoctorId = 2, AppointmentId = 4 },  
             new Prescription { PrescriptionId = 5, PatientId = 1, DoctorId = 3, AppointmentId = 5 },  
             new Prescription { PrescriptionId = 6, PatientId = 2, DoctorId = 3, AppointmentId = 6 }  
    );  



            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { MedicineId = 1, Name = "Vitamin 190X", Instruction = "Take with water", Quantity = 10 },
                new Medicine { MedicineId = 2, Name = "Aspirin", Instruction = "Take after meals", Quantity = 20 }
            );


            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 2 , Appointment_Id = 1, PrescriptionId = 1, Type = AppointmentType.Online},
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 3, Appointment_Id = 2 , PrescriptionId = 2, Type = AppointmentType.Online },
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2, Appointment_Id = 3 , PrescriptionId = 3, Type = AppointmentType.Online },
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 3, Appointment_Id = 4 , PrescriptionId = 4, Type = AppointmentType.InPerson },
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 3, PatientId = 1, Appointment_Id = 5 , PrescriptionId = 5, Type = AppointmentType.Online },
                new Appointment { Booking = DateTime.UtcNow, DoctorId = 3, PatientId = 2, Appointment_Id = 6, PrescriptionId = 6, Type = AppointmentType.InPerson }

                );

      

            base.OnModelCreating(modelBuilder);
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
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicinePrescription> medicinePrescriptions { get; set; }
       

    }
}
