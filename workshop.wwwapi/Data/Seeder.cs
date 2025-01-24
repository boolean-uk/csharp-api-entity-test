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
            Patient patient = new Patient();
            patient.FullName = "Erik Bergvall";
            patient.Id = 1;
            _patients.Add(patient);

            Patient patient2 = new Patient();
            patient2.FullName = "Albin Bergvall";
            patient2.Id = 2;
            _patients.Add(patient2);

            Doctor doctor = new Doctor();
            doctor.FullName = "Marcus Dombret";
            doctor.Id = 1;
            _doctors.Add(doctor);

            Doctor doctor2 = new Doctor();
            doctor2.FullName = "Evelina Dombret";
            doctor2.Id = 2;
            _doctors.Add(doctor2);

            Appointment appointment = new Appointment();
            appointment.Id = 1;
            appointment.Booking = DateTime.UtcNow.Date;
            appointment.DoctorId = doctor.Id;
            appointment.PatientId = patient.Id;
            _appointments.Add(appointment);

            patient.Appointments.ToList().Add(appointment);
            doctor.Appointments.ToList().Add(appointment);

            Appointment appointment2 = new Appointment();
            appointment2.Id = 2;
            appointment2.Booking = DateTime.UtcNow.Date;
            appointment2.DoctorId = doctor.Id;
            appointment2.PatientId = patient2.Id;
            _appointments.Add(appointment2);

            patient2.Appointments.ToList().Add(appointment2);
            doctor.Appointments.ToList().Add(appointment2);

            Appointment appointment3 = new Appointment();
            appointment3.Id = 3;
            appointment3.Booking = DateTime.UtcNow.Date;
            appointment3.DoctorId = doctor2.Id;
            appointment3.PatientId = patient.Id;
            _appointments.Add(appointment3);

            patient.Appointments.ToList().Add(appointment3);
            doctor2.Appointments.ToList().Add(appointment3);




        }
        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get { return _appointments; } }
    }
}

