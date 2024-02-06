using System.Diagnostics;

namespace workshop.wwwapi.Models.DTObjects
{
    public class DTO //<T> where T : class
    {
        private DTPatient _patient = new DTPatient();
        private DTDoctor _doctor = new DTDoctor();
        private DTAppointment _appointment = new DTAppointment();
        private List<DTAppointment> _appointments = new List<DTAppointment>();
        private List<DTPatient> _patients = new List<DTPatient>();
        private List<DTDoctor> _doctors = new List<DTDoctor>();
        //public T data { get; set; }
        public DTAppointment Appointment { get { return _appointment; } }
        public DTDoctor Doctor { get { return _doctor; } }
        public DTPatient Patient { get { return _patient; } }
        public List<DTAppointment> Appointments { get { return _appointments; } }
        public List<DTPatient> Patients { get { return _patients; } }
        public List<DTDoctor> Doctors { get { return _doctors; } }

        public DTPatient CreateTransferPatient(Patient p)
        {
            _patient = new DTPatient();
          _patient.Id = p.Id;
            _patient.Name = p.FullName;
            _appointments = new List<DTAppointment>();
            foreach(Appointment appointment in p.Appointments)
            {
                CreateTransferAppointment(appointment);
            }
            _patient.Appointments = _appointments;
            _patients.Add(_patient);
            return _patient;
        }
        public DTAppointment CreateTransferAppointment(Appointment a)
        {
            _appointment = new DTAppointment();
            _appointment.Id = a.Id;
            _appointment.Booking = DateTime.Parse(a.Booking);
            _appointment.PatientName = a.Patient.FullName;
            _appointment.PatientId = a.Patient.Id;
            _appointment.DoctorId = a.Doctor.Id;
            _appointment.DoctorName = a.Doctor.FullName;
            _appointments.Add(_appointment);
            return _appointment;
           
        }
        public void CreateTransferDoctor(Doctor doc)
        {
            _doctor = new DTDoctor();
            _doctor.Id = doc.Id;
            _doctor.Name = doc.FullName;
            _appointments = new List<DTAppointment>();
            foreach (Appointment a in doc.Appointments)
            {
                CreateTransferAppointment(a);
            }
            _doctor.Appointments = _appointments;
            _doctors.Add(_doctor);
        }
    }
}
