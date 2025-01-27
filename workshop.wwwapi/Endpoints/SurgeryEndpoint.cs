using System.Drawing;
using System.Numerics;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using workshop.wwwapi.Data;
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
            surgeryGroup.MapGet("/doctors", GetDoctors);
            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", GetAppointmentsByDoctor);
            surgeryGroup.MapGet("doctors/{id}", GetDoctorById);
            surgeryGroup.MapGet("/appointments", GetAppointments);
            surgeryGroup.MapGet("/appointments/{id}", GetAppointmentById);
            surgeryGroup.MapGet("/appointment/{doctorId}", GetAppointmentsByDoctorId);
            surgeryGroup.MapGet("/appointmen/{patientId}", GetAppointmentsByPatientId);
            surgeryGroup.MapGet("/prescriptions", GetPrescriptions);
            surgeryGroup.MapPost("/prescriptions/{appointmentId}", CreatePrescription);
        }
        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatients(IRepository repository)
        {
            List<PatientDTO> dtos = new List<PatientDTO>();

            var patients = await repository.GetPatients();

            foreach (Patient patient in patients)
            {

                PatientDTO dto = new PatientDTO
                {
                    Id = patient.Id,
                    FullName = patient.FullName,
                    Appointments = new List<AppointmentDTOwithName>()
                };
                IEnumerable<Appointment> appointments = await repository.GetAppointmentByPatientId(patient.Id);

                foreach (Appointment appointment in appointments)
                {
                    AppointmentDTOwithName dtoName = new AppointmentDTOwithName();
                    Doctor doc = await repository.GetDoctorById(appointment.DoctorId);
                    dtoName.DoctorName = doc.FullName;
                    dtoName.DoctorId = appointment.DoctorId;
                    dtoName.Booking = appointment.Booking;

                    dto.Appointments.Add(dtoName);
                }

                dtos.Add(dto);
            }

            return TypedResults.Ok(dtos);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPatientById(IRepository repository, int id)
        {
            var patients = await repository.GetPatientById(id);

            PatientDTO dto = new PatientDTO()
            {
                Id = patients.Id,
                FullName = patients.FullName,
                Appointments = new List<AppointmentDTOwithName>()
            };

            IEnumerable<Appointment> appointments = await repository.GetAppointmentByPatientId(patients.Id);
            
            foreach(Appointment appointment in appointments)
            {
                AppointmentDTOwithName dtoName = new AppointmentDTOwithName();
                Doctor doc = await repository.GetDoctorById(appointment.DoctorId);
                dtoName.DoctorName = doc.FullName;
                dtoName.DoctorId = appointment.DoctorId;
                dtoName.Booking = appointment.Booking;

                dto.Appointments.Add(dtoName);
            }
                

            return TypedResults.Ok(dto);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctors(IRepository repository)
        {
            List<DoctorDTO> dtos = new List<DoctorDTO>();

            var doctors = await repository.GetDoctors();

            foreach (Doctor doctor in doctors)
            {

                DoctorDTO dto = new DoctorDTO
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    Appointments = new List<AppointmentDTODoctor>()
                };

                IEnumerable<Appointment> appointments = await repository.GetAppointmentByDoctorId(doctor.Id);

                foreach (Appointment appointment in appointments)
                {
                    AppointmentDTODoctor dtoName = new AppointmentDTODoctor();
                    Patient patient = await repository.GetPatientById(appointment.PatientId);
                    dtoName.Name = patient.FullName;
                    dtoName.PatientId = appointment.PatientId;
                    dtoName.Booking = appointment.Booking;

                    dto.Appointments.Add(dtoName);
                }
                dtos.Add(dto);
            }

            return TypedResults.Ok(dtos);
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetDoctorById(IRepository repository, int id)
        {
            var doctors = await repository.GetDoctorById(id);

            DoctorDTO dto = new DoctorDTO()
            {
                Id = doctors.Id,
                FullName = doctors.FullName,
                Appointments = new List<AppointmentDTODoctor>()
            };

            IEnumerable<Appointment> appointments = await repository.GetAppointmentByDoctorId(doctors.Id);

            foreach (Appointment appointment in appointments)
            {
                AppointmentDTODoctor dtoName = new AppointmentDTODoctor();
                Patient patient = await repository.GetPatientById(appointment.PatientId);
                dtoName.Name = patient.FullName;
                dtoName.PatientId = appointment.PatientId;
                dtoName.Booking = appointment.Booking;

                dto.Appointments.Add(dtoName);
            }

            return TypedResults.Ok(dto);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)] 
        
        public static async Task<IResult> GetAppointmentsByDoctor(IRepository repository, int id)
        {
            return TypedResults.Ok(await repository.GetAppointmentsByDoctor(id));
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointments(IRepository repository)
        {
            List<AppointmentDTO> dtos = new List<AppointmentDTO>();

            var appointments = await repository.GetAppointments();

            foreach (Appointment appointment in appointments)
            {
                Doctor doc = await repository.GetDoctorById(appointment.DoctorId);
                Patient pat = await repository.GetPatientById(appointment.PatientId);

                AppointmentDTO dto = new AppointmentDTO()
                {
                    Id = appointment.Appointment_Id,
                    Booking = appointment.Booking,
                    DoctorId = appointment.DoctorId,
                    PatientId = appointment.PatientId,
                    
                    DoctorName = doc.FullName,
                    PatientName = pat.FullName
                };

                dtos.Add(dto);
            }

            return TypedResults.Ok(dtos);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetAppointmentById(IRepository repository, int id)
        {
            var appointment = await repository.GetAppointmentById(id);
            Doctor doc = await repository.GetDoctorById(appointment.DoctorId);
            Patient pat = await repository.GetPatientById(appointment.PatientId);
           
            AppointmentDTO dto = new AppointmentDTO()
            {
                Id = appointment.Appointment_Id,
                Booking = appointment.Booking,
                DoctorId = appointment.DoctorId,
                PatientId = appointment.PatientId,
                DoctorName = doc.FullName,
                PatientName = pat.FullName
            };

            return TypedResults.Ok(dto);
        }
        

        public static async Task<IResult> GetAppointmentsByDoctorId(IRepository repository, int doctor_id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentByDoctorId(doctor_id);
            List<AppointmentDTO> appointmentsDTO = new List<AppointmentDTO>();
            
            
            foreach (Appointment appointment in appointments)
            {
                Doctor doc = await repository.GetDoctorById(appointment.DoctorId);
                Patient pat = await repository.GetPatientById(appointment.PatientId);
                AppointmentDTO dto = new AppointmentDTO()
                {
                    Id = appointment.Appointment_Id,
                    Booking = appointment.Booking,
                    DoctorId = appointment.DoctorId,
                    PatientId = appointment.PatientId,
                    DoctorName = doc.FullName,
                    PatientName = pat.FullName

                };
                appointmentsDTO.Add(dto);
            }

            return TypedResults.Ok(appointmentsDTO);
        }

        public static async Task<IResult> GetAppointmentsByPatientId(IRepository repository, int patient_id)
        {
            IEnumerable<Appointment> appointments = await repository.GetAppointmentByPatientId(patient_id);
            List<AppointmentDTO> appointmentsDTO = new List<AppointmentDTO>();
            foreach (Appointment appointment in appointments)
            {
                Doctor doc = await repository.GetDoctorById(appointment.DoctorId);
                Patient pat = await repository.GetPatientById(appointment.PatientId);
                AppointmentDTO dto = new AppointmentDTO()
                {
                    Id = appointment.Appointment_Id,
                    Booking = appointment.Booking,
                    DoctorId = appointment.DoctorId,
                    PatientId = appointment.PatientId,
                    DoctorName = doc.FullName,
                    PatientName = pat.FullName
                };
                appointmentsDTO.Add(dto);
            }

            return TypedResults.Ok(appointmentsDTO);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        public static async Task<IResult> GetPrescriptions(IRepository repository)
        {
            List<PrescriptionDTO> dto = new List<PrescriptionDTO>();

            foreach (Prescription prescription in await repository.GetPrescriptions())
            {
                PrescriptionDTO DTO = new PrescriptionDTO();
                //doctor
                SimplifiedDocDTO doc = new SimplifiedDocDTO();
                int docid = prescription.DoctorId;
                Doctor fullname = await repository.GetDoctorById(docid);
                doc.FullName = fullname.FullName;
                doc.Id = docid;

                //patient
                SimplifiedPatientDTO pat = new SimplifiedPatientDTO();
                int patid = prescription.PatientId;
                Patient name = await repository.GetPatientById(patid);
                pat.FullName = name.FullName;
                pat.Id = patid;

                //Medicine
                MedicineDTO med = new MedicineDTO();
                MedicinePrescription pres = await repository.GetMedicinePrescriptionsById(prescription.PrescriptionId);
                
                med.MedicineId = pres.MedicineId;
                med.Instruction = pres.Notes;
                med.Quantity = pres.Quantity;
                med.Name = pres.Name;


                //Appointment
                AppointmentDTO appointment = new AppointmentDTO();
                appointment.Id = prescription.AppointmentId;
                appointment.DoctorId = prescription.DoctorId;
                appointment.PatientId = prescription.PatientId;
                appointment.PatientName = pat.FullName;
                appointment.DoctorName = doc.FullName;
                Appointment appe = await repository.GetAppointmentById(prescription.AppointmentId);
                appointment.Booking = appe.Booking;
                

                //add all
                DTO.Id = prescription.PrescriptionId;
                DTO.doctor = doc;
                DTO.patient = pat;
                DTO.appointment = appointment;
                DTO.medicine = med;

                dto.Add(DTO);

            }
            return TypedResults.Ok(dto);
        }

        [ProducesResponseType(200)]
        public static async Task<IResult> CreatePrescription(IRepository repository, int appointmentId, string name, string instruction, int quantity)
        {
            // Initialize a DTO to hold the full prescription info
            PrescriptionDTO dto = new PrescriptionDTO();

            // Fetch medicines (although this is not directly used for creation in this context)
            IEnumerable<Medicine> meds = await repository.GetMedicines();
            
            Medicine newMed = new Medicine
            {
                MedicineId = meds.Count() + 1, 
                Name =name,
                Instruction =instruction,
                Quantity = quantity
            };


            

            Appointment appointment = await repository.GetAppointmentById(appointmentId);

            
            MedicinePrescription medicinePrescription = new MedicinePrescription
            {
                Name = newMed.Name,
                MedicineId = newMed.MedicineId,
                Notes = newMed.Instruction,
                Quantity = newMed.Quantity
            };

            
            Prescription prescription = await repository.CreatePrescription(appointment, medicinePrescription);

            
            SimplifiedDocDTO doctorDto = new SimplifiedDocDTO();



            Doctor doctor = await repository.GetDoctorById(appointment.DoctorId);
            doctorDto.FullName = doctor.FullName;
            doctorDto.Id = doctor.Id;

            SimplifiedPatientDTO patientDto = new SimplifiedPatientDTO();
            Patient patient = await repository.GetPatientById(appointment.PatientId);
            patientDto.FullName = patient.FullName;
            patientDto.Id = patient.Id;

           
            MedicineDTO medicineDto = new MedicineDTO
            {
                MedicineId = newMed.MedicineId,
                Name = medicinePrescription.Name,
                Instruction = medicinePrescription.Notes,
                Quantity = medicinePrescription.Quantity
            };

            
            AppointmentDTO appointmentDto = new AppointmentDTO
            {
                Id = appointment.Appointment_Id,
                DoctorId = prescription.DoctorId,
                PatientId = prescription.PatientId,
                PatientName = patient.FullName,
                DoctorName = doctor.FullName,
                Booking = appointment.Booking
            };

           
            dto.Id = prescription.PrescriptionId;
            dto.doctor = doctorDto;
            dto.patient = patientDto;
            dto.appointment = appointmentDto;
            dto.medicine = medicineDto;

            return TypedResults.Ok(dto);
        }



    }
}
