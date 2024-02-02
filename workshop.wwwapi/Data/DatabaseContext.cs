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

            //TODO: Seed Data Here
            // Our collection..
            modelBuilder.Entity<Patient>().HasData(
                new Patient() { Id = 1, FullName = "GoogleP" },
                new Patient() { Id = 2, FullName = "WIKIP" }
                //new Patient() { Id = 3, FullName = "AMOZP" },
                //new Patient() { Id = 4, FullName = "FaceP" }
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
