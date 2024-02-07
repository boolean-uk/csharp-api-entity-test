using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.Models.Types;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _db;
        public Repository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _db.Patients
                .Include(p => p.Appointments).ThenInclude(a => a.Doctor)
                .Include(p => p.Appointments).ThenInclude(a => a.Prescription).ThenInclude(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine)
                .ToListAsync();
        }

        public async Task<Patient?> GetPatient(int id)
        {
            return await _db.Patients
                .Include(p => p.Appointments).ThenInclude(a => a.Doctor)
                .Include(p => p.Appointments).ThenInclude(a => a.Prescription).ThenInclude(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _db.Doctors
                .Include(d => d.Appointments).ThenInclude(a => a.Patient)
                .Include(p => p.Appointments).ThenInclude(a => a.Prescription).ThenInclude(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine)
                .ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int id)
        {
            return await _db.Doctors
                .Include(d => d.Appointments).ThenInclude(a => a.Patient)
                .Include(p => p.Appointments).ThenInclude(a => a.Prescription).ThenInclude(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        /*public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _db.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }*/

        public async Task<IEnumerable<Prescription>> GetPrescriptions()
        {
            return await _db.Prescriptions.Include(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine).ToListAsync();
        }

        public async Task<Prescription?> GetPrescription(int id)
        {
            return await _db.Prescriptions.Include(p => p.MedicinePrescriptions).ThenInclude(mp => mp.Medicine).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Prescription?> CreatePrescription(PostPrescription prescription)
        {
            var medicinePrescriptions = new List<MedicinePrescription>();
            foreach (var mp in prescription.MedicinePrescriptions)
            {
                var medicine = await _db.Medicines.FirstOrDefaultAsync(m => m.Id == mp.MedicineId);
                if (medicine == null) return null;
                medicinePrescriptions.Add(new MedicinePrescription()
                {
                    Medicine = medicine,
                    Quantity = mp.Quantity,
                    Instructions = mp.Instructions,
                });
            }
            var newPrescription = new Prescription() { Name = prescription.Name, MedicinePrescriptions = medicinePrescriptions };
            await _db.Prescriptions.AddAsync(newPrescription);
            await _db.SaveChangesAsync();
            return newPrescription;
        }
    }
}
