using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints;

public static class PatientsEndpoint
{
    public static void ConfigurePatientsEndpoint(this IEndpointRouteBuilder routes)
    {
        var group = routes
            .MapGroup("/api/patients")
            .WithTags("Patient")
            .WithSummary("Patients API")
            .WithDescription("This API allows you to manage Patients at the hospital.")
            .WithOpenApi();
        
        group.MapGet("/", GetPatients)
            .WithName("GetPatients")
            .WithSummary("Get all patients.")
            .WithDescription("Retrieves all patients from hospital data base.");

        group.MapGet("/{id:int}", GetPatient)
            .WithName("GetPatient")
            .WithSummary("Get a patient.")
            .WithDescription("Retrieves a patient by ID from hospital data base.");
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    private static async Task<IResult> GetPatients (IRepository repository)
    { 
        return TypedResults.Ok(await repository.GetPatients());
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    private static async Task<IResult> GetPatient(IRepository repository, int id)
    {
        var entity = await repository.GetPatient(id);
        return entity == null ? TypedResults.NotFound($"No patient with {id} found") : TypedResults.Ok(entity);
    }
}