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
            modelBuilder.Entity<Patient>().HasMany(p => p.Appointments).WithOne(a => a.Patient).HasForeignKey(a => a.PatientId);
            modelBuilder.Entity<Doctor>().HasMany(d => d.Appointments).WithOne(a => a.Doctor).HasForeignKey(a => a.DoctorId);
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.PatientId, a.DoctorId });

            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(new List<Patient>() {
                new Patient() { Id = 1, FullName = "Sick Guy" },
                new Patient() { Id = 2, FullName = "Local Junkie" },
            });
            modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
            {
                new Doctor() { Id = 1, FullName = "Bob Builder" },
            });
            modelBuilder.Entity<Appointment>().HasData(new List<Appointment>()
            {
                new Appointment() { DoctorId = 1, PatientId = 1, Booking = DateTime.SpecifyKind(new DateTime(2024, 7, 14, 12, 45, 0), DateTimeKind.Utc)},
                new Appointment() { DoctorId = 1, PatientId = 2, Booking = DateTime.SpecifyKind(new DateTime(2024, 4, 21, 9, 5, 0), DateTimeKind.Utc)},
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
    }
}
