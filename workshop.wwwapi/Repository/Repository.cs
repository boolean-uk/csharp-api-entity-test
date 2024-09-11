using Microsoft.EntityFrameworkCore;
using System.Numerics;
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
            var patients = await _databaseContext.Patients.ToListAsync();
            var appointments = await _databaseContext.Appointments.ToListAsync();
            List<PatientDTO> result = new List<PatientDTO>();
            foreach (var patient in patients)
            {
                PatientDTO patientDTO = new PatientDTO(patient.Id, patient.FullName);
                CreatePatientDTO(patient, patientDTO, appointments);
                result.Add(patientDTO);
            }
            return result;
        }

        private void CreatePatientDTO(Patient patient, PatientDTO patientDTO, List<Appointment> appointments)
        {
            var docs = _databaseContext.Doctors.ToList();
            foreach (var appointment in appointments)
            {
                if(appointment.PatientId == patient.Id)
                {
                    var doc = docs.Where(d => appointment.DoctorId == d.Id).FirstOrDefault();
                    PatientAppointmentDTO app = new PatientAppointmentDTO(doc.Id, doc.FullName, appointment.Booking);
                    patientDTO.Appointments.Add(app);
                }
            }
        }

        public async Task<IEnumerable<DoctorDTO>> GetDoctors()
        {
            var doctors = await _databaseContext.Doctors.ToListAsync();
            var appointments = await _databaseContext.Appointments.ToListAsync();
            List<DoctorDTO> result = new List<DoctorDTO>();
            foreach (var doctor in doctors)
            {
                DoctorDTO doctorDTO = new DoctorDTO(doctor.Id, doctor.FullName);
                CreateDoctorDTO(doctor, doctorDTO, appointments);
                result.Add(doctorDTO);
            }
            return result;
        }
        private void CreateDoctorDTO(Doctor doctor, DoctorDTO doctorDTO, List<Appointment> appointments)
        {
            var patients = _databaseContext.Patients.ToList();
            foreach (var appointment in appointments)
            {
                if (appointment.DoctorId == doctor.Id)
                {
                    var pat = patients.Where(d => appointment.PatientId == d.Id).FirstOrDefault();
                    DoctorAppointmentDTO app = new DoctorAppointmentDTO(pat.Id, pat.FullName, appointment.Booking);
                    doctorDTO.Appointments.Add(app);
                }
            }
        }

    


        public async Task<IEnumerable<AppointmentDTO>> GetAllAppointments()
        {
            var appointments = await _databaseContext.Appointments.ToListAsync();
            List<AppointmentDTO> result = new List<AppointmentDTO>();
            foreach (var app in appointments)
            {
                result.Add(CreateAppointmentDTO(app));
            }
            return result;
        }

        private AppointmentDTO CreateAppointmentDTO(Appointment app)
        {
            AppointmentDTO ret = new AppointmentDTO();
            ret.booking = app.Booking;
            ret.PatientID = app.PatientId;
            ret.doctorID = app.DoctorId;
            var docName = _databaseContext.Doctors.ToList().Where(d => app.DoctorId == d.Id).FirstOrDefault().FullName;
            var patName = _databaseContext.Patients.ToList().Where(d => app.PatientId == d.Id).FirstOrDefault().FullName;
            ret.PatientName = patName;
            ret.doctorName = docName;
            if (app.type == AppointmentType.online)
            {
                ret.type = "Online";
            }
            else if (app.type == AppointmentType.inPerson)
            {
                ret.type = "In person";
            }
            return ret;
        }

        public async Task<AppointmentDTO> GetAppointment(int id)
        {
            var appointment = await _databaseContext.Appointments.SingleOrDefaultAsync(a => a.Id == id);
            if (appointment == null)
            {
                return null;
            }
            return CreateAppointmentDTO(appointment);
        }

        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByPatient(int id)
        {
            var patient = await _databaseContext.Patients.FindAsync(id);
            if (patient == null)
            {
               
                return null;
            }
            var appointments = await _databaseContext.Appointments.ToListAsync();
            
            List<AppointmentDTO> result = new List<AppointmentDTO>();

            foreach (var appointment in appointments)
            {
                if (appointment.PatientId == id)
                {
                    result.Add(CreateAppointmentDTO(appointment));
                }
            }
            return result;
        }

        public async Task<AppointmentDTO> CreateAppointment( int docId, int patientId)
        {
            var doctor = await _databaseContext.Doctors.FindAsync(docId);
            if (doctor == null)
            {
                return null;
            }
            var patient = await _databaseContext.Patients.FindAsync(patientId);
            if (patient == null)
            {
                return null;
            }
            Appointment appointment = new Appointment();
            appointment.PatientId = patientId;
            DateTime now = DateTime.Now;
            appointment.Booking = now.ToUniversalTime();
            appointment.DoctorId = docId;

            _databaseContext.Appointments.Add(appointment);
            _databaseContext.SaveChangesAsync();
            AppointmentDTO ret = CreateAppointmentDTO(appointment);
            return ret;
        }


        public async Task<IEnumerable<AppointmentDTO>> GetAppointmentsByDoctor(int id)
        {
            var doctor = await _databaseContext.Doctors.FindAsync(id);
            if (doctor == null)
            {
                return null;
            }
            var appointments = await _databaseContext.Appointments.ToListAsync();

            List<AppointmentDTO> result = new List<AppointmentDTO>();

            foreach (var appointment in appointments)
            {
                if (appointment.DoctorId == id)
                {
                    result.Add(CreateAppointmentDTO(appointment));
                }
            }
            return result;
        }
        public async Task<bool> CheckExists(int type, int id) 
        {
            if (type == 0) //doctor
            {
                var existingDoctorIds = await _databaseContext.Doctors
                    .Where(a => id.Equals(a.Id))
                    .Select(a => a.Id)
                    .ToListAsync();

                return existingDoctorIds.Count == 1;
            }
            else if (type == 1) //patient
            {
                var existingPatientIds = await _databaseContext.Patients
                        .Where(a => id.Equals(a.Id))
                        .Select(a => a.Id)
                        .ToListAsync();

                return existingPatientIds.Count == 1;
            }
            else if(type == 2)//prescription
            {
                var existingPrescriptionIds = await _databaseContext.Prescriptions
                        .Where(a => id.Equals(a.Id))
                        .Select(a => a.Id)
                        .ToListAsync();

                return existingPrescriptionIds.Count == 1;
            }
            else if(type == 3)//appointment
            {
                var existingAppointmentIds = await _databaseContext.Appointments
                                        .Where(a => id.Equals(a.Id))
                                        .Select(a => a.Id)
                                        .ToListAsync();

                return existingAppointmentIds.Count == 1;
            }
            else if (type == 4)//medince
            {
                var existingMedicineIds = await _databaseContext.Medicines
                                        .Where(a => id.Equals(a.Id))
                                        .Select(a => a.Id)
                                        .ToListAsync();

                return existingMedicineIds.Count == 1;
            }
            return false;
        }

        public async Task<DoctorDTO> AddDoctor(string firstName, string lastName)
        {
            Doctor doc = new Doctor();
            doc.FullName = firstName + " " + lastName;
            _databaseContext.Doctors.Add(doc);
            await _databaseContext.SaveChangesAsync();
            DoctorDTO ret = new DoctorDTO(doc.Id, doc.FullName);
            return ret;
        }

        public async Task<PatientDTO> AddPatient(string firstName, string lastName)
        {
            Patient pat = new Patient();
            pat.FullName = firstName + " " + lastName;
            _databaseContext.Patients.Add(pat);
            await _databaseContext.SaveChangesAsync();
            PatientDTO ret = new PatientDTO(pat.Id, pat.FullName);
            return ret;
        }

        public async Task<PrescriptionDTO> CreatePrescription(int appointmentId, List<int> medicinIds)
        {
            Prescription prescription = new Prescription();
            _databaseContext.Prescriptions.Add(prescription);
            await _databaseContext.SaveChangesAsync();
            
            var per = await _databaseContext.Prescriptions.Include(p => p.PrescriptionMedicines).ThenInclude(pm => pm.Medicine).Where(p => p.Id == _databaseContext.Prescriptions.Count()).FirstOrDefaultAsync();
            var app = await _databaseContext.Appointments.Where(a => a.Id == appointmentId).FirstOrDefaultAsync();

            _databaseContext.Appointments.Remove(app);
            await _databaseContext.SaveChangesAsync();

            app.PrescriptionId = per.Id;
            await _databaseContext.Appointments.AddAsync(app);
            await _databaseContext.SaveChangesAsync();

            

            foreach (var med in medicinIds)
            {
                PrescriptionMedicine pre = new PrescriptionMedicine();
                pre.PrescriptionId = appointmentId;
                pre.MedicineId = med;
                pre.Medicine = _databaseContext.Medicines.FirstOrDefault(m => m.Id == med);
                pre.Prescription = _databaseContext.Prescriptions.FirstOrDefault(p => p.Id == prescription.Id);
                _databaseContext.PrescriptionMedicines.Add(pre);
                await _databaseContext.SaveChangesAsync();

            }
           

            PrescriptionDTO retValue = new PrescriptionDTO();
            retValue.appointmentId = appointmentId;
            MakePrescriptionDTO(prescription, retValue);

            

            return retValue;

        }

        private void MakePrescriptionDTO(Prescription prescription, PrescriptionDTO ret)
        {
            foreach (var item in prescription.PrescriptionMedicines)
            {
                ret.MedicinID.Add(item.MedicineId);
                MedicineDTO dto = new MedicineDTO();
                dto.prescriptionId = item.PrescriptionId;
                dto.Quantity = item.Medicine.Quantity;
                dto.Instruction = item.Medicine.Instruction;
                dto.Name = item.Medicine.Name;
                ret.Medicines.Add(dto);
            }
        }

        public async Task<PrescriptionDTO> GetPrescription(int id)
        {

            var prescription = await _databaseContext.Prescriptions.Include(p => p.PrescriptionMedicines).ThenInclude(pm => pm.Medicine).Where(p => p.Id == id).FirstOrDefaultAsync();
            if (prescription == null)
            {

                return null;
            }
            PrescriptionDTO prescriptionDTO = new PrescriptionDTO();
            MakePrescriptionDTO(prescription, prescriptionDTO);
            return prescriptionDTO;
        }

        public async Task<IEnumerable<PrescriptionDTO>> GetPrescriptions()
        {
            var prescriptions = await _databaseContext.Prescriptions.Include(p => p.PrescriptionMedicines).ThenInclude(pm => pm.Medicine).ToListAsync();
            List<PrescriptionDTO> result = new List<PrescriptionDTO>();
            foreach (var pre in prescriptions)
            {
                PrescriptionDTO add = new PrescriptionDTO();
                MakePrescriptionDTO(pre, add);
                result.Add(add);
            }
            return result;
        }
    }
}
