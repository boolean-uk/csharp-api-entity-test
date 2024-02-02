using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.DatabaseModels;

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
            return await _databaseContext.Patients.Include(p=>p.Appointments).ThenInclude(a=>a.Doctor).ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(p => p.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(p => p.Patient).Include(a => a.Doctor).Where(a => a.DoctorId==id).ToListAsync();
        }

        public async Task<Patient> GetAPatient(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstAsync(p=>p.Id == id);
        }

        public async Task<Patient> CreatePatient(string name)
        {
            Patient newPatient = new Patient()
            {
                FullName = name,
                Id = (_databaseContext.Patients.Count() == 0 ? 0 : _databaseContext.Patients.Max(patient => patient.Id) + 1)
            };
            _databaseContext.Patients.Add(newPatient);
            _databaseContext.SaveChangesAsync();
            return await GetAPatient(newPatient.Id);
        }

        public async Task<Doctor> GetADoctor(int id)
        {
            return await _databaseContext.Doctors.Include(p => p.Appointments).ThenInclude(a => a.Patient).FirstAsync(p=>p.Id == id);
        }

        public async Task<Doctor> CreateDoctor(string name)
        {
            Doctor newDoctor = new Doctor()
            {
                FullName = name,
                Id = (_databaseContext.Doctors.Count() == 0 ? 0 : _databaseContext.Doctors.Max(doctor => doctor.Id) + 1)
            };
            _databaseContext.Doctors.Add(newDoctor);
            _databaseContext.SaveChangesAsync();
            return await GetADoctor(newDoctor.Id);
        }

        public async Task<IEnumerable<Appointment>> GettAppointments()
        {
            return await _databaseContext.Appointments.Include(p => p.Patient).Include(a => a.Doctor).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Include(p => p.Patient).Include(a => a.Doctor).Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByIds(int DId, int PId)
        {
            return await _databaseContext.Appointments.Include(p => p.Patient).Include(a => a.Doctor).Where(a => a.DoctorId == DId && a.PatientId == PId).ToListAsync();
        }

        public async Task<Appointment> CreateAppointment(int Doc_id, int Pat_id)
        {
            Appointment newAppointment = new Appointment()
            {
                Booking = DateTimeOffset.UtcNow,
                DoctorId = Doc_id,
                PatientId = Pat_id
            };
            _databaseContext.Appointments.Add(newAppointment);
            _databaseContext.SaveChangesAsync();
            return newAppointment;
        }
    }
}
