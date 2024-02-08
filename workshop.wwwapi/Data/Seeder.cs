using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {

        private List<Patient> _patients = new();
        private List<Doctor> _doctors = new();
        private List<Appointment> _appointments = new();
        private List<Prescription> _prescriptions = new();
        private List<Medicine> _medicines = new();
        private List<MedicinePrescription> _mp = new();


        public Seeder() 
        {
            _patients.Add(new() { Id = 1, FullName = "Iamin Extremepain" });
            _patients.Add(new() { Id = 2, FullName = "Greg Hurt" });

            _doctors.Add(new() { Id = 1, FullName = "Will Saveu" });
            _doctors.Add(new() { Id = 2, FullName = "John Bonesaw" });

            _appointments.Add(new() { DoctorId = 1, PatientId = 1, Booking = DateTime.UtcNow.AddDays(1), Type = AppointmentType.Online });
            _appointments.Add(new() { DoctorId = 2, PatientId = 2, Booking = DateTime.UtcNow.AddDays(3), Type = AppointmentType.InPerson });

            _prescriptions.Add(new() { Id = 1, PatientId = 1, DoctorId = 2 });
            _prescriptions.Add(new() { Id = 2, PatientId = 2, DoctorId = 1 });
            _medicines.Add(new() { Id = 1, Name = "LargePillTM" });
            _medicines.Add(new() { Id = 2, Name = "A magic potion" });
            _medicines.Add(new() { Id = 3, Name = "Pack of ice" });

            _mp.Add(new() { PrescriptionId = 1, MedicineId = 2, Count = 2 });
            _mp.Add(new() { PrescriptionId = 1, MedicineId = 3, Count = 3 });
            _mp.Add(new() { PrescriptionId = 2, MedicineId = 1, Count = 2 });
        }

        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get {  return _appointments; } }
        public List<Medicine> Medicines { get { return _medicines; } }
        public List<Prescription> Prescriptions { get { return _prescriptions; } }
        public List<MedicinePrescription> Mp { get { return _mp; } }
    }
}
