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

        // Patients
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (patient == null)
            {
                return null;
            }
            return patient;
        }

        public async Task<Patient> CreatePatient(Patient entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        // Doctors
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors
                .Include(d => d.Appointments)
                .ThenInclude(a => a.Patient)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (doctor == null)
            {
                return null;
            }
            return doctor;
        }

        public async Task<Doctor> CreateDoctor(Doctor entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        // Appointments
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                .Where(a => a.DoctorId==id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                .Where(a => a.PatientId == id)
                .ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(DateTime booking, int doctorId, int patientId)
        {
            return await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                .FirstOrDefaultAsync(a => a.Booking.Equals(booking) && 
                                          a.DoctorId == doctorId && 
                                          a.PatientId == patientId);
        }

        public async Task<Appointment> CreateAppointment(Appointment entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        // Medicines & Perscriptions
        public async Task<IEnumerable<Medicine>> GetMedicines()
        {
            return await _databaseContext.Medicines
                .Include(m => m.Prescriptions)
                .ToListAsync();
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions
                .Include(p => p.Medicines)
                .Include(p => p.Appointment)
                .ToListAsync();
        }

        public async Task<Prescription> CreatePrescription(Prescription entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Medicine> CreateMedicine(Medicine entity)
        {
            await _databaseContext.AddAsync(entity);
            await _databaseContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Prescription> AddMedicineToPrescription(int medicineId, int prescriptionId)
        {
            var medicine = await _databaseContext.Medicines
                .Include(m => m.Prescriptions)
                .FirstOrDefaultAsync(m => m.Id == medicineId);

            if (medicine == null)
            {
                return null;
            }

            var prescription = await _databaseContext.Prescriptions
                .Include(p => p.Medicines)
                .FirstOrDefaultAsync(p => p.Id == prescriptionId);

            if (prescription == null)
            {
                return null;
            }

            if (prescription.Medicines.Contains(medicine))
            {
                prescription.Medicines.FirstOrDefault(m => m.Id == medicineId).Quantity += 1;
                //int medicineIndex = prescription.Medicines.IndexOf(medicine);
                //prescription.Medicines[medicineIndex].Quantity += 1;
            }
            else
            {
                prescription.Medicines.Add(medicine);
            }

            if (!medicine.Prescriptions.Contains(prescription))
            {
                medicine.Prescriptions.Add(prescription);
            }

            _databaseContext.Attach(medicine).State = EntityState.Modified;
            _databaseContext.Attach(prescription).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();

            return prescription;
        }

        public async Task<Appointment> AddPrescriptionToAppointment(DateTime booking, int doctorId, int patientId, int prescriptionId)
        {
            var appointment = await _databaseContext.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .Include(a => a.Prescription)
                .FirstOrDefaultAsync(a => a.Booking.Equals(booking) &&
                                          a.DoctorId == doctorId &&
                                          a.PatientId == patientId);

            if (appointment == null)
            {
                return null;
            }

            var prescription = await _databaseContext.Prescriptions
                .Include(p => p.Medicines)
                .Include(p => p.Appointment)
                .FirstOrDefaultAsync(p => p.Id == prescriptionId);

            if (prescription == null)
            {
                return null;
            }

            appointment.PrescriptionId = prescriptionId;
            appointment.Prescription = prescription;

            prescription.Appointment = appointment;

            _databaseContext.Attach(prescription).State = EntityState.Modified;
            _databaseContext.Attach(appointment).State = EntityState.Modified;
            await _databaseContext.SaveChangesAsync();

            return appointment;
        }
    }
}
