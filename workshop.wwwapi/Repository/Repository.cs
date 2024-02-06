using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _db;
        public Repository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientById(int id)
        {
            return await _db.Patients.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors.ToListAsync();
        }

        public async Task<Patient> CreatePatient(PostPatient p)
        {
            Patient patient =  new Patient()
            {
                Id = _db.Patients.Max(x => x.Id) +1,
                FirstName = p.FirstName,
                LastName = p.LastName,
            };
            _db.Patients.Add(patient);
            _db.SaveChanges();
            return patient;
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _db.Doctors.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Doctor> CreateDoctor(PostDoctor d)
        {
            Doctor doctor = new Doctor()
            {
                Id = _db.Doctors.Max(x => x.Id) + 1,
                FirstName = d.FirstName,
                LastName = d.LastName,
            };
            _db.Doctors.Add(doctor);
            _db.SaveChanges();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _db.Appointments.Include(p => p.Patient).Include(d => d.Doctor).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int doctorId, int patientId)
        {
            return await _db.Appointments.Include(p => p.Patient)
                                         .Include(d => d.Doctor)
                                         .Where(x => x.DoctorId == doctorId && x.PatientId == patientId)
                                         .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _db.Appointments.Where(a => a.PatientId == id).Include(p => p.Patient).Include(d => d.Doctor).ToListAsync();

        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorId == id).Include(p => p.Patient).Include(d => d.Doctor).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(PostAppointment app)
        {
            if(await GetAppointmentById(app.PatientId, app.DoctorId) != null)
            {
                return null;
            }
            Doctor doctor = _db.Doctors.Where(d => d.Id == app.DoctorId).FirstOrDefault();
            Patient patient = _db.Patients.Where(d => d.Id == app.PatientId).FirstOrDefault();
            Appointment appToCreate = new Appointment()
            {
                PatientId = app.PatientId,
                DoctorId = app.DoctorId,
                Booking = app.Booking,
                Patient = patient,
                Doctor = doctor,
            };
            _db.Appointments.Add(appToCreate);
            _db.SaveChanges();
            return appToCreate;
        }
    }
}
