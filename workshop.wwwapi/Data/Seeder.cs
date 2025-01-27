using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Doctor> _doctors = [
            new Doctor { Id = 1, FirstName = "Todd", LastName = "Braverly" },    
            new Doctor { Id = 2, FirstName = "Erica", LastName = "Health" },    
            new Doctor { Id = 3, FirstName = "Sylvia", LastName = "Parker" },
        ];
        private List<Patient> _patients = [
            new Patient { Id = 1, FirstName = "Tom", LastName = "Dickerson"},  
            new Patient { Id = 2, FirstName = "Mae", LastName = "Guerrero"},  
            new Patient { Id = 3, FirstName = "Ernest", LastName = "Mcneil"},
        ];
        private List<Appointment> _appointments = [
            new Appointment { DoctorId = 1, PatientId = 1, Booking = DateTime.UtcNow.AddDays(-14)},   
            new Appointment { DoctorId = 2, PatientId = 1, Booking = DateTime.UtcNow.AddDays(3)},
            new Appointment { DoctorId = 3, PatientId = 3, Booking = DateTime.UtcNow},
        ];
        private List<Medicine> _medicines = [
            new Medicine { Id = 1, Category = "Analgesics", Name = "Aspirin" },
            new Medicine { Id = 2, Category = "Antibacterials", Name = "Amoxicillin" },
            new Medicine { Id = 3, Category = "Antihistamines", Name = "Azelastine" },
        ];
        private List<Prescription> _prescriptions = [
            new Prescription { Id = 1, AppointmentDoctorId = 1, AppointmentPatientId = 1, Quantity = 24, Notes = "Take one at need, but with at least 8 hours between." },
            new Prescription { Id = 2, AppointmentDoctorId = 3, AppointmentPatientId = 3, Quantity = 14, Notes = "Take one each morning and evening. Best taken right after a meal." },
        ];
        private List<MedicinePrescription> _medicinePrescriptions = [
            new MedicinePrescription { MedicineId = 1, PrescriptionId = 1 },
            new MedicinePrescription { MedicineId = 2, PrescriptionId = 2 }
        ];

        public List<Doctor> Doctors { get {  return _doctors; } }
        public List<Patient> Patients { get {  return _patients; } }
        public List<Appointment> Appointments { get {  return _appointments; } }
        public List<Medicine> Medicines { get {  return _medicines; } }
        public List<Prescription> Prescriptions { get {  return _prescriptions; } }
        public List<MedicinePrescription> MedicinePrescriptions { get {  return _medicinePrescriptions; } }
    }
}
