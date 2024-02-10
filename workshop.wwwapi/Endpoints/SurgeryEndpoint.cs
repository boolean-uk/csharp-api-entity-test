using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.Models.AppointmentModels;
using workshop.wwwapi.Models.AppointmentModels.DTO;
using workshop.wwwapi.Models.DoctorModels;
using workshop.wwwapi.Models.DoctorModels.DTO;
using workshop.wwwapi.Models.PatientModels;
using workshop.wwwapi.Models.PatientModels.DTO;
using workshop.wwwapi.Repository.ExtensionRepository;
using workshop.wwwapi.Repository.GenericRepository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentsByDoctor);
        }

        private static async Task<IResult> GetAppointments(IRepository<Appointment> repo)
        {
            var appointments = await repo.Get();
            var appointmentDtos = appointments.Select(AppointmentAppointmentDto.Create);
            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository<Patient> repository)
        {
            var patients = await repository.Get();
            var patientDtos = patients.Select(PatientPatientDto.Create);
            return TypedResults.Ok(patientDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository<Doctor> doctorRepo, IRepository<Patient> patientRepo)
        {
            var doctors = await doctorRepo.Get();
            var patients = await patientRepo.Get();

            var doctorDtos = new List<DoctorDoctorDto>();
            foreach (var doctor in doctors)
            {
                doctorDtos.Add(DoctorDoctorDto.Create(doctor));
            }
            return TypedResults.Ok(doctorDtos);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository<Doctor> repository, int id)
        {
            var doctor = await repository.GetById(id);
            var doctorDto = DoctorDoctorDto.Create(doctor);
            return TypedResults.Ok(doctorDto);
        } 
    }
}
