using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);
            surgeryGroup.MapPost("/patients", CreatePatient);

            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", CreateDoctor);

            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments", CreateAppointment);


        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            GetPatientsResponse response = new GetPatientsResponse();
            var results = await repository.GetPatients();

            foreach (Patient p in results)
            {


                PatientAppointmentsDTO patientDTO = new PatientAppointmentsDTO()
                {
                    Id = p.Id,
                    FullName = p.FullName,
                };


                foreach (Appointment item in p.Appointments)
                {
                    DoctorDTO doctor = new DoctorDTO() {
                        Id = item.DoctorId,
                        FullName = item.Doctor.FullName,
                    };
                    GetAppointmentDTO dto = new GetAppointmentDTO()
                    {
                        Booking = item.Booking,
                        Doctor = doctor,

                    };

                    patientDTO.Appointments.Add(dto);
                }

                response.Patients.Add(patientDTO);
            }
            return TypedResults.Ok(response.Patients);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {

            var response = await repository.GetPatient(id);

            PatientAppointmentsDTO patientDTO = new PatientAppointmentsDTO()
            {
                Id = id,
                FullName = response.FullName
            };

            foreach (Appointment a in response.Appointments)
            {
                DoctorDTO doctorDTO = new DoctorDTO() {
                    Id = a.DoctorId,
                    FullName = a.Doctor.FullName
                };

                GetAppointmentDTO dto = new GetAppointmentDTO()
                {
                    Booking = a.Booking,
                    Doctor = doctorDTO,
                };

                patientDTO.Appointments.Add(dto);
            }

            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPostModel model)
        {
            try { 
            var patient = await repository.CreatePatient(new Patient() { FullName = model.FullName });

            var response = await repository.GetPatient(patient.Id);

            PatientDTO patientDTO = new PatientDTO()
            {
                Id = patient.Id,
                FullName = patient.FullName
            };


            return TypedResults.Ok(patientDTO);
        }catch(Exception ex)
            {
                return TypedResults.Problem(ex.Message);

            }

}
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            GetDoctorResponse response = new GetDoctorResponse();
            var results = await repository.GetDoctors();

            foreach (Doctor doctor in results)
            {
                DoctorAppointmentsDTO doctorDTO = new DoctorAppointmentsDTO()
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                };

                foreach (Appointment a in doctor.Appointments)
                {
                    PatientDTO patientDTO = new PatientDTO()
                    {
                        Id = a.PatientId,
                        FullName = a.Patient.FullName
                    };

                    GetAppointmentForDoctorsDTO dto = new GetAppointmentForDoctorsDTO()
                    {
                        Booking = a.Booking,
                        Patient = patientDTO
                    };

                    doctorDTO.Appointments.Add(dto);

                }

                response.Doctors.Add(doctorDTO);
            }


            return TypedResults.Ok(response.Doctors);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {

            var response = await repository.GetDoctor(id);


            DoctorAppointmentsDTO doctorDTO = new DoctorAppointmentsDTO()
            {
                Id = id,
                FullName = response.FullName
            };
          

            foreach (Appointment a in response.Appointments)
            {
                PatientDTO patientDTO = new PatientDTO()
                {
                    Id = a.PatientId,
                    FullName = a.Patient.FullName
                };

                GetAppointmentForDoctorsDTO dto = new GetAppointmentForDoctorsDTO()
                {
                    Booking = a.Booking,
                    Patient = patientDTO,
                };

                doctorDTO.Appointments.Add(dto);
            }
            

            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPostModel model)
        {
            try
            {
                var doctor = await repository.CreateDoctor(new Doctor() { FullName = model.FullName });

                var response = await repository.GetDoctor(doctor.Id);

                DoctorDTO doctorDTO = new DoctorDTO()
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName
                };


                return TypedResults.Ok(doctorDTO);
            }catch(Exception ex)
            {
                return TypedResults.Problem(ex.Message);

            }
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            GetAppointmentsResponse response = new GetAppointmentsResponse();
            var results = await repository.GetAppointments();
           
            foreach (Appointment a in results)
            {
                PatientDTO patientDTO = new PatientDTO()
                {
                    Id = a.PatientId,
                    FullName = a.Patient.FullName
                };

                DoctorDTO doctorDTO = new DoctorDTO() { 
                
                    Id = a.DoctorId,
                    FullName = a.Doctor.FullName
                };
                AppointmentDTO appointmentDTO = new AppointmentDTO()
                {
                    Booking = a.Booking,
                    Doctor = doctorDTO,
                    Patient = patientDTO,
                };

                response.Appointments.Add(appointmentDTO);
            }

            return TypedResults.Ok(response.Appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int id)
        {

            var response = await repository.GetAppointmentById(id);
            PatientDTO patientDTO = new PatientDTO()
            {
                Id = response.PatientId,
                FullName = response.Patient.FullName
            };

            DoctorDTO doctorDTO = new DoctorDTO()
            {

                Id = response.DoctorId,
                FullName = response.Doctor.FullName
            };
            AppointmentDTO appointmentDTO = new AppointmentDTO()
            {
                Doctor = doctorDTO,
                Patient = patientDTO
            };
         

            return TypedResults.Ok(appointmentDTO);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            GetAppointmentPasientResponse response = new GetAppointmentPasientResponse();
            var results = await repository.GetAppointmentsByDoctor(id);

            foreach (Appointment a in results)
            {

                PatientDTO patientDTO = new PatientDTO()
                {
                    Id = a.PatientId,
                    FullName = a.Patient.FullName
                };

                AppointmentPatientDTO appointmentDTO = new AppointmentPatientDTO()
                {
                   
                    Patient = patientDTO
                };

                response.Appointments.Add(appointmentDTO);
            }

            return TypedResults.Ok(response.Appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            GetAppointmentDoctorResponse response = new GetAppointmentDoctorResponse();
            var results = await repository.GetAppointmentsByPatient(id);

            foreach (Appointment a in results)
            {

                DoctorDTO doctorDTO = new DoctorDTO()
                {
                    Id = a.DoctorId,
                    FullName = a.Doctor.FullName
                };

                AppointmentDoctorDTO appointmentDTO = new AppointmentDoctorDTO()
                {
                    Doctor = doctorDTO
                  
                };
                
                response.Appointments.Add(appointmentDTO);
            }

            return TypedResults.Ok(response.Appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPostModel model)
        {

            try
            {
                var appointment = await repository.CreateAppointment(new Appointment() { Booking = model.Booking, DoctorId = model.DoctorId, PatientId = model.PatientId });

                var response = await repository.GetAppointmentById(appointment.PatientId);


                PatientDTO patientDTO = new PatientDTO()
                {

                    Id = appointment.PatientId,
                    FullName = appointment.Patient.FullName,
                };

                DoctorDTO doctorDTO = new DoctorDTO()
                {
                    Id = appointment.DoctorId,
                    FullName = appointment.Doctor.FullName,
                };


                AppointmentDTO appointmentDTO = new AppointmentDTO()
                {
                    Booking = appointment.Booking,
                    Doctor = doctorDTO,
                    Patient = patientDTO
                };
            return TypedResults.Ok(appointmentDTO);
            }catch (Exception ex)
            {
                return TypedResults.Problem(ex.Message);
            }


        }

    }
}
