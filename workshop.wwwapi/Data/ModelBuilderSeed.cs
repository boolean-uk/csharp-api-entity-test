using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization.Formatters;
using workshop.wwwapi.Models.Domain;

namespace workshop.wwwapi.Data
{
    public static class ModelBuilderSeed
    {
        private static List<string> patientFirstnames = new List<string>
        {
            "Ben",
            "John",
            "Greg",
            "Ian",
            "Chris",
            "Dave",
            "Frank",
            "Jack",
            "Anna",
            "Beth",
            "Claire",
            "Emily",
            "Diane",
            "Julia",
            "Grace"
        };

        private static List<string> doctorFirstnames = new List<string>
        {
            "Alexander",
            "Benedict",
            "Charles",
            "Dorian",
            "Edmund",
            "Frederick",
            "Geoffrey",
            "Harrison",
            "Julian",
            "Leopold",
            "Maximilian",
            "Nathaniel",
            "Oliver",
            "Percival",
            "Quentin",
            "Anastasia",
            "Beatrice",
            "Charlotte",
            "Daphne",
            "Eleanor",
            "Felicity",
            "Genevieve",
            "Henrietta",
            "Isabella",
            "Josephine",
            "Katherine",
            "Lavinia",
            "Miranda",
            "Ophelia",
            "Penelope"
        };
        private static List<string> patientSurnames = new List<string>
        {
            "Smith",
            "Johnson",
            "Williams",
            "Brown",
            "Davis",
            "Miller",
            "Wilson",
            "Moore",
            "Taylor",
            "Anderson",
            "Thomas",
            "Jackson",
            "White",
            "Harris",
            "Martin",
            "Thompson",
            "Garcia",
            "Martinez",
            "Robinson"
        };
        private static List<string> doctorSurnames = new List<string>
        {
            "Montague-Smythe",
            "Beaumont-Cavendish",
            "St. Clair-Winthrop",
            "Vanderbilt-Astor",
            "Archibald-Wellesley",
            "Hawthorne-Devereux",
            "Sterling-Montgomery",
            "Sinclair-Fitzgerald",
            "Pembroke-Ellington",
            "Langford-Salisbury",
            "Carrington-Leigh",
            "Kensington-Rowe",
            "Hargrave-Chamberlain",
            "Sterling-Goldsmith",
            "Ravenswood-Grantham",
            "Fairbanks-Crowley",
            "Blackwood-Mornington",
            "Fitzroy-Davenport",
            "Huntington-Whitely",
            "Westminster-Finchley",
            "Stratford-Belgravia",
            "Kingsley-Harrington",
            "Wentworth-Fitzwilliam",
            "Ashford-Lexington",
            "Blenheim-Sterling",
            "Clarendon-Marlborough",
            "Derbyshire-Langford",
            "Eddington-Hawthorne",
            "Falmouth-Pennington",
            "Grantham-Leighton",
            "Jones"
        };
        public static List<string> doctorTitles = new List<string>
        {
            "Doctor",
            "Dr.",
            "Doc.",
            "Prof. Dr.",
            "Dr. PhD",
            "Master Dr.",
            "Dr. Master"
        };

        private static Random random = new Random();

        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            int numPatients = 1000;
            int numDoctors = 15;
            int numApppintments = 200;
            var patients = Enumerable.Range(1, numPatients).Select(id => new Patient { ID = id, FullName = GeneratePatientName() });
            var doctors = Enumerable.Range(1, numDoctors).Select(id => new Doctor {  ID = id, FullName = GenerateDoctorName() });
            var appointments = new List<Appointment>();
            for (int i = 0; i < numApppintments; i++)
            {
                int doctorID = random.Next(1, numDoctors + 1);
                int patientID = random.Next(1, numPatients + 1);
                Appointment appointment = new Appointment() { ID = i + 1, DoctorID = doctorID, PatientID = patientID, AppointmentTime = GenerateRandomDate()};
                appointments.Add(appointment);
            }
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Appointment>().HasData(appointments);
        }

        private static string GeneratePatientName()
        {
            int firstnameIdx = random.Next(patientFirstnames.Count);
            int surnameIdx = random.Next(patientSurnames.Count);
            return patientFirstnames[firstnameIdx] + " " + patientSurnames[surnameIdx];
        }

        private static string GenerateDoctorName()
        {
            int firstnameIdx = random.Next(doctorFirstnames.Count);
            int surnameIdx = random.Next(doctorSurnames.Count);
            int titleIdx = random.Next(doctorTitles.Count);
            return $"{doctorTitles[titleIdx]} {doctorFirstnames[firstnameIdx]} {doctorSurnames[surnameIdx]}";
        }

        private static DateTime GenerateRandomDate()
        {
            DateTime startDate = new DateTime(2024, 1, 1);
            DateTime endDate = new DateTime(2025, 12, 31);
            TimeSpan timeSpan = endDate - startDate;
            int totalDays = timeSpan.Days;
            int randomDaysToAdd = random.Next(totalDays + 1);
            DateTime randomDate = startDate.AddDays(randomDaysToAdd);
            return DateTime.SpecifyKind(randomDate, DateTimeKind.Utc);
        }
    }
}
