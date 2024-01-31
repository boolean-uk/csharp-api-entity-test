using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Endpoints;
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
        public async Task<Patient?> GetPatient(int id)
        {
            return await _databaseContext.Patients.FindAsync(id);
        }
        public async Task<Patient?> CreatePatient(string name)
        {
            //Create patient to return
            Patient patient = new Patient();
            //Populate the book with payload data
            patient.FullName = name;
            //add book to database and save it + return
            _databaseContext.Patients.Add(patient);
            _databaseContext.SaveChanges();
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
