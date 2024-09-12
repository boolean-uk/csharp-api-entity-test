using workshop.wwwapi.Models;

namespace exercise.webapi.Data
{
    public class Seeder
    {
        //private List<string> _firstnames = new List<string>()
        //{
        //    "Audrey",
        //    "Donald",
        //    "Elvis",
        //    "Barack",
        //    "Oprah",
        //    "Jimi",
        //    "Mick",
        //    "Kate",
        //    "Charles",
        //    "Kate"
        //};
        //private List<string> _lastnames = new List<string>()
        //{
        //    "Hepburn",
        //    "Trump",
        //    "Presley",
        //    "Obama",
        //    "Winfrey",
        //    "Hendrix",
        //    "Jagger",
        //    "Winslet",
        //    "Windsor",
        //    "Middleton"

        //};
        //private List<string> _domain = new List<string>()
        //{
        //    "bbc.co.uk",
        //    "google.com",
        //    "theworld.ca",
        //    "something.com",
        //    "tesla.com",
        //    "nasa.org.us",
        //    "gov.us",
        //    "gov.gr",
        //    "gov.nl",
        //    "gov.ru"
        //};
        //private List<string> _firstword = new List<string>()
        //{
        //    "The",
        //    "Two",
        //    "Several",
        //    "Fifteen",
        //    "A bunch of",
        //    "An army of",
        //    "A herd of"


        //};
        //private List<string> _secondword = new List<string>()
        //{
        //    "Orange",
        //    "Purple",
        //    "Large",
        //    "Microscopic",
        //    "Green",
        //    "Transparent",
        //    "Rose Smelling",
        //    "Bitter"
        //};
        //private List<string> _thirdword = new List<string>()
        //{
        //    "Buildings",
        //    "Cars",
        //    "Planets",
        //    "Houses",
        //    "Flowers",
        //    "Leopards"
        //};
        //private List<string> _publishernames = new List<string>()
        //{
        //    "RELX Group",
        //    "Thomson Reuters",
        //    "Pearson",
        //    "Bertelsmann",
        //    "Wotlers Kluwer",
        //    "Hachette Livre",
        //    "Springer Nature",
        //    "Wiley"
        //};

        private List<Patient> _patients = new List<Patient>();
        private List<Doctor> _doctors = new List<Doctor>();
        private List<Appointment> _appointments = new List<Appointment>();

        public List<Patient> Patients { get => _patients; }
        public List<Doctor> Doctors { get => _doctors; }
        public List<Appointment> Appointments { get => _appointments; }

        public Seeder()
        {
            //Random authorRandom = new Random();
            //Random bookRandom = new Random();
            //Random publisherRandom = new Random();

            _patients.Add(new Patient() { Id = 1, FullName = "John Doe" });
            _patients.Add(new Patient() { Id = 2, FullName = "Jane Doe" });

            _doctors.Add(new Doctor() { Id = 1, FullName = "Meredith Grey" });
            _doctors.Add(new Doctor() { Id = 2, FullName = "Kaja Doctor" });

            _appointments.Add(new Appointment() { Booking = DateTime.UtcNow, DoctorId = 1, PatientId = 2 });
            _appointments.Add(new Appointment() { Booking = DateTime.UtcNow, DoctorId = 2, PatientId = 1 });
        }
    }
}
