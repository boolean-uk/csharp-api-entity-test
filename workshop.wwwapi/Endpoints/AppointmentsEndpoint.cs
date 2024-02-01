using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class AppointmentsEndpoint
    {
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            try
            {
                IEnumerable<Appointment> appointments = await repository.GetAppointmentsByDoctor(id);
                List<GetAppointmentDTO> dtos = appointments.Select(a => new GetAppointmentDTO()
                {
                    AppointmentDate = a.AppointmentDate,
                    DoctorName = a.Doctor.Name,
                    PatientFullName = $"{a.Patient.FirstName} {a.Patient.LastName}"
                }).ToList();
                return TypedResults.Ok(dtos);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            try
            {
                IEnumerable<Appointment> appointments = await repository.GetAppointmentsByPatient(id);
                List<GetAppointmentDTO> dtos = appointments.Select(a => new GetAppointmentDTO()
                {
                    AppointmentDate = a.AppointmentDate,
                    DoctorName = a.Doctor.Name,
                    PatientFullName = $"{a.Patient.FirstName} {a.Patient.LastName}"
                }).ToList();
                return TypedResults.Ok(dtos);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetAppointmentByIds(IRepository repository, int patientId, int doctorId)
        {
            try
            {
                Appointment appointment = await repository.GetAppointmentById(patientId, doctorId);
                GetAppointmentDTO dto = new()
                {
                    AppointmentDate = appointment.AppointmentDate,
                    DoctorName = appointment.Doctor.Name,
                    PatientFullName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}"
                };
                return TypedResults.Ok(dto);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddAppointment(IRepository repository, AddAppointmentDTO dto)
        {
            try
            {
                Appointment appointment = await repository.AddAppointment(dto);
                GetAppointmentDTO getDTO = new()
                {
                    AppointmentDate = appointment.AppointmentDate,
                    DoctorName = appointment.Doctor.Name,
                    PatientFullName = $"{appointment.Patient.FirstName} {appointment.Patient.LastName}"
                };
                return TypedResults.Created(nameof(AddAppointment), getDTO);
            } catch (Exception ex)
            {
                return TypedResults.NotFound(ex.Message);
            }

        }

        public static async Task<IResult> GetAll(IRepository repository)
        {
            IEnumerable<Appointment> appointments = await repository.GetAllAppointments();
            List<GetAppointmentDTO> dtos = appointments.Select(a => new GetAppointmentDTO()
            {
                AppointmentDate = a.AppointmentDate,
                DoctorName = a.Doctor.Name,
                PatientFullName = $"{a.Patient.FirstName} {a.Patient.LastName}"
            }).ToList();
            return TypedResults.Ok(dtos);
        }
    }
}
