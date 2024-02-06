using workshop.wwwapi.DTOs.Extension;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();
        private List<Medicine> _medicines = new List<Medicine>();
        private List<Prescription> _prescriptions = new List<Prescription>();
        private List<MedicinePrescription> _medicinePrescriptions = new List<MedicinePrescription>();

        public Seeder()
        {
            //Update the db context class and seed 1 or 2 patients with hard-coded ids and names
            _patients.Add(new Patient() { Id = 1, FullName = "Maynard James Keenan" });
            _patients.Add(new Patient() { Id = 2, FullName = "Danny Carey" });

            //Update the db context class and seed 2 doctors with hard-coded ids and names;
            _doctors.Add(new Doctor() { Id = 1, FullName = "Justin Chancellor" });
            _doctors.Add(new Doctor() { Id = 2, FullName = "Adam Jones" });

            //create a few appointments for each doctor with some patients
            _appointments.Add(new Appointment() { Id = 1, DoctorId = 1, PatientId = 1, Booking = DateTime.UtcNow.AddDays(1), AppointmentType= AppointmentType.InPerson });
            _appointments.Add(new Appointment() { Id = 2, DoctorId = 1, PatientId = 2, Booking = DateTime.UtcNow.AddDays(2), AppointmentType = AppointmentType.Digital });

            _appointments.Add(new Appointment() { Id = 3, DoctorId = 2, PatientId = 1, Booking = DateTime.UtcNow.AddDays(3), AppointmentType = AppointmentType.InPerson });
            _appointments.Add(new Appointment() { Id = 4, DoctorId = 2, PatientId = 2, Booking = DateTime.UtcNow.AddDays(4), AppointmentType = AppointmentType.Digital });
            _appointments.Add(new Appointment() { Id = 5, DoctorId = 2, PatientId = 2, Booking = DateTime.UtcNow.AddDays(5), AppointmentType = AppointmentType.InPerson });

            _medicines.Add(new Medicine() { Id = 1, Name = "Ibuprofen", Quantity = 50, Instruction = "Take two pills in the morning and another before bed." });
            _medicines.Add(new Medicine() { Id = 2, Name = "Morphine", Quantity = 100, Instruction = "Take one pill every 4 hours." });
            _medicines.Add(new Medicine() { Id = 3, Name = "Totally not LSD", Quantity = 200, Instruction = "Consume half the bottle once every day." });

            _prescriptions.Add(new Prescription() { Id = 1, DoctorsNote = "You are very sick. Take double dose." });
            _prescriptions.Add(new Prescription() { Id = 2, DoctorsNote = "Follow the instructions as is on the medicine." });
            _prescriptions.Add(new Prescription() { Id = 3, DoctorsNote = "Consume half the dose of what the medicine instructs you."});

            Random random = new Random();
            for (int i = 0; i < 7; i++)
            {
                _medicinePrescriptions.Add(new MedicinePrescription() { Id = i+1, MedicineId = random.Next(1,4), PrescriptionId = random.Next(1, 4), AppointmentId = random.Next(1,6) });
            }
        }

        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get { return _appointments; } }
        public List<Medicine> Medicines { get { return _medicines; } }
        public List<Prescription> Prescriptions { get { return _prescriptions; } }
        public List<MedicinePrescription> MedicinePrescriptions { get { return _medicinePrescriptions; } }
    }
}
