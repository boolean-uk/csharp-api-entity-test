using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentEndpoint
    {
        public static void ConfigureAppointmentEndpoint(this WebApplication app)
        {
            var appointments = app.MapGroup("appointments");
            appointments.MapGet("/", GetAppointments);
            appointments.MapGet("/{id}", GetAppointmentsById);
            appointments.MapGet("/doctor/{id}", GetAppointmentsByDoctorId);
            //appointments.MapGet("patients/{id}" GetAppointmentsByPasientId);
            appointments.MapPost("/", CreateAppointment);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            AppointmentsResponseDTO response = new AppointmentsResponseDTO();
            var appointments = await repository.GetAppointments();

            if (appointments == null)
            {
                return TypedResults.NotFound();
            }
            foreach (Appointment a in appointments)
            {
                PatientDTOwithoutAppointment patientdto = new PatientDTOwithoutAppointment()
                {
                    Id = a.Patient.Id,
                    FullName = a.Patient.FullName
                };
                DoctorDTOWithoutAppointment doctordto = new DoctorDTOWithoutAppointment()
                {
                    Id = a.Doctor.Id,
                    FullName = a.Doctor.FullName,
                };
                AppointmentDTO appointmentDTO = new AppointmentDTO()
                {
                    Booking = a.Booking,
                    Patient = patientdto,
                    Doctor = doctordto


                };

                response.Appointments.Add(appointmentDTO);

            }
            return TypedResults.Ok(response.Appointments);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsById(IRepository repository, int doctorid, int patientid)
        {
            var appointments = await repository.GetAppointments();
            var appointment = appointments.FirstOrDefault(a => a.DoctorId == doctorid && a.PatientId == patientid);

            if (appointment == null)
            {
                return TypedResults.NotFound();
            }

            PatientDTOwithoutAppointment patientdto = new PatientDTOwithoutAppointment()
            {
                Id = appointment.Patient.Id,
                FullName = appointment.Patient.FullName,
            };

            DoctorDTOWithoutAppointment doctordto = new DoctorDTOWithoutAppointment()
            {
                Id = appointment.DoctorId,
                FullName = appointment.Doctor.FullName,
            };

            AppointmentDTO appointmentDTO = new AppointmentDTO()
            {
                Booking = appointment.Booking,
                Patient = patientdto,
                Doctor = doctordto
            };

            return TypedResults.Ok(appointmentDTO);

        }

        public static async Task<IResult> GetAppointmentsByDoctorId(IRepository repository, int doctorid)
        {
            var doctor = await repository.GetDoctorById(doctorid);

            DoctorDTOwithAppointment doctorDTOwithAppointment = new DoctorDTOwithAppointment()
            {
                Id = doctor.Id,
                FullName = doctor.FullName
            };

            foreach (Appointment a in doctor.Appointments)
            {
                PatientDTOwithoutAppointment patientdto = new PatientDTOwithoutAppointment();
                patientdto.Id = a.PatientId;
                patientdto.FullName = a.Patient.FullName;
                DoctorAppointmentDTO doctorappointmentdto = new DoctorAppointmentDTO();
                doctorappointmentdto.DoctorAppointmentDate = a.Booking;
                doctorappointmentdto.Patient = patientdto;

                doctorDTOwithAppointment.DoctorAppointments.Add(doctorappointmentdto);
            }
            return TypedResults.Ok(doctorDTOwithAppointment);


        }
       /* public static async Task<IResult> GetAppointmentsByPasientId(IRepository repository, int patientid)
        {
            var patient = await repository.GetPatientById(patientid);

            PatientDTOwithAppointments patientDTOwithAppointment = new PatientDTOwithAppointments()
            {
                Id = patient.Id,
                FullName = patient.FullName,
            };

            foreach (Appointment a in patient.Appointments)
            {
                DoctorDTOWithoutAppointment doctordto = new DoctorDTOWithoutAppointment();
                doctordto.Id = a.DoctorId;
                doctordto.FullName = a.Doctor.FullName;
                PatientAppointmentDTO patientAppointmentDTO = new PatientAppointmentDTO();
                patientAppointmentDTO.PatientAppointmentDate = a.Booking;
                patientAppointmentDTO.Doctor = doctordto;

                patientDTOwithAppointment.PatientAppointments.Add(patientAppointmentDTO);
            }*/
                
        
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPostModel model)
        {
            var addedappointment = await repository.CreateAppointment(new Appointment() { Booking = model.booking, DoctorId = model.DoctorId, PatientId = model.PatientId });
            var appointments = await repository.GetAppointments();
            var target = appointments.FirstOrDefault(a => a.DoctorId == model.DoctorId && a.PatientId == model.PatientId);

            PatientDTOwithoutAppointment patientDTO = new PatientDTOwithoutAppointment()
            {
                Id = target.Patient.Id,
                FullName = target.Patient.FullName,
            };
            DoctorDTOWithoutAppointment doctorDTO = new DoctorDTOWithoutAppointment()
            {
                Id = target.Doctor.Id,
                FullName = target.Doctor.FullName,
            };
            AppointmentDTO appointmentDTO = new AppointmentDTO()
            {
                Booking = target.Booking,
                Patient = patientDTO,
                Doctor = doctorDTO,
            };
            return TypedResults.Ok(appointmentDTO);
         

        }
    }
}

