using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        public List<Patient> Patients = new List<Patient>()
        {
            new Patient{Id = 1, FullName = "Homer Simpson"},
            new Patient{Id = 2, FullName = "George Washington"}
        };

        public List<Doctor> Doctors = new List<Doctor>()
        { 
            new Doctor{Id = 1, FullName = "Doctor George"},
            new Doctor{Id = 2, FullName = "Doctor Homer"}
        };

        public List<Appointment> Appointments = new List<Appointment>()
        {
            new Appointment{Booking = DateTime.SpecifyKind(DateTime.UtcNow.AddDays(1), DateTimeKind.Utc), DoctorId = 1, PatientId = 1},
            new Appointment{Booking = DateTime.SpecifyKind(DateTime.UtcNow.AddDays(2), DateTimeKind.Utc), PatientId = 2, DoctorId = 2}

        };
    }
}
