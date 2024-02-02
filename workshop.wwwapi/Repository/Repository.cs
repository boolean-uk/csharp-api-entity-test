using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Dto;
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
        public async Task<IEnumerable<PatientDto>> GetPatients()
        {
            var patients = await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();

          
            var patientDtos = patients.Select(p => new PatientDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Appointments = p.Appointments.Select(a => new AppointmentDto
                {
                    PatientId = a.PatientId,
                    DoctorId = a.DoctorId,
                    PatientFullName = a.Patient.FullName,  
                    DoctorFullName = a.Doctor.FullName,
                    AppointmentDate = a.Booking
                }).ToList()
            });
               return patientDtos;
        }

        public async Task<PatientDto> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);


            return new PatientDto
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentDto
                {
                    PatientId = a.PatientId,
                    DoctorId = a.DoctorId,
                    PatientFullName = a.Patient.FullName,
                    DoctorFullName = a.Doctor.FullName,
                    AppointmentDate = a.Booking
                }).ToList()
            };
        }

        public async Task<PatientDto> CreatePatient(CreatePatientDto createPatientDto)
        {
            var patient = new Patient
            {
                FullName = createPatientDto.FullName
               
            };

            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();

            return new PatientDto { Id = patient.Id, FullName = patient.FullName };
        }



        public async Task<IEnumerable<DoctorDto>> GetDoctors()

        {
            var doctors = await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();

            var doctorDtos = doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                Name = d.FullName,
                Appointments = d.Appointments.Select(a => new AppointmentDto
                {
                    PatientId = a.PatientId,
                    DoctorId = a.DoctorId,
                    PatientFullName = a.Patient.FullName,  
                    DoctorFullName = a.Doctor.FullName,
                    AppointmentDate = a.Booking
                }).ToList()
            });

            return doctorDtos;
        }
        public async Task<DoctorDto> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(p => p.Id == id);

            return doctor != null
         ? new DoctorDto
         {
             Id = doctor.Id,
             Name = doctor.FullName,
             Appointments = doctor.Appointments.Select(a => new AppointmentDto
             {
                 PatientId = a.PatientId,
                 DoctorId = a.DoctorId,
                 PatientFullName = a.Patient.FullName,
                 DoctorFullName = a.Doctor.FullName,
                 AppointmentDate = a.Booking
             }).ToList()
         }
         : null;
        }

        public async Task<DoctorDto> CreateDoctor(CreateDoctorDto createDoctorDto)
        {
            var doctor = new Doctor
            {
                FullName = createDoctorDto.Name

            };

            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();

            return new DoctorDto { Id = doctor.Id, Name = doctor.FullName };
        }
        public async Task<IEnumerable<AppointmentDto>> GetAppointments()
        {
            var appointments = await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).ToListAsync();

            var Appointmentsdtos = appointments.Select(a => new AppointmentDto
            {
              
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                PatientFullName = a.Patient.FullName,
                DoctorFullName = a.Doctor.FullName,
                AppointmentDate = a.Booking,
                Type = a.Type

            });

            return Appointmentsdtos;
        }
        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctor(int id)
        {
            var appointments = await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Where(a => a.DoctorId == id).ToListAsync();

           
            var appointmentDtos = appointments.Select(a => new AppointmentDto
            {
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                PatientFullName = a.Patient.FullName,
                DoctorFullName = a.Doctor.FullName,
                AppointmentDate = a.Booking,
                Type = a.Type

            });

            return appointmentDtos;
        }
        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByPatient(int id)
        {
            var appointments = await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Where(p => p.PatientId == id).ToListAsync();


            var appointmentDtos = appointments.Select(a => new AppointmentDto
            {
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                PatientFullName = a.Patient.FullName,
                DoctorFullName = a.Doctor.FullName,
                AppointmentDate = a.Booking,
                Type = a.Type

            });

            return appointmentDtos;
        }

        public async Task<AppointmentDto> GetAppointmentById(int DoctorId, int PatientId)
        {
            var appointment = await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).Where(a => a.PatientId == PatientId && a.DoctorId == DoctorId).FirstOrDefaultAsync();


            return appointment != null
                ? new AppointmentDto
                {
                    
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    PatientFullName = appointment.Patient.FullName,
                    DoctorFullName = appointment.Doctor.FullName,
                    AppointmentDate = appointment.Booking,
                    Type = appointment.Type
                }
                : null;
        }

        public async Task<AppointmentDto> CreateAppointment(CreateAppointmentDto createAppointmentDto)
            {
                var appointment = new Appointment
                {
                    PatientId = createAppointmentDto.PatientId,
                    DoctorId = createAppointmentDto.DoctorId,
                    Booking = createAppointmentDto.AppointmentDate,
                    Type = createAppointmentDto.Type

                };

                _databaseContext.Appointments.Add(appointment);
                await _databaseContext.SaveChangesAsync();
            await _databaseContext.Entry(appointment).Reference(a => a.Patient).LoadAsync();
            await _databaseContext.Entry(appointment).Reference(a => a.Doctor).LoadAsync();

            return new AppointmentDto
                {
                    PatientId = appointment.PatientId,
                    DoctorId = appointment.DoctorId,
                    PatientFullName = appointment.Patient.FullName,
                    DoctorFullName = appointment.Doctor.FullName,
                    AppointmentDate = appointment.Booking,
                    Type = appointment.Type
            };
        }


    }
}
