using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Data;

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
        Random appointmentRandom = new Random();

        for (int x = 1; x < 10; x++)
        {
            Patient patient = new Patient();
            patient.Id = x;
            patient.FullName = $"{_firstnames[patientRandom.Next(_firstnames.Count)]} {_lastnames[patientRandom.Next(_lastnames.Count)]}";
            _patients.Add(patient);
        }

        for (int y = 1; y < 5; y++)
        {
            Doctor doctor = new Doctor();
            doctor.Id = y;
            doctor.FullName = $"{_firstnames[doctorRandom.Next(_firstnames.Count)]} {_lastnames[doctorRandom.Next(_lastnames.Count)]}";
            _doctors.Add(doctor);
        }

        for (int y = 1; y < 20; y++)
        {
            Appointment appointment = new Appointment();
            appointment.Booking = new DateTime();
            appointment.PatientId = _patients[appointmentRandom.Next(_patients.Count)].Id;
            appointment.DoctorId = _doctors[appointmentRandom.Next(_doctors.Count)].Id;
            _appointments.Add(appointment);
        }
    }
    public List<Patient> Patients { get { return _patients; } }
    public List<Doctor> Doctors { get { return _doctors; } }
    public List<Appointment> Appointments { get { return _appointments; } }
}
