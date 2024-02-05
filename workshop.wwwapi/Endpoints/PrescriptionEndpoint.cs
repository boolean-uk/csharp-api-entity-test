using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var prescriptionGroup = app.MapGroup("prescriptions");
            prescriptionGroup.MapGet("/", GetPrescriptions);
            prescriptionGroup.MapPost("/", CreatePrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            IEnumerable<PrescriptionDTO> result = await repository.GetPrescriptions();
            return TypedResults.Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePrescription(CreatePrescriptionDTO cDTO, IRepository repository)
        {
            int result = await repository.CreatePrescription(cDTO);
            if (result == -1) { return TypedResults.BadRequest($"Appointment with doctorid {cDTO.AppointmentDoctorId} and {cDTO.AppointmentPatientId} doesnt exist!"); }
            if (result == -2) { return TypedResults.BadRequest($"No valid medicine IDs provided."); }
            return TypedResults.Created("", result);
        }
    }
}
