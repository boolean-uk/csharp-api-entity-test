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
          
                this.Database.EnsureCreated();
            }

        
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
            modelBuilder.Entity<Perscription>()
                 .HasMany(p => p.Medicines)
                 .WithMany(m => m.Perscription)
                 .UsingEntity<Dictionary<string, object>>(
                     "PrescriptionMedicines",  
                     j => j.HasOne<Medicine>()    
                           .WithMany()
                           .HasForeignKey("MedicinesId")
                           .OnDelete(DeleteBehavior.Cascade),  
                     j => j.HasOne<Perscription>()  
                           .WithMany()
                           .HasForeignKey("PerscriptionId")
                           .OnDelete(DeleteBehavior.Cascade),  
                     j =>
                     {
                         j.HasKey("PerscriptionId", "MedicinesId");  
                         j.ToTable("PrescriptionMedicines");       
                     });

                        modelBuilder.Entity<Perscription>()
                 .HasOne(p => p.Appointment)
                 .WithOne(a => a.Perscription) 
                 .HasForeignKey<Perscription>(p => p.AppointmentId);

            Doctor doctor2 = new Doctor { Id = 2, FullName = "Dr. Jane Doe" };
                Patient patient2 = new Patient { Id = 2, FullName = "John Doe" };
                Doctor doctor = new Doctor { Id = 1, FullName = "Dr. John Doe" };
                Patient patient = new Patient { Id = 1, FullName = "Jane Doe" };

                Appointment appointment = new Appointment { Id = 1, Booking = DateTime.UtcNow, DoctorId = 1, PatientId =  1 };
                Appointment appointment2 = new Appointment { Id = 2, Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2 };

                 Perscription perscription = new Perscription { Id = 1, AppointmentId = 1, Medicines = new List<Medicine>() };
                 Perscription perscription2 = new Perscription { Id = 2, AppointmentId = 2, Medicines = new List<Medicine>() };

                Medicine medicine = new Medicine { Id = 1, Name = "Paracetamol", Quantity = 4, Instructions = "After every meal" };
                Medicine medicine2 = new Medicine { Id = 2, Name = "Ibuprofen", Quantity = 2, Instructions = "Before every meal" };
          

                modelBuilder.Entity<Doctor>().HasData(doctor, doctor2);
                modelBuilder.Entity<Patient>().HasData(patient, patient2);  
                modelBuilder.Entity<Appointment>().HasData(appointment, appointment2);
                modelBuilder.Entity<Perscription>().HasData(perscription, perscription2);
                modelBuilder.Entity<Medicine>().HasData(medicine, medicine2);


                modelBuilder.Entity<Perscription>()
                .HasMany(p => p.Medicines)
                .WithMany(m => m.Perscription)
                .UsingEntity(j => j.HasData(
                    new { MedicinesId = 1, PerscriptionId = 1 },
                    new { MedicinesId = 2, PerscriptionId = 2 }
                    ));

                }
   


            public DbSet<Patient> Patients { get; set; }
            public DbSet<Doctor> Doctors { get; set; }
            public DbSet<Appointment> Appointments { get; set; }
            public DbSet<Medicine> Medicines { get; set; }
            public DbSet<Perscription> Perscriptions { get; set; }
        }
    }
