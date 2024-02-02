using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public static class AppointmentDtoManager
    {
        private static OutputAppointment Convert(Appointment appointment)
        {
            return new OutputAppointment
            {
                Booking = appointment.Booking,
                Doctor = new DoctorWhithoutAppointment
                {
                    Id = appointment.Doctor.Id,
                    FullName = appointment.Doctor.FullName
                },
                Patient = new PatientWhithoutAppointment
                {
                    Id = appointment.Patient.Id,
                    FullName = appointment.Patient.FullName
                }
            };
        }

        public static IEnumerable<OutputAppointment> Convert(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => Convert(appointment));
        }
    }
}
