using workshop.wwwapi.Models;

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
        private List<string> _medicineFirstNames = new List<string>()
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
        private List<string> _medicineLastNames = new List<string>()
        {
            "Pills",
            "Laxatives",
            "Cough Drops",
            "Candy",
            "Paracetamol",
            "Mold",
            "Heroin",
            "Drugs"
        };

        private List<string> _medicineInstructionsStart = new List<string>()
        {
            "Swallow with",
            "Dilute with",
            "Submerge in",
            "Eat with",
            "Inject into arm and then take some",
            "Crush and mix with",
            "Apply on your face and then take some"
        };
        private List<string> _medicineInstructionsEnd = new List<string>()
        {
            "air",
            "water",
            "juice",
            "cinammon",
            "cocaine",
            "gasoline",
            "cooking Oil",
            "sand",
            "alcohol",
            "chinese chicken stock",
            "swedish meatballs"
        };

        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();
        private List<Medicine> _medicines = new List<Medicine>();
        private List<Perscription> _perscriptions = new List<Perscription>();
        private List<PerscriptionMedicine> _perscriptionMedicines = new List<PerscriptionMedicine>();

        public Seeder()
        {
            Random patientRandom = new Random();
            Random doctorRandom = new Random();
            Random dateRandom = new Random();
            Random medicineRandom = new Random();

            for (int x = 1; x < 5; x++)
            {
                Patient patient = new Patient();
                patient.Id = x;
                patient.FullName = $"{_firstnames[patientRandom.Next(_firstnames.Count)]} {_lastnames[patientRandom.Next(_lastnames.Count)]}";
                _patients.Add(patient);
            }

            for(int y = 1; y < 5; y++)
            {
                Doctor doctor = new Doctor();
                doctor.Id = y;
                doctor.FullName = $"{_firstnames[doctorRandom.Next(_firstnames.Count)]} {_lastnames[doctorRandom.Next(_lastnames.Count)]}";
                _doctors.Add(doctor);
            }

            for (int a = 1; a < 5; a++)
            {
                Medicine medicine = new Medicine();
                medicine.Id = a;
                medicine.Name = $"{_medicineFirstNames[medicineRandom.Next(_medicineFirstNames.Count)]} {_medicineLastNames[medicineRandom.Next(_medicineLastNames.Count)]}";
                medicine.Instruction = $"{_medicineInstructionsStart[medicineRandom.Next(_medicineInstructionsStart.Count)]} {_medicineInstructionsEnd[medicineRandom.Next(_medicineInstructionsEnd.Count)]}";
                medicine.Quantity = medicineRandom.Next(1, 10);

                _medicines.Add(medicine);
            }

            for (int b = 1; b < 5; b++)
            {
                Perscription perscription = new Perscription();
                perscription.Id = b;

                _perscriptions.Add(perscription);
            }

            for(int p = 1; p < 5; p++)
            {
                //Each perscription can have 2 medicines
                List<int> randoms = new List<int>();
                while(randoms.Count < 2) 
                {
                    int random = _medicines[medicineRandom.Next(_medicines.Count)].Id;
                    if (!randoms.Contains(random))
                    {
                        randoms.Add(random);
                    }
                }

                foreach (var id in randoms)
                {
                    _perscriptionMedicines.Add(new PerscriptionMedicine() { MedicineId = p, PerscriptionId = id }); 
                }
            }

            for (int z = 1; z < 5; z++)
            {
                Appointment appointment = new Appointment();
                appointment.Id = z;

                //Every patient has an appointment, but not every doctor has one
                appointment.PatientId = _patients[z - 1].Id;
                appointment.DoctorId = _doctors[doctorRandom.Next(_doctors.Count)].Id;
                appointment.PerscriptionId = _perscriptions[medicineRandom.Next(_perscriptions.Count)].Id;

                //Create a random date for the booking
                DateTime now = DateTime.Now;
                DateTime futureDate = now.AddDays(dateRandom.Next(1, 366)).AddHours(dateRandom.Next(0, 24)).AddMinutes(dateRandom.Next(0, 60)).AddSeconds(dateRandom.Next(0, 60));
                appointment.Booking = futureDate.ToUniversalTime();

                _appointments.Add(appointment);
            }
        }

        public List<Patient> patients { get { return _patients; } }
        public List<Doctor> doctors { get {return _doctors; } }
        public List<Appointment> appointments { get { return _appointments; } }
        public List<Medicine> medicines { get { return _medicines; } }
        public List<Perscription> perscriptions { get { return _perscriptions; } }
        public List<PerscriptionMedicine> perscriptionMedicines { get { return _perscriptionMedicines; } }
    }
}
