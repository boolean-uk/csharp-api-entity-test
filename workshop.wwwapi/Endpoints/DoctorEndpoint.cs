using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class DoctorEndpoint
    {
        public static void ConfigureDoctorEndpoint(this WebApplication app)
        {
            var doctors = app.MapGroup("doctors");
            doctors.MapGet("/", GetDoctors);
            doctors.MapGet("/{id}", GetDoctor);
            doctors.MapPost("/", CreateDoctor);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            DoctorResponse doctorResponse = new DoctorResponse();

            var doctors = await repository.GetDoctors();

            foreach (Doctor doctor in doctors)
            {
                DoctorDTO doctorDTO = new DoctorDTO() { Id = doctor.Id, FullName = doctor.FullName };

                foreach (var appointment in doctor.Appointments)
                {
                    doctorDTO.Appointments.Add(appointment);
                }

                doctorResponse.doctors.Add(doctorDTO);
            }

            return TypedResults.Ok(doctorResponse);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctor(id);

            if (doctor == null) return TypedResults.NotFound();

            DoctorDTO doctorDTO = new DoctorDTO() { Id = doctor.Id, FullName = doctor.FullName };

            foreach (var appointment in doctor.Appointments)
            {
                doctorDTO.Appointments.Add(appointment);
            }

            return TypedResults.Ok(doctorDTO);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> CreateDoctor(IRepository repository, Doctor doctor)
        {
            try
            {
                var addDoctor = await repository.CreateDoctor(new Doctor() { Id = doctor.Id, FullName = doctor.FullName });
                DoctorDTO doctorDTO = new DoctorDTO() { Id = addDoctor.Id, FullName = addDoctor.FullName };
                return TypedResults.Ok(addDoctor);
            }
            catch (Exception ex)
            {
                return TypedResults.NotFound();
            }
        }




    }
}
