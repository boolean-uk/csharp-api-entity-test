using AutoMapper;
using workshop.wwwapi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Appointment, GetAppointmentDTO>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));


        CreateMap<Patient, GetPatientDTO>()
            .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments));

        CreateMap<CreatePatientDTO, Patient>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id property
            .ForMember(dest => dest.Appointments, opt => opt.Ignore()); // Ignore navigation property
    }
}