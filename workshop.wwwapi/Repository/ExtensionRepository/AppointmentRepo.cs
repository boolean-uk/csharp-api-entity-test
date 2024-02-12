using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Repository.GenericRepository;

namespace workshop.wwwapi.Repository.ExtensionRepository
{
    public class AppointmentRepo : Repository<Appointment>
    {
        private readonly DatabaseContext _db;

        public AppointmentRepo(DatabaseContext db) : base(db)
        {
            _db = db;
        }

        public override async Task<IEnumerable<Appointment>> Get()
        {
            return await _db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public override async Task<IEnumerable<Appointment>> GetById(object doctor_id, object patient_id)
        {
            var appointments = await _db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
            
            return appointments.Where(a=>a.DoctorId==(int)doctor_id && a.PatientId==(int)patient_id);
        }
        
    }
}
