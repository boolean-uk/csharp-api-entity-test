using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Repository;

namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md

        //get appointments by doctor id, get appointments by patient id and create new appointment 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", GetPatients);//-------------------------------------------Has test
            surgeryGroup.MapGet("/doctors", GetDoctors);//---------------------------------------------Has test
            surgeryGroup.MapGet("/doctors/{id}", GetDoctorById);//-------------------------------------Has test
            surgeryGroup.MapPost("/doctors", CreateDoctor);//------------------------------------------Has test                                          
            surgeryGroup.MapGet("/patients/{id}", GetPatientById);//-----------------------------------Has test
            surgeryGroup.MapPost("/patients", CreatePatient);//----------------------------------------Has test       
            surgeryGroup.MapGet("/appointments", GetAppointments);//-----------------------------------Has test
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);//---------------------------Has test
            surgeryGroup.MapGet("/appointments/doctor/{doctorid}", GetAppointmentsByDoctorId);//-------Has test
            surgeryGroup.MapGet("/appointments/patient/{patientid}",GetAppointmentsByPatientId);//-----Has test
            surgeryGroup.MapPost("/appointments", CreateAppointment);//--------------------------------Has test
            surgeryGroup.MapGet("/prescriptions", GetPrescriptions);//--------------------------------Has test
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            var patients = await repository.GetPatients();
            List<PatientDTO> patientDTO = new();

            foreach (Patient p in patients)
            {
                PatientDTO dto = new();
                dto.FullName = p.FullName;
                foreach (Appointment a in p.Appointments)
                {
                    AppointmentDTO app = new AppointmentDTO(a.Doctor.FullName, a.Patient.FullName, a.Booking, a.Type);
                    dto.Appointments.Add(app);
                }
                patientDTO.Add(dto);
            }

            return TypedResults.Ok(patientDTO);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            var doctors = await repository.GetDoctors();
            List<DoctorDTO> doctorDTO = new();

            foreach (Doctor d in doctors)
            {
                DoctorDTO dto = new();
                dto.FullName = d.FullName;
                foreach (Appointment a in d.Appointments)
                {
                    AppointmentDTO app = new AppointmentDTO(a.Doctor.FullName, a.Patient.FullName, a.Booking, a.Type);
                    dto.Appointments.Add(app);
                }
                doctorDTO.Add(dto);
            }

            return TypedResults.Ok(doctorDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var result = await repository.GetPatientById(id);
            PatientDTO dto = new();
            dto.FullName = result.FullName;
            foreach (Appointment a in result.Appointments)
            {
                AppointmentDTO app = new AppointmentDTO(a.Doctor.FullName, a.Patient.FullName, a.Booking, a.Type);
                dto.Appointments.Add(app);
            }
            return TypedResults.Ok(dto);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreatePatient(IRepository repository, PatientPost patient)
        {
            var result = await repository.CreatePatient(patient);
            PatientDTO dto = new();
            dto.FullName = result.FullName;
            return TypedResults.Created("Patient created",dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var result = await repository.GetDoctorById(id);
            DoctorDTO dto = new();
            dto.FullName = result.FullName;
            foreach (Appointment a in result.Appointments)
            {
                AppointmentDTO app = new AppointmentDTO(a.Doctor.FullName, a.Patient.FullName, a.Booking, a.Type);
                dto.Appointments.Add(app);
            }
            return TypedResults.Ok(dto);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateDoctor(IRepository repository, DoctorPost doctor)
        {
            var result = await repository.CreateDoctor(doctor);
            DoctorDTO dto = new();
            dto.FullName = result.FullName;
            return TypedResults.Created("New doctor added",dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            var appointments = await repository.GetAppointments();
            List<AppointmentDTO> appointmentDTO = new();

            foreach (Appointment a in appointments)
            {
                AppointmentDTO dto = new();
                dto.DoctorName = a.Doctor.FullName;
                dto.PatientName = a.Patient.FullName;
                dto.Booking = a.Booking;
                appointmentDTO.Add(dto);
            }

            return TypedResults.Ok(appointmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int id)
        {
            var result = await repository.GetAppointmentById(id);
            AppointmentDTO dto = new();
            dto.DoctorName = result.Doctor.FullName;
            dto.PatientName = result.Patient.FullName;
            dto.Booking = result.Booking;
            return TypedResults.Ok(dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByDoctorId(IRepository repository, int doctorid)
        {
            var appointments = await repository.GetAppointmentsByDoctorId(doctorid);
            List<AppointmentDTO> appointmentDTO = new();

            foreach (Appointment a in appointments)
            {
                AppointmentDTO dto = new();
                dto.DoctorName = a.Doctor.FullName;
                dto.PatientName = a.Patient.FullName;
                dto.Booking = a.Booking;
                appointmentDTO.Add(dto);
            }

            return TypedResults.Ok(appointmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentsByPatientId(IRepository repository, int patientid)
        {
            var appointments = await repository.GetAppointmentsByPatientId(patientid);
            List<AppointmentDTO> appointmentDTO = new();

            foreach (Appointment a in appointments)
            {
                AppointmentDTO dto = new();
                dto.DoctorName = a.Doctor.FullName;
                dto.PatientName = a.Patient.FullName;
                dto.Booking = a.Booking;
                appointmentDTO.Add(dto);
            }

            return TypedResults.Ok(appointmentDTO);
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        public static async Task<IResult> CreateAppointment(IRepository repository, AppointmentPost appointment)
        {
            var result = await repository.CreateAppointment(appointment);
            AppointmentDTO dto = new();
            dto.DoctorName = result.Doctor.FullName;
            dto.PatientName = result.Patient.FullName;
            dto.Booking = result.Booking;
            return TypedResults.Created("New appointment created",dto);
        }

        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            var prescri = await repository.GetPrescriptions();
            List<PrescriptionDTO> prescriDTO = new();

            foreach (Prescription p in prescri)
            {
                PrescriptionDTO dto = new();
           
                dto.Appointment = new AppointmentDTO(p.Appointment.Doctor.FullName, p.Appointment.Patient.FullName, p.Appointment.Booking, p.Appointment.Type);

                foreach(Medicine m in p.Medicine)
                {
                    MedicineDTO newm = new MedicineDTO(m.Name, m.Notes, m.Quantity);
                    dto.Medicine.Add(newm);
                }
              
                prescriDTO.Add(dto);
            }

            return TypedResults.Ok(prescriDTO);
        }
    }
}
