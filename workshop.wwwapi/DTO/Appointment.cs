using workshop.wwwapi.Enums;

namespace workshop.wwwapi.DTO
{
    public record AppointmentPost(int DoctorId, int PatientId, int DaysTilBooking, string AppointmentType);
    public record AppointmentView(string AppointmentType, DateTime Booking, DoctorInternal Doctor, PatientInternal Patient);
    public record AppointmentInternal(string AppointmentType, DateTime Booking);
    public record AppointmentPatient(string AppointmentType, DateTime Booking, PatientInternal Patient);
    public record AppointmentDoctor(string AppointmentType, DateTime Booking, DoctorInternal Doctor);
    public record AppointmentDoctorPatient(string AppointmentType, DateTime Booking, DoctorInternal Doctor, PatientInternal Patient);

}
