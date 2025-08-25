using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
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

        public async Task<IEnumerable<PatientAppointmentDto>> GetPatients()
        {
            return await _databaseContext.Patients
                .Select(p => new PatientAppointmentDto
                {
                    FullName = p.FullName,
                    Appointments = p.Appointments.Select(a => new AppointmentDto
                    {
                        Doctor = new DoctorDto { FullName = a.Doctor.FullName },
                        Patient = new PatientDto { FullName = a.Patient.FullName },
                        AppointmentDate = a.AppointmentDate
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<PatientAppointmentDto?> GetPatient(int id)
        {
            return await _databaseContext.Patients
                .Where(p => p.Id == id)
                .Select(p => new PatientAppointmentDto
                {
                    FullName = p.FullName,
                    Appointments = p.Appointments.Select(a => new AppointmentDto
                    {
                        Doctor = new DoctorDto { FullName = a.Doctor.FullName },
                        Patient = new PatientDto { FullName = a.Patient.FullName },
                        AppointmentDate = a.AppointmentDate
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<DoctorAppointmentDto>> GetDoctors()
        {
            return await _databaseContext.Doctors
                .Select(p => new DoctorAppointmentDto
                {
                    FullName = p.FullName,
                    Appointments = p.Appointments.Select(a => new AppointmentDto
                    {
                        Doctor = new DoctorDto { FullName = a.Doctor.FullName },
                        Patient = new PatientDto { FullName = a.Patient.FullName },
                        AppointmentDate = a.AppointmentDate
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<DoctorAppointmentDto?> GetDoctor(int id)
        {
            return await _databaseContext.Doctors
                .Where(p => p.Id == id)
                .Select(p => new DoctorAppointmentDto
                {
                    FullName = p.FullName,
                    Appointments = p.Appointments.Select(a => new AppointmentDto
                    {
                        Doctor = new DoctorDto { FullName = a.Doctor.FullName },
                        Patient = new PatientDto { FullName = a.Patient.FullName },
                        AppointmentDate = a.AppointmentDate
                    }).ToList()
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointments()
        {
            return await _databaseContext.Appointments
                .Select(p => new AppointmentDto
                {
                    Doctor = new DoctorDto { FullName = p.Doctor.FullName },
                    Patient = new PatientDto { FullName = p.Patient.FullName },
                    AppointmentDate = p.AppointmentDate
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(d => d.DoctorId == id)
                .Select(p => new AppointmentDto
                {
                    Doctor = new DoctorDto { FullName = p.Doctor.FullName },
                    Patient = new PatientDto { FullName = p.Patient.FullName },
                    AppointmentDate = p.AppointmentDate
                })
                .ToListAsync();
        }

        public async Task<AppointmentDto?> CreateAppointment(NewAppointmentDto dto)
        {
            var doctor = await _databaseContext.Doctors.FindAsync(dto.DoctorId);
            if (doctor == null) return null;
            
            var patient = await _databaseContext.Patients.FindAsync(dto.PatientId);
            if (patient == null) return null;
            
            var appointment = new Appointment
            {
                DoctorId = doctor.Id,
                Doctor = doctor,
                PatientId = patient.Id,
                Patient = patient,
                AppointmentDate = dto.AppointmentDate
            };
            
            _databaseContext.Appointments.Add(appointment);
            await _databaseContext.SaveChangesAsync();

            return new AppointmentDto
            {
                Doctor = new DoctorDto { FullName = doctor.FullName },
                Patient = new PatientDto { FullName = patient.FullName },
                AppointmentDate = dto.AppointmentDate
            };
        }
    }
}