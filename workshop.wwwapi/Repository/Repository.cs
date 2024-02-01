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
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            var patients = await _databaseContext.Patients.ToListAsync();
            
            _databaseContext.SaveChanges();
            return patients;
        }

        public async Task<Patient> GetPatient(int id)
        {
            var patient = await _databaseContext.Patients.FindAsync(id);
            
            _databaseContext.SaveChanges();
            return patient;
        }

        public async Task<Patient> CreateAPatient(PatientPostPayload patientPayload)
        {
            Patient patient =  new Patient() {FullName = patientPayload.fullName };
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
