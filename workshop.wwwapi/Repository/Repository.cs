using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _db;
        public Repository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            var apps = await _db.Appointments.Include(a => a.Patient).Include(b => b.Doctor).Where(c => c.Id == id).ToListAsync();
            var app = apps.First();
            return app;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _db.Appointments.Include(a => a.Patient).Include(b => b.Doctor).ToListAsync();
        }

        public async Task<int> GetLastDoctorId()
        {
            var doctors = _db.Doctors.OrderByDescending(d => d.Id).ToList();
            return doctors.FirstOrDefault().Id;
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            _db.Doctors.Add(doctor);
            await _db.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var doctor = _db.Doctors.Include(b => b.Appointments).ThenInclude(c => c.Patient).Where(d => d.Id == id).FirstOrDefault();
            return doctor;
        }


        public async Task<int> GetLastAppointmentId()
        {
            var appointments = _db.Appointments.OrderByDescending(b => b.Id).ToList();
            return appointments.FirstOrDefault().Id;
        }

        public async Task<int> GetLastPatientId()
        {
            var patients = _db.Patients.OrderByDescending(b => b.Id).ToList();
            return patients.FirstOrDefault().Id;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients.Include(a => a.Appointments).ThenInclude(b => b.Doctor).ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors.Include(a => a.Appointments).ThenInclude(b => b.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            var b = await _db.Appointments.Include(a => a.Doctor).Include(b => b.Patient).Where(a => a.DoctorId == id).ToListAsync();
            return b;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            var b = await _db.Appointments.Include(a => a.Doctor).Include(b => b.Patient).Where(a => a.PatientId == id).ToListAsync();
            return b;
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _db.Patients.Include(a => a.Appointments).ThenInclude(b => b.Doctor).Where(p => p.Id ==id).FirstOrDefaultAsync();
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            
            _db.Patients.Add(patient);
            await _db.SaveChangesAsync();
            return patient;
        }

        public async Task<Appointment> AddAppointment(Appointment appointment)
        {
            _db.Appointments.Add(appointment);
            await _db.SaveChangesAsync();

            return await _db.Appointments.Include(a => a.Doctor).Include(b => b.Patient).FirstOrDefaultAsync(c => c.Id == appointment.Id);

        }
    }
}
