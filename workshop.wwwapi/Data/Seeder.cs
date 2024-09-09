using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<string> _firstNames = new List<string>()
        {
            "Felix",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Adam",
            "Mickey",
            "Kate",
            "Charles",
            "Arnold",
            "Ragnar",
            "Neo"
        };

        private List<string> _lastNames = new List<string>()
        {
            "Mathiasson",
            "Duck",
            "Presley",
            "Obama",
            "Winfrey",
            "Sandler",
            "Mouse",
            "Winslow",
            "Xavier",
            "Schwarzenegger",
            "Lothbrok",
            "Andersson"
        };

        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _patients = new List<Patient>();
        private List<Appointment> _appointments = new List<Appointment>();

        public Seeder()
        {
            Random doctorRandom = new Random();
            Random patientRandom = new Random();
            Random dateRandom = new Random();

            for (int i = 1; i < 11; i++)
            {
                Doctor doctor = new Doctor();
                doctor.Id = i;
                doctor.FullName =
                    _firstNames[doctorRandom.Next(_firstNames.Count)] + " " +
                    _lastNames[doctorRandom.Next(_lastNames.Count)];
                _doctors.Add(doctor);
            }
            for (int i = 1; i < 11; i++)
            { 

                Patient patient = new Patient();
                patient.Id = i;
                patient.FullName =
                    _firstNames[patientRandom.Next(_firstNames.Count)] + " " +
                    _lastNames[patientRandom.Next(_lastNames.Count)];
                _patients.Add(patient);
            }

            for (int i = 1; i < 11; i++)
            {
                Appointment appointment = new Appointment();
                appointment.Id = i;

                appointment.PatientId = _patients[i - 1].Id;
                appointment.DoctorId = _doctors[doctorRandom.Next(_doctors.Count)].Id;

                DateTime now = DateTime.Now;
                DateTime futureDate = now.AddDays(dateRandom.Next(1, 366)).AddHours(dateRandom.Next(0, 24)).AddMinutes(dateRandom.Next(0, 60)).AddSeconds(dateRandom.Next(0, 60));
                appointment.Booking = futureDate.ToUniversalTime();

                _appointments.Add(appointment);
            }
        }

        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Patient> Patients { get { return _patients; } }

        public List<Appointment> Appointments { get { return _appointments; } }
        
    }
}
