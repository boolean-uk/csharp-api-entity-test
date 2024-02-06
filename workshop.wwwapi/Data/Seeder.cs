using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {

        private List<Appointment>  _appointments = new List<Appointment>();
        private List<Patient>  _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
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
            "Kate", 
            "Arthur",
            "Emma"
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
            "Middleton", 
            "Jacobsen",
            "Olsen"

        };
        private List<int> day = new List<int>()
        {
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28
        };
        private List<int> month = new List<int>()
        {
            1,2,3,4,5,6,7,8,9,10,11,12
        };
        private List<int> hrs = new List<int>()
        {
            8,9,10,11
        };
        private List<int> min = new List<int>()
        {
            0,10,20,30,40,50
        };
        
        public Seeder() {

            Random patientRandom = new Random();
            Random doctorRandom = new Random();
            Random appointmentRandom = new Random();
      

            
                for (int i = 3; i < 40; i++)
                {
                Patient patient = new Patient();
                patient.Id = i;
                patient.FullName = _firstnames[patientRandom.Next(_firstnames.Count)] + " " + _lastnames[patientRandom.Next(_lastnames.Count)];
                _patients.Add(patient);
                 }
                for (int j = 3; j < 15; j++)
                 {
                Doctor doctor = new Doctor();
                doctor.Id = j;
                doctor.FullName = _firstnames[doctorRandom.Next(_firstnames.Count)] + " " + _lastnames[doctorRandom.Next(_lastnames.Count)];
                _doctors.Add(doctor);

                Appointment appointment = new Appointment();
                appointment.Id = j;
                appointment.DoctorId = doctor.Id;
                appointment.PatientId = _patients[patientRandom.Next(_patients.Count)].Id;
                appointment.Booking = new DateTime(2024, month[appointmentRandom.Next(12)], day[appointmentRandom.Next(28)], hrs[appointmentRandom.Next(hrs.Count)], min[appointmentRandom.Next(min.Count)], 00, DateTimeKind.Utc).ToString();
                _appointments.Add(appointment);
                }

                              
              
           
        }

        public List<Appointment> Appointments { get { return _appointments; } }
        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }

    }
}
