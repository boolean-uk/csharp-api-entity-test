using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Models.DTOs
{
    public class DoctrorWithAppointmentsPatientAndPrescriptionDTO
    {
        public DoctorDTO Doctor {  get; set; }
        public ICollection<AppointmentWithPatentAndPrescriptionDTO> Appointments { get; set; }

        public static DoctrorWithAppointmentsPatientAndPrescriptionDTO ToDTO(Doctor doctor)
        {
            var appointments = new List<AppointmentWithPatentAndPrescriptionDTO>();
            foreach (var appointment in doctor.Appointments)
            {
                appointments.Add(AppointmentWithPatentAndPrescriptionDTO.ToDTO(appointment));
            }
            return new DoctrorWithAppointmentsPatientAndPrescriptionDTO()
            {
                Doctor = DoctorDTO.ToDTO(doctor),
                Appointments = appointments,
            };
        }
    }
}
