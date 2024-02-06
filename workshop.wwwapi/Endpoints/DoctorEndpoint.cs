using workshop.wwwapi.Models.DataTransfer.Appointment;
using workshop.wwwapi.Models.DataTransfer.Doctor;
using workshop.wwwapi.Models.Domain;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var group = app.MapGroup("doctor");
            group.MapGet("/", GetAll);
            group.MapGet("/{id}", Get);
            group.MapPost("/", Create);
            group.MapGet("/{id}/appointments", GetAppointments);
        }

        private static async Task<IResult> GetAll(IRepository<Doctor> doctorRepository)
        {
            var doctors = await doctorRepository.GetAll();
            List<DoctorWithAppointmentsDTO> results = new List<DoctorWithAppointmentsDTO>();
            foreach (var doctor in doctors)
            {
                results.Add(new DoctorWithAppointmentsDTO(doctor));
            }
            return TypedResults.Ok(results);
        }

        private static async Task<IResult> Get(IRepository<Doctor> doctorRepository, int id)
        {
            var doctor = await doctorRepository.Get(id);
            return TypedResults.Ok(new DoctorWithAppointmentsDTO(doctor));
        }

        private static async Task<IResult> Create(IRepository<Doctor> doctorRepository, DoctorInsertDTO doctorInput)
        {
            string fullName = $"{doctorInput.Title} {doctorInput.Firstname} {doctorInput.Surname}";
            var result = await doctorRepository.Insert(new Doctor() { FullName = fullName });
            return TypedResults.Created(result.ID.ToString(), new DoctorDTO(result));
        }

        private static async Task<IResult> GetAppointments(IAppointmentRepository appointmentRepository, int id)
        {
            var appointments = await appointmentRepository.GetByDoctorID(id);
            List<AppointmentWithDoctorAndPatientDTO> results = new List<AppointmentWithDoctorAndPatientDTO>();
            foreach (var appointment in appointments)
            {
                results.Add(new AppointmentWithDoctorAndPatientDTO(appointment));
            }
            return TypedResults.Ok(results);
        }
    }
}
