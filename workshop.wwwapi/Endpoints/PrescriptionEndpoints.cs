using Microsoft.AspNetCore.Mvc;
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
        public static async Task<IResult> GetPrescriptions(IPrescriptionRepo prescriptionRepository)
        {
            try
            {
                var result = await prescriptionRepository.GetPrescriptions();

                List<PrescriptionDTO> prescriptionDTOs = new List<PrescriptionDTO>();

                foreach (var prescription in result)
                {

                    AppointmentDTO appointmentDTO = new AppointmentDTO()
                    {
                        Booking = prescription.Appointment.Booking,
                        Doctor = new DoctorDTO() { Name = prescription.Appointment.Doctor.FullName },
                        Patient = new PatientDTO { Name = prescription.Appointment.Patient.FullName }
                    };

                    PrescriptionDTO prescriptionDTO = new PrescriptionDTO()
                    {
                        Appointment = appointmentDTO,
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
        public static async Task<IResult> GetPrescriptionsById(IPrescriptionRepo prescriptionRepository, int id)
        {
            try
            {
                var result = await prescriptionRepository.GetPrescriptionById(id);

                AppointmentDTO appointmentDTO = new AppointmentDTO()
                {
                    Booking = result.Appointment.Booking,
                    Doctor = new DoctorDTO() { Name = result.Appointment.Doctor.FullName },
                    Patient = new PatientDTO { Name = result.Appointment.Patient.FullName }
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


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public static async Task<IResult> CreatePrescription(IPrescriptionRepo prescriptionRepository, PrescriptionCreateDTO newPrescription)
        {
            try
            {
                List<MedicinePrescription> meds = new List<MedicinePrescription>();

                MedicinePrescription medicinePrescription = new MedicinePrescription()
                {
                    MedicineId = newPrescription.medicinePrescription.medicineId,
                    Quantity = newPrescription.medicinePrescription.quantity,
                    Notes = newPrescription.medicinePrescription.notes
                };

                meds.Add(medicinePrescription);

                var np = new Prescription()
                {
                    DoctorId = newPrescription.doctorId,
                    PatientId = newPrescription.patientId,
                    MedicinePrescriptions = meds
                };

                var result = await prescriptionRepository.CreatePrescription(np);

                var targetPrescription = await prescriptionRepository.GetPrescriptionById(result.Id);


                AppointmentDTO appointmentDTO = new AppointmentDTO()
                {
                    Booking = targetPrescription.Appointment.Booking,
                    Doctor = new DoctorDTO() { Name = targetPrescription.Appointment.Doctor.FullName },
                    Patient = new PatientDTO { Name = targetPrescription.Appointment.Patient.FullName }
                };


                PrescriptionDTO prescriptionDTO = new PrescriptionDTO()
                {
                    Appointment = appointmentDTO,
                    MedecinePerscriptions = new List<PMedicinePrescriptionDTO>()
                };

                foreach (var mp in targetPrescription.MedicinePrescriptions)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return TypedResults.BadRequest(ex.Message);
            }
        }
    }
}
