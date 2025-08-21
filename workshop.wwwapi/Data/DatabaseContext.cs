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

            //modelBuilder.Entity<Appointment>().HasKey(a => new {a.DoctorId, a.PatientId });

            modelBuilder.Entity<Appointment>().HasOne(a => a.Patient).WithMany(p => p.Appointments).HasForeignKey(a => a.PatientId);

            
            modelBuilder.Entity<Appointment>().HasOne(a => a.Doctor).WithMany(d => d.Appointments).HasForeignKey(a => a.DoctorId);

            //TODO: Appointment Key etc.. Add Here


            //TODO: Seed Data Here

            modelBuilder.Entity<Patient>().HasData(new Patient() { Id = 1, FullName = "Johan Reitan" }, new Patient() { Id = 2, FullName = "Georg Reitan" } );

            modelBuilder.Entity<Doctor>().HasData(new Doctor() { Id = 1, FullName = "Tora Klippen", Appointments = new List<Appointment>() }, new Doctor() { Id = 2, FullName = "Inger Hovland", Appointments = new List<Appointment>() } );

            modelBuilder.Entity<Appointment>().HasData(new Appointment() { Id = 1, Booking = DateTime.Parse("2020-05-04 20:04:30").ToUniversalTime(), DoctorId = 1, PatientId = 1 }, new Appointment() { Id = 2, Booking = DateTime.Parse("2020-05-04 21:04:30").ToUniversalTime(), DoctorId = 1, PatientId = 2 });
            

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
