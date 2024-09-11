using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetAPatient);
            surgeryGroup.MapPost("/patients/", CreateAPatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetADoctor);
            surgeryGroup.MapPost("/doctors/", CreateADoctor);

            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            
        }

        public static async Task<IResult> CreateADoctor(IRepository repository, DTODoctorNoId doctor)
        {
            var result = await repository.MakeDoctor(new Doctor() { FullName = doctor.Name });
            return TypedResults.Created("Created");
        }

        public static async Task<IResult> CreateAPatient(IRepository repository, DTOPatientNoId patient)
        {

            var result = await repository.MakePatient(new Patient() { FullName = patient.Name });

            return TypedResults.Created("Created");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            GetPatientResponce response = new GetPatientResponce();
            var patients = await repository.GetPatients();

            foreach (var patient in patients)
            {
                DTOPatientNoId p = new();
                p.Name = patient.FullName;
                response.PatientNoId.Add(p);
            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAPatient(IRepository repository, int id)
        {
            GetPatientResponce response = new GetPatientResponce();
            var result = await repository.GetAEnitityById(id);

            DTOPatientNoId patient = new DTOPatientNoId() { Name = result.FullName };
            response.PatientNoId.Add(patient);

            return TypedResults.Ok(response.PatientNoId[0].Name);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            GetDoctorResponce response = new GetDoctorResponce();
            var doctors = await repository.GetDoctors();

            foreach (var doctor in doctors)
            {
                DTODoctorNoId d = new();
                d.Name = doctor.FullName;
                response.DoctorNoId.Add(d);
            }

            return TypedResults.Ok(response);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetADoctor(IRepository repository, int id)
        {
            GetDoctorResponce response = new GetDoctorResponce();
            var result = await repository.GetDoctorById(id);

            DTODoctorNoId doctor = new DTODoctorNoId() { Name = result.FullName };
            response.DoctorNoId.Add(doctor);

            return TypedResults.Ok(response.DoctorNoId[0].Name);
        }
        
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
        
    }
}
