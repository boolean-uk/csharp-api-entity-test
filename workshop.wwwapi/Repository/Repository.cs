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

        public AppointmentDTO CreateAppointment(int month, int day, int doctorId, int patientId)
        {
            Appointment appointment = null;
            _databaseContext.Appointments.Add(appointment = new Appointment() {Booking = new DateTime(2024, month, day, 0, 0, 0, DateTimeKind.Utc), DoctorId = doctorId, PatientId = patientId });
            _databaseContext.SaveChanges();
            return appointment.MapToDTO();
        }

        public List<AppointmentDTO> GetAppointmentsByPatient(int id)
        {
            var patient = _databaseContext.Patients.Include(a => a.Appointments).FirstOrDefault(x => x.Id == id);
            return patient.Appointments.MapListToDTO();
        }

        public  List<AppointmentDTO> GetAppointments()
        {
            var appointments = _databaseContext.Appointments.ToList();
            return appointments.MapListToDTO();
        }

        public AppointmentDTO GetAppointment(int patientId, int doctorId)
        {
            var appointment = _databaseContext.Appointments.FirstOrDefault(x => x.PatientId == patientId && x.DoctorId == doctorId);
            return appointment.MapToDTO();
        }
    }
}
