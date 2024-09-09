using System;
using System.Security.Cryptography.X509Certificates;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();

        public Seeder() 
        {
            
            Patient patient1 = new Patient() { Id = 1, FullName = "John Doe" };
            Patient patient2 = new Patient() { Id = 2, FullName = "Margot Gray"};

            _patients.Add(patient1);
            _patients.Add(patient2);

            Doctor doctor1 = new Doctor() { Id = 1, FullName = "Marco Polo" };
            Doctor doctor2 = new Doctor() { Id = 2, FullName = "Lauren Middleton" };

            _doctors.Add(doctor1);
            _doctors.Add(doctor2);

            Appointment appointment1 = new Appointment() { AppointmentDate = DateTime.UtcNow.AddDays(5), DoctorId = 1, PatientId = 2 };
            Appointment appointment2 = new Appointment() { AppointmentDate = DateTime.UtcNow, DoctorId = 1, PatientId = 1 };
            Appointment appointment3 = new Appointment() { AppointmentDate = DateTime.UtcNow.AddDays(1), DoctorId = 2, PatientId = 1 };
            Appointment appointment4 = new Appointment() { AppointmentDate = DateTime.UtcNow.AddDays(2), DoctorId = 2, PatientId = 2 };

            _appointments.Add(appointment1);
            _appointments.Add(appointment2);
            _appointments.Add(appointment3);
            _appointments.Add(appointment4);
            

        }

        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get {return _doctors; } }
        public List <Appointment> Appointments { get { return _appointments; } }
    }
}
