using Microsoft.AspNetCore.Mvc;
using Npgsql.Replication;
using System.Xml.Linq;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTO;
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
            surgeryGroup.MapGet("/patients/{id}", GetPatient);
            surgeryGroup.MapPost("/patients/{id}", CreatedPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id1}", GetDoctor);
            surgeryGroup.MapPost("/doctors/{id}", CreateDoctor);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentsById);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctorId);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatientId);
            surgeryGroup.MapGet("/prescriptions", GetPrescriptions);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            var appointments = await repository.GetAppointments();
            var doctors = await repository.GetDoctors();

            List<PatientDTO> patientDTOs = new List<PatientDTO>();

            foreach (var patient in patients)
            {
                PatientDTO pat = new PatientDTO()
                {
                    PatientName = patient.FullName,
                    Appointments = appointments.Where(a => a.PatientId == patient.Id).Select(a => new AppointmentPasientDto()
                    {
                        Booking = a.Booking,
                        DoctorId = a.DoctorId,
                        Name = doctors.FirstOrDefault(d => d.Id == a.DoctorId).FullName
                    }).ToList(),
                };
                patientDTOs.Add(pat);
            }
            return TypedResults.Ok(patientDTOs);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatient(IRepository repository, int id)
        {
            var patient = await repository.GetPatient(id);
            var appointment = await repository.GetAppointmentsByPatientId(id);

            PatientDTO patientDTO = new PatientDTO() { PatientName = patient.FullName, Appointments = (ICollection<AppointmentPasientDto>)appointment };

            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatedPatient(IRepository repository, Patient patient)
        {
            var createdPatient = await repository.CreatePatient(patient);
            var patientDTO = new PatientDTO() { PatientName = createdPatient.FullName };
            return TypedResults.Ok(patientDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            var appointments = await repository.GetAppointments();
            var patients = await repository.GetPatients();

            List<DoctorDTO> doctorsDtos = new List<DoctorDTO>();

            foreach (var doctor in doctors)
            {
                DoctorDTO doc = new DoctorDTO()
                {
                    fullName = doctor.FullName,
                    Appointments = appointments
                        .Where(a => a.DoctorId == doctor.Id)
                        .Select(a => new AppointmentDoctor()
                        {
                            Booking = a.Booking,
                            PatientId = a.PatientId,
                            Name = patients.FirstOrDefault(p => p.Id == a.PatientId).FullName
                        }).ToList(),

                };
                doctorsDtos.Add(doc);
            };
            return TypedResults.Ok(doctorsDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctor(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);

            DoctorDTO doc = new DoctorDTO() { fullName = doctor.FullName };
            return TypedResults.Ok(doc);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, Doctor doctor)
        {
            var createdDoctor = await repository.CreateDoctor(doctor);
            var docDto = new DoctorDTO()
            {
                fullName = createdDoctor.FullName
            };
            return TypedResults.Ok(docDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var pasients = await repository.GetPatients();
            var doctors = await repository.GetDoctors();

            List<AppointmentDto> appointmentDto = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                AppointmentDto app = new AppointmentDto()
                {
                    Booking = appointment.Booking,
                    PatientId = appointment.PatientId,
                    PatientName = pasients.FirstOrDefault(p => p.Id == appointment.PatientId).FullName,
                    DoctorId = appointment.DoctorId,
                    DoctorName = doctors.FirstOrDefault(d => d.Id == appointment.DoctorId).FullName
                };
                appointmentDto.Add(app);
            }
            return TypedResults.Ok(appointmentDto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctorId(IRepository repository, int Id)
        {
            var appointments = await repository.GetAppointmentByDoctorId(Id);
            var pasients = await repository.GetPatients();
            var doctors = await repository.GetDoctors();

            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();

            foreach(var appointment in appointments)
            {
                AppointmentDto app = new AppointmentDto()
                {
                    Booking = appointment.Booking,
                    PatientId = appointment.PatientId,
                    PatientName = pasients.FirstOrDefault(p => p.Id == appointment.PatientId).FullName,
                    DoctorId = appointment.DoctorId,
                    DoctorName = doctors.FirstOrDefault(d => d.Id == appointment.DoctorId).FullName
                };
                appointmentDtos.Add(app);
            }

            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatientId(IRepository repository, int Id)
        {
            var appointments = await repository.GetAppointmentsByPatientId(Id);
            var pasients = await repository.GetPatients();
            var doctors = await repository.GetDoctors();

            List<AppointmentDto> appointmentDtos = new List<AppointmentDto>();

            foreach (var appointment in appointments)
            {
                AppointmentDto app = new AppointmentDto()
                {
                    Booking = appointment.Booking,
                    PatientId = appointment.PatientId,
                    PatientName = pasients.FirstOrDefault(p => p.Id == appointment.PatientId).FullName,
                    DoctorId = appointment.DoctorId,
                    DoctorName = doctors.FirstOrDefault(d => d.Id == appointment.DoctorId).FullName
                };
                appointmentDtos.Add(app);
            }

            return TypedResults.Ok(appointmentDtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsById(IRepository repository, int doctorId, int patientId)
        {
            var appointments = await repository.GetAppointmentsById(doctorId, patientId);
            var pasients = await repository.GetPatients();
            var doctors = await repository.GetDoctors();

            AppointmentDto appDto = new AppointmentDto()
            {
                Booking = appointments.Booking,
                PatientId = appointments.PatientId,
                PatientName = pasients.FirstOrDefault(p => p.Id == appointments.PatientId).FullName,
                DoctorId = appointments.DoctorId,
                DoctorName = doctors.FirstOrDefault(d => d.Id == appointments.DoctorId).FullName
            };

            return TypedResults.Ok(appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var prescriptions = await repository.GetPrescriptions();

            List<PrescriptionDto> preDtos = new List<PrescriptionDto>();

            foreach (var prescription in prescriptions)
            {
                PrescriptionDto script = new PrescriptionDto()
                {
                    Instruction = prescription.Instruction,
                    DocotrId = prescription.DocotrId,
                    PatientId = prescription.PatientId,
                    medicineId = prescription.medicineId
                };
                preDtos.Add(script);
            }

            
            return TypedResults.Ok(preDtos);
        }
    }
}
