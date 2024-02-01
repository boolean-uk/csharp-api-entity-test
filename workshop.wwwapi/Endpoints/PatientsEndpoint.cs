using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientsEndpoint
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IGeneralRepository<Patient> repository)
        {
            var patients = await repository.GetAll();
            List<GetPatientDTO> dtos = patients
                .Select(p => new GetPatientDTO()
                {
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                })
                .ToList();
            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatient(IGeneralRepository<Patient> repository, int id)
        {
            try
            {
                Patient patient = await repository.GetById(id);
                GetPatientDTO dto = new()
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                };
                return TypedResults.Ok(dto);
            }
            catch (ArgumentException ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        public static async Task<IResult> AddPatient(IGeneralRepository<Patient> repository, AddPatientDTO dto)
        {
            try
            {
                Patient patient = new()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                };
                await repository.Add(patient);
                GetPatientDTO getDTO = new()
                {
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                };
                return TypedResults.Created(nameof(AddPatient), getDTO);
            }
            catch (Exception ex)
            {
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
