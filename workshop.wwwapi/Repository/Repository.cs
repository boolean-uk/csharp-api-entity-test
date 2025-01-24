using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTO;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<PatientDTO>> GetPatients()
        {
            var patients = await _databaseContext.Patients.Include(p => p.Appointments).ToListAsync();
            var patientsDTO = new List<PatientDTO>();
            foreach (var patient in patients)
            {
                var appointments = new List<PatientAppointments>();
                foreach (var appoint in patient.Appointments)
                {
                    await _databaseContext.Entry(appoint).Reference(a => a.Doctor).LoadAsync();
                    appointments.Add(new PatientAppointments()
                    {
                        Doctor = new DoctorInfo() { Id = appoint.DoctorId, FullName = appoint.Doctor.FullName },
                        Booking = appoint.Booking,
                        Type = appoint.Type.ToString()
                    });
                }
                patientsDTO.Add(new PatientDTO()
                {
                    Name = patient.FullName,
                    Appointments = appointments
                });                    
            }
            return patientsDTO;
        }
        
        public async Task<PatientDTO> GetPatientById(int id)
        {
            var patient = await _databaseContext.Patients.Include(p => p.Appointments).FirstOrDefaultAsync(p => p.Id == id);
            var appointments = new List<PatientAppointments>();
            foreach (var appoint in patient.Appointments)
            {
                await _databaseContext.Entry(appoint).Reference(a => a.Doctor).LoadAsync();
                appointments.Add(new PatientAppointments()
                {
                    Doctor = new DoctorInfo() { Id = appoint.DoctorId, FullName = appoint.Doctor.FullName },
                    Booking = appoint.Booking,
                    Type = appoint.Type.ToString()
                });
            }
            PatientDTO dto = new PatientDTO()
            {
                Name = patient.FullName,
                Appointments = appointments
            };
            return dto;
        }

        public async Task<PatientDTO> CreatePatient(PatientView view)
        {
            var patient = new Patient() { FullName = view.Name };
            _databaseContext.Patients.Add(patient);
            await _databaseContext.SaveChangesAsync();
            return new PatientDTO() { Name = view.Name, Appointments = [] };
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = await _databaseContext.Doctors.Include(p => p.Appointments).ToListAsync();
            var patientsDTO = new List<DoctorDTO>();
            foreach (var doctor in doctors)
            {
                var appointments = new List<DoctorAppointments>();
                foreach (var appoint in doctor.Appointments)
                {
                    await _databaseContext.Entry(appoint).Reference(a => a.Patient).LoadAsync();
                    appointments.Add(new DoctorAppointments()
                    {
                        Patient = new PatientInfo() { Id = appoint.PatientId, FullName = appoint.Patient.FullName },
                        Booking = appoint.Booking,
                        Type = appoint.Type.ToString()
                    });
                }
                patientsDTO.Add(new DoctorDTO()
                {
                    Name = doctor.FullName,
                    Appointments = appointments
                });
            }
            return patientsDTO;
        }

        public async Task<DoctorDTO> GetDoctorById(int id)
        {
            var doctor = await _databaseContext.Doctors.Include(d => d.Appointments).FirstOrDefaultAsync(p => p.Id == id);
            var appointments = new List<DoctorAppointments>();
            foreach (var appoint in doctor.Appointments)
            {
                await _databaseContext.Entry(appoint).Reference(a => a.Patient).LoadAsync();
                appointments.Add(new DoctorAppointments()
                {
                    Patient = new PatientInfo() { Id = appoint.PatientId, FullName = appoint.Patient.FullName },
                    Booking = appoint.Booking,
                    Type = appoint.Type.ToString()
                });
            }
            DoctorDTO dto = new DoctorDTO()
            {
                Name = doctor.FullName,
                Appointments = appointments
            };
            return dto;
        }

        public async Task<DoctorDTO> CreateDoctor(DoctorView view)
        {
            var doctor = new Doctor() { FullName = view.Name };
            _databaseContext.Doctors.Add(doctor);
            await _databaseContext.SaveChangesAsync();
            return new DoctorDTO() { Name = view.Name, Appointments = [] };
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointments()
        {
            var appoints = await _databaseContext.Appointments.Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
            var appointsDTO = new List<AppointmentDTO>();
            foreach (var appoint in appoints)
            {
                appointsDTO.Add(new AppointmentDTO()
                {
                    Type = appoint.Type.ToString(),
                    Booking = appoint.Booking,
                    Doctor = new DoctorInfo() { Id = appoint.Doctor.Id, FullName = appoint.Doctor.FullName },
                    Patient = new PatientInfo() { Id = appoint.Patient.Id, FullName = appoint.Patient.FullName }
                });
            }
            return appointsDTO;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id)
        {
            var appoints = await _databaseContext.Appointments.Where(a => a.DoctorId == id).Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
            var appointsDTO = new List<AppointmentDTO>();
            foreach (var appoint in appoints)
            {
                appointsDTO.Add(new AppointmentDTO()
                {
                    Type = appoint.Type.ToString(),
                    Booking = appoint.Booking,
                    Doctor = new DoctorInfo() { Id = appoint.Doctor.Id, FullName = appoint.Doctor.FullName },
                    Patient = new PatientInfo() { Id = appoint.Patient.Id, FullName= appoint.Patient.FullName }
                });
            }
            return appointsDTO;
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id)
        {
            var appoints = await _databaseContext.Appointments.Where(a => a.PatientId == id).Include(a => a.Doctor).Include(a => a.Patient).ToListAsync();
            var appointsDTO = new List<AppointmentDTO>();
            foreach (var appoint in appoints)
            {
                appointsDTO.Add(new AppointmentDTO()
                {
                    Type = appoint.Type.ToString(),
                    Booking = appoint.Booking,
                    Doctor = new DoctorInfo() { Id = appoint.Doctor.Id, FullName = appoint.Doctor.FullName },
                    Patient = new PatientInfo() { Id = appoint.Patient.Id, FullName = appoint.Patient.FullName }
                });
            }
            return appointsDTO;
        }

        public async Task<AppointmentDTO> CreateAppointment(AppointmentView view)
        {
            var appoint = new Appointment() { Type = view.Type, Booking = view.Booking, DoctorId = view.DoctorId, PatientId = view.PatientId };
            _databaseContext.Appointments.Add(appoint);
            await _databaseContext.SaveChangesAsync();
            await _databaseContext.Entry(appoint).Reference(a => a.Patient).LoadAsync();
            await _databaseContext.Entry(appoint).Reference(a => a.Doctor).LoadAsync();
            return new AppointmentDTO()
            { 
                Type= appoint.Type.ToString(),
                Booking = view.Booking,
                Doctor = new DoctorInfo() { Id = view.DoctorId, FullName = appoint.Doctor.FullName },
                Patient = new PatientInfo() { Id = view.PatientId, FullName= appoint.Patient.FullName }
            };
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetPrescriptions()
        {
            var prescriptions = await _databaseContext.Prescriptions.ToListAsync();
            var presDTO = new List<PrescriptionDTO>();
            foreach (var prescription in prescriptions)
            {
                presDTO.Add(new PrescriptionDTO()
                {
                    Quantity = prescription.Quantity,
                    Notes = prescription.Notes,
                    DoctorId = prescription.DoctorId,
                    PatientId = prescription.PatientId
                });
            }
            return presDTO;
        }

        public async Task<PrescriptionDTO> GetPrescriptionById(int id)
        {
            var prescription = await _databaseContext.Prescriptions.FirstOrDefaultAsync(p => p.Id == id);
            PrescriptionDTO presDTO = new PrescriptionDTO()
            {
                Quantity = prescription.Quantity,
                Notes = prescription.Notes,
                DoctorId = prescription.DoctorId,
                PatientId = prescription.PatientId
            };
            return presDTO;
        }

        public async Task<PrescriptionDTO> CreatePrescription(PrescriptionView view)
        {
            var prescription = new Prescription() { Quantity = view.Quantity, Notes = view.Notes, DoctorId = view.DoctorId, PatientId = view.PatientId };
            _databaseContext.Prescriptions.Add(prescription);
            await _databaseContext.SaveChangesAsync();
            PrescriptionDTO presDTO = new PrescriptionDTO()
            {
                Quantity = prescription.Quantity,
                Notes = prescription.Notes,
                DoctorId = prescription.DoctorId,
                PatientId = prescription.PatientId
            };
            return presDTO;
        }
    }
}
