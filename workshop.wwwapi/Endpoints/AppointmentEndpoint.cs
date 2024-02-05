using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {

        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var appointmentGroup = app.MapGroup("appointment");

            appointmentGroup.MapGet("/", GetAppointments);
            appointmentGroup.MapGet("/GetAppointmentById{id}", GetAnAppointmentById);
            appointmentGroup.MapGet("/GetAppointmentByPatient{id}", GetAnAppointmentByPantient);
            appointmentGroup.MapGet("/GetAppointmentByDoctor{id}", GetAnAppointmentByDoctor);

        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {

            //Soruce:
            var source = await repository.GetAppointments();
            //Target & Transferring:

            List<OutAppointmentDTO> _appointments = source.Select(a => new OutAppointmentDTO
            {
                Booking = a.Booking,
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                Appointmenttype = a.Appointmenttype,
                PrescriptionId = a.PrescriptionId,
                Prescription = new OutPrescriptionDTO {  PrescriptMed = a.Prescription.PrescriptMed.Select(p => new OutPrescriptionMedicineDTO {
                    MedicineId = p.MedicineId,
                    Note = p.Note,
                    Quatity = p.Quatity
                }).ToList()}

            
                
            }).ToList();

            return TypedResults.Ok(_appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAnAppointmentById(IRepository repository, int PantientId, int DoctorId)
        {
            try
            {   //Source
                var source = await repository.GetAnAppointment(PantientId, DoctorId);
                //Target and transferring:
                OutAppointmentDTO appointment = new OutAppointmentDTO
                {
                    Booking = source.Booking,
                    DoctorId = source.DoctorId,
                    PatientId = source.PatientId,
                    Appointmenttype=source.Appointmenttype,
                    PrescriptionId =  source.PrescriptionId,

                    Prescription = new OutPrescriptionDTO
                    {
                        PrescriptMed = source.Prescription.PrescriptMed.Select(p => new OutPrescriptionMedicineDTO
                        {
                            MedicineId = p.MedicineId,
                            Note = p.Note,
                            Quatity = p.Quatity
                        }).ToList()
                    }

                };
                return TypedResults.Ok(appointment);
            }

            catch (ArgumentException ex) { return TypedResults.NotFound(ex.Message); }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAnAppointmentByPantient(IRepository repository, int PantientId)
        {
            try
            {   //Source
                var source = await repository.GetAppointmentsByPatient(PantientId);
                //Target and transferring:

                List<OutAppointmentDTO> _appointments = source.Select(a => new OutAppointmentDTO
                {
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    PatientId = a.PatientId,
                    Appointmenttype = a.Appointmenttype,
                    PrescriptionId = a.PrescriptionId,
                    Prescription = new OutPrescriptionDTO
                    {
                        PrescriptMed = a.Prescription.PrescriptMed.Select(p => new OutPrescriptionMedicineDTO
                        {
                            MedicineId = p.MedicineId,
                            Note = p.Note,
                            Quatity = p.Quatity
                        }).ToList()
                    }
                }).ToList();

                return TypedResults.Ok(_appointments);
            }

            catch (ArgumentException ex) { return TypedResults.NotFound(ex.Message); }


        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAnAppointmentByDoctor(IRepository repository, int DoctorId)
        {
            try
            {    //Source
                var source = await repository.GetAppointmentsByDoctor(DoctorId);
                //Target and transferring:

                List<OutAppointmentDTO> _appointments = source.Select(a => new OutAppointmentDTO
                {
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    PatientId = a.PatientId,
                    Appointmenttype = a.Appointmenttype,
                    PrescriptionId = a.PrescriptionId,

                    Prescription = new OutPrescriptionDTO
                    {
                        PrescriptMed = a.Prescription.PrescriptMed.Select(p => new OutPrescriptionMedicineDTO
                        {
                            MedicineId = p.MedicineId,
                            Note = p.Note,
                            Quatity = p.Quatity
                        }).ToList()
                    }

                }).ToList();

                return TypedResults.Ok(_appointments);
            }

            catch (ArgumentException ex) { return TypedResults.NotFound(ex.Message); }
            
        }





    }
}
