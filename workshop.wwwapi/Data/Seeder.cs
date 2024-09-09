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

        List<DateTime> _appointmentDates = new List<DateTime>
        {
            new DateTime(2024, 9, 10),
            new DateTime(2024, 9, 15),
            new DateTime(2024, 9, 20),
            new DateTime(2024, 9, 25),
            new DateTime(2024, 9, 30),
            new DateTime(2024, 10, 5),
            new DateTime(2024, 10, 10),
            new DateTime(2024, 10, 15),
            new DateTime(2024, 10, 20),
            new DateTime(2024, 10, 25)
        };

        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _patients = new List<Patient>();
        private List<Appointment> _appointments = new List<Appointment>();


        public Seeder()
        {

            Random doctorRandom = new Random();
            Random patientRandom = new Random();
            Random appointmentRandom = new Random();




            for (int x = 1; x < 250; x++)
            {
                Doctor doctor = new Doctor();
                doctor.Id = x;
                doctor.FullName = _firstnames[doctorRandom.Next(_firstnames.Count)] +" "+ _lastnames[doctorRandom.Next(_lastnames.Count)];
                _doctors.Add(doctor);

            }

            for (int x = 1; x < 250; x++)
            {
                Patient patient = new Patient();
                patient.Id = x;
                patient.FullName = _firstnames[patientRandom.Next(_firstnames.Count)] + " " + _lastnames[patientRandom.Next(_lastnames.Count)];
                _patients.Add(patient);

            }

            for (int x = 1; x < 250; x++)
            {
                Appointment appointment = new Appointment();
                appointment.Booking = _appointmentDates[appointmentRandom.Next(_appointmentDates.Count)];
                appointment.DoctorId = _doctors[appointmentRandom.Next(_doctors.Count)].Id;
                appointment.PatientId = _patients[appointmentRandom.Next(_lastnames.Count)].Id;
                _appointments.Add(appointment);

            }



        }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Patient> Patients { get { return _patients; } }
        public List<Appointment> Appointments { get { return _appointments; } }
    }
}
