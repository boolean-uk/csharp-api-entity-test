using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        public Task<IEnumerable<PatientDTO>> GetPatients();

        public Task<IEnumerable<DoctorDTO>> GetDoctors();

        public Task<IEnumerable<AppointmentDTO>> GetAppointments();

        public Task<IEnumerable<AppointmentDTO>> GetApointment(int patientid, int doctorid);

        public Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id);


        public Task<PatientDTO> GetPatient(int id);

        public Task<DoctorDTO> GetDoctor(int id);

        public Task<IEnumerable<DoctorDTO>> CreateDoctor( string fullname);

        public Task<IEnumerable<AppointmentDTO>> CreateAppointment(int doctorid, int patientid, DateTime datetime);

    }
}
