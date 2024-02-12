using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<string> _firstnames = new List<string>()
        {
            "Andy",
            "Clyde",
            "Jekyll",
            "Hannibal",
            "Bonnie",
            "Will",
            "Graham",
            "Lisa",
            "Edison",
            "Freddy",
            "Crueger"
        };

        private List<string> _lastnames = new List<string>()
        {
            "Lecter",
            "Tesla",
            "Doofenschmitz",
            "Crawford",
            "Reed",
            "McGallan",
            "Space",
            "Trumpet"
        };

        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _patients = new List<Patient>();
        private List<Appointment> _appointments = new List<Appointment>();

        public Seeder() 
        {
            Random doctorRandom = new Random();
            Random patientRandom = new Random();
            Random appointmentRandom = new Random();
            RandomDateTime dateTime = new RandomDateTime();


            for (int i = 1; i <= 20; i++)
            {
                Doctor doctor = new Doctor();
                doctor.Id = i;
                doctor.FullName = $"{_firstnames[doctorRandom.Next(_firstnames.Count)]} {_lastnames[doctorRandom.Next(_lastnames.Count)]}";
                _doctors.Add(doctor);
            }

            for (int i = 1; i <= 20; i++)
            {
                Patient patient = new Patient();
                patient.Id = i;
                patient.FullName = $"{_firstnames[patientRandom.Next(_firstnames.Count)]} {_lastnames[patientRandom.Next(_lastnames.Count)]}";
                _patients.Add(patient);
            }
            for (int i = 1; i <= 20; i++)
            {
                Appointment appointment = new Appointment();
                appointment.Booking = dateTime.New();
                appointment.DoctorId = _doctors[appointmentRandom.Next(_doctors.Count)].Id;
                appointment.PatientId = _patients[appointmentRandom.Next(_patients.Count)].Id;
                _appointments.Add(appointment);
            }
        }

        public List<Appointment> Appointments { get { return _appointments; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Patient> Patients { get { return _patients; } }
    }
}
