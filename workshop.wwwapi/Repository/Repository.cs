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
            var patients = await _databaseContext.Patients.ToListAsync();

          
            var patientDtos = patients.Select(p => new PatientDto
            {
                Id = p.Id,
                FullName = p.FullName,
              
            });
               return patientDtos;
        }

        public async Task<PatientDto> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.FindAsync(id);

            return new PatientDto { Id = patient.Id, FullName = patient.FullName };
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
            var doctors = await _databaseContext.Doctors.ToListAsync();

            var doctorDtos = doctors.Select(d => new DoctorDto
            {
                Id = d.Id,
                Name = d.FullName,
             
            });

            return doctorDtos;
        }
        public async Task<IEnumerable<AppointmentDto>> GetAppointmentsByDoctor(int id)
        {
            var appointments = await _databaseContext.Appointments
                .Where(a => a.DoctorId == id)
                .ToListAsync();

           
            var appointmentDtos = appointments.Select(a => new AppointmentDto
            {
                PatientId = a.PatientId,
                DoctorId = a.DoctorId,
                AppointmentDate = a.Booking,
            
            });

            return appointmentDtos;
        }
    }
}
