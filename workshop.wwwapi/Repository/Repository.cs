using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.PureModels;

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

        public async Task<Patient?> GetPatientById(int id) 
        {
            return await _databaseContext.Patients.FindAsync(id);
        }

        public async Task<Patient> PostPatient(Patient patient) 
        {
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
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
