using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints;

public static class DoctorsEndpoint
{
    public static void ConfigureDoctorsEndpoint(this IEndpointRouteBuilder routes)
    {
        var group = routes
            .MapGroup("/api/doctors")
            .WithTags("Doctors")
            .WithSummary("Doctors API")
            .WithDescription("This API allows you to manage Doctors at the hospital.")
            .WithOpenApi();
        
        group.MapGet("/", GetDoctors)
            .WithName("GetDoctors")
            .WithSummary("Get all doctors.")
            .WithDescription("Retrieves all doctors from hospital data base.");

        group.MapGet("/{id:int}", GetDoctor)
            .WithName("GetDoctor")
            .WithSummary("Get a doctor.")
            .WithDescription("Retrieves a doctor by ID from hospital data base.");
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    private static async Task<IResult> GetDoctors (IRepository repository)
    { 
        return TypedResults.Ok(await repository.GetDoctors());
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    private static async Task<IResult> GetDoctor(IRepository repository, int id)
    {
        var entity = await repository.GetDoctor(id);
        return entity == null ? TypedResults.NotFound($"No patient with {id} found") : TypedResults.Ok(entity);
    }
}