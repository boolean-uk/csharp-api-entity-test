using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.Conventions;
using System.Collections;
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
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor).ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients
                .Include(p => p.Appointments)
                .ThenInclude(a=> a.Doctor)
                .FirstAsync(p => p.Id.Equals(id));

        }
        public async Task<Patient> CreatePatient(PostPerson model)
        {
            int id = _databaseContext.Patients.Max(p => p.Id) + 1;
            _databaseContext.Patients.Add(new Patient() { Id = id, FullName = model.FullName });
            _databaseContext.SaveChanges();
            return await _databaseContext.Patients.Include(p => p.Appointments)
                .ThenInclude(a => a.Doctor)
                .FirstAsync(p => p.Id.Equals(id));
        }
        public async Task<Doctor> CreateDoctor(PostPerson model)
        {
            int id = _databaseContext.Doctors.Max(p => p.Id) + 1;
            _databaseContext.Doctors.Add(new Doctor() { Id = id, FullName = model.FullName });
            _databaseContext.SaveChanges();
            return await _databaseContext.Doctors.Include(d=>d.Appointments).ThenInclude(a=>a.Patient).FirstAsync(d => d.Id.Equals(id));
        }
        public async Task<Doctor> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstAsync(d => d.Id.Equals(id));
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>> GetAppointments(int id, string person)
        {
            switch (person)
            {
                case "doctor":
                    return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.DoctorId.Equals(id)).ToListAsync();
                case "patient":
                    return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Where(a => a.PatientId.Equals(id)).ToListAsync();
                default:
                    return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
            }
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
        }

        public async Task<Appointment>  GetAppointmentById(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstAsync(a=>a.Id==id);
        }

        public async Task<Appointment> AddAppointment(PostAppointment model)
        {
            int id = _databaseContext.Appointments.Max(x => x.Id) + 1;
            _databaseContext.Appointments.Add(new Appointment() {
                Id = id, 
                Booking = model.AppointmentTime.ToString(),
                DoctorId = model.DoctorId,
                PatientId = model.PatientId});
            _databaseContext.SaveChanges();

            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(a=>a.Patient).FirstAsync(a => a.Id == id);
        }
    }
}
