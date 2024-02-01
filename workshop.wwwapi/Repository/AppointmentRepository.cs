using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using workshop.wwwapi.Data;

namespace workshop.wwwapi.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        DatabaseContext _db;
        public AppointmentRepository(DatabaseContext db)
        {
            _db = db;
        }

        //public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        //{
        //    return await _databaseContext.Appointments.Where(a => a.DoctorId == id).ToListAsync();
        //}
    }
}
