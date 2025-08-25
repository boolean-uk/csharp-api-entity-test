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
        public async Task<Patient> GetOnePatient(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Patient> CreatePatient(Patient model)
        {
            await _databaseContext.Patients.AddAsync(model);
            await _databaseContext.SaveChangesAsync();
            return model;
        }


        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }
        public async Task<Doctor> GetOneDoctor(int id)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<Doctor> CreateDoctor(Doctor model)
        {
            await _databaseContext.Doctors.AddAsync(model);
            await _databaseContext.SaveChangesAsync();
            return model;
        }


        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.PatientId == id).Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }



        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
    }
}


