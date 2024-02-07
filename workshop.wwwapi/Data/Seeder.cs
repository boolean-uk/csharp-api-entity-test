using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<string> _firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate"
        };
        private List<string> _lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton"

        };

        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _patients = new List<Patient>();
        private List<Appointment> _appoitments = new List<Appointment>();

        public Seeder()
        {

            Random doctorRandom = new Random();
            Random patientRandom = new Random();
            Random appoitmentRandom = new Random();

            RandomDateTime randDate = new RandomDateTime();



            for (int x = 1; x < 20; x++)
            {
                Doctor doctor = new Doctor();
                doctor.Id = x;
                doctor.FullName = $"{_firstnames[doctorRandom.Next(_firstnames.Count)]} {_lastnames[doctorRandom.Next(_lastnames.Count)]}";
                _doctors.Add(doctor);
            }

            for (int y = 1; y < 20; y++)
            {
                Patient patient = new Patient();
                patient.Id = y;
                patient.FullName = $"{_firstnames[patientRandom.Next(_firstnames.Count)]} {_lastnames[patientRandom.Next(_lastnames.Count)]}";
                _patients.Add(patient);
            }

            for (int z = 1; z < 20; z++)
            {
                Appointment appoitment = new Appointment();
                appoitment.Booking = randDate.Next();
                appoitment.DoctorId = _doctors[appoitmentRandom.Next(_doctors.Count)].Id;
                appoitment.PatientId = _patients[appoitmentRandom.Next(_patients.Count)].Id;
                _appoitments.Add(appoitment);
            }
        }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Patient> Patients { get { return _patients; } }
        public List<Appointment> Appointments { get { return _appoitments; } }
    }
}
