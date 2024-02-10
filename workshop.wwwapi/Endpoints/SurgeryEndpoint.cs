using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Repository;
using workshop.wwwapi.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            //patients
            surgeryGroup.MapGet("/patients/", GetPatients);
            surgeryGroup.MapGet("/patient/{id}/", GetPatientByID);
            surgeryGroup.MapPost("/patients/", CreatePatient);

            //doctors
            surgeryGroup.MapGet("/doctors/", GetDoctors);
            surgeryGroup.MapGet("/doctor/{id}/", GetDoctorByID);
            surgeryGroup.MapPost("/doctors/", CreateDoctor);
            
            //appointments
            surgeryGroup.MapGet("/appointments/", GetAppointments);
            surgeryGroup.MapGet("/appointment/doctor/{id}/", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointment/patient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapPost("/appointments/", CreateAppointment);

            //prescriptions
            surgeryGroup.MapGet("/prescriptions/", GetPrescriptions);
            surgeryGroup.MapPost("/prescriptions/", CreatePrescription);
            surgeryGroup.MapGet("/prescriptions/{id}/", GetPrescriptionByID);
        }

        //get all patients
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patient = await repository.GetPatients();
            var results = new List<PatientResponseDTO>();
            foreach (var pat in patient)
            {
                results.Add(new PatientResponseDTO(pat));
            }
            return TypedResults.Ok(results);
        }

        //get patient by ID
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientByID(IRepository repository, int id)
        {
            var patient = await repository.GetPatientByID(id);
            if (patient == null)
            {
                return TypedResults.NotFound(id);
            }
            PatientResponseDTO patientToReturn = new PatientResponseDTO(patient); 
            return TypedResults.Ok(patientToReturn);
        }

        //create patient
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Patient))]
        public static async Task<IResult> CreatePatient(IRepository repository, string name)
        {
            var patient = await repository.CreatePatient(name);
            PatientResponseDTO patientToReturn = new PatientResponseDTO(patient);
            return TypedResults.Created("created", patientToReturn);
        }

        //get all doctors
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctor = await repository.GetDoctors();
            var results = new List<DoctorsResponseDTO>();
            foreach (var doc in doctor)
            {
                DoctorsResponseDTO doctorToReturn = new DoctorsResponseDTO(doc);
                results.Add(doctorToReturn);
            }
            return TypedResults.Ok(results);
        }

        //get doctor by ID
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorByID(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorByID(id);
            if (doctor == null)
            {
                return TypedResults.NotFound(id);
            }

            DoctorsResponseDTO doctorToReturn = new DoctorsResponseDTO(doctor);
            return TypedResults.Ok(doctorToReturn);
        }

        //create doctor
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Doctor))]
        public static async Task<IResult> CreateDoctor(IRepository repository, string name)
        {
            var doctor = await repository.CreateDoctor(name);
            DoctorsResponseDTO doctorToReturn = new DoctorsResponseDTO(doctor);
            return TypedResults.Created("created", doctorToReturn);
        }

        //get all appointments
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            var results = new List<AppointmentsResponseDTO>();
            foreach (var appo in appointments)
            {
                AppointmentsResponseDTO appointmentsToReturn = 
                    new AppointmentsResponseDTO(appo);
                results.Add(appointmentsToReturn);
            }
            return TypedResults.Ok(results);
        }

        //get appointment by doctorID
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> 
            GetAppointmentsByDoctor(IRepository repository, int doctorId)
        {
            var appointments = await repository.GetAppointmentsByDoctorID(doctorId);
            if (appointments == null)
            {
                return TypedResults.NotFound(doctorId);
            }
            List<AppointmentsResponseDTO> appointmentsToReturn = 
                new List<AppointmentsResponseDTO>();
            foreach (var appointment in appointments)
            {
                AppointmentsResponseDTO appointmentToReturn = 
                    new AppointmentsResponseDTO(appointment);
                appointmentsToReturn.Add(appointmentToReturn);
            }
            return TypedResults.Ok(appointmentsToReturn);
        }

        //get appointment by patientID
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> 
            GetAppointmentsByPatient(IRepository repository, int patientId)
        {
            var appointments = await repository.GetAppointmentsByPatientID(patientId);
            if (appointments == null)
            {
                return TypedResults.NotFound(patientId);
            }
            List<AppointmentsResponseDTO> appointmentsToReturn = 
                new List<AppointmentsResponseDTO>();
            foreach (var appointment in appointments)
            {
                AppointmentsResponseDTO appointmentToReturn = 
                    new AppointmentsResponseDTO(appointment);
                appointmentsToReturn.Add(appointmentToReturn);
            }
            return TypedResults.Ok(appointmentsToReturn);
        }

        //create appointment
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Appointment))]
        public static async Task<IResult> CreateAppointment(IRepository repository, 
            int doctorId, int patientId, DateTime appointmentTime)
        {
            var appointment = await repository
                .CreateAppointment(doctorId, patientId, appointmentTime);
            AppointmentsResponseDTO appointmentToReturn = 
                new AppointmentsResponseDTO(appointment);
            return TypedResults.Created("created", appointmentToReturn);
        }

        //get prescription
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var prescriptions = await repository.GetPrescriptions();
            List<PrescriptionsResponseDTO> prescriptionsToReturn = 
                new List<PrescriptionsResponseDTO>();
            foreach(var prescription in prescriptions)
            {
                PrescriptionsResponseDTO prescriptionToReturn = 
                    new PrescriptionsResponseDTO(prescription);
                prescriptionsToReturn.Add(prescriptionToReturn);
            }
            return TypedResults.Ok(prescriptionsToReturn);
        }

        //get prescription by ID
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptionByID
            (IRepository repository, int id)
        {
            var prescription = await repository.GetPrescriptionByID(id);
            if (prescription == null)
            {
                return TypedResults.NotFound("prescription does'nt exists");
            }
            PrescriptionsResponseDTO prescriptionToReturn = 
                new PrescriptionsResponseDTO(prescription);
            return TypedResults.Ok(prescriptionToReturn);

        }

        //create prescription
        [ProducesResponseType(StatusCodes.Status201Created, Type = 
            typeof(PrescriptionsResponseDTO))]
        public static async Task<IResult> CreatePrescription(IRepository repository, 
            string name, int appointmentId, int medicineId)
        {
            var prescription = await repository.CreatePrescription
                (name, appointmentId, medicineId);
            PrescriptionsResponseDTO prescriptionToReturn =
                new PrescriptionsResponseDTO(prescription);
            return TypedResults.Created("created", prescriptionToReturn);
        }
    }
}