using AutoMapper;
using workshop.wwwapi.DTO.Responses;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Tools
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<Patient, PatientDTO>();

            CreateMap<Doctor, DoctorDTO>();

            CreateMap<Appointment, AppointmentPatientDTO>()
                .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));

            CreateMap<Appointment, AppointmentDoctorDTO>()
                .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName));
        }
    }
}
