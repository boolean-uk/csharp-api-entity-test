using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
        //private string _connectionString;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
          //  var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
          //  _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
          //  this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(e => new { e.PatientId, e.DoctorId });
            modelBuilder.Entity<MedicinePrescription>().HasKey(e => new { e.MedicineId, e.PrescriptionId });
            modelBuilder.Entity<Prescription>().HasMany(e => e.Appointments).WithOne(e => e.Prescription).HasForeignKey(e => e.PrescriptionId);


            modelBuilder.Entity<Medicine>().HasData(
                new Medicine { Id = 1, Name = "Melatonin" },
                new Medicine { Id = 2, Name = "Ibuprofen" },
                new Medicine { Id = 3, Name = "Penicillin" });



            List<Prescription> prs = new List<Prescription>();

            prs.Add(new Prescription { Id = 1, Quantity = 1, Notes = "Take 3 per day" });
            prs.Add(new Prescription { Id = 2, Quantity = 12, Notes = "Twice a week" });
            prs.Add(new Prescription { Id = 3, Quantity = 3, Notes = "Use when needed" });
            prs.Add(new Prescription { Id = 4, Quantity = 6, Notes = "Avoid if possible" });



            modelBuilder.Entity<Prescription>().HasData(prs);

            List<MedicinePrescription> mps = new List<MedicinePrescription>();
            mps.Add(new MedicinePrescription { Id = 1, MedicineId = 1, PrescriptionId = 1 });
            mps.Add(new MedicinePrescription { Id = 2, MedicineId = 2, PrescriptionId = 2 });
            mps.Add(new MedicinePrescription { Id = 3, MedicineId = 3, PrescriptionId = 2 });
            modelBuilder.Entity<MedicinePrescription>().HasData(mps);


            modelBuilder.Entity<Patient>().HasData(
                new Patient { Id = 1, FullName = "May Doe" },
                new Patient { Id = 2, FullName = "John Smith" },
                new Patient { Id = 3, FullName = "Henry Johnson"});

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, FullName = "Mr. Dentist" },
                new Doctor { Id = 2, FullName = "Mrs. Cardiologist" },
                new Doctor { Id = 3, FullName = "Ms. Nurse" });

            List<Appointment> appointments = new List<Appointment>();
            appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), Type = "online",             DoctorId = 1, PatientId = 1,  PrescriptionId = 1 }); ;
            appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), Type = "3rd floor room 34",  DoctorId = 2, PatientId = 2,  PrescriptionId = 2 });
            appointments.Add(new Appointment { Booking = DateTime.Now.ToUniversalTime(), Type = "2nd floor, room 12", DoctorId = 3, PatientId = 3, PrescriptionId = 3 });
            modelBuilder.Entity<Appointment>().HasData(appointments);

        }


     // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      //  {
      //      //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
      //      optionsBuilder.UseNpgsql(_connectionString);
      //      optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
      //  }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
