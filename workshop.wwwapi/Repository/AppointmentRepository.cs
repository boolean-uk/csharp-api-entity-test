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
        public async Task<Appointment> CreateAppointment(DateTime booking, int patientId, int doctorId)
        {
            Appointment appointment = new Appointment(booking, patientId, doctorId);
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();
            return appointment;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            // TODO added lambda patientID
            // await _databaseContext.Appointments.Include(a => a.PatientId).Where(a => a.DoctorId==id).ToListAsync();
            return await _databaseContext.Appointments
                .Where(a => a.DoctorId == id)
                //.Include(a => a.Doctor)
                //.Include(a => a.Patient)
                .ToListAsync();
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentById(int id)
        {
            // TODO added lambda patientID
            // await _databaseContext.Appointments.Include(a => a.PatientId).Where(a => a.DoctorId==id).ToListAsync();
            return await _databaseContext.Appointments
                .Where(a => a.Id == id)
                .Include(a => a.Doctor)
                .Include(a => a.Patient)
                .ToListAsync();
        }
    }
}
