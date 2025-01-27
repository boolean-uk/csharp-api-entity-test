using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Exceptions;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class MedicineEndpoints
    {
        public static string Path { get; private set; } = "medicines";

        public static void ConfigureMedicinesEndpoints(this WebApplication app)
        {
            var group = app.MapGroup(Path);

            group.MapPost("/", CreateMedicine);
            group.MapGet("/", GetMedicines);
            group.MapGet("/{id}", GetMedicine);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> CreateMedicine(IRepository<Medicine, int> repository, IMapper mapper, MedicinePost entity)
        {
            try
            {
                Medicine medicine = await repository.Add(new Medicine
                {
                    Name = entity.Name,
                    Category = entity.Category,
                });
                return TypedResults.Created($"/{Path}/{medicine.Id}", mapper.Map<MedicineView>(medicine));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetMedicines(IRepository<Medicine, int> repository, IMapper mapper)
        {
            try
            {
                IEnumerable<Medicine> medicines = await repository.GetAll();
                return TypedResults.Ok(mapper.Map<List<MedicineView>>(medicines));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetMedicine(IRepository<Medicine, int> repository, IMapper mapper, int id)
        {
            try
            {
                Medicine medicine = await repository.Get(id);
                return TypedResults.Ok(mapper.Map<MedicineView>(medicine));
            }
            catch (IdNotFoundException ex)
            {
                return TypedResults.NotFound(new { ex.Message });
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
