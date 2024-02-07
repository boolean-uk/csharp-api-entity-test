using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Models.DTOs;

public class AppointmentWithPatentAndPrescriptionDTO
{
    public DateTime Booking { get; set; }
    public PatientDTO Patient { get; set; }
    public PrescriptionWithMedicinesDTO? Prescription { get; set; }

    public static AppointmentWithPatentAndPrescriptionDTO ToDTO(Appointment appointment)
    {
        PrescriptionWithMedicinesDTO? prescription = null;
        if (appointment.Prescription != null)
        {
            prescription = PrescriptionWithMedicinesDTO.ToDTO(appointment.Prescription);
        }
        return new AppointmentWithPatentAndPrescriptionDTO
        {
            Booking = appointment.Booking,
            Patient = PatientDTO.ToDTO(appointment.Patient),
            Prescription = prescription,
        };
    }
}
