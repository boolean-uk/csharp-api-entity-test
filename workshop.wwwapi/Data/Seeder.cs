using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {

        private List<Patient> _patients = new();
        private List<Doctor> _doctors = new();
        private List<Appointment> _appointments = new();


        public Seeder() 
        {
            _patients.Add(new() { Id = 1, FullName = "Iamin Extremepain" });
            _patients.Add(new() { Id = 2, FullName = "Greg Hurt" });

            _doctors.Add(new() { Id = 1, FullName = "Will Saveu" });
            _doctors.Add(new() { Id = 2, FullName = "John Bonesaw" });

            _appointments.Add(new() { DoctorId =  1, PatientId = 1, Booking = DateTime.UtcNow.AddDays(1)});
            _appointments.Add(new() { DoctorId= 2, PatientId = 2, Booking = DateTime.UtcNow.AddDays(3) });
        }

        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List <Appointment> Appointments { get {  return _appointments; } }
    }
}
