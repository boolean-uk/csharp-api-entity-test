using Microsoft.AspNetCore.Mvc;
using System.Linq;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.JunctionTable;
using workshop.wwwapi.Models.PureModels;
using workshop.wwwapi.Models.TransferInputModels;
using workshop.wwwapi.Models.TransferModels.Appointments;
using workshop.wwwapi.Models.TransferModels.Items;
using workshop.wwwapi.Models.TransferModels.People;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        // Endpoints done in seperate files
        public static void ConfigureSurgeryEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");


        }


    }
}
