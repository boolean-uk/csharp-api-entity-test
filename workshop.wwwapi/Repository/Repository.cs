using Microsoft.EntityFrameworkCore;
using System.Text;
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

        //Patients
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).Include(p => p.Prescriptions).ToListAsync();
        }
        public async Task<Patient> GetPatient(int id)
        {
            return await _databaseContext.Patients.FirstAsync(x => x.Id == id);
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            _databaseContext.Patients.Add(patient);
            _databaseContext.SaveChanges();
            return patient;
        }

        //Doctors
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).Include(p=> p.Prescriptions).ToListAsync();
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
           return await _databaseContext.Doctors.FirstAsync(x => x.Id == id);
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            _databaseContext.Doctors.Add(doctor);
            _databaseContext.SaveChanges();
            return doctor;
        }

        //Appointments
        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<Appointment> GetAppointmentsById(int docotrId, int patientId)
        {
            return await _databaseContext.Appointments.FindAsync(docotrId, patientId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByDoctorId(int id)
        {
            return await _databaseContext.Appointments.Where(d => d.DoctorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int id)
        {
            return await _databaseContext.Appointments.Where(p => p.PatientId == id).ToListAsync();
        }

        //Prescription
        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _databaseContext.Prescriptions.Include(m => m.Doctor).Include(p => p.Patient).ToListAsync();
        }

        public async Task<IEnumerable<PrescriptionMedicine>> GetPrescriptionMedicines()
        {
            return await _databaseContext.PrescriptionMedicines
                .Include(m => m.Medicine)
                .Include(p => p.Prescription)
                .Include(d => d.Prescription.Doctor)
                .Include(p => p.Prescription.Patient)
                .ToListAsync();
        }

        public async Task<PrescriptionMedicine> CreatePrescriptionMedicine(PrescriptionMedicine preMed)
        {
            _databaseContext.PrescriptionMedicines.Add(preMed);
            _databaseContext.SaveChangesAsync();
            return preMed;
        }
    }
}
