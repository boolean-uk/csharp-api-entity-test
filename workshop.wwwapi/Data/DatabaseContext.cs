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
            .HasKey(a => new { a.DoctorId, a.PatientId });

            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "Jonas Berlin" },
                new Patient() { Id = 2, FullName = "Timmy Smith" }
                );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "Jan Thingsaker" },
                new Doctor() { Id = 2, FullName = "Ragnhild Ilnas" });

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { Booking = new DateTime(2024, 9, 15, 9, 15, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 2 },
                new Appointment() { Booking = new DateTime(2024, 11, 1, 13, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 1 });

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
