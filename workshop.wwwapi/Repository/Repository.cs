using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.JunctionTable;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Patient?> GetPatientById(int id)
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                    .ThenInclude(a => a.Doctor)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Patient> PostPatient(Patient patient)
        {
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext
                .Doctors
                .Include(d => d.Appointments)
                    .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Doctor?> GetSpecificDoctor(int id)
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                    .ThenInclude(a => a.Patient)
                .Where(d => d.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Doctor> PostDoctor(Doctor doctorInput)
        {
            await _databaseContext.Doctors.AddAsync(doctorInput);
            await _databaseContext.SaveChangesAsync();
            return doctorInput;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Appointment>> GetAppointmentsForDoctors(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.DoctorId == id)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Appointment>> GetAppointmentsForPatients(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.PatientId == id)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Appointment>> GetAppointmentsByIds(int doctorId, int patientId)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.DoctorId == doctorId && a.PatientId == patientId)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Appointment?> GetAppointmentByAppointmentId(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(a => a.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Appointment> PostAppointment(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions
                .Include(p => p.PrescriptionMedicine)
                    .ThenInclude(pm => pm.Medicine)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Prescription?> GetSpecificPrescription(int id)
        {
            return await _databaseContext.Prescriptions
                .Include(p => p.PrescriptionMedicine)
                    .ThenInclude(pm => pm.Medicine)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                .Include(p => p.Appointment)
                    .ThenInclude(a => a.Doctor)
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines
                .Include(m => m.PrescriptionMedicine)
                    .ThenInclude(pm => pm.Prescription)
                .ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<Medicine?> GetMedicine(int id) 
        {
            return await _databaseContext.Medicines.Where(m => m.Id == id).FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task<Prescription> PostPrescription(Prescription prescription) 
        {
            prescription.Appointment = await GetAppointmentByAppointmentId(prescription.AppointmentId);
            await _databaseContext.Prescriptions.AddAsync(prescription);
            await _databaseContext.SaveChangesAsync();
            return prescription;
        }

        /// <inheritdoc/>
        public async Task<PrescriptionMedicine> PostPrescriptionMedicine(PrescriptionMedicine pm)
        {
            await _databaseContext.PrescriptionMedicines.AddAsync(pm);
            await _databaseContext.SaveChangesAsync();
            return pm;
        }
    }
}
