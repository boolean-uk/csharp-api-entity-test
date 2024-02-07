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
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.ToListAsync();
        }
        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.ToListAsync();
        }
        public async Task<Patient> GetPatient(int id)
        {
            return await _databaseContext.Patients.Where(patient => patient.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            return await _databaseContext.Doctors.Where(doctor => doctor.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();
        }

        public async Task<Appointment> GetAppointment(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Where(appointment => appointment.Id == id).FirstOrDefaultAsync();

        }
        public async Task<Doctor> GetDoctorWithAppointments(int id)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Patient> GetPatientWithAppointments(int id)
        {
            return await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<int> GenereateAppointmentId()
        {
            var ids = await _databaseContext.Appointments.Select(a => a.Id).ToListAsync();
            Random random = new Random();
            int id;
            do
            {
                id = random.Next();
            } while (ids.Contains(id));
            return id;
        }
        public async Task<Appointment> AddAppointment(PostAppointment appointment)
        {
            var id = await GenereateAppointmentId();
            var newAppointment = new Appointment
            {
                Id = id,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                Booking = appointment.Booking.ToUniversalTime()
            };
            await _databaseContext.Appointments.AddAsync(newAppointment);
            _databaseContext.SaveChanges();
            return await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).FirstOrDefaultAsync(a => a.Id == id);
        }
    }
}
