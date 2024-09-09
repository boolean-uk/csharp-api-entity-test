using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appoinments = new List<Appointment>();
        private List<Prescription> _prescriptions = new List<Prescription>();
        private List<Medicine> _medicines = new List<Medicine>();
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

            Medicine medicine1 = new Medicine() { Id = 1, Name = "Paracetamol", Instruction = "1-2 for upto 3 times a day", Quantity=30 };
            _medicines.Add(medicine1);
            Medicine medicine2 = new Medicine() { Id = 2, Name = "Ibux", Instruction = "1-2 for upto 3 times a day", Quantity = 30 };
            _medicines.Add(medicine2);



            _appoinments.Add(new Appointment() { Booking = DateTime.SpecifyKind(new DateTime(2023, 5, 7, 8, 30, 0), DateTimeKind.Utc), DoctorId=1, PatientId=1});
            _appoinments.Add(new Appointment() { Booking = DateTime.SpecifyKind(new DateTime(2023, 5, 7, 9, 30, 0), DateTimeKind.Utc), DoctorId=1, PatientId=2});

            _appoinments.Add(new Appointment() { Booking = DateTime.SpecifyKind(new DateTime(2023, 5, 7, 8, 30, 0), DateTimeKind.Utc), DoctorId = 2, PatientId = 2});
            _appoinments.Add(new Appointment() { Booking = DateTime.SpecifyKind(new DateTime(2023, 5, 7, 9, 30, 0), DateTimeKind.Utc), DoctorId = 2, PatientId = 1});
            
            Prescription pres1 = new Prescription() { Id = 1, Medicines = [medicine1, medicine2], Appointment = Appointments[1] };
            Prescription pres2 = new Prescription() { Id = 2, Medicines = [ medicine2], Appointment = Appointments[0] };
            _prescriptions.Add(pres1);
            _prescriptions.Add(pres2);
        }

        public List<Patient> Patients { get {  return _patients; } }
        public List<Doctor> Doctors { get {  return _doctors; } }
        public List<Appointment> Appointments { get {  return _appoinments; } }

        public List<Prescription> Prescriptions { get { return _prescriptions; } }

        public List<Medicine> Medicines { get { return _medicines; } }

        
    }
}
