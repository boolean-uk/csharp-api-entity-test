using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();
        public Seeder()
        {
            //Update the db context class and seed 1 or 2 patients with hard-coded ids and names
            _patients.Add(new Patient() { Id = 1, FullName = "Maynard James Keenan" });
            _patients.Add(new Patient() { Id = 2, FullName = "Danny Carey" });

            //Update the db context class and seed 2 doctors with hard-coded ids and names;
            _doctors.Add(new Doctor() { Id = 1, FullName = "Justin Chancellor" });
            _doctors.Add(new Doctor() { Id = 2, FullName = "Adam Jones" });

            //create a few appointments for each doctor with some patients
            _appointments.Add(new Appointment() { Id = 1, DoctorId = 1, PatientId = 1, Booking = DateTime.UtcNow.AddDays(1) });
            _appointments.Add(new Appointment() { Id = 2, DoctorId = 1, PatientId = 2, Booking = DateTime.UtcNow.AddDays(2) });

            _appointments.Add(new Appointment() { Id = 3, DoctorId = 2, PatientId = 1, Booking = DateTime.UtcNow.AddDays(3) });
            _appointments.Add(new Appointment() { Id = 4, DoctorId = 2, PatientId = 2, Booking = DateTime.UtcNow.AddDays(4) });
            _appointments.Add(new Appointment() { Id = 5, DoctorId = 2, PatientId = 2, Booking = DateTime.UtcNow.AddDays(5) });
        }

        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get { return _appointments; } }
    }
}
