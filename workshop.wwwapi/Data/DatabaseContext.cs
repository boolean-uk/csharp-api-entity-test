using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models.DatabaseModels;

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
            Seeder seeder = new Seeder();

            //TODO: Appointment Key etc.. Add Here
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId });
            modelBuilder.Entity<Patient>().HasMany(x => x.Appointments).WithOne(x => x.Patient).HasForeignKey(x => x.PatientId);
            modelBuilder.Entity<Doctor>().HasMany(x => x.Appointments).WithOne(x => x.Doctor).HasForeignKey(x => x.DoctorId);
            modelBuilder.Entity<Perscription>().HasMany(x => x.Medicines).WithMany(x => x.Perscriptions).UsingEntity<MedicinePerscription>();
            


            //TODO: Seed Data Here
            modelBuilder.Entity<Patient>().HasData(seeder.Patients);
            modelBuilder.Entity<Doctor>().HasData(seeder.Doctors);
            modelBuilder.Entity<Medicine>().HasData(seeder.Medicines);
            modelBuilder.Entity<Perscription>().HasData(seeder.Perscriptions);
            modelBuilder.Entity<Appointment>().HasData(seeder.Appointments);
            modelBuilder.Entity<MedicinePerscription>().HasData(seeder.MedicinePerscriptions);
            

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemmoryDatabase(databaseName: "_connectionString");
            optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console        
        }


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Perscription> Perscriptions { get; set; }
        public DbSet<MedicinePerscription> MedicinePerscriptions { get; set; }
    }
}
