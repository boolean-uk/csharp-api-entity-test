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
            _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnection")!;
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Doctor>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Patient>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Appointment>()
                .HasKey(x => x.id);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(d => d.DoctorId);
            modelBuilder.Entity<Patient>()
                .HasMany(d => d.Appointments)
                .WithOne(p => p.Patient)
                .HasForeignKey(d => d.PatientId);

            //TODO: Seed Data Here
            modelBuilder.Entity<Doctor>().HasData(Seeder.Doctors);
            modelBuilder.Entity<Patient>().HasData(Seeder.Patients);
            modelBuilder.Entity<Appointment>().HasData(Seeder.Appointments);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
