using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Appointment> _appointments = [];
        private List<Doctor> _doctors = [];
        private List<Patient> _patients = [];

        private List<string> _patientnames =
            [
            "Donald Trump",
            "Fredrik Reinfeldt",
            "Astrid Lindgren",
            "Mike Tyson"
            ];

        
        public Seeder() 
        {
            for(int i = 0; i < _patientnames.Count; i++) 
            {
                Patient patient = new() { Id = i+1, FullName = _patientnames[i] };
                _patients.Add(patient);
            }
        }
        public List<Appointment> Appointments { get { return _appointments; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Patient> Patients { get { return _patients; } }
    }
}
