using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _databaseContext;
        public Repository(DataContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            var exists = await _databaseContext.Doctors.Where(d => d.Id == id).FirstOrDefaultAsync();
            if (exists is null)
            {
                return null;
            }

            return await _databaseContext.Appointments
                .Where(a => a.DoctorId==id)
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            var exists = await _databaseContext.Patients.Where(p => p.Id==id).FirstOrDefaultAsync();
            if (exists is null)
            {
                return null;
            }

            return await _databaseContext.Appointments
                .Where(a => a.PatientId == id)
                .Include(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            var exists = await _databaseContext.Appointments
                .Where(a => a.PatientId == appointment.PatientId)
                .Where(A => A.DoctorId == appointment.DoctorId)
                .FirstOrDefaultAsync();

            if (exists is not null)
            {
                return null;
            }

            await _databaseContext.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();

            var entity = await _databaseContext.Appointments
                .Where(a => a.PatientId == appointment.PatientId)
                .Where(A => A.DoctorId == appointment.DoctorId)
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync();

            if (entity is null)
            {
                return null;
            }
            return entity;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions
                .Include(p => p.Appointment)
                .Include(p => p.Medicines)
                .ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionbyId(int id)
        {
            var exists = await _databaseContext.Prescriptions
                .Where(p => p.Id == id)
                .Include(p => p.Appointment)
                .Include(p => p.Medicines)
                .FirstOrDefaultAsync();

            if (exists is null)
            {
                return null;
            }

            return exists;
        }

        public async Task<Prescription> CreatePrescription(Prescription prescription)
        {
            var exists = await _databaseContext.Prescriptions
                .Where(p => p.PatientId == prescription.PatientId)
                .Where(A => A.DoctorId == prescription.DoctorId)
                .FirstOrDefaultAsync();
            if (exists is not null)
            {
                return null;
            }

            await _databaseContext.Prescriptions.AddAsync(prescription);
            await _databaseContext.SaveChangesAsync();

            return prescription;
        }

        public async Task<PrescribedMedicine> CreatePrescribedMedicide(PrescribedMedicine prescribed)
        {
            var exists = await _databaseContext.PrescribedMedicines
                .Where(pm => pm.MedicineId == prescribed.MedicineId)
                .Where(pm => pm.PrescriptionId == prescribed.PrescriptionId)
                .FirstOrDefaultAsync();
            if (exists is not null) { return null; }

            await _databaseContext.PrescribedMedicines.AddAsync(prescribed);
            await _databaseContext.SaveChangesAsync();

            var added = await _databaseContext.PrescribedMedicines
                .Where(pm => pm.MedicineId == prescribed.MedicineId)
                .Where(pm => pm.PrescriptionId == prescribed.PrescriptionId)
                .FirstOrDefaultAsync();

            return added;
        }
    }
}
