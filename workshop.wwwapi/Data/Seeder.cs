using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        private DatabaseContext _dbContext;

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

        List<DateTime> _appointmentDates = new List<DateTime>
        {
            new DateTime(2024, 9, 10),
            new DateTime(2024, 9, 15),
            new DateTime(2024, 9, 20),
            new DateTime(2024, 9, 25),
            new DateTime(2024, 9, 30),
            new DateTime(2024, 10, 5),
            new DateTime(2024, 10, 10),
            new DateTime(2024, 10, 15),
            new DateTime(2024, 10, 20),
            new DateTime(2024, 10, 25)
        };

        private List<Doctor> _doctors = new List<Doctor>() {
                        new Doctor() { Id = 1, FullName = "Adrian" },
                new Doctor() { Id = 2, FullName = "Jake" }
        };

        private List<Patient> _patients = new List<Patient>() {
                new Patient() {Id = 1, FullName= "Joe"},
                new Patient() {Id = 2, FullName= "Mark"},
                new Patient() {Id = 3, FullName= "Jeff"},
                new Patient() {Id = 4, FullName= "Rolf"},
                new Patient() {Id = 5, FullName= "Gabe"},
                new Patient() {Id = 6, FullName= "Jesus"}
        };

        private List<Appointment> _appointments = new List<Appointment>() {

                         new Appointment() { Booking = new DateTime(2024, 06, 06, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 1 },
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 2},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 5},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 4},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 3},
                 //new Appointment() { Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 6 },
        };


        public Seeder(DatabaseContext dbContext)
        {
            _dbContext = dbContext;

            Random doctorRandom = new Random();
            Random patientRandom = new Random();
            Random appointmentRandom = new Random();

            List<Patient> patients = new List<Patient>()
            {
                new Patient() {Id = 1, FullName= "Joe"},
                new Patient() {Id = 2, FullName= "Mark"},
                new Patient() {Id = 3, FullName= "Jeff"},
                new Patient() {Id = 4, FullName= "Rolf"},
                new Patient() {Id = 5, FullName= "Gabe"},
                new Patient() {Id = 6, FullName= "Jesus"}
            };

            List<Doctor> doctors = new List<Doctor>()
            {
                new Doctor() { Id = 1, FullName = "Adrian" },
                new Doctor() { Id = 2, FullName = "Jake" }
            };

            List<Appointment> appointments = new List<Appointment>() {
                 new Appointment() { Booking = new DateTime(2024, 06, 06, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 1 },
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 2},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 1, PatientId = 5},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 4},
                 new Appointment() {Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 3},
                 //new Appointment() { Booking = new DateTime(2024, 06, 07, 0, 0, 0, DateTimeKind.Utc), DoctorId = 2, PatientId = 6 },
             };

            _dbContext.Appointments.Where(a => a.DoctorId == 1).ExecuteUpdate(a => a.SetProperty(p => p.doctor, doctors.FirstOrDefault(x => x.Id == 1)));
            _dbContext.Appointments.Where(a => a.DoctorId == 2).ExecuteUpdate(a => a.SetProperty(p => p.doctor, doctors.FirstOrDefault(x => x.Id == 2)));

            //for (int x = 1; x < 250; x++)
            //{
            //    Doctor doctor = new Doctor();
            //    doctor.Id = x;
            //    doctor.FullName = _firstnames[doctorRandom.Next(_firstnames.Count)] + " " + _lastnames[doctorRandom.Next(_lastnames.Count)];
            //    _doctors.Add(doctor);

            //}

            //for (int x = 1; x < 250; x++)
            //{
            //    Patient patient = new Patient();
            //    patient.Id = x;
            //    patient.FullName = _firstnames[patientRandom.Next(_firstnames.Count)] + " " + _lastnames[patientRandom.Next(_lastnames.Count)];
            //    _patients.Add(patient);

            //}

            //for (int x = 1; x < 4; x++)
            //{
            //    Appointment appointment = new Appointment();
            //    //appointment.Booking = _appointmentDates[appointmentRandom.Next(_appointmentDates.Count)];
            //    appointment.DoctorId = _doctors[appointmentRandom.Next(_doctors.Count)].Id;
            //    //bool exists = AppointmentExists(appointment.Booking, appointment.DoctorId);
            //    //if (!exists)
            //    //{
            //    appointment.PatientId = _patients[appointmentRandom.Next(_patients.Count)].Id;
            //    _appointments.Add(appointment);
            //    //}

            //}




        }

        //private bool AppointmentExists(DateTime date, int doctorId)
        //{
        //    bool exists = false;
        //    _appointments.ForEach(appointment =>
        //    {
        //        if (appointment.Booking == date && appointment.DoctorId == doctorId)
        //        {
        //            exists = true;
        //        }

        //    });
        //    return exists;
        //}
        public List<Doctor> Doctors { get { return _doctors; } }
        public List<Patient> Patients { get { return _patients; } }
        public List<Appointment> Appointments { get { return _appointments; } }
    }
}
