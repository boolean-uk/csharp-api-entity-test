namespace workshop.wwwapi.Models.DTOs;

public class AppointmentWithDoctorAndPrescriptionDTO
{
    public DateTime Booking { get; set; }
    public DoctorDTO Doctor { get; set; }
    public PrescriptionWithMedicinesDTO? Prescription { get; set; }

    public static AppointmentWithDoctorAndPrescriptionDTO ToDTO(Appointment appointment)
    {
        PrescriptionWithMedicinesDTO? prescription = null;
        if (appointment.Prescription != null)
        {
            prescription = PrescriptionWithMedicinesDTO.ToDTO(appointment.Prescription);
        }
        return new AppointmentWithDoctorAndPrescriptionDTO
        {
            Booking = appointment.Booking,
            Doctor = DoctorDTO.ToDTO(appointment.Doctor),
            Prescription = prescription,
        };
    }
}
