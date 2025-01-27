using AutoMapper;

namespace workshop.wwwapi.Mapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Models.Patient, DTO.PatientResponse>();
        CreateMap<Models.Doctor, DTO.DoctorResponse>();
        CreateMap<Models.Appointment, DTO.AppointmentResponse>()
            .ForPath(m => m.Doctor!.Appointments, opt => opt.Ignore())
            .ForPath(m => m.Patient!.Appointments, opt => opt.Ignore());
        CreateMap<Models.Prescription, DTO.PrescriptionResponse>()
            .ForMember(m => m.Lines, opt => opt.MapFrom(src => src.Lines));
        CreateMap<Models.PrescriptionLine, DTO.PrescriptionLineResponse>()
            .ForMember(m => m.Medicine, opt => opt.MapFrom(src => src.Medicine))
            .ForMember(m => m.Quantity, opt => opt.MapFrom(src => src.Quantity))
            .ForMember(m => m.Instructions, opt => opt.MapFrom(src => src.Instructions));
        CreateMap<Models.Medicine, DTO.MedicineResponse>();
    }
}