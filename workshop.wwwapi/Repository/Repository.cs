using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using workshop.wwwapi.Data;
using workshop.wwwapi.DTOs;
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

        /// <summary>
        /// Get all the patients
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(p => p.Prescription).ThenInclude(p => p.PrescriptMed).ToListAsync();
        }

        /// <summary>
        /// Get doctors
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(p => p.Prescription).ThenInclude(p => p.PrescriptMed).ToListAsync();
        }


 

        /// <summary>
        /// Get a patient by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Patient> GetPatient(int? id)
        {
            Patient patient = await  _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(p => p.Prescription).ThenInclude(p => p.PrescriptMed).FirstOrDefaultAsync(p => p.Id == id);
            if (patient == null) { throw new Exception("No match id."); }
            return patient; 
        }

        /// <summary>
        /// Get a Doctor by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Doctor> GetADoctor(int? id)
        {
            Doctor doctor = await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(p => p.Prescription).ThenInclude(p => p.PrescriptMed).FirstOrDefaultAsync(d => d.Id == id) ?? throw new ArgumentException("No match for this id");
            return doctor;
        }

        /// <summary>
        /// Add a doctor
        /// </summary>
        /// <param name="newDoctor"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="BadHttpRequestException"></exception>
        public async Task<Doctor> AddDoctor(InnDoctorDTO newDoctor)
        {
            if ( newDoctor.FullName == null) { throw new ArgumentException("Invalid input"); }
            else if (_databaseContext.Doctors.Any(d => d.FullName == newDoctor.FullName))
            {

                throw new BadHttpRequestException("The doctor is already exist");
            }
            else {
                Doctor doctor = new Doctor {
                    FullName = newDoctor.FullName,
                    
                };
                await _databaseContext.AddAsync(doctor);
                await _databaseContext.SaveChangesAsync();
                return doctor;
            }

        }

        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(p => p.Prescription).ThenInclude(p => p.PrescriptMed).ToListAsync();  
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            List<Appointment> appointment = await _databaseContext.Appointments.Include(d => d.Doctor).Include(p => p.Patient).Include(p => p.Prescription).ThenInclude(p => p.PrescriptMed).Where(a => a.DoctorId == id).ToListAsync();
            if (appointment == null) {throw new ArgumentException("No match for this id"); }
            return appointment;
           
        }

        public async Task<Appointment> GetAnAppointment(int id1, int id2)
        {
            Appointment appointment = await _databaseContext.Appointments.Include(d => d.Doctor).Include(p => p.Patient).Include(p => p.Prescription).ThenInclude(p => p.PrescriptMed).FirstOrDefaultAsync(a => a.PatientId == id1 && a.DoctorId == id2);
            if (appointment == null) { throw new ArgumentException("No match for this id"); }
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            List<Appointment> appointment = await _databaseContext.Appointments.Include(d => d.Doctor).Include(p => p.Patient).Include(p => p.Prescription).ThenInclude(p => p.PrescriptMed).Where(a => a.PatientId == id).ToListAsync();
            if (appointment == null) { throw new ArgumentException("No match for this id"); }
            return appointment;

        }

        public async Task<IEnumerable<Prescription>> Getprescriptions()
        {
            return await _databaseContext.Prescriptions.Include(a => a.PrescriptMed).ToListAsync();
        }


        /// <summary>
        /// Add new prescription with existing medicine.
        /// </summary>
        /// <param name="newPrescription"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public async Task<Prescription> AddPrescription(InPrescriptionDTO newPrescription)
        {
            if (newPrescription.MedicineId == 0 /*|| newPrescription.prescriptionMedicineDTO.Where(x => x.Quatity == 0)*/) { throw new ArgumentException("Invalid input"); }

            /*  else if (_databaseContext.Medicines.Any(d => d.Name == newPrescription.Name))
              {

                  throw new BadHttpRequestException("The Med is already exist");
              }*/
            else
            {
                Medicine medicine = await _databaseContext.Medicines.FirstOrDefaultAsync(m => m.Id == newPrescription.MedicineId);
                //List<PrescriptionMedicine>  prescriptMed = new List<PrescriptionMedicine>();
                Prescription prescription = new Prescription()

                {
                    PrescriptMed = new List<PrescriptionMedicine>() {
                    new PrescriptionMedicine() {
                     MedicineId = medicine.Id,
                     Note = newPrescription.Note,
                     Quatity = newPrescription.Quatity
                    } }


                /* new PrescriptionMedicine() { 
                     MedicineId = medicine.Id,
                     Note = newPrescription.Note,
                     Quatity = newPrescription.Quatity

                 };*/


            };

/*
                PrescriptionMedicine prescriptionMedicine = new PrescriptionMedicine() { 
                    MedicineId = medicine.Id,
                    PrescriptionId = prescription.Id,
                    Note = newPrescription.Note,
                    Quatity = newPrescription.Quatity
                };

                await _databaseContext.AddAsync(medicine);*/


                await _databaseContext.AddAsync(prescription);
               // await _databaseContext.AddAsync(prescriptionMedicine);
                await _databaseContext.SaveChangesAsync();
                return prescription;
            }
        }
    }
}



/*Prescription prescription = new();

List<Medicine> medicines = await _context.Medicines
    .Where(m => addDTO.MedicineId.Contains(m.Id))
    .ToListAsync();
if (medicines.Count == 0)
{
    throw new ArgumentException("No medicines with given IDs!");
}
prescription.Medicines = medicines;
await _context.Prescriptions.AddAsync(prescription);
await _context.SaveChangesAsync();
*/