using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models.DTOs;

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
            return await _databaseContext.Patients.Select(x => new PatientDTO()
            {
                PatientId = x.Id,
                PatientName = x.FullName,
                Appointments = x.Appointments
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new PatientAppointmentDTO()
                      {
                          BookingTime = appointment.BookingTime,
                          DoctorId = appointment.DoctorId,
                          DoctorName = doctor.FullName
                      })
                .ToList()
            }).ToListAsync();
        }

        public async Task<PatientDTO?> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Where(x => x.Id == id).Select(x => new PatientDTO()
            {
                PatientId = x.Id,
                PatientName = x.FullName,
                Appointments = x.Appointments
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new PatientAppointmentDTO()
                      {
                          BookingTime = appointment.BookingTime,
                          DoctorId = appointment.DoctorId,
                          DoctorName = doctor.FullName
                      })
                .ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            return await _databaseContext.Doctors.Select(x => new DoctorDTO()
            {
                DoctorId = x.Id,
                DoctorName = x.FullName,
                Appointments = x.Appointments
                .Join(_databaseContext.Patients,
                      appointment => appointment.PatientId,
                      patient => patient.Id,
                      (appointment, patient) => new DoctorAppointmentDTO()
                      {
                          BookingTime = appointment.BookingTime,
                          PatientId = appointment.PatientId,
                          PatientName = patient.FullName
                      })
                .ToList()
            }).ToListAsync();
        }

        public async Task<DoctorDTO?> GetDoctorById(int id)
        {
            return await _databaseContext.Doctors.Where(x => x.Id == id).Select(x => new DoctorDTO()
            {
                DoctorId = x.Id,
                DoctorName = x.FullName,
                Appointments = x.Appointments
                .Join(_databaseContext.Patients,
                      appointment => appointment.PatientId,
                      patient => patient.Id,
                      (appointment, patient) => new DoctorAppointmentDTO()
                      {
                          BookingTime = appointment.BookingTime,
                          PatientId = appointment.PatientId,
                          PatientName = patient.FullName
                      })
                .ToList()
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new { Appointment = appointment, DoctorName = doctor.FullName })
                .Join(_databaseContext.Patients,
                      combined => combined.Appointment.PatientId,
                      patient => patient.Id,
                      (combined, patient) => new AppointmentDTO()
                      {
                          DoctorId = combined.Appointment.DoctorId,
                          DoctorName = combined.DoctorName,
                          PatientId = combined.Appointment.PatientId,
                          PatientName = patient.FullName
                      })
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatientId(int id)
        {
            return await _databaseContext.Appointments
                .Where(x => x.PatientId == id)
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new { Appointment = appointment, DoctorName = doctor.FullName })
                .Join(_databaseContext.Patients,
                      combined => combined.Appointment.PatientId,
                      patient => patient.Id,
                      (combined, patient) => new AppointmentDTO()
                      {
                          DoctorId = combined.Appointment.DoctorId,
                          DoctorName = combined.DoctorName,
                          PatientId = combined.Appointment.PatientId,
                          PatientName = patient.FullName
                      })
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctorId(int id)
        {
            return await _databaseContext.Appointments
                .Where(x => x.PatientId == id)
                .Join(_databaseContext.Doctors,
                      appointment => appointment.DoctorId,
                      doctor => doctor.Id,
                      (appointment, doctor) => new { Appointment = appointment, DoctorName = doctor.FullName })
                .Join(_databaseContext.Patients,
                      combined => combined.Appointment.PatientId,
                      patient => patient.Id,
                      (combined, patient) => new AppointmentDTO()
                      {
                          DoctorId = combined.Appointment.DoctorId,
                          DoctorName = combined.DoctorName,
                          PatientId = combined.Appointment.PatientId,
                          PatientName = patient.FullName
                      })
                .ToListAsync();
        }
    }
}
