using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOS;

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
            return await _databaseContext.Patients.ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId == id).ToListAsync();
        }

        public async Task<PatientDTO?> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (patient == null) { return null; }
            return new PatientDTO(patient);
        }

        public async Task<Patient?> AddPatient(string fullname)
        {
            if (string.IsNullOrWhiteSpace(fullname)) { return null; }

            var newPatient = _databaseContext.Patients.AddAsync(new Patient { FullName = fullname });

            if (newPatient.IsFaulted) { return null; }
            await _databaseContext.SaveChangesAsync();

            return newPatient.Result.Entity;
        }
    }
}
