using workshop.wwwapi.Models;

namespace workshop.wwwapi.Services
{
    public static class AppointmentDtoManager
    {
        public static OutputAppointment Convert(Appointment appointment)
        {
            return new OutputAppointment
            {
                Id = appointment.Id,
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
                },
                Prescription = PrescriptionDtoManager.ConvertRemoveAppointment(appointment.Prescription),
                Type = appointment.Type.ToString()
            };
        }

        public static IEnumerable<OutputAppointment> Convert(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => Convert(appointment));
        }

        public static AppointmentWhithoutPrescription ConvertRemovePrescription(Appointment appointment)
        {
            return new AppointmentWhithoutPrescription
            {
                Id = appointment.Id,
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
                },
                Type = appointment.Type.ToString()
            };
        }

        public static AppointmentWhithoutPatient ConvertRemovePatient(Appointment appointment)
        {
            return new AppointmentWhithoutPatient
            {
                Booking = appointment.Booking,
                Doctor = new DoctorWhithoutAppointment
                {
                    Id = appointment.Doctor.Id,
                    FullName = appointment.Doctor.FullName
                },
                Prescription = PrescriptionDtoManager.ConvertRemoveAppointment(appointment.Prescription),
                Type = appointment.Type.ToString()
            };
        }

        public static IEnumerable<AppointmentWhithoutPatient> ConvertRemovePatient(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => ConvertRemovePatient(appointment));
        }

        public static AppointmentWhithoutDoctor ConvertRemoveDoctor(Appointment appointment)
        {
            return new AppointmentWhithoutDoctor
            {
                Booking = appointment.Booking,
                Patient = new PatientWhithoutAppointment
                {
                    Id = appointment.Patient.Id,
                    FullName = appointment.Patient.FullName
                },
                Prescription = PrescriptionDtoManager.ConvertRemoveAppointment(appointment.Prescription),
                Type = appointment.Type.ToString()
            };
        }

        public static IEnumerable<AppointmentWhithoutDoctor> ConvertRemoveDoctor(IEnumerable<Appointment> appointments)
        {
            return appointments.Select(appointment => ConvertRemoveDoctor(appointment));
        }
    }
}
