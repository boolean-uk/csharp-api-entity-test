using System.Numerics;
using workshop.wwwapi.Models;

namespace SurgeryEndpoints.DTOs
{
    class PatientResponseDTO
    {
        // define all of the properties that we want to return to the client
        public int Id { get; set; }
        public string FullName { get; set; }
        
        public List<PatientAppointmentsDTO> patientappointments { get; set; } = new List<PatientAppointmentsDTO>();

        public PatientResponseDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            foreach (Appointment appointment in patient.Appointments)
            {
                patientappointments.Add(new PatientAppointmentsDTO(appointment));
            }
        }
    }

    class DoctorResponseDTO
    {
        // define all of the properties that we want to return to the client
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<DoctorAppointmentDTO> doctorappointments { get; set; } = new List<DoctorAppointmentDTO>();

        public DoctorResponseDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            foreach (Appointment appointment in doctor.Appointments)
            {
                doctorappointments.Add(new DoctorAppointmentDTO(appointment));
            }
        }
    }

    class PatientAppointmentsDTO
    {
        public DateTime Booking { get; set; }
        public int DoctorId { get; set; }

        public DoctorDTO doctor { get; set; }

        public PatientAppointmentsDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            doctor = new DoctorDTO(appointment.Doctor);
        }
    }

    class DoctorAppointmentDTO
    {
        public DateTime Booking { get; set; }
        public int PatientId { get; set; }

        public PatientDTO patient { get; set; }

        public DoctorAppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            patient = new PatientDTO(appointment.Patient);
        }
    }
    class AppointmentDTO
    {
        public DateTime Booking { get; set; }
        public PatientDTO patient { get; set; }
        public DoctorDTO doctor { get; set; }

        public AppointmentDTO(Appointment appointment)
        {
            Booking = appointment.Booking;
            patient = new PatientDTO(appointment.Patient);
            doctor = new DoctorDTO(appointment.Doctor);
        }
    }

    class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public PatientDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;
            
        }
    }

    class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public DoctorDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
        }
    }
        
}