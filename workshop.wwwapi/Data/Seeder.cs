using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Appointment> _appointments = new List<Appointment>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _patients = new List<Patient>();
        private List<Medicine> _medicines = new List<Medicine>();
        private List<Prescription> _prescriptions = new List<Prescription>();
        private List<MedicinePrescription> _medicinesPrescriptions = new List<MedicinePrescription>();

        public Seeder()
        {
            _patients.Add(new Patient() { Id = 1, FullName = "Nigel" });
            _patients.Add(new Patient() { Id = 2, FullName = "Jonas" });

            _appointments.Add(new Appointment() { Id = 1, Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 2, PrescriptionId = 1 });
            _appointments.Add(new Appointment() { Id = 2, Booking = DateTime.UtcNow + TimeSpan.FromMinutes(30), DoctorId = 1, PatientId = 2 });
            _appointments.Add(new Appointment() { Id = 3, Booking = DateTime.UtcNow + TimeSpan.FromMinutes(60), DoctorId = 2, PatientId = 1 });
            _appointments.Add(new Appointment() { Id = 4, Booking = DateTime.UtcNow + TimeSpan.FromMinutes(45), DoctorId = 2, PatientId = 1, PrescriptionId = 2 });
            _appointments.Add(new Appointment() { Id = 5, Booking = DateTime.UtcNow + TimeSpan.FromMinutes(90), DoctorId = 1, PatientId = 2 });
            _appointments.Add(new Appointment() { Id = 6, Booking = DateTime.UtcNow + TimeSpan.FromMinutes(20), DoctorId = 2, PatientId = 1 });

            _doctors.Add(new Doctor() { Id = 1, FullName = "Doctor Jekyll" });
            _doctors.Add(new Doctor() { Id = 2, FullName = "Doctor Hyde" });

            _medicines.Add(
                new Medicine()
                {
                    Id = 1,
                    Name = "Paracetamol",
                    Quantity = 25,
                    Instructions = "Take up to two times a day",
                    Prescriptions = _medicinesPrescriptions.Where(mp => mp.MedicineId == 1).SelectMany(mp => _prescriptions.Where(p => p.Id == mp.PrescriptionId)).ToList()
                });

            _medicines.Add(
                new Medicine()
                {
                    Id = 2,
                    Name = "Ibux",
                    Quantity = 5,
                    Instructions = "Take one a day",
                    Prescriptions = _medicinesPrescriptions.Where(mp => mp.MedicineId == 2).SelectMany(mp => _prescriptions.Where(p => p.Id == mp.PrescriptionId)).ToList()
                });

            _prescriptions.Add(new Prescription() { Id = 1, AppointmentId = 1 });
            _prescriptions.Add(new Prescription() { Id = 2, AppointmentId = 4 });

            //_appointments[0].Prescription = _prescriptions[0];
            //_appointments[3].Prescription = _prescriptions[1];

            _medicinesPrescriptions.Add(new MedicinePrescription() { Id = 1, MedicineId = 1, PrescriptionId = 2 });
            _medicinesPrescriptions.Add(new MedicinePrescription() { Id = 2, MedicineId = 2, PrescriptionId = 1 });
        }

        public List<Appointment> Appointments { get { return _appointments; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List <Patient> Patients { get {return _patients; } }
        public List <Medicine> Medicines { get { return _medicines; } }
        public List <Prescription> Prescriptions { get {return _prescriptions; } }
        public List <MedicinePrescription> MedicinesPrescriptions { get { return _medicinesPrescriptions; } }
    }
}
