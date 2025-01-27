using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnectionString"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           Seeder seed = new Seeder();



            modelBuilder.Entity<Appointment>()
                .HasKey(a => new { a.DoctorId, a.PatientId });

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.Appointments)
                .WithOne(a => a.Doctor)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Appointments)
                .WithOne(a => a.Patient)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicinePrescription>()
        .HasKey(mp => new { mp.PrescriptionId, mp.MedicineId }); // Composite primary key

            modelBuilder.Entity<MedicinePrescription>()
                .HasOne(mp => mp.Prescription)
                .WithMany(p => p.MedicinePrescriptions)
                .HasForeignKey(mp => mp.PrescriptionId);

            modelBuilder.Entity<MedicinePrescription>()
                .HasOne(mp => mp.Medicine)
                .WithMany(m => m.MedicinePrescriptions)
                .HasForeignKey(mp => mp.MedicineId);

            modelBuilder.Entity<Prescription>()
         .HasOne(p => p.Appointment)
         .WithMany()
         .HasForeignKey(p => new { p.DoctorId, p.PatientId });

            modelBuilder.Entity<Medicine>()
        .HasMany(m => m.MedicinePrescriptions)
        .WithOne(mp => mp.Medicine);


            modelBuilder.Entity<Doctor>().HasData(seed.Doctors);
            modelBuilder.Entity<Patient>().HasData(seed.Patients);
            modelBuilder.Entity<Appointment>().HasData(seed.Appointments);
            modelBuilder.Entity<Medicine>().HasData(seed.Medicines);
            modelBuilder.Entity<Prescription>().HasData(seed.Prescriptions);
            modelBuilder.Entity<MedicinePrescription>().HasData(seed.MedicinePrescriptions);
        }
     


        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
