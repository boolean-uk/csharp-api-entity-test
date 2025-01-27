using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using workshop.wwwapi.Enums;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data;

public class DatabaseContext : DbContext
{
    private readonly string _connectionString;

    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
        //Database.EnsureCreated();
    }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionLine> PrescriptionLines { get; set; }
    public DbSet<Medicine> Medicines { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId });
        modelBuilder.Entity<Appointment>().HasKey(a => a.Id);
        
        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Doctor)
            .WithMany(d => d.Appointments)
            .HasForeignKey(a => a.DoctorId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Patient)
            .WithMany(p => p.Appointments)
            .HasForeignKey(a => a.PatientId);
        
        modelBuilder.Entity<Prescription>()
            .HasOne(p => p.Appointment)
            .WithMany(a => a.Prescriptions)
            .HasForeignKey(p => p.AppointmentId);
        
        modelBuilder.Entity<Prescription>()
            .HasMany(p => p.Lines)
            .WithOne()
            .HasForeignKey(l => l.PrescriptionId);

        modelBuilder.Entity<PrescriptionLine>()
            .HasKey(l => new { l.PrescriptionId, l.MedicineId });
        
        modelBuilder.Entity<PrescriptionLine>()
            .HasOne(l => l.Medicine)
            .WithMany()
            .HasForeignKey(l => l.MedicineId);

        //TODO: Seed Data Here
        modelBuilder.Entity<Patient>().HasData(
            new Patient { Id = 1, FullName = "John Doe" },
            new Patient { Id = 2, FullName = "Jane Doe" }
        );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { Id = 1, FullName = "Dr. John Smith" },
            new Doctor { Id = 2, FullName = "Dr. Jane Smith" }
        );

        modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                Id = 1,
                Type = AppointmentType.Online, DoctorId = 1, PatientId = 1,
                Booking = DateTime.UtcNow - TimeSpan.FromMinutes(60)
            },
            new Appointment
            {
                Id = 2,
                Type = AppointmentType.InPerson, DoctorId = 2, PatientId = 2,
                Booking = DateTime.UtcNow - TimeSpan.FromMinutes(30)
            }
        );

        modelBuilder.Entity<Medicine>().HasData(
            new Medicine { Id = 1, Name = "Paracetamol", Category = "Analgesics" },
            new Medicine { Id = 2, Name = "Cetirizine", Category = "Antihistamines" },
            new Medicine { Id = 3, Name = "Warfarin", Category = "Anticoagulants" }
        );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription
            {
                Id = 1,
                AppointmentId = 1
            },
            new Prescription
            {
                Id = 2,
                AppointmentId = 2
            }
        );
        
        modelBuilder.Entity<PrescriptionLine>().HasData(
            new PrescriptionLine
            {
                PrescriptionId = 1,
                MedicineId = 1,
                Quantity = 28,
                Instructions = "Take two pills up to four times a day. Wait at least two hours between each dose."
            },
            new PrescriptionLine
            {
                PrescriptionId = 1,
                MedicineId = 2,
                Quantity = 7,
                Instructions = "Take one pill every night"
            },
            new PrescriptionLine
            {
                PrescriptionId = 2,
                MedicineId = 3,
                Quantity = 14,
                Instructions = "Take one pill in the morning for the first two days. Then take two pills every morning."
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_connectionString);
        optionsBuilder.LogTo(message => Debug.WriteLine(message));
        optionsBuilder.ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    }
}