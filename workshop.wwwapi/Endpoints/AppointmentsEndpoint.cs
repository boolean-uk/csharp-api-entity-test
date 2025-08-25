using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints;

public static class AppointmentsEndpoint
{
    public static void ConfigureAppointmentsEndpoint(this IEndpointRouteBuilder routes)
    {
        var group = routes
            .MapGroup("/api/appointments")
            .WithTags("Appointments")
            .WithSummary("Appointments API")
            .WithDescription("This API allows you to manage appointments at the hospital.")
            .WithOpenApi();
        
        group.MapGet("/", GetAppointments)
            .WithName("GetAppointments")
            .WithSummary("Get all appointments.")
            .WithDescription("Retrieves all appointments from hospital data base.");
        
        group.MapGet("/{id:int}", GetAppointmentsByDoctor)
            .WithName("GetAppointmentsByDoctor")
            .WithSummary("Get all appointments by doctor ID.")
            .WithDescription("Retrieves all appointments from hospital data base concerning doctor with doctor ID.");

        group.MapPut("/", CreateAppointment)
            .WithName("CreateAppointment")
            .WithSummary("Create a new appointment.")
            .WithDescription("Creates a new appointment in the hospital data base.")
            .Accepts<NewAppointmentDto>("application/json");
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    private static async Task<IResult> GetAppointments (IRepository repository)
    { 
        return TypedResults.Ok(await repository.GetAppointments());
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    private static async Task<IResult> GetAppointmentsByDoctor (IRepository repository, int id)
    { 
        return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    private static async Task<IResult> CreateAppointment(IRepository repository, NewAppointmentDto dto)
    {
        var appointment = await repository.CreateAppointment(dto);
        return appointment != null ? TypedResults.Ok(appointment) : TypedResults.NotFound();
    }
}