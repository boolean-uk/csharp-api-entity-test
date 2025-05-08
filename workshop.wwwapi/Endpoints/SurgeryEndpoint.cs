using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        
        public static void ConfigurePatientEndpoint_Notuse(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/{id}", GetAPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            //Soruce:
            var source = await repository.GetPatients();

            List<OutPatientDTO> patients = new List<OutPatientDTO>();
            patients = source.Select(p => new OutPatientDTO() { FullName = p.FullName, Id = p.Id }).ToList();
            return TypedResults.Ok(patients);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAPatient(IRepository repository, int? id)
        {
            try
            {
                //Soruce:
                var source = await repository.GetPatient(id);

                OutPatientDTO patients = new OutPatientDTO() { FullName = source.FullName, Id = source.Id };

                return TypedResults.Ok(patients);
            }

            catch (Exception ex) { return TypedResults.NotFound(ex.Message); }

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
    }
}
