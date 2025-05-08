using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
using workshop.wwwapi.Models;
using workshop.wwwapi.Payload;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<Payload<IEnumerable<PatientGetDTO>>> GetPatients()
        {
            Payload<IEnumerable<PatientGetDTO>> payload = new Payload<IEnumerable<PatientGetDTO>>();
            List<Patient> patients = await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).ToListAsync();
            var patientGetDTOs = new List<PatientGetDTO>();
            patients.ForEach(p => patientGetDTOs.Add(new PatientGetDTO(p)));
            payload.Data = patientGetDTOs;
            return payload;
        }
        public async Task<Payload<IEnumerable<DoctorGetDTO>>> GetDoctors()
        {
            Payload<IEnumerable<DoctorGetDTO>> payload = new Payload<IEnumerable<DoctorGetDTO>>();
            List<Doctor> doctors = await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).ToListAsync();
            List<DoctorGetDTO> doctorGetDTOs = new List<DoctorGetDTO>();
            doctors.ForEach(d => doctorGetDTOs.Add(new DoctorGetDTO(d)));
            payload.Data = doctorGetDTOs;
            return payload;
        }
        public async Task<Payload<IEnumerable<AppointmentGetDoctor>>> GetAppointmentsByDoctor(int id)
        {
            Payload<IEnumerable<AppointmentGetDoctor>> payload = new Payload<IEnumerable<AppointmentGetDoctor>>();
            if (!_databaseContext.Doctors.Any(d => d.Id == id))
            {
                payload.GoodResponse = false;
                payload.Message = $"Could not find doctor with id={id}";
                return payload;
            }
            List<Appointment> appointments = await _databaseContext.Appointments.Where(a => a.DoctorId==id).Include(a => a.Patient).ToListAsync();

            List<AppointmentGetDoctor> appointmentDTO = new List<AppointmentGetDoctor>();
            appointments.ForEach(a => appointmentDTO.Add(new AppointmentGetDoctor() {Booking = a.Booking, Patient = a.Patient.FullName}));
            payload.Data =  appointmentDTO;
            return payload;
        }

        public async Task<Payload<PatientGetDTO>> GetPatient(int id)
        {
            Payload<PatientGetDTO> payload = new Payload<PatientGetDTO>();
            if (!_databaseContext.Patients.Any(p => p.Id == id))
            {
                payload.GoodResponse = false;
                payload.Message = $"Could not find patient with id={id}";
                return payload;
            }
            Patient patient = await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(p => p.Id == id);

            try
            {
                payload.Data = new PatientGetDTO(patient);
                return payload;
            }
            catch 
            {
                payload.GoodResponse = false;
                payload.Message = $"Could not find patient with id={id}"; 
                return payload;
            }
        }

        public async Task<Payload<PatientGetDTO>> CreatePatient(CreatePatientDTO patient)
        {
            Payload<PatientGetDTO> payload = new Payload<PatientGetDTO>();
            List<Patient> patients = await _databaseContext.Patients.ToListAsync();
            if (patients.Where(p => p.FullName == patient.FullName).Count() == 0)
            {
                Patient p = new Patient() {FullName = patient.FullName};
                p.Id = _databaseContext.Patients.Max(p => p.Id) + 1;
                await _databaseContext.Patients.AddAsync(p);

                await _databaseContext.SaveChangesAsync();
                payload.Data = new PatientGetDTO(p);

                return payload;
            }


            payload.GoodResponse = false;
            payload.Message = $"FullName {patient.FullName} already exists!";
            return payload;
        }

        public async Task<Payload<DoctorGetDTO>> GetDoctor(int id)
        {
            Payload<DoctorGetDTO> payload = new Payload<DoctorGetDTO>();
            Doctor doctor = await _databaseContext.Doctors.Include(p => p.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(p => p.Id == id);

            try
            {
                payload.Data = new DoctorGetDTO(doctor);
                return payload;
            }
            catch 
            {
                payload.GoodResponse = false;
                payload.Message = $"Could not find doctor with id={id}"; 
                return payload;
            }
        }

        public async Task<Payload<DoctorGetDTO>> CreateDoctor(CreateDoctorDTO doctor)
        {
            Payload<DoctorGetDTO> payload = new Payload<DoctorGetDTO>();
            List<Doctor> doctors = await _databaseContext.Doctors.ToListAsync();
            if (doctors.Where(d => d.FullName == doctor.FullName).Count() == 0)
            {
                Doctor doc = new Doctor() {FullName = doctor.FullName};
                doc.Id = _databaseContext.Doctors.Max(d => d.Id) + 1;
                await _databaseContext.Doctors.AddAsync(doc);

                await _databaseContext.SaveChangesAsync();
                payload.Data = new DoctorGetDTO(doc);

                return payload;
            }


            payload.GoodResponse = false;
            payload.Message = $"FullName {doctor.FullName} already exists!";
            return payload;
        }


        public async Task<Payload<IEnumerable<AppointmentGetPatient>>> GetAppointmentsByPatient(int id)
        {
            
            Payload<IEnumerable<AppointmentGetPatient>> payload = new Payload<IEnumerable<AppointmentGetPatient>>();
            List<Appointment> appointments = await _databaseContext.Appointments.Where(a => a.DoctorId==id).Include(a => a.Patient).ToListAsync();

            List<AppointmentGetPatient> appointmentDTO = new List<AppointmentGetPatient>();
            appointments.ForEach(a => appointmentDTO.Add(new AppointmentGetPatient(a)));
            payload.Data =  appointmentDTO;
            return payload;
        }

        public async Task<Payload<AppointmentGetDTO>> GetAppointment(int id)
        {
            Payload<AppointmentGetDTO> payload = new Payload<AppointmentGetDTO>();
            Appointment appointment = await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).FirstOrDefaultAsync(a => a.Id == id);

            try 
            {
                payload.Data = new AppointmentGetDTO(appointment);

                return payload;
            }
            catch (Exception)
            {
                payload.GoodResponse = false;
                payload.Message = $"Could not find appointment with id={id}";
                return payload;
            }
        }

        public async Task<Payload<AppointmentGetDTO>> CreateAppointment(CreateAppointmentDTO appoinmentDTO)
        {
            Payload<AppointmentGetDTO> payload = new Payload<AppointmentGetDTO>();
            bool doctorExists = _databaseContext.Doctors.Any(d => d.Id == appoinmentDTO.DoctorId);
            bool patientExists = _databaseContext.Patients.Any(p => p.Id == appoinmentDTO.PatientId);
            bool doctorGotTime = !_databaseContext.Appointments.Any(a => 
                                a.DoctorId == appoinmentDTO.DoctorId  
                                && a.Booking >= appoinmentDTO.Booking 
                                && a.Booking < appoinmentDTO.Booking.AddMinutes(30));
            bool patientGotTime = !_databaseContext.Appointments.Any(a => 
                                a.PatientId == appoinmentDTO.PatientId  
                                && a.Booking >= appoinmentDTO.Booking 
                                && a.Booking < appoinmentDTO.Booking.AddMinutes(30));

            if (doctorExists && patientExists && doctorGotTime && patientGotTime)
            {
                Appointment appointment = new Appointment() {DoctorId = appoinmentDTO.DoctorId,
                                                            PatientId = appoinmentDTO.PatientId,
                                                            Booking = appoinmentDTO.Booking};
                appointment.Id = _databaseContext.Appointments.Max(d => d.Id) + 1;
                await _databaseContext.Appointments.AddAsync(appointment);
                await _databaseContext.SaveChangesAsync();
                Appointment insertedAppointment = await _databaseContext.Appointments.Include(a => a.Patient).Include(a => a.Doctor).FirstOrDefaultAsync(a => a.Id == appointment.Id);

                try
                {
                    payload.Data = new AppointmentGetDTO(insertedAppointment);

                    return payload;
                }
                catch
                {
                    payload.GoodResponse = false;
                    payload.Message = "Appointment not created due to unknown error";

                    return payload;
                } 
                
            }
            payload.GoodResponse = false;
            payload.Message = "Appointment not created due to a conflict!";

            return payload;
        }

        public async Task<Payload<IEnumerable<AppointmentGetDTO>>> GetAppointments()
        {
            Payload<IEnumerable<AppointmentGetDTO>> payload = new Payload<IEnumerable<AppointmentGetDTO>>();

            List<Appointment> appointments = await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();

            List<AppointmentGetDTO> appointmentGetDTOs = new List<AppointmentGetDTO>();

            appointments.ForEach(a => appointmentGetDTOs.Add(new AppointmentGetDTO(a)));

            payload.Data = appointmentGetDTOs;

            return payload;
        }
    }
}
