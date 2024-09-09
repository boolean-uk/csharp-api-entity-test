using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModel;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patients = app.MapGroup("patients");

            patients.MapGet("/GetAll", GetPatients);
            patients.MapGet("/GetById{id}", GetPatient);
            patients.MapPost("/Create", CreatePatient);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            try
            {
                return TypedResults.Ok(await repository.GetPatients());
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            try
            {
                return TypedResults.Ok(await repository.GetPatient(id));
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePatient(IRepository repository, InputDTO data)
        {
            try
            {
                //Check if the name is empty
                if(data.FullName == string.Empty)
                {
                    return TypedResults.BadRequest();
                }

                //Check if the name is the same as any other name that already exists
                var patients = await repository.GetPatients();
                if(patients != null)
                {
                    foreach (var pat in patients)
                    {
                        if(pat.Name == data.FullName)
                        {
                            return TypedResults.BadRequest();
                        }
                    }
                }

                //Create a new patient
                var patient = new Patient() { FullName = data.FullName };

                //Add the new patient
                var result = await repository.AddPatient(patient);

                //Reponse
                return TypedResults.Created($"http://localhost:5045/patients/{result.Id}", result);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }
    }
}
