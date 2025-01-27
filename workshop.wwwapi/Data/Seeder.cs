using workshop.wwwapi.Enums;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<string> _firstnames = new List<string>()
    {
        "Audrey", "Donald", "Elvis", "Barack", "Oprah",
        "Jimi", "Mick", "Kate", "Charles", "Kate"
    };

        private List<string> _lastnames = new List<string>()
    {
        "Hepburn", "Trump", "Presley", "Obama", "Winfrey",
        "Hendrix", "Jagger", "Winslet", "Windsor", "Middleton"
    };

        private List<string> _specializations = new List<string>()
    {
        "Cardiology", "Neurology", "Orthopedics", "Pediatrics", "Oncology",
        "Dermatology", "Psychiatry", "Radiology", "General Practice", "Surgery"
    };

        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();
        private List<Medicine> _medicines = new List<Medicine>();
        private List<Prescription> _prescriptions = new List<Prescription>();
        private List<MedicinePrescription> _medicinePrescriptions = new List<MedicinePrescription>();

        public Seeder()
        {
            Random random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                Patient patient = new Patient
                {
                    Id = i,
                    FullName = $"{_firstnames[random.Next(_firstnames.Count)]} {_lastnames[random.Next(_lastnames.Count)]}"
                };
                _patients.Add(patient);
            }

            for (int i = 1; i <= 20; i++)
            {
                Doctor doctor = new Doctor
                {
                    Id = i,
                    FullName = $"{_firstnames[random.Next(_firstnames.Count)]} {_lastnames[random.Next(_lastnames.Count)]}"
                };
                _doctors.Add(doctor);
            }

            for (int i = 0; i < 200; i++)
            {
                int doctorId = _doctors[random.Next(_doctors.Count)].Id;
                int patientId = _patients[random.Next(_patients.Count)].Id;
                AppointmentType randomAppointmentType = (AppointmentType)random.Next(Enum.GetValues(typeof(AppointmentType)).Length);


                if (_appointments.Any(a => a.DoctorId == doctorId && a.PatientId == patientId))
                    continue;

                Appointment appointment = new Appointment
                {
                    Booking = DateTime.UtcNow.AddDays(random.Next(-30, 30)),
                    DoctorId = doctorId,
                    PatientId = patientId,
                    AppointmentType = randomAppointmentType
                };
                _appointments.Add(appointment);
            }

            for (int i = 1; i <= 50; i++)
            {
                Medicine medicine = new Medicine
                {
                    Id = i,
                    Name = $"Medicine {i}",
                    Description = $"Description for Medicine {i}",
                    
                };
                _medicines.Add(medicine);
            }

            for (int i = 1; i <= 20; i++)
            {
                var appointment = _appointments[random.Next(_appointments.Count)];

                Prescription prescription = new Prescription
                {
                    Id = i,
                    IssueDate = DateTime.UtcNow.AddDays(random.Next(-30, 30)), 
                    DoctorId = appointment.DoctorId,
                    PatientId = appointment.PatientId 
                };

                _prescriptions.Add(prescription);


                int medicineCount = random.Next(1, 6);
                for (int j = 0; j < medicineCount; j++)
                {
                    var medicine = _medicines[random.Next(_medicines.Count)];
                    if (!_medicinePrescriptions.Any(mp => mp.PrescriptionId == prescription.Id && mp.MedicineId == medicine.Id)) 
                    {
                        _medicinePrescriptions.Add(new MedicinePrescription
                        {
                            PrescriptionId = prescription.Id,
                            MedicineId = medicine.Id,
                            Quantity = random.Next(1, 10), 
                            Notes = $"Take {random.Next(1, 3)} times a day" 
                        });
                    }
                }
            }
        }

        public List<Patient> Patients => _patients;
        public List<Doctor> Doctors => _doctors;
        public List<Appointment> Appointments => _appointments;
        public List<Medicine> Medicines => _medicines;
        public List<Prescription> Prescriptions => _prescriptions;
        public List<MedicinePrescription> MedicinePrescriptions => _medicinePrescriptions;
    }


}
