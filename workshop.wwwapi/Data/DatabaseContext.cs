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
            // Configure the Patient model
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.ToTable("patients");
                entity.HasKey(e => e.Id).HasName("patient_id");
                entity.Property(e => e.Id).HasColumnName("patient_id");
                entity.Property(e => e.FullName).HasColumnName("full_name");
            });

            // Configure the Doctor model
            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.ToTable("doctors");
                entity.HasKey(e => e.Id).HasName("doctor_id");
                entity.Property(e => e.Id).HasColumnName("doctor_id");
                entity.Property(e => e.FullName).HasColumnName("full_name");
            });

            // Configure the Appointment model
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("appointments");
                entity.Property(e => e.Booking).HasColumnName("booking");
                entity.HasKey(e => new { e.PatientId, e.DoctorId }).HasName("pk_appointments");

                // Define foreign key relationships
                entity.HasOne(e => e.Patient)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(e => e.PatientId)
                    .HasConstraintName("fk_appointments_patients");

                entity.HasOne(e => e.Doctor)
                    .WithMany(d => d.Appointments)
                    .HasForeignKey(e => e.DoctorId)
                    .HasConstraintName("fk_appointments_doctors");

            });

            //TODO: Seed Data Here
            //Update the db context class and seed 1 or 2 patients with hard-coded ids and names
            modelBuilder.Entity<Patient>().HasData(
                new { Id = 1, FullName = "Jeon Jungkook" },
                new { Id = 2, FullName = "Kim Taehyung" }
                );

            // Update the db context class and seed 2 doctors with hard-coded ids and names; create a few appointments for each doctor with some patients
            modelBuilder.Entity<Doctor>().HasData(
                new { Id = 1, FullName = "Felix Lee" },
                new { Id = 2, FullName = "Hyunjin" }
                );

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment { PatientId = 1, DoctorId = 1, Booking = DateTime.SpecifyKind(new DateTime(2024, 3, 7, 14, 0, 0), DateTimeKind.Utc), Type="Online" },
                new Appointment { PatientId = 2, DoctorId = 2, Booking = DateTime.SpecifyKind(new DateTime(2024, 4, 8, 15, 0, 0), DateTimeKind.Utc), Type= "In Person" }
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
