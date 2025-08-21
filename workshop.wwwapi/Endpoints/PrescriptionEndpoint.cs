using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Factories;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var prescriptionGroup = app.MapGroup("prescription");
            string contentType = "application/json";

            prescriptionGroup.MapGet("/", GetPrescriptions);
            prescriptionGroup.MapGet("/{id}", GetPrescription);
            prescriptionGroup.MapPost("/create", CreatePrescription).Accepts<PrescriptionPostDto>(contentType);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var prescriptions = await repository.GetPrescriptions();
            
            List<PrescriptionDto> dtos = new List<PrescriptionDto>();
            foreach (var prescription in prescriptions)
            {
                dtos.Add(PrescriptionFactory.DtoFromPrescription(prescription));
            }

            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPrescription(IRepository repository, int id)
        {
            var prescription = await repository.GetPrescriptionbyId(id);
            if (prescription is null)
            {
                return TypedResults.NotFound();
            }

            var dto = PrescriptionFactory.DtoFromPrescription(prescription);
            return TypedResults.Ok(dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePrescription(IRepository repository, HttpRequest request)
        {
            PrescriptionPostDto inDto = await ValidateFromRequest<PrescriptionPostDto>(request);
            if (inDto is null) 
            { 
                return TypedResults.BadRequest(); 
            }

            var prescription = PrescriptionFactory.PrescriptionFromDto(inDto);
                
            var created = await repository.CreatePrescription(prescription);
            if (created is null)
            {
                return TypedResults.BadRequest();
            }

            foreach (var prescribedDto in inDto.Medicines)
            {
                var prescribed = PrescribedMedicineFactory.PrescribedMedicineFromDto(prescribedDto);
                prescribed.PrescriptionId = created.Id;
                await repository.CreatePrescribedMedicide(prescribed);
            }

            var outDto = PrescriptionFactory.DtoFromPrescription(created);
            return TypedResults.Ok();
        }

        private async static Task<T> ValidateFromRequest<T>(HttpRequest request)
        {
            T? entity;
            try
            {
                entity = await request.ReadFromJsonAsync<T>();
            }
            catch (JsonException ex)
            {
                return default;
            }

            return entity;
        }
    }
}
