namespace workshop.wwwapi.Models
{
    public static class PatientMapper
    {
        public static PatientDTO MapToDTO(this Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName
            };
        }

        public static List<PatientDTO> MapListToDTO(this List<Patient> patient)
        {
            return patient.Select(patient => new PatientDTO
            {
                Id = patient.Id,
                FullName = patient.FullName,
            }).ToList();
        }
    }
}
