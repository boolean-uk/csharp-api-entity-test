using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
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
        public async Task<IEnumerable<Patient_DTO>> GetPatients()
        {
            List<Patient> patients = await _databaseContext.Patients.Include(a => a.appointments).ToListAsync();
            List<Patient_DTO> patients_DTO = new List<Patient_DTO>();
            foreach(Patient patient in patients)
            {
                patients_DTO.Add(new Patient_DTO(patient));
            }
            return patients_DTO;
        }

        public async Task<Patient_DTO> GetPatientById(int id)
        {
            Patient patient = await _databaseContext.Patients.Include(a => a.appointments).SingleOrDefaultAsync(a => a.Id == id);
            return new Patient_DTO(patient);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(a => a.appointments).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }
    }
}
