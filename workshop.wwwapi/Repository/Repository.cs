using Microsoft.EntityFrameworkCore;
using System.Numerics;
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



        //              PATIENTS
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.
                Include(p => p.Appointments).ThenInclude(ap => ap.Doctor).
                Include(p => p.Appointments).ThenInclude(ap => ap.Prescriptions).
                ThenInclude(p => p.Medicines).ThenInclude(pm => pm.Medicine).
                ToListAsync();
        }
        public async Task<Patient> GetPatient(int id)
        {
            return await _databaseContext.Patients.
                Include(p => p.Appointments).ThenInclude(ap => ap.Doctor).
                Include(p => p.Appointments).ThenInclude(ap => ap.Prescriptions).
                ThenInclude(p => p.Medicines).ThenInclude(pm => pm.Medicine).
                FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _databaseContext.Patients.AddAsync(patient);
            _databaseContext.SaveChanges();
            int id = await _databaseContext.Patients.MaxAsync(p => p.Id);
            return await GetPatient(id);
        }


        //          DOCTORS
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.
                Include(d => d.Appointments).ThenInclude(ap => ap.Patient).
                Include(p => p.Appointments).ThenInclude(ap => ap.Prescriptions).
                ThenInclude(p => p.Medicines).ThenInclude(pm => pm.Medicine).
                ToListAsync();
        }
        public async Task<Doctor> GetDoctor(int id)
        {
            return await _databaseContext.Doctors.
                Include(d => d.Appointments).ThenInclude(ap => ap.Patient).
                Include(p => p.Appointments).ThenInclude(ap => ap.Prescriptions).
                ThenInclude(p => p.Medicines).ThenInclude(pm => pm.Medicine).
                FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _databaseContext.Doctors.AddAsync(doctor);
            _databaseContext.SaveChanges();
            int id = await _databaseContext.Doctors.MaxAsync(p => p.Id);
            return await GetDoctor(id);
        }


        //              Appointements
        public async Task<Appointment> GetAppointment(int patientId, int doctorId)
        {
            return await _databaseContext.Appointments.
                Include(ap => ap.Patient).Include(ap => ap.Doctor).
                Include(ap => ap.Prescriptions).
                ThenInclude(p => p.Medicines).ThenInclude(pm => pm.Medicine).
                FirstOrDefaultAsync(ap => ap.PatientId == patientId & ap.DoctorId == doctorId);
        }
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.
                Include(ap => ap.Patient).Include(ap => ap.Doctor).Include(ap => ap.Prescriptions).
                ThenInclude(p => p.Medicines).ThenInclude(pm => pm.Medicine).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.
                Include(ap => ap.Patient).Include(ap => ap.Doctor).
                Include(ap => ap.Prescriptions).
                ThenInclude(p => p.Medicines).ThenInclude(pm => pm.Medicine).
                Where(a => a.DoctorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.
                Include(ap => ap.Patient).Include(ap => ap.Doctor).
                Include(ap => ap.Prescriptions).
                ThenInclude(p => p.Medicines).ThenInclude(pm => pm.Medicine).
                Where(a => a.PatientId == id).ToListAsync();
        }
        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return await GetAppointment(appointment.PatientId, appointment.DoctorId);
        }

        //                  Prescriptions
        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.
                Include(p => p.Medicines).ThenInclude(m => m.Medicine).
                Include(p => p.Appointment).ThenInclude(a => a.Doctor).
                Include(p => p.Appointment).ThenInclude(d => d.Patient).
                ToListAsync();
        }
        public async Task<Prescription> GetPrescription(int id)
        {
            return await _databaseContext.Prescriptions.
                Include(p => p.Medicines).ThenInclude(m => m.Medicine).
                Include(p => p.Appointment).ThenInclude(a => a.Doctor).
                Include(p => p.Appointment).ThenInclude(d => d.Patient).
                FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Prescription> CreatePrescription(Prescription prescription)
        {
            await _databaseContext.Prescriptions.AddAsync(prescription);
            await _databaseContext.SaveChangesAsync();
            int id = await _databaseContext.Prescriptions.MaxAsync(p => p.Id);

            return await GetPrescription(id);
        }
        public async Task<Prescription> UpdatePrescription(Prescription prescription)
        {
            _databaseContext.Prescriptions.Attach(prescription);
            await _databaseContext.SaveChangesAsync();

            return await GetPrescription(prescription.Id);
        }

        public async Task<Medicine> GetMedicine(int id)
        {
            return await _databaseContext.Medicines.
                Include(m => m.Prescriptions).ThenInclude(pm => pm.Prescription).
                ThenInclude(pr => pr.Appointment).ThenInclude(a => a.Patient).
                ThenInclude(p => p.Appointments).ThenInclude(p => p.Doctor).
                FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Prescription> GetConnection(PrescriptionMedicine prescriptionMedicine)
        {
            await _databaseContext.PrescriptionsMedicines.AddAsync(prescriptionMedicine);
            await _databaseContext.SaveChangesAsync();
            return await GetPrescription(prescriptionMedicine.PrescriptionId);
        }

        public async Task<PrescriptionMedicine> GetMedicinePrescription(int prescriptionId, int medicineId)
        {
            return await _databaseContext.PrescriptionsMedicines.
                Include(pm => pm.Medicine).Include(pm => pm.Prescription).
                ThenInclude(pr => pr.Appointment).ThenInclude(a => a.Patient).
                ThenInclude(p => p.Appointments).ThenInclude(p => p.Doctor).
                FirstOrDefaultAsync(mp => mp.PrescriptionId == prescriptionId && mp.MedicineId == medicineId);
        }
    }
}
