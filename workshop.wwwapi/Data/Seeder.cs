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



        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();
        private List<Medicine> _medicines = new List<Medicine>();
        private List<Prescription> _prescriptions = new List<Prescription>();
        private List<MedicinePrescription> _medPre = new List<MedicinePrescription>();


        public Seeder()
        {

            Random patientRandom = new Random();
            Random doctorRandom = new Random();
            Random appointmentRandom = new Random();
            Random medicineRandom = new Random();



            for (int x = 1; x < 11; x++)
            {
                Patient patient = new Patient();
                patient.Id = x;
                patient.FullName = $"{_firstnames[patientRandom.Next(_firstnames.Count)]} {_lastnames[patientRandom.Next(_lastnames.Count)]}";

                _patients.Add(patient);
            }


            for (int y = 1; y < 11; y++)
            {
                Doctor doctor = new Doctor();
                doctor.Id = y;
                doctor.FullName = $"{_firstnames[doctorRandom.Next(_firstnames.Count)]} {_lastnames[doctorRandom.Next(_lastnames.Count)]}";


                //book.Author = authors[book.AuthorId-1];
                _doctors.Add(doctor);
            }

            for (int z = 1; z < 11; z++)
            {
                Appointment app = new Appointment();
                app.Booking = DateTime.UtcNow;
                app.PatientId = z;//appointmentRandom.Next(1, Patients.Count);
                app.DoctorId = z;//appointmentRandom.Next(1, Doctors.Count);


                _appointments.Add(app);
            }

            _medicines.Add(new Medicine() { MedName = "Paracetamol", Id = 1});
            _medicines.Add(new Medicine() { MedName = "Zyrtec", Id = 2 });
            _medicines.Add(new Medicine() { MedName = "Hyrimoz", Id = 3 });


            for (int v = 1; v < 6; v++)
            {
                Prescription pre = new Prescription();
                pre.Id = v;
                pre.DoctorId = v;
                pre.PatientId = v;
                MedicinePrescription preMed = new MedicinePrescription();
                preMed.PrescriptionId = v;
                preMed.MedId = medicineRandom.Next(1, _medicines.Count + 1);
                preMed.MedAmount = medicineRandom.Next(0, 10);

                _prescriptions.Add(pre);
                _medPre.Add(preMed);
            }


        }
        public List<Patient> Patients { get { return _patients; } }
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Appointment> Appointments { get { return _appointments; } }
        public List<Medicine> Medicines { get { return _medicines; }}
        public List<Prescription> Prescriptions { get { return _prescriptions; }}
        public List<MedicinePrescription> MedicinePrescriptions { get { return _medPre; } }
    }
}
