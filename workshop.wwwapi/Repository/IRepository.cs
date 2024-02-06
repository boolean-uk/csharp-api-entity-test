using workshop.wwwapi.Models.JunctionTable;
using workshop.wwwapi.Models.PureModels;

namespace workshop.wwwapi.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Retrieve a list of all patients in the database
        /// </summary>
        /// <returns> IEnumerable of Patient objects</returns>
        Task<IEnumerable<Patient>> GetPatients();

        /// <summary>
        /// Create a new patient object
        /// </summary>
        /// <param name="patient">The patient object to be stored in the database</param>
        /// <returns>Patient object that was added to the database</returns>
        Task<Patient> PostPatient(Patient patient);

        /// <summary>
        /// Retrieve a specific patient based on their Id
        /// </summary>
        /// <param name="id">int - the Id of the patient to be retrieved</param>
        /// <returns>The patient that matched the provided Id, null if not found</returns>
        Task<Patient?> GetPatientById(int id);

        /// <summary>
        /// Retrieve a list of all doctors in the database
        /// </summary>
        /// <returns>IEnumerable of Doctor objects</returns>
        Task<IEnumerable<Doctor>> GetDoctors();

        /// <summary>
        /// Retrieve a specfici doctor based on their Id
        /// </summary>
        /// <param name="id">int - the Id of the doctor to be retrieved</param>
        /// <returns>The doctor that matches the provided Id, null if not found</returns>
        Task<Doctor?> GetSpecificDoctor(int id);

        /// <summary>
        /// Create a new doctor object
        /// </summary>
        /// <param name="doctorInput">The doctor object to be stored in the database</param>
        /// <returns>Doctor object that was added to the database</returns>
        Task<Doctor> PostDoctor(Doctor doctorInput);

        /// <summary>
        /// Retrieve a list of all appointents in the database
        /// </summary>
        /// <returns>IEnumerable of Appointment objects</returns>
        Task<IEnumerable<Appointment>> GetAppointments();

        /// <summary>
        /// Retrieve a list of all appointments that is registered to a specific doctor
        /// </summary>
        /// <param name="id">int - the Id of the doctor to retrieve appointments for</param>
        /// <returns>IEnumerable of Appointment objects</returns>
        Task<IEnumerable<Appointment>> GetAppointmentsForDoctors(int id);

        /// <summary>
        /// Retrieve a list of all appointments that is registered to a specific patient
        /// </summary>
        /// <param name="id">int - the Id of the patient to retrieve appointments for</param>
        /// <returns>IEnumerable of Appointment objects</returns>
        Task<IEnumerable<Appointment>>  GetAppointmentsForPatients(int id);

        /// <summary>
        /// Retrieve a list of all appointments that is registered to a specific doctor-patient combination
        /// </summary>
        /// <param name="doctorId">int - the Id of the doctor to retrieve appointments for</param>
        /// <param name="patientId">int - the Id of the doctor to retrieve appointments for</param>
        /// <returns>IEnumerable of Appointment objects</returns>
        Task<IEnumerable<Appointment>> GetAppointmentsByIds(int doctorId, int patientId);

        /// <summary>
        /// Retrieve a specific appointment that is registered in the database
        /// </summary>
        /// <param name="id">int - the Id of the appointment to retrieve</param>
        /// <returns>Appointment object retrieved from the database, null if none found</returns>
        Task<Appointment?> GetAppointmentByAppointmentId(int id);

        /// <summary>
        /// Create a new appointment in the database
        /// </summary>
        /// <param name="appointment">The appointment to add to the database</param>
        /// <returns>Appointment object that was added to the database</returns>
        Task<Appointment> PostAppointment(Appointment appointment);

        /// <summary>
        /// Retrieve a list of all Prescription objects in the database
        /// </summary>
        /// <returns>IEnumerable of Prescription objects</returns>
        Task<IEnumerable<Prescription>> GetPrescriptions();

        /// <summary>
        /// Retrieve a specific prescription based on its unique id
        /// </summary>
        /// <param name="id">Int - the id of the prescription to retrieve</param>
        /// <returns>The prescription object with corresponding id, null if no prescription of provided id found</returns>
        Task<Prescription?> GetSpecificPrescription(int id);

        /// <summary>
        /// Retrieve a list of all Medicine objects in the database
        /// </summary>
        /// <returns>IEnumerable of Medicine objects</returns>
        Task<IEnumerable<Medicine>> GetMedicines();

        /// <summary>
        /// Retrieve a specific Medicine object from the database
        /// </summary>
        /// <param name="id">int - the id of the medicine to retrieve</param>
        /// <returns>The Medicine object with corresponding id, null if no medicine of the provided id was found</returns>
        Task<Medicine?> GetMedicine(int id);

        /// <summary>
        /// Create a new Prescription object in the database
        /// </summary>
        /// <param name="prescription">The prescription to add to the database</param>
        /// <returns>The created prescription object</returns>
        Task<Prescription> PostPrescription(Prescription prescription);

        /// <summary>
        /// Create a new PrescriptionMedicine object in the database, a support table to facilitate linking between prescriptions and medicines.
        /// </summary>
        /// <param name="pm">The prescriptionMedicine object to add to the database</param>
        /// <returns>The PrescriptionMedicine object that was saved in the database</returns>
        Task<PrescriptionMedicine> PostPrescriptionMedicine(PrescriptionMedicine pm);
    }
}
