using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Data.Post;
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
                .Include(patient => patient.Appointments)
                .ThenInclude(appointment => appointment.Doctor).ToListAsync();
        }

        public async Task<Patient?> GetPatient(int id)
        {
            return await _databaseContext.Patients
                .Include(patient => patient.Appointments)
                .ThenInclude(appointment => appointment.Doctor)
                .FirstOrDefaultAsync(patient => patient.Id == id);
        }

        public async Task<Patient> AddPatient(Patient patient)
        {
            await _databaseContext.Patients.AddAsync(patient);
            _databaseContext.SaveChanges();
            return patient;
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Include(doctor => doctor.Appointments)
                .ThenInclude(appointment => appointment.Patient).ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int id)
        {
            return await _databaseContext.Doctors
                .Include(doctor => doctor.Appointments)
                .ThenInclude(appointment => appointment.Patient)
                .FirstOrDefaultAsync(patient => patient.Id == id);
        }

        public async Task<Doctor> AddDoctor(Doctor doctor)
        {
            await _databaseContext.Doctors.AddAsync(doctor);
            _databaseContext.SaveChanges();
            return doctor;
        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Include(appointment => appointment.Patient)
                .Include(appointment => appointment.Doctor).ToListAsync();
        }

        public async Task<Appointment?> GetAppointment(int doctorId, int patientId)
        {
            return await _databaseContext.Appointments
                .Include(appointment => appointment.Doctor)
                .Include(appointment => appointment.Patient)
                .FirstOrDefaultAsync(a => a.DoctorId == doctorId && a.PatientId == patientId);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments
                .Include(appointment => appointment.Doctor)
                .Include(appointment => appointment.Patient)
                .Where(appointment => appointment.DoctorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments
                .Include(appointment => appointment.Doctor)
                .Include(appointment => appointment.Patient)
                .Where(appointment => appointment.PatientId == id).ToListAsync();
        }

        public async Task<Appointment?> AddAppointment(AppointmentPost appointment)
        {
            var doctor = await _databaseContext.Doctors
                .FirstOrDefaultAsync(doctor => doctor.Id == appointment.DoctorId);

            var patient = await _databaseContext.Patients
                .FirstOrDefaultAsync(patient => patient.Id == appointment.PatientId);

            if (doctor == null || patient == null)
            {
                return null;
            }

            Appointment newAppointment = new Appointment
            {
                DoctorId = doctor.Id,
                Doctor = doctor,
                PatientId = patient.Id,
                Patient = patient,
                Booking = appointment.BookingTime,
                AppointmentType = appointment.AppointmentType
            };

            await _databaseContext.Appointments.AddAsync(newAppointment);
            _databaseContext.SaveChanges();
            return newAppointment;
        }

    }
}
