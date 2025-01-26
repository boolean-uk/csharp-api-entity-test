using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Appointment> _appointments = new();
        private List<Doctor> _doctors = new();
        private List<Patient> _patients = new();

        private List<string> _patientnames = new()
        {
            "Donald Trump",
            "Fredrik Reinfeldt",
            "Astrid Lindgren",
            "Mike Tyson"
        };

        private List<string> _doctornames = new()
        {
            "Dr. Alok Kanojia",
            "Dr. Sigmund Freud",
            "Dr. Carl Jung",
            "Dr. Friedrich Nietzsche",
        };

        public Seeder()
        {
            for (int i = 0; i < _patientnames.Count; i++)
            {
                Patient patient = new() { Id = i + 1, FullName = _patientnames[i] };
                Doctor doctor = new() { Id = i + 1, FullName = _doctornames[i] };

                _patients.Add(patient);
                _doctors.Add(doctor);
            }

            for (int i = 0; i < _patients.Count; i++)
            {
                Appointment appointment = new Appointment()
                {
                    Booking = DateTime.UtcNow,
                    PatientId = _patients[i].Id,
                    DoctorId = _doctors[i].Id,   
                };

                _appointments.Add(appointment);
            }
        }

        public List<Appointment> Appointments { get { return _appointments; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Patient> Patients { get { return _patients; } }
    }
}
