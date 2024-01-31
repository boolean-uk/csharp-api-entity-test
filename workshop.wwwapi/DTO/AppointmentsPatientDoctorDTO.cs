using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class AppointmentsPatientDoctorDTO
    {
        public int Id { get; set; }
        public string Booking { get; set; }


        public List<DoctorAppointmentDTO> doctorAppointments { get; set; }
    }

    public class DoctorAppointmentDTO
    {
        public int Id { get; set; }
        public string doc_name { get; set; }
        public PatientOnlyDTO patientOnly { get; set; }

        public DoctorAppointmentDTO(Doctor doc)
        {
            Id = doc.Id;
            doc_name = doc.FullName;
        }

        
    }
}
