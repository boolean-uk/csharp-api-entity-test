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
            return await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).ToListAsync();
        }

        public async Task<Patient?> GetPatient(int id)
        {
            var patient = await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).FirstOrDefaultAsync(b => b.Id == id);
            return patient;
        }

        public async Task<Patient> CreatePatient(string name)
        {
            List<Patient> patients = await _databaseContext.Patients.ToListAsync();
            int id = patients.Last().Id;
            id++;

            var newPatient = new Patient() { Id = id, FullName =  name};
            await _databaseContext.AddAsync(newPatient);
            await _databaseContext.SaveChangesAsync();
            return newPatient;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return null; // await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }
    }
}
