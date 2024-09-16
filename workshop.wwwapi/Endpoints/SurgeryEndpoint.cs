namespace workshop.wwwapi.Endpoints
{
    public static class SurgeryEndpoint
    {
        //TODO:  add additional endpoints in here according to the requirements in the README.md 
        public static void ConfigurePatientEndpoint(this WebApplication app)
        {
            var surgeryGroup = app.MapGroup("surgery");

            surgeryGroup.MapGet("/patients", PatientsEndpoint.GetPatients);
            surgeryGroup.MapGet("/patients/{id}", PatientsEndpoint.GetPatient);
            surgeryGroup.MapPost("/patients", PatientsEndpoint.AddPatient);

            surgeryGroup.MapGet("/doctors", DoctorsEndpoint.GetDoctors);
            surgeryGroup.MapGet("/doctors/{id}", DoctorsEndpoint.GetDoctor);
            surgeryGroup.MapPost("/doctors", DoctorsEndpoint.AddDoctor);

            surgeryGroup.MapGet("/appointmentsbydoctor/{id}", AppointmentsEndpoint.GetAppointmentsByDoctor);
            surgeryGroup.MapGet("/appointmentsbypatient/{id}", AppointmentsEndpoint.GetAppointmentsByPatient);
            surgeryGroup.MapGet("/appointmentbyid", AppointmentsEndpoint.GetAppointmentByIds);
            surgeryGroup.MapPost("/appointments", AppointmentsEndpoint.AddAppointment);
            surgeryGroup.MapGet("/appointments", AppointmentsEndpoint.GetAll);

            surgeryGroup.MapGet("/prescriptions", PrescriptionEndpoint.GetAll);
            surgeryGroup.MapGet("/prescriptions/{id}", PrescriptionEndpoint.Get);
            surgeryGroup.MapPost("/prescriptions", PrescriptionEndpoint.Add);
        }
    }
}
