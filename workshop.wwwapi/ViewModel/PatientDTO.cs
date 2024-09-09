using workshop.wwwapi.Models;

namespace workshop.wwwapi.ViewModel
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DetailsDTO> doctorAppointments { get; set; } = new List<DetailsDTO>();

        public PatientDTO(Patient patient, List<Appointment> appointments, List<Doctor> doctors)
        {
            this.Id = patient.Id;
            this.Name = patient.FullName;
            if (appointments.Count > 0)
            {
                foreach (Appointment appointment in appointments)
                {
                    var doctor = doctors.Where(d => d.Id == appointment.DoctorId).FirstOrDefault();
                    if (doctor != null && appointment.PatientId == patient.Id)
                    {
                        this.doctorAppointments.Add(new DetailsDTO(doctor.Id, doctor.FullName, appointment.Booking));
                    }
                }
            }
        }
    }
}
