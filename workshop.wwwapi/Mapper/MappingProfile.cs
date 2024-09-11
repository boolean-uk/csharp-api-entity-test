﻿using AutoMapper;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.AppointmentDTOs;
using workshop.wwwapi.Models.DoctorDTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //Get patient/-s endpoint
        CreateMap<Appointment, GetPatientAppDTO>()
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName));

        CreateMap<Patient, GetPatientDTO>()
            .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments));

        //Create patient
        CreateMap<CreatePatientDTO, Patient>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id property
            .ForMember(dest => dest.Appointments, opt => opt.Ignore()); // Ignore navigation property

        //Get doctor/-s endpoint
        CreateMap<Appointment, GetDoctorAppDTO>()
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName));

        CreateMap<Doctor, GetDoctorDTO>()
            .ForMember(dest => dest.Appointments, opt => opt.MapFrom(src => src.Appointments));

        //Create doctor
        CreateMap<CreateDoctorDTO, Doctor>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Ignore Id property
            .ForMember(dest => dest.Appointments, opt => opt.Ignore()); // Ignore navigation property

        //Get appointment/-s endpoint
        CreateMap<Appointment, GetAppointmentDTO>()
            .ForMember(dest => dest.PatientId, opt => opt.MapFrom(src => src.Patient.Id))
            .ForMember(dest => dest.PatientName, opt => opt.MapFrom(src => src.Patient.FullName))
            .ForMember(dest => dest.DoctorName, opt => opt.MapFrom(src => src.Doctor.FullName))
            .ForMember(dest => dest.DoctorId, opt => opt.MapFrom(src => src.Doctor.Id));

        //Create appointment
        CreateMap<CreateAppointmentDTO, Appointment>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());

        //Get doctor/-s endpoint
        CreateMap<Prescription, GetPrescriptionDTO>()
            .ForMember(dest => dest.Appointment, opt => opt.MapFrom(src => src.Appointment))
            .ForMember(dest => dest.Medicines, opt => opt.MapFrom(src => src.Medicines));

        // Get medicine 
        CreateMap<Medicine, GetMedicineDTO>();

        //Create appointment
        CreateMap<CreatePrescriptionDTO, Prescription>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}