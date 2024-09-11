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
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(p => p.Doctor).ToListAsync();
        }
        public async Task<Patient> GetPatient(Guid id)

        {
            Patient patient = await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(p => p.Doctor).FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
                throw new Exception("Patient not found");

            return patient;
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();

            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(p => p.Doctor).FirstOrDefaultAsync(p => p.Id == patient.Id);
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(p => p.Patient).ToListAsync();
        }

        public async Task<Doctor> GetDoctor(Guid id)
        {
            Doctor doctor = await _databaseContext.Doctors.Include(p => p.Appointments).ThenInclude(p => p.Patient).FirstOrDefaultAsync(p => p.Id == id);

            if (doctor == null)
                throw new Exception("Doctor not found");

            return doctor;
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();

            return await _databaseContext.Doctors.Include(p => p.Appointments).ThenInclude(p => p.Patient).FirstOrDefaultAsync(p => p.Id == doctor.Id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a=> a.Patient).ToListAsync();
        }

        public async Task<Appointment> GetAppointment(Guid patientId, Guid doctorId)
        {
            Appointment appointment = await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.PatientId == patientId && a.DoctorId == doctorId);

            if (appointment == null)
                throw new Exception("Appointment not found");

            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(Guid id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(Guid id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task CreateAppointment(Appointment appointment)
        {
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext
                .Prescriptions.Include(p => p.Medicines)
                .Include(p => p.Appointment)
                    .ThenInclude(p => p.Doctor)
                .Include(p => p.Appointment)
                    .ThenInclude(p => p.Patient)
                .ToListAsync();
        }

        public async Task<Prescription> GetPrescription(Guid id)

        {
            Prescription prescription = await _databaseContext
                .Prescriptions.Include(p => p.Medicines)
                .Include(p => p.Appointment)
                    .ThenInclude(p => p.Doctor)
                .Include(p => p.Appointment)
                    .ThenInclude(p => p.Patient)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prescription == null)
                throw new Exception("Prescription not found");

            return prescription;
        }

        public async Task CreatePrescription(Prescription prescription)
        {
            _databaseContext.Prescriptions.Add(prescription);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Medicine> GetMedicine(Guid id)
        {
            Medicine medicine = await _databaseContext.Medicines.FirstOrDefaultAsync(m => m.Id == id);

            if (medicine == null)
                throw new Exception("Medicine not found");

            return medicine;
        }

        public async Task AddMedicineToPrescription(Guid medicineId, Guid prescriptionId)
        {

            var prescription = await _databaseContext.Prescriptions
                .Include(p => p.Medicines) 
                .FirstOrDefaultAsync(p => p.Id == prescriptionId);

            var medicine = await _databaseContext.Medicines
                .FirstOrDefaultAsync(m => m.Id == medicineId);

            if (!prescription.Medicines.Contains(medicine))
            {
                prescription.Medicines.Add(medicine);
            }

            await _databaseContext.SaveChangesAsync();
        }
    }
}
