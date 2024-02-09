using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using wwwapi.DTO;

namespace workshop.wwwapi.Endpoints
{
    public record PrescriptionPayload(List<int> MedicineIds);
    public record AppointmentPrescriptionPayload(int prescriptionId);

    public static class PrescriptionEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md
        public static void ConfigurePrescriptionEndpoint(this WebApplication app)
        {
            var PrescriptionGroup = app.MapGroup("Prescriptions");

            PrescriptionGroup.MapGet("/", GetPrescriptions);
            PrescriptionGroup.MapPost("/", CreatePrescription);
            PrescriptionGroup.MapDelete("/{id:int}", DeletePrescriptionById);
            app.MapPost("/Appointment/{appointmentId:int}/Prescription", AddPrescriptionToAppointment);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IPrescriptionRepository repository)
        {
            IEnumerable<Prescription> res = await repository.GetPrescriptions();

            return TypedResults.Ok(PrescriptionDTO.FromList(res.ToList()));
        
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(404)]
        public static async Task<IResult> CreatePrescription(IPrescriptionRepository repository, PrescriptionPayload payload )
        {
            Prescription? prescription = await repository.CreatePrescription(payload.MedicineIds);
            if (prescription == null) { return TypedResults.NotFound(); }
            return TypedResults.Ok(new PrescriptionDTO(prescription));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> DeletePrescriptionById(int id, IPrescriptionRepository repository)
        {
            var res = await repository.DeletePrescriptionById(id);
            if(res == null) {return  TypedResults.NotFound(); }    
            return TypedResults.Ok(new PrescriptionDTO(res));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddPrescriptionToAppointment(IPrescriptionRepository PrescriptionRepository, IRepository Repository, int appointmentId, AppointmentPrescriptionPayload payload )
        {
            Appointment appointment = await Repository.GetAppointmentsById(appointmentId);
            if (appointment == null) { return TypedResults.NotFound(); }
            if (appointment.Prescription != null) { return TypedResults.BadRequest("Appointment already has a prescription."); }

            Prescription? prescription = await PrescriptionRepository.AddPrescriptionToAppointment(payload.prescriptionId, appointmentId);
            if (prescription == null) { return TypedResults.NotFound(); }
            return TypedResults.Ok(new PrescriptionDTO(prescription));
        }

    }
}