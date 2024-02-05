using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PatientEndpoint
    {


        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var patientGroup = app.MapGroup("patients");

            patientGroup.MapGet("/", GetAllPatients);
            patientGroup.MapGet("/{id}", GetAPatient);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllPatients(IRepository repository) {

                //Soruce:
                var source = await repository.GetPatients();

            List<OutPatientDTO> patients = new List<OutPatientDTO>();
            patients = source.Select(p => new OutPatientDTO() {
                FullName = p.FullName, 
                Id = p.Id,
                Appointments = p.Appointments.Select(a => new OutAppointmentDTO { 
                    Booking = a.Booking,
                    DoctorId = a.DoctorId,
                    PatientId = a.PatientId,
                    Appointmenttype = a.Appointmenttype,
                    Prescription = new OutPrescriptionDTO
                    {
                        PrescriptMed = a.Prescription.PrescriptMed.Select(p => new OutPrescriptionMedicineDTO
                        {
                            MedicineId = p.MedicineId,
                            Note = p.Note,
                            Quatity = p.Quatity
                        }).ToList()
                    }


                }).ToList()
            
            }).ToList();
            return TypedResults.Ok(patients);
           
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAPatient(IRepository repository, int ? id)
        {
            try {
            //Soruce:
            var source = await repository.GetPatient(id);

            OutPatientDTO patients = new OutPatientDTO() {
                FullName = source.FullName, 
                Id = source.Id,
                Appointments = source.Appointments.Select(a => new OutAppointmentDTO { DoctorId = a.DoctorId, 
                    Booking = a.Booking,
                    PatientId = a.PatientId,
                    Appointmenttype = a.Appointmenttype,
                    Prescription = new OutPrescriptionDTO
                    {
                        PrescriptMed = a.Prescription.PrescriptMed.Select(p => new OutPrescriptionMedicineDTO
                        {
                            MedicineId = p.MedicineId,
                            Note = p.Note,
                            Quatity = p.Quatity
                        }).ToList()
                    }

                }).ToList()
            };
            
            return TypedResults.Ok(patients);
            } 

            catch (Exception ex){ return TypedResults.NotFound(ex.Message); }

        }

    }
}
