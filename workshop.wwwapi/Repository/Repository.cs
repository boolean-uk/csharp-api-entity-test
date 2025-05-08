using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _db;
        public Repository(DatabaseContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<PatientDisplayDto>> GetPatients()
        {
            //return await _db.Patients.Include(x => x.Appointments).ToListAsync();
            return from patient in _db.Patients select new PatientDisplayDto { Id = patient.Id, FullName = patient.FullName };
        }

        public async Task<PatientSpecificDto> GetPatientById(int id)
        {
            PatientSpecificDto patient = new();
            Patient getPatient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);
            List<Doctor> doctors = await _db.Doctors.ToListAsync();

            patient.Id = id;
            patient.FullName = getPatient.FullName;
            foreach (Appointment getAppointment in await _db.Appointments.Where(a => a.PatientId == id).ToListAsync())
            {
                AppointmentPatientDto appointment = new();
                DoctorDisplayDto doctorDto = new();


                appointment.DoctorId = getAppointment.DoctorId;
                appointment.Booking = getAppointment.Booking;

                Doctor doctor = doctors.FirstOrDefault(d => d.Id == appointment.DoctorId);
                doctorDto.Id = doctor.Id;
                doctorDto.FullName = doctor.FullName;
                appointment.Doctor = doctorDto;

                patient.Appointments.Add(appointment);
            }
            return patient;
        }

        public async Task<Patient> CreatePatient(PatientCreate patient)
        {
            Patient addPatient = new();
            addPatient.Id = _db.Patients.ToList().Last().Id + 1;
            addPatient.FullName = patient.FullName;
            await _db.Patients.AddAsync(addPatient);
            _db.SaveChangesAsync();
            return addPatient;
        }

        

        public async Task<bool> PatientIdExists(int id)
        {
            return await _db.Patients.Where(p => p.Id == id).CountAsync() != 0;
        }


        public async Task<IEnumerable<DoctorDisplayDto>> GetDoctors()
        {
            return from doctor in _db.Doctors select new DoctorDisplayDto { Id = doctor.Id, FullName = doctor.FullName };
        }

        public async Task<DoctorSpecificDto> GetDoctorById(int id)
        {
            Doctor getDoctor = await _db.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            DoctorSpecificDto displayDoctor = new();
            displayDoctor.Id = id;
            displayDoctor.FullName = getDoctor.FullName;

            foreach(Appointment appointment in await _db.Appointments.Where(a => a.DoctorId == id).ToListAsync())
            {
                DoctorAppointmentDto appointmentDto = new();
                PatientDisplayDto patientDto = new();
                Patient patient = _db.Patients.FirstOrDefault(p => p.Id == appointment.PatientId);

                patientDto.FullName = patient.FullName;
                patientDto.Id = patient.Id;
                appointmentDto.Booking = appointment.Booking;
                appointmentDto.Patient = patientDto;
                displayDoctor.Appointments.Add(appointmentDto);

            }

            return displayDoctor;
        }

        public async Task<Doctor> CreateDoctor(DoctorCreate doctor)
        {
            Doctor addDoctor = new();
            addDoctor.Id = _db.Doctors.ToList().Last().Id + 1;
            addDoctor.FullName = doctor.FullName;
            await _db.Doctors.AddAsync(addDoctor);
            _db.SaveChangesAsync();
            return addDoctor;
        }

        public async Task<List<AppointmentDoctorDto>> GetAppointments()
        {
            List<Doctor> doctors = await _db.Doctors.ToListAsync(); 
            List<Patient> patients = await _db.Patients.ToListAsync();
            List<AppointmentDoctorDto> appointments = new();

            foreach (Appointment getAppointment in await _db.Appointments.ToListAsync())
            {
                Doctor getDoctor = doctors.FirstOrDefault(d => d.Id == getAppointment.DoctorId);
                Patient getPatient = patients.FirstOrDefault(p => p.Id == getAppointment.PatientId);
                AppointmentDoctorDto appointment = new();
                
                PatientDisplayDto patient = new();
                DoctorDisplayDto doctor = new();

                doctor.Id = getAppointment.DoctorId;
                doctor.FullName = getDoctor.FullName;
                patient.Id = getAppointment.PatientId;
                patient.FullName = getPatient.FullName;

                appointment.Booking = getAppointment.Booking;
                appointment.Type = getAppointment.Type;
                appointment.Doctor = doctor;
                appointment.Patient = patient;

                appointments.Add(appointment);
            }
            return appointments;
        }

        public async Task<AppointmentDoctorDto> GetAppointmentById(int patientId, int doctorId)
        {
            AppointmentDoctorDto appointment = new();
            Appointment getAppointment = await _db.Appointments.FirstOrDefaultAsync(a => a.PatientId == patientId && a.DoctorId == doctorId);
            if (getAppointment == null)
            {
                return appointment;
            }

            Doctor getDoctor = await _db.Doctors.FirstOrDefaultAsync(d => d.Id == getAppointment.DoctorId);
            Patient getPatient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == getAppointment.PatientId);
            
            PatientDisplayDto patient = new();
            DoctorDisplayDto doctor = new();

            doctor.Id = getAppointment.DoctorId;
            doctor.FullName = getDoctor.FullName;
            patient.Id = getAppointment.PatientId;
            patient.FullName = getPatient.FullName;

            appointment.Booking = getAppointment.Booking;
            appointment.Type = getAppointment.Type;
            appointment.Doctor = doctor;
            appointment.Patient = patient;

            return appointment;
        }

        public async Task<List<AppointmentDoctorDto>> GetAppointmentsByDoctor(int id)
        {
            //return await _db.Appointments.Where(a => a.DoctorId==id).ToListAsync();
            Doctor getDoctor = await _db.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            List<Patient> patients = await _db.Patients.ToListAsync();
            List<AppointmentDoctorDto> appointments = new();

            DoctorDisplayDto doctor = new();
            doctor.Id = id;
            doctor.FullName = getDoctor.FullName;


            foreach(Appointment getAppointment in await _db.Appointments.Where(a => a.DoctorId == id).ToListAsync())
            {
                AppointmentDoctorDto appointment = new();
                PatientDisplayDto patientDto = new();

                appointment.Booking = getAppointment.Booking;
                appointment.Type = getAppointment.Type;
                appointment.Doctor = doctor;

                Patient patient = patients.FirstOrDefault(p => p.Id == getAppointment.PatientId);
                patientDto.FullName = patient.FullName;
                patientDto.Id = getAppointment.PatientId;
                appointment.Patient = patientDto;

                appointments.Add(appointment);
            }
            return appointments;
        }

        public async Task<List<AppointmentPatientDto>> GetAppointmentsByPatient(int id)
        {
            List<Doctor> doctors = await _db.Doctors.ToListAsync();
            List<AppointmentPatientDto> appointments = new();
            Patient getPatient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);

            foreach (Appointment getAppointment in await _db.Appointments.Where(p => p.PatientId == id).ToListAsync())
            {
                Doctor getDoctor = doctors.FirstOrDefault(d => d.Id == getAppointment.DoctorId);
                AppointmentPatientDto appointment = new();

                PatientDisplayDto patient = new();
                DoctorDisplayDto doctor = new();

                doctor.Id = getAppointment.DoctorId;
                doctor.FullName = getDoctor.FullName;
                patient.Id = getAppointment.PatientId;
                patient.FullName = getPatient.FullName;

                appointment.Booking = getAppointment.Booking;
                appointment.Type = getAppointment.Type;
                appointment.Doctor = doctor;
                appointment.Patient = patient;

                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
