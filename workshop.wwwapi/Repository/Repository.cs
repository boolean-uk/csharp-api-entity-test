using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Dtoes.ViewModels;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DataContext _db;
        public Repository(DataContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
        }

        public async Task<Patient> GetSinglePatient(int id)
        {
            return await _db.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.PatientId == id);
        }

        public async Task<Patient> CreatePatient(Patient patient)
        {
            await _db.AddAsync(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors.Include(p => p.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }
        public async Task<Doctor> GetSingleDoctor(int id)
        {
            return await _db.Doctors.Include(p => p.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(d => d.DoctorId == id);
        }

        public async Task<Doctor> CreateDoctor(Doctor dct)
        {
            if(GetSingleDoctor(dct.DoctorId) != null)
            {
                return null;
            }
            await _db.Doctors.AddAsync(dct);
            await _db.SaveChangesAsync();
            return dct;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorId == id).Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _db.Appointments.Where(a => a.PatientId == id).Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<Appointment> GetSingleAppointment(int doctorId, int patientId)
        {
            return await _db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            Appointment test = await GetSingleAppointment(appointment.DoctorId, appointment.PatientId);
            if (test != null)
            {
                return null;
            }
            if(appointment.PrescriptionId == 0)
            {

            }
            await _db.AddAsync(appointment);
            await _db.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> UpdateAppointment(Appointment appointment)
        {
            _db.Appointments.Attach(appointment);
            _db.Entry(appointment).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return appointment;
        }
    }
}
