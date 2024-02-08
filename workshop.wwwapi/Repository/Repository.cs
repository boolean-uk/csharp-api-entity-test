using Microsoft.EntityFrameworkCore;
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
            return await _databaseContext.Patients.Include(d => d.Appointments).ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(d => d.Appointments).FirstAsync(p => p.Id == id);
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ToListAsync();
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(d  => d.Appointments).FirstAsync(d => d.Id == id);
        }

        public async Task<Doctor> CreateDoctor(Doctor doctor)
        {
            await _databaseContext.Doctors.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            return doctor;
        }



        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorId(int doctorid)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId == doctorid).ToListAsync();
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientId(int patientid)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == patientid).ToListAsync();
        }

    }
}
