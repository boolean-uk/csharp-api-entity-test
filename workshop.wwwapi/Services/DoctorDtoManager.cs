using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public class DoctorDtoManager
    {
        public static OutputDoctor Convert(Doctor doctor)
        {
            return new OutputDoctor
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                Appointments = Convert(doctor.Appointments)
            };
        }

        public static IEnumerable<OutputDoctor> Convert(IEnumerable<Doctor> doctors)
        {
            return doctors.Select(doctor => Convert(doctor));
        }

        public static Doctor Convert(InputDoctor inputDoctor)
        {
            return new Doctor
            {
                FullName = inputDoctor.FullName
            };
        }

        public static AppointmentWhithoutDoctor Convert(Appointment appointment)
        {
            return new AppointmentWhithoutDoctor
            {
                Booking = appointment.Booking,
                Patient = new PatientWhithoutAppointment
                {
                    Id = appointment.Patient.Id,
                    FullName = appointment.Patient.FullName
                }
            };
        }

        public static IEnumerable<AppointmentWhithoutDoctor> Convert(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => Convert(appointment));
        }
    }
}
