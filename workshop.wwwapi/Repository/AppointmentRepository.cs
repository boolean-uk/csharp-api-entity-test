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

        public Task<IEnumerable<Appointment>> GetAllAppointments()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(d => d.DoctorId == id).ToListAsync();
        }
    }
}
