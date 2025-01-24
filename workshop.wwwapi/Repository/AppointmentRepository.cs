using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private DatabaseContext _databaseContext;
        public AppointmentRepository(DatabaseContext db)
        {
            _databaseContext = db;
        }

        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _databaseContext.Appointments.AddAsync(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId == id).ToListAsync();
        }

        public async Task<Appointment> GetAppointmentById(int doctorId, int patientId)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByPatient(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == id).ToListAsync();
        }
    }
}
