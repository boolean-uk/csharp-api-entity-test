using AutoMapper;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Patient, PatientDTO>()
            .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments));
        CreateMap<Doctor, DoctorDTO>();
        CreateMap<Appointment, AppointmentPatientDTO>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));
        CreateMap<Appointment, AppointmentDoctorDTO>()
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName));
    }
}

