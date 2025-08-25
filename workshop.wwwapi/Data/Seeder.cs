using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data;

public class Seeder
{
    private List<string> _firstNames =
    [
        "John", "Jane", "Alice", "Bob", "Charlie", "Diana", "Ethan", "Fiona",
        "George", "Hannah", "Ian", "Julia", "Kevin", "Laura", "Mike", "Nina"
    ];

    private List<string> _lastNames =
    [
        "Smith", "Doe", "Johnson", "Brown", "Williams", "Miller", "Davis", "Wilson",
        "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson"
    ];

    private List<string> _medicalSpecialty =
    [
        "Cardiology", "Dermatology", "Endocrinology", "Gastroenterology", "Hematology", "Neurology", "Oncology",
        "Ophthalmology", "Orthopedics", "Otolaryngology", "Pediatrics", "Psychiatry", "Pulmonology", "Radiology",
        "Rheumatology", "Surgery", "Urology", "Nephrology", "Emergency Medicine",
        "Family Medicine"
    ];

    private List<Patient> _patients = [];
    private List<Doctor> _doctors = [];
    private List<Appointment> _appointments = [];
    private List<Medicine> _medicines =
    [
        new() { Id = 1, Name = "Amoxicillin", Description = "Antibiotic" },
        new() { Id = 2, Name = "Ibuprofen 400mg", Description = "NSAID" },
        new() { Id = 3, Name = "Lisinopril 10mg", Description = "ACE inhibitor" }
    ];

    public Seeder()
    {
        Random random = new Random();

        for (int i = 1; i < 10; i++)
        {
            Patient p = new Patient
            {
                Id = i,
                FullName = $"{_firstNames[random.Next(_firstNames.Count)]} {_lastNames[random.Next(_lastNames.Count)]}"
            };

            _patients.Add(p);
        }

        for (int i = 1; i < 4; i++)
        {
            Doctor d = new Doctor()
            {
                Id = i,
                FullName = $"{_firstNames[random.Next(_firstNames.Count)]} {_lastNames[random.Next(_lastNames.Count)]}"
            };

            _doctors.Add(d);
        }

        for (int i = 1; i < _patients.Count; i++)
        {
            int rngPatient = random.Next(_patients.Count);
            int rngDoc = random.Next(_doctors.Count);

            _appointments.Add(new Appointment
            {
                AppointmentId = i,
                PatientId = _patients[rngPatient].Id,
                DoctorId = _doctors[rngDoc].Id,
                AppointmentDate = DateTime.UtcNow.AddDays(random.Next(1, 30)),
            });
        }
    }

    public List<Patient> Patients => _patients;
    public List<Doctor> Doctors => _doctors;
    public List<Appointment> Appointments => _appointments;
    public List<Medicine> Medicines => _medicines;
}