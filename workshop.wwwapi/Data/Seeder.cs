using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private List<string> _firstNames = new List<string>()
        {
            "Felix",
            "Donald",
            "Elvis",
            "Barack",
            "Oprah",
            "Adam",
            "Mickey",
            "Kate",
            "Charles",
            "Arnold",
            "Ragnar",
            "Neo"
        };

        private List<string> _lastNames = new List<string>()
        {
            "Mathiasson",
            "Duck",
            "Presley",
            "Obama",
            "Winfrey",
            "Sandler",
            "Mouse",
            "Winslow",
            "Xavier",
            "Schwarzenegger",
            "Lothbrok",
            "Andersson"
        };
        private List<string> _medicinesPartOne = new List<string>()
        {
            "Super",
            "Stupid",
            "Bad",
            "Good",
            "Crazy",
            "Not",
            "Yummy",
            "Blazing",
            "Dangerous",
            "Ultra"
        };  

        private List<string> _medicinesPartTwo = new List<string>()
        {
            "Xanax",
            "Aspirin",
            "Morphine",
            "Pills",
            "Blue Pills",
            "Couch drops",
            "Heroin",
            "Laxatives",
            "Mushrooms",
            "Leaves",
            "Potion",
            "Drugs"
        };

        private List<string> _medicinesInstructions = new List<string>()
        {
            "Swallow with water.",
            "Swallow without anything added.",
            "Inject with needle into the bloodstream.",
            "Insert into rectum.",
            "Disolve into drink of your choice.",
            "Put in coworker's food.",
            "Hide in cabinet and let the placebo effect do it's job.",
            "Lick over a long period of time.",
            "Consume with any meal.",
            "Snort before tequila shot.",
            "Mix with chicken noodle soup.",
            "Chew on it for 3 hours."
        };

        private List<Doctor> _doctors = new List<Doctor>();
        private List<Patient> _patients = new List<Patient>();
        private List<Appointment> _appointments = new List<Appointment>();

        private List<Medicine> _medicines = new List<Medicine>();
        private List<Prescription> _prescriptions = new List<Prescription>();
        private List<PrescriptionMedicine> _prescriptionMedicines = new List<PrescriptionMedicine>();


        public Seeder()
        {
            Random doctorRandom = new Random();
            Random patientRandom = new Random();
            Random dateRandom = new Random();
            Random medicineRandom = new Random();
            Random descRandom = new Random();
            Random prescriptionRandom = new Random();

            for (int i = 1; i < 11; i++)
            {
                Doctor doctor = new Doctor();
                doctor.Id = i;
                doctor.FullName =
                    _firstNames[doctorRandom.Next(_firstNames.Count)] + " " +
                    _lastNames[doctorRandom.Next(_lastNames.Count)];
                _doctors.Add(doctor);
            }
            for (int i = 1; i < 11; i++)
            { 

                Patient patient = new Patient();
                patient.Id = i;
                patient.FullName =
                    _firstNames[patientRandom.Next(_firstNames.Count)] + " " +
                    _lastNames[patientRandom.Next(_lastNames.Count)];
                _patients.Add(patient);
            }

            




            //extension seeding, didn't see(d) this coming, eh?
           
            for (int i = 1; i < 11; i++)
            {
                Medicine medicine = new Medicine
                {
                    Id = i,
                    Name = _medicinesPartOne[medicineRandom.Next(_medicinesPartOne.Count)] + " " +
                        _medicinesPartTwo[medicineRandom.Next(_medicinesPartTwo.Count)],
                    Instruction = _medicinesInstructions[descRandom.Next(_medicinesInstructions.Count)],
                    Quantity = medicineRandom.Next(1, 100) 
                };
                _medicines.Add(medicine);
            }



            for (int i = 1; i < 11; i++)
            {
                Prescription prescription = new Prescription
                {
                    Id = i
                };

                _prescriptions.Add(prescription);
            }

            for (int i = 1; i < 11; i++)
            {
                // Prescription can have 3 medicines
                List<int> randoms = new List<int>();
                while (randoms.Count < 3)
                {
                    int random = _medicines[medicineRandom.Next(_medicines.Count)].Id;
                    if (!randoms.Contains(random))
                    {
                        randoms.Add(random);
                    }
                }

                foreach (var id in randoms)
                {
                    _prescriptionMedicines.Add(new PrescriptionMedicine() { MedicineId = i, PrescriptionId = id });
                }
            }


            for (int i = 1; i < 11; i++)
            {
                Appointment appointment = new Appointment();
                appointment.Id = i;

                appointment.PatientId = _patients[i - 1].Id;
                appointment.DoctorId = _doctors[doctorRandom.Next(_doctors.Count)].Id;

                DateTime now = DateTime.Now;
                DateTime futureDate = now.AddDays(dateRandom.Next(1, 366)).AddHours(dateRandom.Next(0, 24)).AddMinutes(dateRandom.Next(0, 60)).AddSeconds(dateRandom.Next(0, 60));
                appointment.Booking = futureDate.ToUniversalTime();

                _appointments.Add(appointment);
            }

        }

        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Patient> Patients { get { return _patients; } }

        public List<Appointment> Appointments { get { return _appointments; } }

        public List<Medicine> Medicines { get { return _medicines; } }

        public List<Prescription> Prescriptions { get { return _prescriptions; } }

        public List<PrescriptionMedicine> PrescriptionsMedicines { get {return _prescriptionMedicines; } }
        
    }
}
