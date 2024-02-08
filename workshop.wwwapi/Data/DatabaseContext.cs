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
            modelBuilder.Entity<Appointment>().HasKey(e => new { e.Booking, e.PatientId, e.DoctorId });

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);


            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Nigel"}, 
                new Patient() { Id = 2, FullName = "AJ"}, 
                new Patient() { Id = 3, FullName = "Kevin"}
                );
            
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Doctor Phil"}, 
                new Doctor() { Id = 2, FullName = "Doctor Jim"}, 
                new Doctor() { Id = 3, FullName = "Doctor R2D2"}
                );

            DateTime now = DateTime.UtcNow;
            TimeSpan timeDifference = TimeSpan.FromMinutes(30);

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { Booking = now, DoctorId = 1, PatientId = 1 },
                new Appointment() { Booking = now /*+ timeDifference*/, DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = now + 2 * timeDifference, DoctorId = 3, PatientId = 1 },
                new Appointment() { Booking = now + 3 * timeDifference, DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = now + 4 * timeDifference, DoctorId = 2, PatientId = 1 },
                new Appointment() { Booking = now + 5 * timeDifference, DoctorId = 3, PatientId = 3 },
                new Appointment() { Booking = now + 6 * timeDifference, DoctorId = 2, PatientId = 2 },
                new Appointment() { Booking = now + 7 * timeDifference, DoctorId = 2, PatientId = 3 }
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
    }
}
