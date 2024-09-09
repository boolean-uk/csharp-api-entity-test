namespace workshop.wwwapi.Models
{
    public static class DoctorMapper
    {
        public static DoctorDTO MapToDTO(this Doctor doctor)
        {
            return new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName
            };
        }

        public static List<DoctorDTO> MapListToDTO(this List<Doctor> doctor)
        {
            return doctor.Select(doctor => new DoctorDTO
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
            }).ToList();
        }
    }
}
