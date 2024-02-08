using Microsoft.EntityFrameworkCore;
using workshop.wwwapi.Data;
using workshop.wwwapi.Models;
using workshop.wwwapi.StatusPayloads;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using workshop.wwwapi.DTO.Server;
using workshop.wwwapi.DTO.Client;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Security.Cryptography.Xml;
using Microsoft.EntityFrameworkCore.Storage;

namespace workshop.wwwapi.Repository
{
    public class Repository : IRepository
    {
        private DatabaseContext _databaseContext;
        public Repository(DatabaseContext db)
        {
            _databaseContext = db;
        }
        public async Task<IEnumerable<Patient_server_dto>> GetPatients()
        {
            List<Patient> patients = await _databaseContext.Patients.ToListAsync();
            IEnumerable<Patient_server_dto> patientDto = patients.Select(x => new Patient_server_dto
            {
                FullName = x.FullName
            });
            return patientDto;
        }

        public async Task<Payload<patientAndDoctor_dto>> GetAPatient(int id) 
        {
            Patient? patient = await _databaseContext.Patients.Include(p => p.Appointments).ThenInclude(a => a.Doctor).FirstOrDefaultAsync(x => x.Id == id);
            if (patient != null) 
            {
                patientAndDoctor_dto dto = new patientAndDoctor_dto
                {
                    FullName = patient.FullName,
                    appointments = patient.Appointments.Select(x => new patientAndDoctorAppointments
                    {
                        DoctorName = x.Doctor.FullName,
                        Date = x.Booking
                    })
                };

                Payload<patientAndDoctor_dto> payload = new Payload<patientAndDoctor_dto>()
                {
                    StatusCode = HttpStatusCode.OK,
                    data = dto
                };
                return payload;
            }
            Payload<patientAndDoctor_dto> errorResponse = new Payload<patientAndDoctor_dto>()
            {
                StatusCode = HttpStatusCode.NotFound,
                data = new patientAndDoctor_dto()
            };
            return errorResponse;
        }

        public async Task<Payload<doctorAndPatient>> GetADoctor(int id) 
        {
            Doctor? doctor = await _databaseContext.Doctors.Include(d => d.Appointments).ThenInclude(a => a.Patient).FirstOrDefaultAsync(x => x.Id == id);
            if (doctor != null)
            {
                doctorAndPatient doctorAndPatient = new doctorAndPatient()
                {
                    FullName = doctor.FullName,
                    appointments = doctor.Appointments.Select(x => new doctorAndPatientAppointment
                    {
                        PatientName = x.Patient.FullName,
                        Date = x.Booking
                    })
                };
                Payload<doctorAndPatient> payload = new Payload<doctorAndPatient>()
                {
                    StatusCode = HttpStatusCode.OK,
                    data = doctorAndPatient
                };
                return payload;
            }
            Payload<doctorAndPatient> errorResponse = new Payload<doctorAndPatient>()
            {
                StatusCode = HttpStatusCode.NotFound,
                data = new doctorAndPatient()
            };
            return errorResponse;
        }

        public async Task<Patient_server_dto> CreatePatient(patient_client_dto patientInfo) 
        {
            Patient patient = new Patient()
            {
                FullName = patientInfo.FullName
            };
            await _databaseContext.Patients.AddAsync(patient);
            await _databaseContext.SaveChangesAsync();
            Patient_server_dto dto = new Patient_server_dto()
            {
                FullName = patient.FullName
            };
            return dto;
        }

        public async Task<createDoctor_dto> CreateDoctor(createDoctor_dto doctorInfo)
        {
            Doctor doctor = new Doctor()
            {
                FullName = doctorInfo.FullName
            };
            await _databaseContext.Doctors.AddAsync(doctor);
            await _databaseContext.SaveChangesAsync();
            createDoctor_dto dto = new createDoctor_dto()
            {
                FullName = doctor.FullName
            };
            return dto;
        }


        public async Task<IList<doctor_server_dto>> GetDoctors()
        {           
            IList<doctor_server_dto> doctors = await _databaseContext.Doctors.Select(x => new doctor_server_dto
            {
                FullName = x.FullName
            }).ToListAsync();
            return doctors;
        }
        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctor(int id)
        {
            return await _databaseContext.Appointments.Where(a => a.DoctorId==id).ToListAsync();
        }    
        
        public async Task<IList<appointment_server_dto>> GetAppointments() 
        {
            List<Appointment> appointments = await _databaseContext.Appointments.ToListAsync();
            List<appointment_server_dto> dto = appointments.Select(a => new appointment_server_dto
            {
                DoctorId = a.DoctorId,
                PatientId = a.PatientId,
                Booking = a.Booking,
            }).ToList();
            return dto;
        }

        public async Task<Payload<anAppointment>> GetAnAppointment(int doctorId, int patientId)
        {
            Appointment? appointment = await _databaseContext.Appointments.Include(a => a.Patient)
                .Include(a => a.Doctor)
                .FirstOrDefaultAsync(x => x.PatientId == patientId && x.DoctorId == doctorId);

            if (appointment != null)
            {
                anAppointment dto = new anAppointment
                {
                    Booking = appointment.Booking,
                    DoctorName = appointment.Doctor.FullName,
                    PatientName = appointment.Patient.FullName,
                };

                Payload<anAppointment> payload = new Payload<anAppointment>()
                {
                    StatusCode = HttpStatusCode.OK,
                    data = dto
                };
                return payload;
            }
            Payload<anAppointment> errorResponse = new Payload<anAppointment>()
            {
                StatusCode = HttpStatusCode.NotFound,
                data = new anAppointment()
            };
            return errorResponse;

        }

        public async Task<Payload<List<anAppointment>>> GetApointmentByDoctorId(int id) 
        {
            List<Appointment> appointment = await _databaseContext.Appointments.Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(x => x.DoctorId == id).ToListAsync();

            if (appointment.Any())
            {
                List<anAppointment> dto = appointment.Select(a => new anAppointment
                {
                    Booking = a.Booking,
                    DoctorName = a.Doctor.FullName,
                    PatientName = a.Patient.FullName,
                }).ToList();                

                Payload<List<anAppointment>> payload = new Payload<List<anAppointment>>()
                {
                    StatusCode = HttpStatusCode.OK,
                    data = dto
                };
                return payload;
            }
            Payload<List<anAppointment>> errorResponse = new Payload<List<anAppointment>>()
            {
                StatusCode = HttpStatusCode.NotFound,
                data = new List<anAppointment>()
            };
            return errorResponse;
        }

        public async Task<Payload<List<anAppointment>>> GetApointmentByPatientId(int id)
        {
            List<Appointment> appointment = await _databaseContext.Appointments.Include(a => a.Patient)
                .Include(a => a.Doctor)
                .Where(x => x.PatientId == id).ToListAsync();

            if (appointment.Any())
            {
                List<anAppointment> dto = appointment.Select(a => new anAppointment
                {
                    Booking = a.Booking,
                    DoctorName = a.Doctor.FullName,
                    PatientName = a.Patient.FullName,
                }).ToList();

                Payload<List<anAppointment>> payload = new Payload<List<anAppointment>>()
                {
                    StatusCode = HttpStatusCode.OK,
                    data = dto
                };
                return payload;
            }
            Payload<List<anAppointment>> errorResponse = new Payload<List<anAppointment>>()
            {
                StatusCode = HttpStatusCode.NotFound,
                data = new List<anAppointment>()
            };
            return errorResponse;
        }

        public async Task<List<perscription_server_dto>> GetPerscriptions()
        {
            var perscriptions = await _databaseContext.perscriptions.Include(p => p.medicinPerscriptions)
               .ThenInclude(p => p.Medicine).Include(p => p.Doctor).Include(p => p.Patient).ToListAsync();
           
            List<perscription_server_dto> dto = perscriptions.Select(a => new perscription_server_dto
            {
                Id = a.Id,
                DoctorName = a.Doctor.FullName,
                PatientName = a.Patient.FullName,
                Perscription_Details = a.medicinPerscriptions.Select(m => new perscription_details 
                {
                    Medicine = m.Medicine.Name,
                    Quantity = m.Quantity,
                    Note = m.Note
                }).ToList()               
            }).ToList();

            return dto;
        }
        
        public async Task<Payload<Perscription>> CreatePerscription(perscription_create_dto perscriptionDetails) 
        {
            Perscription perscription = new Perscription()
            {
                Id = _databaseContext.perscriptions.Max(p => p.Id + 1),
                DoctorId = perscriptionDetails.DoctorId,
                PatientId = perscriptionDetails.PatientId,
            };
            await _databaseContext.AddAsync(perscription);            

            List<MedicinPerscription> medicinePerscriptions = new List<MedicinPerscription>();

            foreach (var p in perscriptionDetails.PerscriptionDetails) 
            {
                var medicineExisist = await _databaseContext.Medicines.FirstOrDefaultAsync(m => m.Id == p.MedicineId);
                if (medicineExisist == null) 
                {
                    Payload<Perscription> errorResponse = new Payload<Perscription>()
                    {
                        StatusCode = HttpStatusCode.NotFound,
                        data = new Perscription()
                    };
                    return errorResponse;
                }
                
                MedicinPerscription mp = new MedicinPerscription()
                {
                    PerscriptionId = perscription.Id,
                    medicineid = p.MedicineId,
                    Quantity = p.Quantity,
                    Note = p.Note
                };
                medicinePerscriptions.Add(mp);                               
            }

            await _databaseContext.medicinPerscriptions.AddRangeAsync(medicinePerscriptions);
            await _databaseContext.SaveChangesAsync();
            Payload<Perscription> dto = new Payload<Perscription>()
            {
                StatusCode = HttpStatusCode.OK,
                data = await _databaseContext.perscriptions.FirstAsync(x => x.Id == perscription.Id)
            };
            return dto;
        }
        public bool test() 
        {
            Perscription perscription = new Perscription()
            {
                DoctorId = 1,
                PatientId = 1
            };
            var d = perscription.Id;
            _databaseContext.Add(perscription);
            _databaseContext.SaveChanges();
           
            Debug.WriteLine("IDDDD: " + d);
            /*
            foreach (var p in perscriptions.medicinPerscriptions) 
            {
                Debug.WriteLine(p.Note + ", med: " + p.Medicine.Name);
            }*/
            return true;
        }
    }
}
