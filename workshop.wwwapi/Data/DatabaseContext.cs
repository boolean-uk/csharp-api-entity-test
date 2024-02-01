using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models.PureModels;

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
            modelBuilder.Entity<Appointment>().HasKey(app => new { app.DoctorId, app.PatientId});

            modelBuilder.Entity<Appointment>()
                .HasOne(app => app.Doctor)
                .WithMany(doctor => doctor.Appointments)
                .HasForeignKey(app => app.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(app => app.Patient)
                .WithMany(patient => patient.Appointments)
                .HasForeignKey(app => app.PatientId);

            //TODO: Seed Data Here
            Patient p1 = new Patient() { Id = 5, FullName = "John Doe" };
            Patient p2 = new Patient() { Id = 1, FullName = "Jimmy Bob" };
            modelBuilder.Entity<Patient>().HasData(p1);
            modelBuilder.Entity<Patient>().HasData(p2);

            Doctor d1 = new Doctor() { Id = 1, FullName = "Jan Itor" };
            Doctor d2 = new Doctor() { Id = 3, FullName = "Dr. Acula" };
            modelBuilder.Entity<Doctor>().HasData(d1);
            modelBuilder.Entity<Doctor>().HasData(d2);

            modelBuilder.Entity<Appointment>().HasData(new Appointment() { 
                DoctorId = 1, 
                PatientId = 1, 
                Booking = DateTime.SpecifyKind(new DateTime(2010, 03, 05), DateTimeKind.Utc)
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment() { 
                DoctorId = 1, 
                PatientId = 5, 
                Booking = DateTime.SpecifyKind(new DateTime(2005, 05, 10), DateTimeKind.Utc)
            });
            modelBuilder.Entity<Appointment>().HasData(new Appointment() { 
                DoctorId = 3, 
                PatientId = 5, 
                Booking = DateTime.SpecifyKind(new DateTime(1995, 05, 10), DateTimeKind.Utc)
            });

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
    }
}
