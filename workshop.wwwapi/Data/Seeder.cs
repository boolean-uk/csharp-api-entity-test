using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appoinments = new List<Appointment>();
        public Seeder() 
        {
            Patient patient1 = new Patient() { Id = 1, FirstName = "Øystein", LastName = "Haugen" };
            _patients.Add(patient1);
            Patient patient2 = new Patient() { Id = 2, FirstName = "Bøystein", LastName = "Baugen" };
            _patients.Add(patient2);

            Doctor doctor1 = new Doctor() { Id = 1, FirstName = "Empty", LastName = "Reflections" };
            _doctors.Add(doctor1);
            Doctor doctor2 = new Doctor() { Id = 2, FirstName = "Containing", LastName = "Thoughlessness" };
            _doctors.Add(doctor2);

            _appoinments.Add(new Appointment() { Booking = DateTime.SpecifyKind(new DateTime(2023, 5, 7, 8, 30, 0), DateTimeKind.Utc), DoctorId=1, PatientId=1});
            _appoinments.Add(new Appointment() { Booking = DateTime.SpecifyKind(new DateTime(2023, 5, 7, 9, 30, 0), DateTimeKind.Utc), DoctorId=1, PatientId=2});

            _appoinments.Add(new Appointment() { Booking = DateTime.SpecifyKind(new DateTime(2023, 5, 7, 8, 30, 0), DateTimeKind.Utc), DoctorId = 2, PatientId = 2});
            _appoinments.Add(new Appointment() { Booking = DateTime.SpecifyKind(new DateTime(2023, 5, 7, 9, 30, 0), DateTimeKind.Utc), DoctorId = 2, PatientId = 1});
        }

        public List<Patient> Patients { get {  return _patients; } }
        public List<Doctor> Doctors { get {  return _doctors; } }
        public List<Appointment> Appointments { get {  return _appoinments; } }
    }
}
