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
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            var patients =  await _databaseContext.Patients.ToListAsync();
            return patients.MapListToDTO();
        }
        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = await _databaseContext.Doctors.ToListAsync();
            return doctors.MapListToDTO();
        }
        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id)
        {
            var appointments = await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
            return appointments.MapListToDTO();
        
        }

        public async Task<DoctorDTO> GetDoctor(int id)
        {
            var doctor = await _databaseContext.Doctors.FirstOrDefaultAsync(a => a.Id == id);
            return doctor.MapToDTO();
        }

        public async Task<AppointmentDTO> CreateAppointment(DateTime time, int doctorId, int patientId)
        {
            Appointment appointment = null;
            await _databaseContext.Appointments.AddAsync(appointment = new Appointment() {Booking = time, DoctorId = doctorId, PatientId = patientId });
            await _databaseContext.SaveChangesAsync();
            return appointment.MapToDTO();
        }
    }
}
