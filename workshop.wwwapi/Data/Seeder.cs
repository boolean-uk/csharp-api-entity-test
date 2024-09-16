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
            Patients.Add(new Patient() { Id = 1, FullName = "Sebastian Hanssen"});;
            Patients.Add(new Patient() { Id = 2, FullName = "Anna Lorentzen" });

            Doctors.Add(new Doctor() { Id = 1, FullName = "Yumi Yumisen" });
            Doctors.Add(new Doctor() { Id = 2, FullName = "Milo Milosen" });

            Appointments.Add(new Appointment() { Id = 1, DoctorId = 1, PatientId = 1, AppointmentDate = DateTime.SpecifyKind(new DateTime(2024, 2, 5, 14, 0, 0), DateTimeKind.Utc) });
            Appointments.Add(new Appointment() { Id = 2, DoctorId = 1, PatientId = 2, AppointmentDate = DateTime.SpecifyKind(new DateTime(2024, 2, 5, 15, 0, 0), DateTimeKind.Utc) });
            Appointments.Add(new Appointment() { Id = 3, DoctorId = 2, PatientId = 1, AppointmentDate = DateTime.SpecifyKind(new DateTime(2024, 2, 6, 14, 0, 0), DateTimeKind.Utc) });
            Appointments.Add(new Appointment() { Id = 4, DoctorId = 2, PatientId = 2, AppointmentDate = DateTime.SpecifyKind(new DateTime(2024, 2, 6, 15, 0, 0), DateTimeKind.Utc) });

        }
        public List<Patient> Patients { get {  return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }

        public List <Appointment> Appointments { get {  return _appointments; } }
    }
}
