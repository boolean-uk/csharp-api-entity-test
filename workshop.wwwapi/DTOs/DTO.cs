using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTOs
{
    class PatientResponseDTO
    {
        // define all of the properties that we want to return to the client
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<PatientAssignmentDTO> Appointments { get; set; } = new List<PatientAssignmentDTO>();

        public PatientResponseDTO(Patient patient)
        {
            Id = patient.Id;
            FullName = patient.FullName;

            foreach (Appointment appo in patient.Appointments)
            {
              Appointments.Add(new PatientAssignmentDTO(appo));
           }
        }
    }

    class DoctorResponseDTO
    {
        // define all of the properties that we want to return to the client
        public int Id { get; set; }
        public string FullName { get; set; }

        public List<DoctorAssignmentDTO> Appointments { get; set; } = new List<DoctorAssignmentDTO>();

        public DoctorResponseDTO(Doctor doctor)
        {
            Id = doctor.Id;
            FullName = doctor.FullName;
            foreach (Appointment appo in doctor.Appointments)
            {
                Appointments.Add(new DoctorAssignmentDTO(appo));
            }
        }
    }



    /// RELATION
    class PatientAssignmentDTO
    {
        public DateTime Booking { get; set; }

        public DoctorDTO Doctor { get; set; }

        public PatientAssignmentDTO(Appointment appo)
        {
            Booking = appo.Booking;
            Doctor = new DoctorDTO(appo.Doctor);
        }
    }

    class DoctorAssignmentDTO
    {
        public DateTime Booking { get; set; }

        public PatientDTO Patient { get; set; }

        public DoctorAssignmentDTO(Appointment appo)
        {
            Booking = appo.Booking;
            Patient = new PatientDTO(appo.Patient);
        }
    }



    /// SINGULAR - STOP LOOP
    class PatientDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public PatientDTO(Patient p)
        {
            Id = p.Id;
            FullName = p.FullName;
        }
    }

    class DoctorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public DoctorDTO(Doctor d)
        {
            Id = d.Id;
            FullName = d.FullName;
        }
    }

    class AppointmentDTO
    {
        public DateTime Booking { get; set; }

        public DoctorDTO Doctor { get; set; }
        public PatientDTO Patient { get; set; }

        public AppointmentDTO(Appointment a)
        {
            Booking = a.Booking;
            Doctor = new DoctorDTO(a.Doctor);
            Patient = new PatientDTO(a.Patient);
        }
    }

    class DoctorAppointmentListingDTO
    {
        public DateTime Booking { get; set; }

        public PatientDTO Patient { get; set; }

        public DoctorAppointmentListingDTO(Appointment a)
        {
            Booking = a.Booking;
            Patient = new PatientDTO(a.Patient);
        }
    }

    class PatientAppointmentListingDTO
    {
        public DateTime Booking { get; set; }

        public DoctorDTO Doctor { get; set; }

        public PatientAppointmentListingDTO(Appointment a)
        {
            Booking = a.Booking;
            Doctor = new DoctorDTO(a.Doctor);
        }
    }


}
