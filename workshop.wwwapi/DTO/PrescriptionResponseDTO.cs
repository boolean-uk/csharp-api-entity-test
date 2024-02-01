using workshop.wwwapi.Models;

namespace workshop.wwwapi.DTO
{
    public class PrescriptionResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<AppointmentDTO> Appointments { get; set; } = new List<AppointmentDTO>();

        public PrescriptionResponseDTO(Prescription prescription)
        {
            Id = prescription.Id;
            Name = prescription.Name;
            foreach (var appointment in prescription.Appointments)
                Appointments.Add(new AppointmentDTO(appointment));
        }

        public static List<PrescriptionResponseDTO> FromRepository(IEnumerable<Prescription> prescriptions)
        {
            var results = new List<PrescriptionResponseDTO>();
            foreach (var prescription in prescriptions)
                results.Add(new PrescriptionResponseDTO(prescription));
            return results;
        }

        public static PrescriptionResponseDTO FromARepository(Prescription prescription)
        {
            PrescriptionResponseDTO result = new PrescriptionResponseDTO(prescription);
            return result;
        }
    }
}
