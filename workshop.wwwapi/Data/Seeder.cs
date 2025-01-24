using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<Patient> _patients = new List<Patient>()
        {
            new Patient { Id = 1, FullName = "Audrey Hepburn" },
            new Patient { Id = 2, FullName = "Donald Trump" },
            new Patient { Id = 3, FullName = "Elvis Presley" },
            new Patient { Id = 4, FullName = "Barack Obama" },
            new Patient { Id = 5, FullName = "Oprah Winfrey" },
            new Patient { Id = 6, FullName = "Jimi Hendrix" },
            new Patient { Id = 7, FullName = "Mick Jagger" },
            new Patient { Id = 8, FullName = "Kate Winslet" },
            new Patient { Id = 9, FullName = "Charles Windsor" },
            new Patient { Id = 10, FullName = "Kate Middleton" }
        };

        private List<Doctor> _doctors = new List<Doctor>()
        {
            new Doctor { Id = 1, FullName = "Dr. John Smith" },
            new Doctor { Id = 2, FullName = "Dr. Jane Doe" },
            new Doctor { Id = 3, FullName = "Dr. Emily Davis" },
            new Doctor { Id = 4, FullName = "Dr. Michael Brown" },
            new Doctor { Id = 5, FullName = "Dr. Sarah Wilson" }
        };

        private List<Appointment> _appointments = new List<Appointment>()
        {
            new Appointment { Id = 1, Booking = new DateTime(2025, 1, 5, 10, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 1 },
            new Appointment { Id = 2, Booking = new DateTime(2025, 1, 6, 11, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 2 },
            new Appointment { Id = 3, Booking = new DateTime(2025, 1, 7, 12, 0, 0, DateTimeKind.Utc), DoctorId = 3, PatientId = 3 },
            new Appointment { Id = 4, Booking = new DateTime(2025, 1, 8, 13, 0, 0, DateTimeKind.Utc), DoctorId = 4, PatientId = 4 },
            new Appointment { Id = 5, Booking = new DateTime(2025, 1, 9, 14, 0, 0, DateTimeKind.Utc), DoctorId = 5, PatientId = 5 },
            new Appointment { Id = 6, Booking = new DateTime(2025, 1, 10, 15, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 6 },
            new Appointment { Id = 7, Booking = new DateTime(2025, 1, 11, 16, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 7 },
            new Appointment { Id = 8, Booking = new DateTime(2025, 1, 12, 17, 0, 0, DateTimeKind.Utc), DoctorId = 3, PatientId = 8 },
            new Appointment { Id = 9, Booking = new DateTime(2025, 1, 13, 18, 0, 0, DateTimeKind.Utc), DoctorId = 4, PatientId = 9 },
            new Appointment { Id = 10, Booking = new DateTime(2025, 1, 14, 19, 0, 0, DateTimeKind.Utc), DoctorId = 5, PatientId = 10 }
        };

        private List<Medicine> _medicines = new List<Medicine>()
        {
            new Medicine { Id = 1, Name = "Aspirin" },
            new Medicine { Id = 2, Name = "Paracetamol" },
            new Medicine { Id = 3, Name = "Ibuprofen" },
            new Medicine { Id = 4, Name = "Penicillin" },
            new Medicine { Id = 5, Name = "Amoxicillin" }
        };

        private List<Prescription> _prescriptions = new List<Prescription>()
        {
            new Prescription { Id = 1, AppointmentId = 1},
            new Prescription { Id = 2, AppointmentId = 2},
            new Prescription { Id = 3, AppointmentId = 3},
            new Prescription { Id = 4, AppointmentId = 4},
            new Prescription { Id = 5, AppointmentId = 5},
            new Prescription { Id = 6, AppointmentId = 6},
            new Prescription { Id = 7, AppointmentId = 7},
            new Prescription { Id = 8, AppointmentId = 8}
        };

        private List<MedicinePresctiption> _medicinePresctiptions = new List<MedicinePresctiption>()
                    {
            new MedicinePresctiption {Id = 1, MedicineId = 1, PrescriptionId = 1, Notes = "Every day"},
            new MedicinePresctiption {Id = 2, MedicineId = 2, PrescriptionId = 2, Notes = "Never forget"},
            new MedicinePresctiption {Id = 3,  MedicineId = 3, PrescriptionId = 3,Notes = "Every 4 hours"},
            new MedicinePresctiption {Id = 4,  MedicineId = 4, PrescriptionId = 4,Notes = "Every 2 minutes"},
            new MedicinePresctiption {Id = 5,  MedicineId = 5, PrescriptionId = 5,Notes = "Dont actually take it"},
            new MedicinePresctiption {Id = 6,  MedicineId = 1, PrescriptionId = 6,Notes = "Only for reselling"},
            new MedicinePresctiption {Id = 7,  MedicineId = 2, PrescriptionId = 7,Notes = "Twice a year"},
            new MedicinePresctiption {Id = 8,  MedicineId = 3, PrescriptionId = 8,Notes = "Every day"}
        };

        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get { return _appointments; } }

        public List<Medicine> Medicines { get { return _medicines; } }
        public List<Prescription> Prescriptions { get { return _prescriptions; } }
        public List<MedicinePresctiption> MedicinePresctiptions
        {
            get { return _medicinePresctiptions; }
        }
    }
}

