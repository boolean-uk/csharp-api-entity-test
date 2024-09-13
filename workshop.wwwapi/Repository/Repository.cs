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
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            await _databaseContext.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }



        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(p => p.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(p => p.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            await _databaseContext.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }



        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int doctorId, int patientId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int doctorId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId == doctorId).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int patientId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == patientId).ToListAsync();
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            await _databaseContext.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }


        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(p => p.Appointment).ThenInclude(a => a.Doctor).Include(p => p.Appointment).ThenInclude(a => a.Patient).Include(p => p.medicines).ThenInclude(m => m.medicine).ToListAsync();
        }

        public async Task<Prescription> GetPrescriptionById(int id)
        {
            return await _databaseContext.Prescriptions.Include(p => p.Appointment).ThenInclude(a => a.Doctor).Include(p => p.Appointment).ThenInclude(a => a.Patient).Include(p => p.medicines).ThenInclude(m => m.medicine).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Prescription> AddPrescription(Prescription prescription, MedicineOnPrescription medicineOnPrescription)
        {
            await _databaseContext.AddAsync(prescription);
            medicineOnPrescription.PrescriptionId = prescription.Id;
            prescription.medicines.Add(medicineOnPrescription);
            await _databaseContext.SaveChangesAsync();
            return prescription;

        }
    }
}
