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
            return await _databaseContext.Patients.ToListAsync();
        }

        public async Task<Patient?> GetPatient(int patientId)
        {
            return await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == patientId);
        }

        public async Task<Patient?> CreatePatient(Patient newPatient)
        {
            _databaseContext.Patients.AddAsync(newPatient);
            await _databaseContext.SaveChangesAsync();
            return newPatient; // Assuming your Patient class has an Id property
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }


    }
}
