using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
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
            surgeryGroup.MapGet("/appointments/doctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointments/patient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/medicine", GetAllMedicines);
            surgeryGroup.MapGet("/prescription", GetAllPrescriptions);
            surgeryGroup.MapPost("/prescription", CreatePrescription);
            surgeryGroup.MapPost("/prescription/prescription={id}", AddMedicineToPrescription);
            surgeryGroup.MapPost("/prescriptions/doctor={id}", AddPrescriptionToAppointment);
        }

        // ------------------------ Patients ------------------------------
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            return TypedResults.Ok(patients);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patient = await repository.GetPatientbyId(id);
            if (patient == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(patient);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, CreatePatientDTO createPatientDTO)
        {
            var patient = new Patient{ FullName = createPatientDTO.FullName};
            var createdPatient = await repository.CreatePatient(patient);
            var patientDTO = new PatientDTO
            {
                Id = createdPatient.Id,
                FullName = createdPatient.FullName
            };
            return TypedResults.Ok(patientDTO);
        }

        // ---------------------- Doctors -----------------------
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            return TypedResults.Ok(doctors);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctor = await repository.GetDoctorById(id);
            if (doctor == null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(doctor);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, CreateDoctorDTO createDoctorDTO)
        {
            var doctor = new Doctor{ FullName = createDoctorDTO.FullName };
            var createdDoctor = await repository.CreateDoctor(doctor);
            var doctorDTO = new DoctorDTO
            {
                Id = createdDoctor.Id,
                FullName = createdDoctor.FullName
            };
            return TypedResults.Ok(doctorDTO);
        }

        //------------------------ Appointments --------------------------
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            return TypedResults.Ok(appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            return TypedResults.Ok(appointments);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByPatient(id);
            return TypedResults.Ok(appointments);
        }

        //-------------------------- Medicine & Prescription -----------------------------
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllMedicines(IRepository repository)
        {
            var medicines = await repository.GetAllMedicines();
            return TypedResults.Ok(medicines);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAllPrescriptions(IRepository repository)
        {
            var prescriptions = await repository.GetAllPrescriptions();
            return TypedResults.Ok(prescriptions);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePrescription(IRepository repository, PrescriptionDTOLess prescriptionDTO)
        {
            var prescription = new Prescription { Id = prescriptionDTO.Id };
            var createdPrescription = await repository.CreatePrescription(prescription);
            var prescriptionToAdd = new PrescriptionDTOLess
            {
                Id = createdPrescription.Id,
            };
            return TypedResults.Ok(prescriptionToAdd);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddMedicineToPrescription(IRepository repository, int prescriptionId, int medicineId)
        {
            var updatedPrescription = await repository.AddMedicineToPrescription(medicineId, prescriptionId);
            if (updatedPrescription != null)
                return TypedResults.Ok(updatedPrescription);
            else
                return TypedResults.NotFound("Prescription or Medicine not found.");
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public static async Task<IResult> AddPrescriptionToAppointment(IRepository repository, int doctorId, int patientId, int prescriptionId)
        {
            var updatedAppointmentDTO = await repository.AddPrescriptionToAppointment(doctorId, patientId, prescriptionId);

            if (updatedAppointmentDTO != null)
                return TypedResults.Ok(updatedAppointmentDTO);
            else
                return TypedResults.NotFound("Appointment, Prescription, or both not found.");
        }
    }
}
