using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using wwwapi.DTO;

namespace workshop.wwwapi.Endpoints
{

    public record patientPayload(string full_name);
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientsById);
            surgeryGroup.MapPost("/patients", CreatePatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        
        public static async Task<IResult> GetPatients(IRepository repository)
        { 
            var patientsRespo = await repository.GetPatients();
            List<Patient> patients = patientsRespo.ToList();

            List<PatientReturnDTO> patientReturnDTO = PatientReturnDTO.ListOfPatients(patients);
            return TypedResults.Ok(patientReturnDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        public static async Task<IResult> GetPatientsById(IRepository repository, int id)
        {

            Patient? patient = await repository.GetPatientById(id);

            if (patient == null) { return TypedResults.NotFound(); }


            return TypedResults.Ok(new PatientReturnDTO(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(patientPayload payload, IRepository repository)
        {
            if(payload.full_name == null) { return TypedResults.BadRequest(); }

            Patient? patient = await repository.CreateNewPatient(payload.full_name);

            if (patient == null) { return TypedResults.NotFound(); }

            return TypedResults.Ok(patient);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            IEnumerable<Doctor> doctors = await repository.GetDoctors();
            List< DoctorReturnDTO> DoctorDTOs =  DoctorReturnDTO.ListOfDoctors(doctors.ToList());
            if(DoctorDTOs.Count == 0) { return TypedResults.NotFound(); }

            return TypedResults.Ok(DoctorDTOs);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var res = await repository.GetAppointmentsByDoctor(id);
            return TypedResults.Ok(AppointmentReturnDTO.ListOfAppointments(res.ToList()));
        }
    }
}
