using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            List<Patient> patients = await _databaseContext.Patients.ToListAsync();
            return patients;
        }

        public async Task<Patient>GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            return patient;
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            return doctor;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            Appointment appo = await _databaseContext.Appointments.FirstOrDefaultAsync(x => x.Appointment_Id == id);
            if (appo != null)
            {
                return appo;
            }
            return null;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByDoctorId(int id)
        {
            return await _databaseContext.Appointments.Where(x => x.DoctorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByPatientId(int id)
        {
            return await _databaseContext.Appointments.Where(x => x.PatientId == id).ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.ToListAsync();
        }

        public async Task<MedicinePrescription> GetMedicinePrescriptionsById(int id)
        {
            
            MedicinePrescription pres= await _databaseContext.medicinePrescriptions.FirstOrDefaultAsync(x => x.PrescriptionId == id);
            if (pres != null)
            {
                return pres;

            }
            return null;
        }

        public async Task<Prescription> CreatePrescription(Appointment appointment, MedicinePrescription meds)
        {
            Prescription pres = new Prescription()
            {
                PrescriptionId = _databaseContext.Prescriptions.Count() + 1,
                PatientId = appointment.PatientId,
                DoctorId = appointment.DoctorId,
                appointment = appointment,
                AppointmentId = appointment.Appointment_Id,
                MedicinePrescriptions = meds

            };
            Medicine med = new Medicine()
            {
                Name = meds.Name,
                Instruction = meds.Notes,
                Quantity = meds.Quantity,
                MedicineId = meds.MedicineId
            };


            
            await _databaseContext.AddAsync(med);
            await _databaseContext.AddAsync(pres);

            await _databaseContext.SaveChangesAsync();

            appointment.prescriptions.Add(pres);

            return pres;
        }

        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines.ToListAsync();
        }
    }
}
