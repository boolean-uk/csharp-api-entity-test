using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
        // Fjern tilkoblingsstrengen fra her
        this.Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.ToTable("appointments");

            // Sett sammensatt nøkkel
            entity.HasKey(e => new { e.PatientId, e.DoctorId });

            entity.Property(e => e.appointmentDate)
                  .HasColumnName("booking_date")
                  .HasConversion(
                      v => v.ToUniversalTime(),
                      v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
                  .IsRequired();

            // Relasjoner
            entity.HasOne(e => e.Doctor)
                  .WithMany(d => d.Appointments)
                  .HasForeignKey(e => e.DoctorId);

            entity.HasOne(e => e.Patient)
                  .WithMany(p => p.Appointments)
                  .HasForeignKey(e => e.PatientId);
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("doctors");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FullName).HasColumnName("name").HasMaxLength(100);

            // Seed-data for leger
            entity.HasData(
                new Doctor { Id = 1, FullName = "Dr. House" },
                new Doctor { Id = 2, FullName = "Dr. Watson" }
            );
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("patients");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FullName).HasColumnName("name").HasMaxLength(100);

            // Seed-data for pasienter
            entity.HasData(
                new Patient { Id = 1, FullName = "John Doe" },
                new Patient { Id = 2, FullName = "Jane Smith" }
            );
        });

        // Seed-data for avtaler
        modelBuilder.Entity<Appointment>().HasData(
            new Appointment { PatientId = 1, DoctorId = 1, appointmentDate = new DateTime(2025, 1, 1, 10, 0, 0, DateTimeKind.Utc) },
            new Appointment { PatientId = 2, DoctorId = 2, appointmentDate = new DateTime(2025, 1, 2, 14, 0, 0, DateTimeKind.Utc) }
        );
    }


    // Fjern OnConfiguring-metoden, den er ikke nødvendig for migrasjoner
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
}
