using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTO;

namespace workshop.wwwapi.Services
{
    public class PatientDtoManager
    {
        public static OutputPatient Convert(Patient patient)
        {
            return new OutputPatient
            {
                Id = patient.Id,
                FullName = patient.FullName,
                Appointments = Convert(patient.Appointments)
            };
        }
        public static IEnumerable<OutputPatient> Convert(IEnumerable<Patient> patients)
        {
            return patients.Select(patient => Convert(patient));
        }

        public static Patient Convert(InputPatient inputPatient)
        {
            return new Patient
            {
                FullName = inputPatient.FullName
            };
        }

        public static AppointmentWhithoutPatient Convert(Appointment appointment)
        {
            return new AppointmentWhithoutPatient
            {
                Booking = appointment.Booking,
                Doctor = new DoctorWhithoutAppointment
                {
                    Id = appointment.Doctor.Id,
                    FullName = appointment.Doctor.FullName
                }
            };
        }

        public static IEnumerable<AppointmentWhithoutPatient> Convert(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => Convert(appointment));
        }
    }
}
