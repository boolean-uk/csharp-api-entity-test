using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.DTOs;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }



        public async Task<Patient> CreatePatient(string fullName)
        {
            //Create the patient
            var patient = new Patient();
            patient.FullName = fullName;
            patient.Id = _databaseContext.Patients.Count() + 1;
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return patient;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).ToListAsync();
        }
        public async Task<Patient> GetPatientById(int id)
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new ArgumentException($"Patient with id: {id} does not exist.");
        }



        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(p => p.Patient).ToListAsync();
        }
        public async Task<Doctor> GetDcotorById(int id)
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(p => p.Patient).FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new ArgumentException($"Doctor with id: {id} does not exist.");
        }



        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(p => p.Patient).Where(d => d.DoctorId == id).ToListAsync()
                 ?? throw new ArgumentException($"Doctor with id: {id} does not exist.");
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Include(a => a.Doctor).Include(p => p.Patient).Where(x => x.PatientId == id).ToListAsync()
                 ?? throw new ArgumentException($"Patient with id: {id} does not exist.");
        }
        public async Task<Appointment> CreateAppointment(CreateAppointmentDto createAppointmentDto)
        {
            // Get doctor and patient
            var doctor = await _databaseContext.Doctors.FindAsync(createAppointmentDto.DoctorId);
            var patient = await _databaseContext.Patients.FindAsync(createAppointmentDto.PatientId);

            if (doctor == null || patient == null)
            {
                throw new ArgumentException("Doctor or patient not found.");
            }

            // Create the appointment
            Appointment appointment = new Appointment()
            {
                Doctor = doctor,
                Patient = patient,
                Booking = createAppointmentDto.AppointmentTime.ToUniversalTime()
            };



            await _databaseContext.Appointments.AddAsync(appointment);
            patient.Appointments.Add(appointment);
            doctor.Appointments.Add(appointment);

            await _databaseContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            IEnumerable<Prescription> prescriptions = await _databaseContext.Prescriptions.Include(x => x.Medicine).ToListAsync();
            return prescriptions;
        }


        public async Task<Prescription> CreatePrescription(CreateMedicinePrescriptionDto dto)
        {
            Prescription prescription = new Prescription();
            List<Medicine> medicines = await _databaseContext.Medicines.Where(x => dto.MedicineId.Contains(x.Id)).ToListAsync();
            prescription.Medicine = medicines;
            await _databaseContext.Prescriptions.AddAsync(prescription);
            await _databaseContext.SaveChangesAsync();
            return prescription;
        }
    }

}

