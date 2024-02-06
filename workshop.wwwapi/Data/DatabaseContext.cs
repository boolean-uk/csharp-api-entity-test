using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Reflection.Metadata;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class DatabaseContext : DbContext
    {
       // private string _connectionString;
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
          //  var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
           // _connectionString = configuration.GetValue<string>("ConnectionStrings:DefaultConnectionString")!;
            //this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Appointment Key etc..
            modelBuilder.Entity<Appointment>().HasKey(i => new { i.PatientId, i.DoctorId });
            modelBuilder.Entity<Doctor>().HasMany(e => e.Appointments).WithOne(e => e.Doctor).HasForeignKey(e => e.DoctorId).IsRequired();
            modelBuilder.Entity<Patient>().HasMany(e => e.Appointments).WithOne(e => e.Patient).HasForeignKey(e => e.PatientId).IsRequired();
            modelBuilder.Entity<Appointment>().HasMany(p => p.Prescriptions).WithOne(e => e.Appointment).HasForeignKey(e => e.AppointmentId).IsRequired(false);
            modelBuilder.Entity<Medicine>().HasMany(e => e.MedicinePrescriptions).WithOne(e => e.Medicine).HasForeignKey(e => e.MedicineId).IsRequired();
            modelBuilder.Entity<Prescription>().HasMany(e => e.MedicinePrescriptions).WithOne(e => e.Prescription).HasForeignKey(e => e.PrescriptionId).IsRequired();
            modelBuilder.Entity<MedicinePrescription>().HasKey(i => new { i.MedicineId, i.PrescriptionId});
            
            // Seed Data 
          /*  Patient[] patient = [new Patient() { Id = 1,FullName = "Ole Olsen" }, new Patient() {Id=2, FullName = "Sigrid Furukongle" }];
            modelBuilder.Entity<Patient>().HasData(patient[0]);
            modelBuilder.Entity<Patient>().HasData(patient[1]);
            modelBuilder.Entity<Doctor>().HasData(new Doctor() { Id = 1, FullName = "Arne Arnesen"});
            modelBuilder.Entity<Doctor>().HasData(new Doctor() { Id = 2, FullName = "Endre Endresen" });

            Seeder _seeder = new Seeder();
            DateTime date = new DateTime(2024,06,12,09,50,10, DateTimeKind.Utc);
                      
            modelBuilder.Entity<Doctor>().HasData(_seeder.Doctors);
            modelBuilder.Entity<Patient>().HasData(_seeder.Patients);
            modelBuilder.Entity<Appointment>().HasData(new Appointment(){ Id =1, Booking= date.ToString(),PatientId = 2, DoctorId = 1 });
            modelBuilder.Entity<Appointment>().HasData(new Appointment() { Id = 2, Booking = date.ToString(), PatientId = 1, DoctorId = 2 });
            modelBuilder.Entity<Appointment>().HasData(_seeder.Appointments);
           
            modelBuilder.Entity<Medicine>().HasData(new Medicine() {Id=1,Name="Paracet", Notes="2-3 pr day", Quantity=500});
            modelBuilder.Entity<Medicine>().HasData(new Medicine() { Id = 2, Name = "Ibux", Notes = "3-4 pr day", Quantity = 20 });
            modelBuilder.Entity<Prescription>().HasData(new Prescription() { Id = 1, AppointmentId = 2 });
            modelBuilder.Entity<Prescription>().HasData(new Prescription() { Id = 2, AppointmentId = 3 });
            modelBuilder.Entity<Prescription>().HasData(new Prescription() { Id = 3, AppointmentId = 3 });
            modelBuilder.Entity<MedicinePrescription>().HasData(new MedicinePrescription() { Id = 1, MedicineId = 1, PrescriptionId = 1 });
        */
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        //    optionsBuilder.UseNpgsql(_connectionString);
            optionsBuilder.LogTo(message => Debug.WriteLine(message)); //see the sql EF using in the console
            
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<MedicinePrescription> MedicinePrescriptions { get; set; }
    }
}
