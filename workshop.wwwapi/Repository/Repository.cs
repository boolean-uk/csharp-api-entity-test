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
                Where(a => a.DoctorId==id).ToListAsync();
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
            _databaseContext.SaveChanges();
            return await GetAppointment(appointment.PatientId, appointment.DoctorId);
        }
    }
}
