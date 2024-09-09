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
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(i => new { i.DoctorId, i.PatientId, i.PerscriptionId });

            modelBuilder.Entity<PerscriptionMedicine>().HasKey(pm => new { pm.MedicineId, pm.PerscriptionId });

            modelBuilder.Entity<PerscriptionMedicine>().HasOne(pm => pm.Medicine).WithMany(p => p.PerscriptionMedicines).HasForeignKey(pm => pm.MedicineId);

            modelBuilder.Entity<PerscriptionMedicine>().HasOne(pm => pm.Perscription).WithMany(p => p.PerscriptionMedicines).HasForeignKey(pm => pm.PerscriptionId);

            //TODO: Seed Data Here
            Seeder seeder = new Seeder();

            modelBuilder.Entity<Patient>().HasData(seeder.patients);
            modelBuilder.Entity<Doctor>().HasData(seeder.doctors);
            modelBuilder.Entity<Appointment>().HasData(seeder.appointments);
            modelBuilder.Entity<Medicine>().HasData(seeder.medicines);
            modelBuilder.Entity<Perscription>().HasData(seeder.perscriptions);
            modelBuilder.Entity<PerscriptionMedicine>().HasData(seeder.perscriptionMedicines);
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
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Perscription> Perscriptions { get; set; }
        public DbSet<PerscriptionMedicine> PerscriptionsMedicines { get; set; }
    }
}
