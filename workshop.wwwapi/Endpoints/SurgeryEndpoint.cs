using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            //surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var returnList = new List<PatientWithAppointmentAndDoctorDTO>();
            foreach (var patient in patients)
            {
                returnList.Add(PatientWithAppointmentAndDoctorDTO.ToDTO(patient));
            }
            return TypedResults.Ok(returnList);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);
            if (patient == null)
            {
                return TypedResults.NotFound($"Id: {id} not found!");
            }
            return TypedResults.Ok(PatientWithAppointmentAndDoctorDTO.ToDTO(patient));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var returnList = new List<DoctrorWithappointmentAndPatientDTO>();
            foreach (var doctor in doctors)
            {
                returnList.Add(DoctrorWithappointmentAndPatientDTO.ToDTO(doctor));
            }
            return TypedResults.Ok(returnList);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);
            if(doctor == null)
            {
                return TypedResults.NotFound($"Id: {id} not found!");
            }
            return TypedResults.Ok(DoctrorWithappointmentAndPatientDTO.ToDTO(doctor));
        }

        /*[ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }*/
    }
}
