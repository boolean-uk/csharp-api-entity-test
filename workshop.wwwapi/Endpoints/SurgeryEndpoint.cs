using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        //get all appointments []
        //get appointment by id,
        //get appointments by doctor id,
        //get appointments by patient id
        //create new appointment
        //Update all dtos for patient, doctor and appointments to include the relevant loaded fields via the relations

        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");
            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointment);
            surgeryGroup.MapGet("/appointments/doctors/{id}", GetDoctorsAppointments);
            surgeryGroup.MapGet("/appointments/patients/{id}", GetPatientsAppointments);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var result = await repository.GetPatient(id);
            return TypedResults.Ok(new PatientDTO { Id = result.Id, Name = result.FullName });
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var result = await repository.GetPatients();
            List<PatientDTO> patients = new List<PatientDTO>();
            foreach (var patient in result)
            {
                patients.Add(new PatientDTO
                {
                    Id = patient.Id,
                    Name = patient.FullName
                });
            }
            return TypedResults.Ok(await repository.GetPatients());
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var result = await repository.GetDoctor(id);
            if (result == null)
            {
                return TypedResults.NotFound("Doctor not found");
            }
            return TypedResults.Ok(new DoctorDTO { Id = result.Id, Name = result.FullName });
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var result = await repository.GetDoctors();
            List<DoctorDTO> doctors = new List<DoctorDTO>();
            foreach (var doctor in result)
            {
                doctors.Add(new DoctorDTO { 
                    Id = doctor.Id, 
                    Name = doctor.FullName 
                });
            }
            return TypedResults.Ok(doctors);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var result = await repository.GetAppointments();
            List<AppointmentDTO> appointments = new List<AppointmentDTO>();
            foreach (var appointment in result)
            {
                appointments.Add(
                    new AppointmentDTO
                    {
                        Id = appointment.Id,
                        Booking = appointment.Booking
                    }
                ); 
            }
            return TypedResults.Ok(appointments);
        }

        public static async Task<IResult> GetAppointment(IRepository repository, int id)
        {
            var result = await repository.GetAppointment(id);
            var appointment = new AppointmentDTO
            {
                Id = result.Id,
                Booking = result.Booking,
                Patient = new PatientDTO
                {
                    Id = result.Patient.Id,
                    Name = result.Patient.FullName
                },
                Doctor = new DoctorDTO
                {
                    Id = result.DoctorId,
                    Name = result.Doctor.FullName
                }
               
            };
            return TypedResults.Ok(appointment);
        }

        public static async Task<IResult> GetDoctorsAppointments(IRepository repository, int id)
        {
            var result = await repository.GetDoctorsAppointments(id);
            List<AppointmentForDoctorDTO> appointments = new List<AppointmentForDoctorDTO>();
            foreach(var appointment in result.Appointments) {
                appointments.Add(new AppointmentForDoctorDTO
                {
                    Booking = appointment.Booking,
                    PatientId = appointment.PatientId
                }
            );
            }
            var doctor = new DoctorAppointmentsDTO
            {
                Id = result.Id,
                Name = result.FullName,
                Appointments = appointments
                
            };
            return TypedResults.Ok(doctor);
        }

        public static async Task<IResult> GetPatientsAppointments(IRepository repository, int id)
        {

            return TypedResults.Ok();
        }
    }


}
