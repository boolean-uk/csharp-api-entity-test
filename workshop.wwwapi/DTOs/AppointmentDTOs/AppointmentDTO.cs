using workshop.wwwapi.DTOs.DoctorDTOs;
using workshop.wwwapi.DTOs.PatientDTOs;
using workshop.wwwapi.Enums;

namespace workshop.wwwapi.DTOs.AppointmentDTOs
{
    public class AppointmentDTO
    {
        public DateTime Booking {  get; set; }
        public int DoctorId { get; set; }
        public DoctorDTO2 Doctor { get; set; }
        public int PatientId { get; set; }
        public PatientDTO2 Patient { get; set; }
        public AppointmentEnums AppointmentType { get; set; }

    }
}
