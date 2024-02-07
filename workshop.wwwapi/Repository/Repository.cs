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

        public async Task<PatientSpesificDto> GetPatientById(int id)
        {
            PatientSpesificDto patient = new();
            Patient getPatient = await _db.Patients.FirstOrDefaultAsync(p => p.Id == id);
            List<Doctor> doctors = await _db.Doctors.ToListAsync();

            patient.Id = id;
            patient.FullName = getPatient.FullName;
            foreach (Appointment getAppointment in await _db.Appointments.Where(a => a.PatientId == id).ToListAsync())
            {
                PatientAppointmentDto appointment = new();
                DoctorDisplayDto doctorDto = new();


                appointment.DoctorId = getAppointment.DoctorId;
                appointment.Booking = getAppointment.Booking;

                Doctor doctor = doctors.FirstOrDefault(d => d.Id == appointment.DoctorId);
                doctorDto.Id = doctor.Id;
                doctorDto.FullName = doctor.FullName;
                appointment.DoctorDto = doctorDto;

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


        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors.ToListAsync();
        }


        public async Task<List<DoctorAppointmentDto>> GetAppointmentsByDoctor(int id)
        {
            //return await _db.Appointments.Where(a => a.DoctorId==id).ToListAsync();
            Doctor getDoctor = await _db.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            List<Patient> patients = await _db.Patients.ToListAsync();
            List<DoctorAppointmentDto> appointments = new();

            DoctorDisplayDto doctor = new();
            doctor.Id = id;
            doctor.FullName = getDoctor.FullName;


            foreach(Appointment getAppointment in await _db.Appointments.Where(a => a.DoctorId == id).ToListAsync())
            {
                DoctorAppointmentDto appointment = new();
                PatientDisplayDto patientDto = new();

                appointment.Booking = getAppointment.Booking;
                appointment.Doctor = doctor;

                Patient patient = patients.FirstOrDefault(p => p.Id == getAppointment.PatientId);
                patientDto.FullName = patient.FullName;
                patientDto.Id = getAppointment.PatientId;
                appointment.Patient = patientDto;

                appointments.Add(appointment);
            }
            return appointments;
        }
    }
}
