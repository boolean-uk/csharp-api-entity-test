using System;
using System.Collections.Generic;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.MedicineModels;
using workshop.wwwapi.Models.PatientModels;
using workshop.wwwapi.Models.PrescriptionMedicineModels;
using workshop.wwwapi.Models.PrescriptionModels;



namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<string> _firstnames = new List<string>()
        {
            "Audrey",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Jimi",
            "Mick",
            "Kate",
            "Charles",
            "Kate"
        };
        private List<string> _lastnames = new List<string>()
        {
            "Hepburn",
            "Trump",
            "Presley",
            "Obama",
            "Winfrey",
            "Hendrix",
            "Jagger",
            "Winslet",
            "Windsor",
            "Middleton"
        };

        private List<string> _medicineNames = new List<string>()
        {
            "Amoxicillin",
            "Ibuprofen",
            "Paracetamol",
            "Ciprofloxacin",
            "Azithromycin"
        };


        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();
        private List<Medicine> _medicines = new List<Medicine>();
        private List<Prescription> _prescriptions = new List<Prescription>();
        private List<PrescriptionMedicine> _prescriptionMedicines = new List<PrescriptionMedicine>();

        public Seeder()
        {
            Random random = new Random();

            for (int i = 0; i < 5; i++) 
            {
                _doctors.Add(new Doctor
                {
                    Id = i + 1,
                    FullName = $"{_firstnames[random.Next(_firstnames.Count)]} {_lastnames[random.Next(_lastnames.Count)]}"
                }) ;

                _medicines.Add(new Medicine
                {
                    MedicineId = i + 1,
                    Name = _medicineNames[i],
                    PrescriptionMedicines = new List<PrescriptionMedicine>()
                });
            }

            for (int i = 0; i < 10; i++)
            {
                _patients.Add(new Patient
                {
                    Id = i + 1,
                    FullName = $"{_firstnames[random.Next(_firstnames.Count)]} {_lastnames[random.Next(_lastnames.Count)]}"
                });
            }
            for (int i = 0; i < 10; i++)
            {
                _appointments.Add( new Appointment
                {
                    Booking = DateTime.UtcNow.AddDays(random.Next(1, 30)),
                    DoctorId = _doctors[random.Next(_doctors.Count)].Id,
                    PatientId = _patients[random.Next(_patients.Count)].Id,
                    Type = (AppointmentType)random.Next(0, 2)
                });
            }
            for (int i = 0; i < 10; i++)
            {
                _prescriptions.Add( new Prescription
                {
                    PrescriptionId = i + 1,
                    AppointmentBooking = _appointments[i].Booking,
                    AppointmentDoctorId= _appointments[i].DoctorId,
                    AppointmentPatientId = _appointments[i].PatientId,
                    PrescriptionMedicines = new List<PrescriptionMedicine>(),
                    

                });
            }
            foreach(Prescription prescription in _prescriptions)
            {
                var medicineBatch = new HashSet<Medicine>();

                for (int j = 0; j < random.Next(1, 4); j++)
                {
                     medicineBatch.Add(_medicines[random.Next(_medicines.Count)]);
                }

                foreach(Medicine medicine in medicineBatch)
                {
                    var prescriptionMedicine = new PrescriptionMedicine
                    {
                        PrescriptionId = prescription.PrescriptionId,
                        MedicineId = medicine.MedicineId,
                        Quantity = random.Next(1, 5),
                        Notes = "Take once daily"
                    };
                    
                    _prescriptionMedicines.Add(prescriptionMedicine);
     
                }
            } 
        }

        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get { return _appointments; } }
        public List<Medicine> Medicines { get { return _medicines; } }
        public List<Prescription> Prescriptions { get { return _prescriptions; } }
        public List<PrescriptionMedicine> PrescriptionMedicines { get { return _prescriptionMedicines; } }
    }
}
