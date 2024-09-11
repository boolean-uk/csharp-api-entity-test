using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class PrescriptionEndpoints
    {
        public static void ConfigurePrescriptionEndpoints(this WebApplication app)
        {
            var prescriptions = app.MapGroup("/prescriptions");

            prescriptions.MapGet("", GetPrescriptions);
            prescriptions.MapGet("/{id}", GetPrescriptionsById);
            prescriptions.MapPost("", CreatePrescription);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IPrescriptionRepository prescriptionRepository)
        {
            try
            {
                var result = await prescriptionRepository.GetPrescriptions();

                List<PrescriptionDTO> prescriptionDTOs = new List<PrescriptionDTO>();

                foreach (var prescription in result)
                {

                    AppointmentDTO appointmentDTO = new AppointmentDTO() 
                    { appointmentDate = prescription.Appointment.ApointementDate, 
                        doctor = new DoctorDTO() { FullName = prescription.Appointment.Doctor.FullName }, 
                        patient = new PatientDTO { FullName = prescription.Appointment.Patient.FullName } 
                    };

                    PrescriptionDTO prescriptionDTO = new PrescriptionDTO()
                    { Appointment = appointmentDTO, 
                        MedecinePerscriptions = new List<PMedicinePrescriptionDTO>() 
                    };

                    foreach (var mp in prescription.MedicinePrescriptions) 
                    {
                        PMedicinePrescriptionDTO pmpDTO = new PMedicinePrescriptionDTO()
                        {
                            medicineName = mp.Medicine.Name,
                            notes = mp.Notes,
                            quantity = mp.Quantity
                        };

                        prescriptionDTO.MedecinePerscriptions.Add(pmpDTO);
                    }
                    prescriptionDTOs.Add(prescriptionDTO);
                }
                return TypedResults.Ok(prescriptionDTOs);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPrescriptionsById(IPrescriptionRepository prescriptionRepository, int id)
        {
            try
            {
                var result = await prescriptionRepository.GetPrescriptionById(id);

                AppointmentDTO appointmentDTO = new AppointmentDTO()
                {
                    appointmentDate = result.Appointment.ApointementDate,
                    doctor = new DoctorDTO() { FullName = result.Appointment.Doctor.FullName },
                    patient = new PatientDTO { FullName = result.Appointment.Patient.FullName }
                };

                PrescriptionDTO prescriptionDTO = new PrescriptionDTO()
                {
                    Appointment = appointmentDTO,
                    MedecinePerscriptions = new List<PMedicinePrescriptionDTO>()
                };

                foreach (var mp in result.MedicinePrescriptions)
                {
                    PMedicinePrescriptionDTO pmpDTO = new PMedicinePrescriptionDTO()
                    {
                        medicineName = mp.Medicine.Name,
                        notes = mp.Notes,
                        quantity = mp.Quantity
                    };

                    prescriptionDTO.MedecinePerscriptions.Add(pmpDTO);
                }

                return TypedResults.Ok(prescriptionDTO);

            }
            catch (Exception)
            {

                return TypedResults.NotFound("Prescription not found");
            }
        }

        /*
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status400BadRequest)]
            public static async Task<IResult> CreatePrescription(IPrescriptionRepository prescriptionRepository, PrescriptionCreateDTO newPrescription)
            {
            try
            {
                List<MedicinePrescription> meds = new List<MedicinePrescription>();

                MedicinePrescription medicinePrescription = new MedicinePrescription() {  };
                meds.Add(new)

                var np = new Prescription() { DoctorId = newPrescription.doctorId, PatientId = newPrescription.patientId, MedicinePrescriptions = new List<MedicinePrescription>() };

            }
            catch (Exception ex)
            {

                return TypedResults.BadRequest(ex.Message);
            } 
            }
        */
    }
}
