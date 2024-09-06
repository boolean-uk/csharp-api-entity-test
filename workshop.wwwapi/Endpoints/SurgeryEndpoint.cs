using Microsoft.AspNetCore.Mvc;
using System.Numerics;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTO;
using workshop.wwwapi.Models.InputObject;
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
            surgeryGroup.MapPost("/patients", PostPatient);
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);
            surgeryGroup.MapPost("/doctors", PostDoctor);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointments/{DocId,PatId}", GetAppointmentsByIDs);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapPost("/appointments/{id}", PostAppointment);
            surgeryGroup.MapGet("/prescription/", GetPrescriptions);
            surgeryGroup.MapGet("/prescription/{id}", GetPrescriptionById);
            surgeryGroup.MapPost("/prescription/", PostPrescription);
            surgeryGroup.MapGet("/medicine/", GetMedicines);
            surgeryGroup.MapGet("/medicine/{id}", GetMedicineById);
            surgeryGroup.MapPost("/medicine/", PostMedicine);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var result = await repository.GetPatients();
            List<PatientDTO> patients = new List<PatientDTO>();
            foreach (var item in result)
            {
                patients.Add(CreatePatientDTO(item));
            }
            return TypedResults.Ok(patients);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            return TypedResults.Ok((await repository.GetPatientById(id)));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> PostPatient(IRepository repository,string fullname)
        {
            return TypedResults.Ok(CreatePatientDTO(await repository.CreatePatient(fullname)));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var result = await repository.GetDoctors();
            List<DoctorDTO> doctorDTOs = new List<DoctorDTO>();
            foreach (var item in result)
            {
                doctorDTOs.Add(CreateDoctorDTO(item));
            }
            return TypedResults.Ok(doctorDTOs);
        }
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            return TypedResults.Ok(CreateDoctorDTO(await repository.GetDoctorById(id)));
        }
        public static async Task<IResult> PostDoctor(IRepository repository, string name)
        {
            return TypedResults.Ok(CreateDoctorDTO(await repository.CreateDoctor(name)));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (var item in appointments)
            {
                appointmentDTOs.Add(CreateAppointmentDTO(item));
            }
            return TypedResults.Ok(appointmentDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatient(IRepository repository, int id)
        {
            var appointments = await repository.GetAppointmentsByDoctor(id);
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (var item in appointments)
            {
                appointmentDTOs.Add(CreateAppointmentDTO(item));
            }
            return TypedResults.Ok(appointmentDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            List<AppointmentDTO> appointmentDTOs = new List<AppointmentDTO>();
            foreach (var item in appointments)
            {
                appointmentDTOs.Add(CreateAppointmentDTO(item));
            }
            return TypedResults.Ok(appointmentDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByIDs(IRepository repository, int DocId, int PatId)
        {
            return TypedResults.Ok(CreateAppointmentDTO(await repository.GetAppointmentByIDs(DocId,PatId)));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> PostAppointment(IRepository repository, InputAppointment input)
        {
            return TypedResults.Ok(CreateAppointmentDTO(await repository.CreateAppointment(input)));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var prescriptions = await repository.GetPrescriptions();
            List<PrescriptionDTO> prescriptionDTO = new List<PrescriptionDTO>();
            foreach (var item in prescriptions)
            {
                prescriptionDTO.Add(CreatePrescriptionDTO(item));
            }
            return TypedResults.Ok(prescriptionDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptionById(IRepository repository,int id)
        {
            return TypedResults.Ok(CreatePrescriptionDTO(await repository.GetPrescriptionById(id)));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> PostPrescription(IRepository repository, IEnumerable<InputPrescription> input)
        {
            return TypedResults.Ok(CreatePrescriptionDTO(await repository.CreatePrescription(input)));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetMedicines(IRepository repository)
        {
            var medicines = await repository.GetMedicines();
            List<MedicineDTO> MedicineDTOs = new List<MedicineDTO>();
            foreach (var item in medicines)
            {
                MedicineDTOs.Add(CreateMedicineDTO(item));
            }
            return TypedResults.Ok(MedicineDTOs);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetMedicineById(IRepository repository, int id)
        {
            return TypedResults.Ok(CreateMedicineDTO(await repository.GetMedicineById(id)));
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> PostMedicine(IRepository repository, string name)
        {
            return TypedResults.Ok(CreateMedicineDTO(await repository.CreateMedicine(name)));
        }
        public static PatientDTO CreatePatientDTO(Patient patient)
        {
            PatientDTO patientDTO = new PatientDTO();
            patientDTO.FullName = patient.FullName;
            foreach (var appointments in patient.Appointments)
            {
                AppointmentForPatientDTO appointment = new AppointmentForPatientDTO();
                appointment.Booking = appointments.Booking;
                appointment.DoctorId = appointments.DoctorId;
                appointment.PrescriptionId = appointments.PrescriptionId;
                patientDTO.Appointments.Add(appointment);
            }
            return patientDTO;
        }
        public static DoctorDTO CreateDoctorDTO(Doctor doctor)
        {
            DoctorDTO doctorDTO = new DoctorDTO();
            doctorDTO.FullName = doctor.FullName;
            foreach (var appointments in doctor.Appointments)
            {
                AppointmentForDoctorDTO appointment = new AppointmentForDoctorDTO();
                appointment.Booking = appointments.Booking;
                appointment.PatientId = appointments.PatientId;
                appointment.PrescriptionId = appointments.PrescriptionId;
                doctorDTO.Appointments.Add(appointment);
            }
            return doctorDTO;
        }
        public static AppointmentDTO CreateAppointmentDTO(Appointment appointment)
        {
            AppointmentDTO appointmentDTO = new AppointmentDTO();
            appointmentDTO.Booking = appointment.Booking;
            appointmentDTO.PatientId = appointment.PatientId;
            appointmentDTO.DoctorId = appointment.DoctorId;
            appointmentDTO.PrescriptionId = appointment.PrescriptionId;


            return appointmentDTO;
        }
        public static PrescriptionDTO CreatePrescriptionDTO(Prescription prescription)
        {
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO();
            prescriptionDTO.ID = prescription.Id;
            foreach (var medicine in prescription.Medicines)
            {
                PrescriptionMedicineDTO presMed = new PrescriptionMedicineDTO()
                {
                    MedicineId = medicine.MedicineId,
                    PrescriptionId = medicine.PrescriptionId,
                    Notes = medicine.Notes,
                    Quantity = medicine.Quantity,
                };
                prescriptionDTO.Medicine.Add(presMed);
            }

            return prescriptionDTO;
        }
        public static MedicineDTO CreateMedicineDTO(Medicine medicine)
        {
            MedicineDTO MedicineDTO = new MedicineDTO();
            MedicineDTO.Name = medicine.Name;

            return MedicineDTO;
        }
    }
}
