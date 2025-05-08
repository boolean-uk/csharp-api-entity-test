namespace workshop.wwwapi.Models
{
    public static class AppointmentMapper
    {
        public static AppointmentDTO MapToDTO(this Appointment appointment)
        {
            return new AppointmentDTO
            {
                Booking = appointment.Booking,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                doctor = appointment.doctor.MapToDTO(),
                patient = appointment.patient.MapToDTO()
            };
        }

        public static List<AppointmentDTO> MapListToDTO(this List<Appointment> appointment)
        {
            return appointment.Select(appointment => new AppointmentDTO
            {
                Booking = appointment.Booking,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                doctor = appointment.doctor.MapToDTO(),
                patient = appointment.patient.MapToDTO()
            }).ToList();
        }
    }
}
