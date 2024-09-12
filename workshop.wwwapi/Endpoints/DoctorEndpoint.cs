using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;
using workshop.wwwapi.ViewModels;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctors = app.MapGroup("doctors");
            doctors.MapGet("/", GetDoctors);
            doctors.MapGet("/{id}", GetDoctorById);
            doctors.MapPost("/", CreateDoctor);
        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            DoctorResponseDTO doctorResponseDTO = new DoctorResponseDTO();

            var doctors = await repository.GetDoctors();

            if (doctors == null)
            {
                return TypedResults.NotFound();
            }
            foreach (Doctor d in doctors)
            {
                DoctorDTOwithAppointment doctorDTO = new DoctorDTOwithAppointment() { Id = d.Id, FullName = d.FullName };

                foreach (Appointment appointment in d.Appointments)
                {
                    DoctorAppointmentDTO appointmentDTO = new DoctorAppointmentDTO();
                    appointmentDTO.DoctorAppointmentDate = appointment.Booking;

                    PatientDTOwithoutAppointment patientDTO = new PatientDTOwithoutAppointment();
                    patientDTO.Id = appointment.Patient.Id;
                    patientDTO.FullName = appointment.Patient.FullName;
                    appointmentDTO.Patient = patientDTO;

                    doctorDTO.DoctorAppointments.Add(appointmentDTO);
                }


                doctorResponseDTO.Doctors.Add(doctorDTO);

            }
            return TypedResults.Ok(doctorResponseDTO.Doctors);


        }
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);

            if (doctor == null)
            {
                return TypedResults.NotFound();
            }

            DoctorDTOwithAppointment doctorDTO = new DoctorDTOwithAppointment() { Id = doctor.Id, FullName = doctor.FullName };

            foreach (Appointment appointment in doctor.Appointments)
            {
                DoctorAppointmentDTO appointmentDTO = new DoctorAppointmentDTO();
                appointmentDTO.DoctorAppointmentDate = appointment.Booking;

                PatientDTOwithoutAppointment patientDTO = new PatientDTOwithoutAppointment();
                patientDTO.Id = appointment.Patient.Id;
                patientDTO.FullName = appointment.Patient.FullName;
                appointmentDTO.Patient = patientDTO;


                doctorDTO.DoctorAppointments.Add(appointmentDTO);
            }
            return TypedResults.Ok(doctorDTO);


        }

        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPostModel model)
        {
            try
            {
                var addeddoctor = await repository.CreateDoctor(new Doctor { FullName = model.FullName });

                if (addeddoctor == null) { return TypedResults.NotFound(); }

                DoctorDTOwithAppointment doctordto = new DoctorDTOwithAppointment() { Id = addeddoctor.Id, FullName = addeddoctor.FullName };

                return TypedResults.Ok(doctordto);
            }
            catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }

        }
    }
}
