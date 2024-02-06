using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    public static class DTOHelper
    {
        public static PatientDTO_L2 CreatePatientDTO(Patient patient)
        {
            return new PatientDTO_L2
            {
                FullName = patient.FullName,
                Appointments = patient.Appointments.Select(a => new AppointmentDTO_P1
                {
                    Doctor = new DoctorDTO_L1
                    {
                        Id = a.Doctor.Id,
                        FullName = a.Doctor.FullName
                    },
                    Booking = a.Booking
                }).ToList()
            };
        }

        public static DoctorDTO_L2 CreateDoctortDTO(Doctor doctor)
        {
            return new DoctorDTO_L2
            {
                FullName = doctor.FullName,
                Appointments = doctor.Appointments.Select(a => new AppointmentDTO_D1
                { 
                    Patient = new PatientDTO_L1
                    {
                        Id = a.Patient.Id,
                        FullName = a.Patient.FullName
                    },
                    Booking = a.Booking
                }).ToList()
            };
        }

        public static List<AppointmentDTO> AppointmentDTOListReturner(IEnumerable<Appointment> appointments)
        {
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();

            foreach (var appointment in appointments)
            {
                var appointmentDTO = CreateAppointmentDTO(appointment);
                appointmentDTOs.Add(appointmentDTO);
            }

            return appointmentDTOs;
        }

        public static AppointmentDTO CreateAppointmentDTO(Appointment appointment)
        {
            return new AppointmentDTO
            {
                Id = appointment.Id,
                DoctorId = appointment.DoctorId,
                Doctor = new DoctorDTO_L1
                {
                    Id = appointment.Doctor.Id,
                    FullName = appointment.Doctor.FullName
                },
                PatientId = appointment.PatientId,
                Patient = new PatientDTO_L1
                {
                    Id = appointment.Patient.Id,
                    FullName = appointment.Patient.FullName
                },
                Booking = appointment.Booking
            };
        }
    }
}
