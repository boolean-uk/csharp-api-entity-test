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
            _patients.Add(new Patient() { Id = 1, FullName = "Brian Smith" });
            _patients.Add (new Patient() { Id = 2, FullName = "Anne Wayne" });
            _doctors.Add(new Doctor() { Id = 1, FullName = "John Doe" });
            _doctors.Add(new Doctor() { Id = 2, FullName = "Jane Doe" });
            _appointments.Add(new Appointment() { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 1 });
            _appointments.Add(new Appointment() { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 2});
        }


        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get { return _appointments; } }
    }
}
