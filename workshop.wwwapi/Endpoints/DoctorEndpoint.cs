using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferInputModels;
using workshop.wwwapi.Models.TransferModels.People;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctors = app.MapGroup("/doctors");

            // Doctors
            doctors.MapGet("/", GetDoctors);
            doctors.MapGet("/{id}", GetSpecificDoctor);
            doctors.MapPost("/", CreateDoctor);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();

            IEnumerable<DoctorDTO> patientsOut = doctors.Select(d => new DoctorDTO(d.Id, d.FullName, d.Appointments)).ToList();
            Payload<IEnumerable<DoctorDTO>> payload = new Payload<IEnumerable<DoctorDTO>>(patientsOut);

            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetSpecificDoctor(IRepository repository, int id)
        {
            Doctor? doc = await repository.GetSpecificDoctor(id);
            if (doc == null)
            {
                return TypedResults.NotFound("No doctor with the provided id could be found.");
            }

            DoctorDTO docOut = new DoctorDTO(doc.Id, doc.FullName, doc.Appointments);
            Payload<DoctorDTO> payload = new Payload<DoctorDTO>(docOut);
            return TypedResults.Ok(payload);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorInputDTO doctorPost)
        {
            Doctor doctorInput = new Doctor() { FullName = doctorPost.fullName };

            Doctor postResult = await repository.PostDoctor(doctorInput);

            DoctorDTO doctorOut = new DoctorDTO(postResult.Id, postResult.FullName, postResult.Appointments);
            Payload<DoctorDTO> payload = new Payload<DoctorDTO>(doctorOut);
            return TypedResults.Created($"/{doctorOut.ID}", payload);
        }

    }
}
