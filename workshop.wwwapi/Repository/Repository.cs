using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
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

        public async Task<Patient> GetPatientById(int id)
        {
            Patient patient = await _databaseContext.Patients.FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new ArgumentException($"No patient with id: {id}");
            return patient;
        }

        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.ToListAsync();
        }

        public async Task<Patient> AddPatient(AddPatientDTO dto) 
        {
            Patient patient = new()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        //public async Task<IEnumerable<Doctor>> GetDoctors()
        //{
        //    return await _databaseContext.Doctors.ToListAsync();
        //}
        //public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        //{
        //    return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        //}
    }
}
