using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data;

public class Seed
{

    //Stole you names... Sorry!
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
            "Nigel",
            "Lowe",
            "Martin",
            "Kristoffer",
            "Jone",
            "Andreas",
            "Jostein",
            "Alex",
            "Aksel",
            "Sander",
            "Abdi",
            "Kristian",
            "Erlend",
            "Espen",
            "Enock",
            "Giar",
            "Petter",
            "Steven",
            "Tonnes",
            "Noah",
            "Magnus",
            "Hans",
            "Nikolai",
            "Hakon",
            "Martin",
            "Erik"

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
        private List<Appointment> _appointments = new List<Appointment>();

        public List<Doctor> Doctors {get {return _doctors;}}
        public List<Patient> Patients {get {return _patients;}}
        public List<Appointment> Appointments {get {return _appointments;}}


        public Seed()
        {
            Random doctorRandom = new Random();
            Random patientRandom = new Random();
            Random appointmentRandom = new Random();

            for (int i = 1; i < 11; i++)
            {
                Doctor d = new Doctor();
                d.FullName = "Dr. " + _firstnames[i-1] + " " + _lastnames[i-1];
                d.Id = i;

                _doctors.Add(d);

                Patient p = new Patient();
                p.FullName = _firstnames[10+i-1] + " " + _lastnames[i-1];
                p.Id = i;

                _patients.Add(p);
            }

            for (int j = 1; j < 11; j++)
            {
                Appointment a = new Appointment();
                a.DoctorId = j;
                a.PatientId = j;
                a.Booking = new DateTime(2025,1,1,10,0,0).ToUniversalTime();
                a.Id = j;
                

                _appointments.Add(a);

            }
        }

}
