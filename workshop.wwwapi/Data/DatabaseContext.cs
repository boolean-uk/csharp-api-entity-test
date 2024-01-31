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

            modelBuilder.Entity<Appointment>().HasKey(e => new { e.Booking, e.PatientId, e.DoctorId });

            modelBuilder.Entity<Patient>().HasData(
                new Patient() {Id = 1, FullName = "Joe"},
                new Patient() {Id = 2, FullName = "Jane"}

                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() {Id = 1, FullName = "Doctor Bob" },
                new Doctor() {Id = 2, FullName = "Doctor Lisa" }

                );
            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() {Booking= DateTime.UtcNow, DoctorId = 1, PatientId =2},
                new Appointment() {Booking= DateTime.UtcNow, DoctorId = 2, PatientId =1},
                new Appointment() {Booking= DateTime.UtcNow, DoctorId = 2, PatientId =2}
                
                );

            //TODO: Seed Data Here

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
