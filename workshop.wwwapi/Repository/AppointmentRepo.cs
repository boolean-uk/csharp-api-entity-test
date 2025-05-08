using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private DatabaseContext _dbContext;
        
        public AppointmentRepo(DatabaseContext dbContext) { _dbContext = dbContext; }
        public async Task<Appointment> CreateAppointment(Appointment appointment)
        {
            await _dbContext.AddAsync(appointment);
            await _dbContext.SaveChangesAsync();
            return appointment;
        }


        public async Task<Appointment> GetAppointment(int doctorId, int patientId)
        {
            var appointment = await _dbContext.Appointments.Include(d => d.Doctor).Include(d => d.Patient).Where(x =>  x.DoctorId == doctorId && x.PatientId == patientId).FirstOrDefaultAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByDoctor(int doctorId)
        {
            var appointment = await _dbContext.Appointments.Include(d => d.Doctor).Include(d => d.Patient).Where(d => d.DoctorId == doctorId).ToListAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByPatient(int patientId)
        {
            var appointment = await _dbContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId == patientId).ToListAsync();
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _dbContext.Appointments.Include(d => d.Doctor).Include(d => d.Patient).ToListAsync();
        }
    }
}
