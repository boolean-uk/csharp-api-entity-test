using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
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
        public async Task<IEnumerable<Patient>> GetPatients()
        {
            return await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).ToListAsync();
        }

        public async Task<Patient?> GetPatient(int patientId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Patients.Include(a => a.Appointments).ThenInclude(d => d.Doctor).FirstOrDefaultAsync(s => s.Id == patientId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Patients.FirstOrDefaultAsync(s => s.Id == patientId);
                default:
                    return null;
            }
        }

        public async Task<Patient?> CreatePatient(string fullname)
        {
            if (fullname == "") return null;
            var patient = new Patient { FullName = fullname };
            await _databaseContext.Patients.AddAsync(patient);
            return patient;
        }




        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            return await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(p => p.Patient).ToListAsync();
        }

        public async Task<Doctor?> GetDoctor(int doctorId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Doctors.Include(a => a.Appointments).ThenInclude(p => p.Patient).FirstOrDefaultAsync(s => s.Id == doctorId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Doctors.FirstOrDefaultAsync(s => s.Id == doctorId);
                default:
                    return null;
            }
        }

        public async Task<Doctor?> CreateDoctor(string fullname)
        {
            if (fullname == "") return null;
            var dc = new Doctor { FullName = fullname };
            await _databaseContext.Doctors.AddAsync(dc);
            return dc;
        }





        public async Task<IEnumerable<Appointment>> GetAppointments()
        {
            return await _databaseContext.Appointments.Include(x => x.Doctor).Include(x => x.Patient).ToListAsync();
        }


        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Include(x => x.Patient).Include(x => x.Doctor).Where(a => a.DoctorId == id).ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatient(int id)
        {
            return await _databaseContext.Appointments.Include(x => x.Doctor).Include(x => x.Patient).Where(a => a.PatientId == id).ToListAsync();
        }

        public async Task<Appointment?> GetAppointment(int doctorId, int patientId, PreloadPolicy preloadPolicy = PreloadPolicy.DoNotPreloadRelations)
        {
            switch (preloadPolicy)
            {
                case PreloadPolicy.PreloadRelations:
                    return await _databaseContext.Appointments.Include(x => x.Doctor).Include(x => x.Patient).Where(d => d.DoctorId == doctorId).FirstOrDefaultAsync(s => s.PatientId == patientId);
                case PreloadPolicy.DoNotPreloadRelations:
                    return await _databaseContext.Appointments.Where(d => d.DoctorId == doctorId).FirstOrDefaultAsync(s => s.PatientId == patientId);
                default:
                    return null;
            }
        }

        public async Task<Appointment?> CreateAppointment(int docId, int patId)
        {
            if (docId.GetType() != typeof(int)) return null;
            if (patId.GetType() != typeof(int)) return null;

            var d = _databaseContext.Doctors.FirstOrDefault(x => x.Id == docId);
            var p = _databaseContext.Patients.FirstOrDefault(x => x.Id == patId);

            if(p == null || d == null)
            {
                return null;
            }

            var appo = new Appointment { Booking = DateTime.Now.ToUniversalTime(), DoctorId = docId, Doctor = d, PatientId = patId, Patient = p };
            await _databaseContext.Appointments.AddAsync(appo);
            return appo;
        }

    }
}
