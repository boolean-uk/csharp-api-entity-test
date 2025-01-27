
- [X] Create a new database in Neon *(Using local postgresql instead)*
- [X] Install the required Nuget packages
- [X] Create an appsettings.json file and Update the db connection string in the app settings.
- [X] Ensure you have configured your gitignore correctly! Do not push your credentials!
- [X] In the DbContext class, load the connection string from the appsettings.json file and make the DB connection.
- [X] Update the Patient model to include decorators for the table name, primary key and column names. Make sure to use good naming conventions for postgres.
- [X] Create a migration and push the migration to the remote database; verify the table was created correctly
- [X] Update the db context class and seed 1 or 2 patients with hard-coded ids and names
- [X] Implement the the get all patients, get patient by id and create patient endpoints in the controller; make sure to use DTOs as required for returning the results

- [X] Add a Doctor model, with the following properties: id, name 
- [X] Add an Appointments model, with the following properties: patientId, doctorId, appointmentDate 
- [X] Update the Doctor and Patient models to include a list of appointments; 
  - [X] define all the foreign keys and relevant model properties 
  - [X] Ensure the primary key for the Appointments model is a composite key of patientId and doctorId (this is specified in the OnModelCreating method of the DbContext class) 
- [X] Create a migration and push the migration to the remote database; 
  - [X] verify the tables were created correctly 
  - [X] Update the db context class and seed 2 doctors with hard-coded ids and names; 
- [X] create a few appointments for each doctor with some patients
  

- [X] Implement API for Doctor; 
  - [X] get all doctors, 
  - [X] get doctor by id 
  - [X] create doctor; 
  - [X] make sure to use DTOs as required for returning the results
- [ ]  Implement API for Appointments; 
  - [X]  get all appointments 
  - [X]  get appointment by id 
  - [X]  get appointments by doctor id
  - [X]  get appointments by patient id 
  - [X]  create new appointment;
  - [X]  make sure to use DTOs as required for returning the results 
- [X]  Update all dtos (to include the relevant loaded fields via the relations) for : 
  - [X]  patient 
    - [X] a patient should include its appointments and each appointment include the doctor's name / id
  - [X]  doctor 
    - [X] a doctor should include its appointments and each appointment include the patient's name / id
  - [X]  appointments
    - [X] an appointment should include the patient's name / id and the doctor's name / id

- [ ] Write some basic tests (one for each of the controller endpoints, to verify the seeded data) for : 
  - [ ] get all 
  - [ ] create 


# Extensions 

- [ ] Create a Medicines model and a Prescription model;
- [ ] Add a many-to-many relationship between the Medicines and Prescription models; 
  - [ ] Each medicine on the prescription should have a quantity, a notes section for instructions on how to take it
  - [ ] Each prescription should be associated to an appointment (and hence linked to a Doctor + Patient)
- [ ] Implement the migration, update the database, seed some medicines and prescriptions
- [ ] Create an endpoint controller to get prescriptions, to create prescriptions and attach to an appointment, etc
- [ ] Extend appointments to include the type of appointment: eg if it was in person or online; bonus: use enumerations for the appointment type


# Super extension
- [ ] Implement both a generic IRepository AND Repository. Before you commit to this ensure that you understand the implications of the DbSet Include method on the generic repository!