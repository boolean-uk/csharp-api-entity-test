using workshop.wwwapi.Models;

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

        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();

        public Seeder()
        {
            Random patientRandom = new Random();
            Random doctorRandom = new Random();
            Random dateRandom = new Random();

            for (int x = 1; x < 3; x++)
            {
                Patient patient = new Patient();
                patient.Id = x;
                patient.FullName = $"{_firstnames[patientRandom.Next(_firstnames.Count)]} {_lastnames[patientRandom.Next(_lastnames.Count)]}";
                _patients.Add(patient);
            }

            for(int y = 1; y < 3; y++)
            {
                Doctor doctor = new Doctor();
                doctor.Id = y;
                doctor.FullName = $"{_firstnames[doctorRandom.Next(_firstnames.Count)]} {_lastnames[doctorRandom.Next(_lastnames.Count)]}";
                _doctors.Add(doctor);
            }

            for(int z = 1; z < 3; z++)
            {
                Appointment appointment = new Appointment();
                appointment.Id = z;

                //Every patient has an appointment, but not every doctor has one
                appointment.PatientId = _patients[z - 1].Id;
                appointment.DoctorId = _doctors[doctorRandom.Next(_doctors.Count)].Id;

                //Create a random date for the booking
                DateTime now = DateTime.Now;
                DateTime futureDate = now.AddDays(dateRandom.Next(1, 366)).AddHours(dateRandom.Next(0, 24)).AddMinutes(dateRandom.Next(0, 60)).AddSeconds(dateRandom.Next(0, 60));
                appointment.Booking = futureDate.ToUniversalTime();

                _appointments.Add(appointment);
            }
        }

        public List<Patient> patients { get { return _patients; } }
        public List<Doctor> doctors { get {return _doctors; } }
        public List<Appointment> appointments { get { return _appointments; } }
    }
}
