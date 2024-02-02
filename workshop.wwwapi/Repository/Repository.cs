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
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorId==id).ToListAsync();
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
    }
}
