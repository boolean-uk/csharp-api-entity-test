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
            //this.Database.EnsureCreated();      
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Appointment Key etc.. Add Here
            /* THIS IS ONLY IF YOU WANT TO use fluent API.. For instance:
             modelBuilder.Entity<Band>().HasMany(x => x.Members).WithOne(x => x.Band).HasForeignKey(x => x.BandId);
             modelBuilder.Entity<BandMemberInstrument>().HasKey(e => new { e.BandMemberId, e.InstrumentId });*/

            //Need to specify a composite primary key consisting of "DoctorId" and "PatientId" and "Booking"
            modelBuilder.Entity<Appointment>().HasKey(a => new { a.DoctorId, a.PatientId, a.Booking });


            // Our collection..
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "GoogleP" },
                new Patient() { Id = 2, FullName = "WIKIP" }
                //new Patient() { Id = 3, FullName = "AMOZP" },
                //new Patient() { Id = 4, FullName = "FaceP" }
                );

            //Seeding Doctor:
            modelBuilder.Entity<Doctor>().HasData(
                new Doctor() { Id = 1, FullName = "TIKOKAS" },
                new Doctor() { Id = 2, FullName = "INSTRAAS" }
                );

            //Seeding Appointment:
            //var sqlFormattedDate = new DateTime().Date.ToString("yyyy-MM-dd HH:mm:ss");
            //DateTime.SpecifyKind(new DateTime(2024, 5, 7, 8, 30, 0), DateTimeKind.Utc)}
            //DateTime _dateTime = DateTime.Now;

            modelBuilder.Entity<Appointment>().HasData(
                new Appointment() { DoctorId = 1, PatientId = 2, Booking = DateTime.Parse("1999/10/12 12:00:00"), Appointmenttype = AppointmentType.Local },
                new Appointment() { DoctorId = 1, PatientId = 1, Booking = DateTime.Parse("1998/10/12 12:00:00"), Appointmenttype = AppointmentType.Online },
                  new Appointment() { DoctorId = 2, PatientId = 2, Booking = DateTime.Parse("1997/10/12 12:00:00"), Appointmenttype = AppointmentType.Local }
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
