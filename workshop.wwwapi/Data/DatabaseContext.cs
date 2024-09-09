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

            //TODO: Seed Data Here
            Seeder seeder = new Seeder();
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
            modelBuilder.Entity<Appointment>().HasKey(f => new {f.PatientId, f.DoctorId});
            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient).WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId);
            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany(p => p.Appointments).HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Patient>().HasKey(d => d.Id);
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Doctor>().HasKey(d => d.Id);

            modelBuilder.Entity<Medicine>().HasData(seeder.Medicines);
            modelBuilder.Entity<Medicine>().HasMany(m => m.Prescriptions).WithMany(p => p.Medicines);
            modelBuilder.Entity<Prescription>().HasData(seeder.Prescriptions);
            modelBuilder.Entity<Prescription>().HasMany(p => p.Medicines).WithMany(m => m.Prescriptions);
            //modelBuilder.Entity<Prescription>().HasOne(p => p.Appointment)
            //                                   .WithMany(a => a.Prescriptions)
            //                                   .HasForeignKey(p => new { p.PatientId, p.DoctorId });



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase(databaseName: "Database");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            optionsBuilder.EnableSensitiveDataLogging();
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set;  }
    }
}
