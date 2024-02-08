using workshop.wwwapi.Models.DatabaseModels;

namespace workshop.wwwapi.Data
{
    public class Seeder
    {
        public List<Patient> Patients = new List<Patient>()
        {
            new Patient{Id = 1, FullName = "Homer Simpson"},
            new Patient{Id = 2, FullName = "George Washington"}
        };

        public List<Doctor> Doctors = new List<Doctor>()
        { 
            new Doctor{Id = 1, FullName = "Doctor George"},
            new Doctor{Id = 2, FullName = "Doctor Homer"}
        };

        public List<Medicine> Medicines = new List<Medicine>()
        {
            new Medicine{Id = 1, Name = "Ibuprofen", Notes = "Maximum 3 pills per day", Quantity = 15},
            new Medicine{Id = 2, Name = "Wondermedicine", Notes ="Infinite", Quantity = 10},
            
        };

        public List<Perscription> Perscriptions = new List<Perscription>()
        {
            new Perscription{Id = 1},
            new Perscription{Id = 2},
        };


        public List<Appointment> Appointments = new List<Appointment>()
        {
            new Appointment{Booking = DateTime.SpecifyKind(DateTime.UtcNow.AddDays(1), DateTimeKind.Utc), DoctorId = 1, PatientId = 1, PerscriptionId = 1, AppointmentType = AppointmentType.Physical},
            new Appointment{Booking = DateTime.SpecifyKind(DateTime.UtcNow.AddDays(2), DateTimeKind.Utc), PatientId = 2, DoctorId = 2, PerscriptionId = 2, AppointmentType = AppointmentType.Digital}

        };

        public List<MedicinePerscription> MedicinePerscriptions = new List<MedicinePerscription>()
        {
            new MedicinePerscription{MedicineId = 1, PerscriptionId = 1},
            new MedicinePerscription{MedicineId = 2, PerscriptionId = 2},
            new MedicinePerscription{MedicineId = 1, PerscriptionId = 2},
        };
    }
}
