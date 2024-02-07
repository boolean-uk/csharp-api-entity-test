using Microsoft.AspNetCore.Mvc;
using System.IO;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatientsById);
            surgeryGroup.MapPost("/patients/add", AddPatient);



            surgeryGroup.MapGet("/doctor/all", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}", GetDoctorById);
            surgeryGroup.MapPost("doctor/add", AddDoctor);

            surgeryGroup.MapGet("/appointments/all", GetAppointments);
            surgeryGroup.MapGet("/appointments/by_doctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments/by_patient/{id}", GetAppointmentsByPatient);

            surgeryGroup.MapGet("/prescription/all", GetPrescriptions);

        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            List<PatientDTO> patientsDTO = new List<PatientDTO>();
            foreach (var pat in patients)
            {
                var appointments = await repository.GetAppointmentsByPatient(pat.Id);

                PatientDTO patDTO = new PatientDTO()
                {
                    FullName = pat.FullName
                };

                foreach (var app in appointments)
                {
                    patDTO.Appointments.Add(new AppointmentPatientDTO()
                    {
                        AppointmentTime = app.Booking,
                        DoctorName = repository.GetDoctorById(app.DoctorId).Result.FullName
                    });
                }

                patientsDTO.Add(patDTO);
            }

            return TypedResults.Ok(patientsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientsById(IRepository repository, int id)
        {
            var pat = await repository.GetPatientById(id);
            PatientDTO patDTO = new PatientDTO() { FullName = pat.FullName };

            var appointments = await repository.GetAppointmentsByPatient(pat.Id);
            foreach (var app in appointments)
            {
                patDTO.Appointments.Add(new AppointmentPatientDTO()
                {
                    AppointmentTime = app.Booking,
                    DoctorName = repository.GetDoctorById(app.DoctorId).Result.FullName
                });
            }

            return TypedResults.Ok(patDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddPatient(IRepository repository, string fullname)
        {
            var pat = await repository.AddPatient(fullname);
            PatientDTO patDTO = new PatientDTO() { FullName = pat.FullName };
            return TypedResults.Ok(patDTO);
        }





        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            List<DoctorDTO> doctorsDTO = new List<DoctorDTO>();
            foreach (var doc in doctors)
            {
                DoctorDTO docDTO = new DoctorDTO() { FullName = doc.FullName };
                doctorsDTO.Add(docDTO);

                var appointments = await repository.GetAppointmentsByDoctor(doc.Id);
                foreach (var app in appointments)
                {
                    docDTO.Appointments.Add(new AppointmentDoctorDTO()
                    {
                        AppointmentTime = app.Booking,
                        PatientName = repository.GetDoctorById(app.DoctorId).Result.FullName
                    });
                }
            }

            return TypedResults.Ok(doctorsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doc = await repository.GetDoctorById(id);
            DoctorDTO docDTO = new DoctorDTO() { FullName = doc.FullName };

            var appointments = await repository.GetAppointmentsByDoctor(doc.Id);
            foreach (var app in appointments)
            {
                docDTO.Appointments.Add(new AppointmentDoctorDTO()
                {
                    AppointmentTime = app.Booking,
                    PatientName = repository.GetDoctorById(app.DoctorId).Result.FullName
                });
            }

            return TypedResults.Ok(docDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> AddDoctor(IRepository repository, string fullName)
        {
            var pat = await repository.AddDoctor(fullName);
            DoctorDTO patDTO = new DoctorDTO() { FullName = pat.FullName };
            return TypedResults.Ok(patDTO);
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var apps = await repository.GetAppointments();
            List<AppointmentDTO> appsDTO = new List<AppointmentDTO>();

            foreach (var app in apps)
            {
                appsDTO.Add(new AppointmentDTO()
                {
                    AppointmentTime = app.Booking,
                    DoctorName = repository.GetDoctorById(app.DoctorId).Result.FullName,
                    PatientName = repository.GetPatientById(app.PatientId).Result.FullName
                });
            }

            return TypedResults.Ok(appsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var apps = await repository.GetAppointmentsByDoctor(id);
            List<AppointmentDTO> appsDTO = new List<AppointmentDTO>();

            foreach (var app in apps)
            {
                appsDTO.Add(new AppointmentDTO()
                {
                    AppointmentTime = app.Booking,
                    DoctorName = repository.GetDoctorById(app.DoctorId).Result.FullName,
                    PatientName = repository.GetPatientById(app.PatientId).Result.FullName
                });
            }

            return TypedResults.Ok(appsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var apps = await repository.GetAppointmentsByPatient(id);
            List<AppointmentDTO> appsDTO = new List<AppointmentDTO>();

            foreach (var app in apps)
            {
                appsDTO.Add(new AppointmentDTO()
                {
                    AppointmentTime = app.Booking,
                    DoctorName = repository.GetDoctorById(app.DoctorId).Result.FullName,
                    PatientName = repository.GetPatientById(app.PatientId).Result.FullName
                });
            }

            return TypedResults.Ok(appsDTO);
        }




        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository, int id)
        {
            var pres = await repository.GetPrescriptions();
            
            List<PrescriptionDTO> presDTOs = new List<PrescriptionDTO>();

            foreach (var pre in pres)
            {
                Doctor doc = await repository.GetDoctorById(pre.DoctorId);
                Patient pat = await repository.GetPatientById(pre.PatientId);
                var meds = await repository.GetMedicinePrescriptions();
                meds = meds.Where(x => x.PrescriptionId == pre.Id);

                List<MedicineDTO> medsDTO = new List<MedicineDTO>();
                foreach (var med in meds)
                {
                    medsDTO.Add(new MedicineDTO()
                    {
                        //TODO GET ALL DATA
                    });
                }

                PrescriptionDTO presDTO = new PrescriptionDTO()
                {
                    DoctorName = doc.FullName, PatientName = pat.FullName
                }
            }

            return TypedResults.Ok(presDTOs);
        }
    }
}
