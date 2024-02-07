using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization.Formatters;
using workshop.wwwapi.Models.Domain;
using workshop.wwwapi.Models.Domain.Junctions;

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
            "Montgomery",
            "Leopold",
            "Chawton",
            "Gregory",
            "Xavier",
            "Sebastian",
            "Maximilian",
            "Nathaniel",
            "Oliver",
            "Percival",
            "Quentin",
            "Indiana",
            "Anastasia",
            "Beatrice",
            "Charlotte",
            "Daphne",
            "Eleanor",
            "Felicity",
            "Genevieve",
            "Henrietta",
            "Isabella",
            "Lavinia",
            "Miranda",
            "Ophelia",
            "Penelope",
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
            "Jones",
            "Chocofix",
            "Carbcrave",
            "Sugarlove",
            "Snackwell",
            "Sodamore",
            "Sugarmore",
            "Chocomore",
            "Snackmore",
            "Colamore",
            "Snackright",
            "Colagood",
            "Candycraze",
            "Sugargood",
            "Candygood",
            "Eatmore",
            "Sodagood",
            "Snackgood"
        };
        private static List<string> doctorTitles = new List<string>
        {
            "Doctor",
            "Dr.",
            "Doc.",
            "M.D.",
            "Professor",
            "Prof. Dr.",
            "PhD Dr.",
            "Supreme Dr.",
            "Specialist",
            "Master Dr."
        };
        private static List<string> doctorNotes = new List<string>
        {
            "don't spend it all at once",
            "wash it down with a glass of coke",
            "take together with a bag of chips",
            "taste even better when you put them in cinnamon rolls",
            "enjoy, and remember what I told you: fruit juice is just as bad for you as soda (perhaps even worse)",
        };

        private static List<Medicine> medicines = new List<Medicine>()
        {
            new Medicine() { ID = 1, Name="Painkillers"},
            new Medicine() { ID = 2, Name="Sleeping Pills"}
        };
        private static Random random = new Random();

        public static void SeedDatabase(this ModelBuilder modelBuilder)
        {
            int numPatients = 200;
            int numDoctors = 20;
            int numAppointments = 100;
            int numPrescriptions = 60;
            List<Patient> patients = Enumerable.Range(1, numPatients).Select(id => new Patient { ID = id, FullName = GeneratePatientName() }).ToList();
            List<Doctor> doctors = Enumerable.Range(1, numDoctors).Select(id => new Doctor {  ID = id, FullName = GenerateDoctorName() }).ToList();
            List<Appointment> appointments = new List<Appointment>();
            for (int i = 0; i < numAppointments; i++)
            {
                int doctorID = random.Next(1, numDoctors + 1);
                int patientID = random.Next(1, numPatients + 1);
                Appointment appointment = new Appointment() { ID = i + 1, DoctorID = doctorID, PatientID = patientID, AppointmentTime = GenerateRandomDate()};
                appointments.Add(appointment);
            }
            List<Prescription> prescriptions = Enumerable.Range(1, numPrescriptions).Select(id => new Prescription() { ID = id, AppointmentID = id }).ToList();
            List<PrescriptionMedicine> prescriptionMedicines = GeneratePrescriptionMedicines(numPrescriptions);
            patients[0].FullName = "Anna Smith";
            doctors[0].FullName = "Specialist Doctor Joseph Morecola";
            appointments[0].AppointmentTime = new DateTime(2024, 2, 17, 16, 30, 0, DateTimeKind.Utc);
            appointments[0].DoctorID = 1;
            appointments[0].PatientID = 1;
            modelBuilder.Entity<Patient>().HasData(patients);
            modelBuilder.Entity<Doctor>().HasData(doctors);
            modelBuilder.Entity<Appointment>().HasData(appointments);
            modelBuilder.Entity<Medicine>().HasData(medicines);
            modelBuilder.Entity<Prescription>().HasData(prescriptions);
            modelBuilder.Entity<PrescriptionMedicine>().HasData(prescriptionMedicines);
        }

        private static List<PrescriptionMedicine> GeneratePrescriptionMedicines(int numEntries)
        {
            List<PrescriptionMedicine> prescriptionMedicines = new List<PrescriptionMedicine>();
            for (int i = 1; i <= numEntries; i++)
            {
                PrescriptionMedicine prescriptionMedicine = GeneratePrescriptionMedicine(i);
                if (random.Next(2) == 1)
                {
                    PrescriptionMedicine secondPrescriptionMedicine = GeneratePrescriptionMedicine(i);
                    if (prescriptionMedicine.MedicineID == secondPrescriptionMedicine.MedicineID) prescriptionMedicine.Quantity++;
                    else prescriptionMedicines.Add(secondPrescriptionMedicine);
                }
                prescriptionMedicines.Add(prescriptionMedicine);
            }
            return prescriptionMedicines;
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
            DateTime randomDate = startDate.AddDays(randomDaysToAdd).AddHours(random.Next(6,20));
            return DateTime.SpecifyKind(randomDate, DateTimeKind.Utc);
        }

        private static PrescriptionMedicine GeneratePrescriptionMedicine(int prescriptionID)
        {
            PrescriptionMedicine prescriptionMedicine = new PrescriptionMedicine() { PrescriptionID = prescriptionID };
            prescriptionMedicine.MedicineID = medicines[random.Next(medicines.Count)].ID;
            prescriptionMedicine.Quantity = random.Next(1,3);
            prescriptionMedicine.NoteFromDoctor = doctorNotes[random.Next(doctorNotes.Count)];
            return prescriptionMedicine;
        }
    }
}
