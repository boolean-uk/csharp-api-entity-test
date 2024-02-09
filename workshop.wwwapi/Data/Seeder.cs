using System;
using System.Collections.Generic;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.PatientModels;



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
            Random random = new Random();

            // Seed Doctors
            for (int i = 0; i < 5; i++) 
            {
                _doctors.Add(new Doctor
                {
                    Id = i + 1,
                    FullName = $"{_firstnames[random.Next(_firstnames.Count)]} {_lastnames[random.Next(_lastnames.Count)]}"
                }) ;
            }

            // Seed Patients
            for (int i = 0; i < 10; i++) 
            {
                _patients.Add(new Patient
                {
                    Id = i + 1, 
                    FullName = $"{_firstnames[random.Next(_firstnames.Count)]} {_lastnames[random.Next(_lastnames.Count)]}"
                });
            }

            // Seed Appointments
            for (int i = 0; i < 10; i++) 
            {
                _appointments.Add(new Appointment
                {
                    Booking = DateTime.UtcNow.AddDays(random.Next(1, 30)),
                    DoctorId = _doctors[random.Next(_doctors.Count)].Id,
                    PatientId = _patients[random.Next(_patients.Count)].Id
                });
            }
        }

        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get { return _appointments; } }
    }
}
