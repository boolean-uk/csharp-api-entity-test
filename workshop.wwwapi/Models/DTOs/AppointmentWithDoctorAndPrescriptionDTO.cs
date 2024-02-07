using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Models.DTOs;

public class AppointmentWithDoctorAndPrescriptionDTO
{
    public DateTime Booking { get; set; }
    public DoctorDTO Doctor { get; set; }
    public AppointmentType AppointmentType { get; set; }
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
            AppointmentType = appointment.AppointmentType,
            Doctor = DoctorDTO.ToDTO(appointment.Doctor),
            Prescription = prescription,
        };
    }
}
