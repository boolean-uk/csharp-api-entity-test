# Instructions

We are going to model the API for a doctor's clinic. The Clinic has Doctors, 
Patients and we need an Appointment system for patients to book appointments with doctors.

The focus of the exercise is on: connecting to an external database; defining models, 
relations and migrations; writing some basic tests and implementing DTOs. 

We have provided some basic scaffolding for you to get started.

## Core Criteria

### Part 1: Database Setup & Patient model

- Create a new database in [Neon](https://neon.tech)
- Install the required Nuget packages
- Create an `appsettings.json` file and Update the db connection string in the app settings.
- Ensure you have configured your gitignore correctly! Do not push your credentials!
- In the DbContext class, load the connection string from the appsettings.json file and make the DB connection.
- Update the `Patient` model to include decorators for the table name, primary key and column names. Make sure to use good naming conventions for postgres.
- Create a migration and push the migration to the remote database; verify the table was created correctly
- Update the db context class and seed 1 or 2 patients with hard-coded ids and names
- Implement the the get all patients, get patient by id and create patient endpoints in the controller; make sure to use DTOs as required for returning the results

### Part 2: Doctor & Appointment models

Add a Doctor model, with the following properties: id, name
Add an Appointments model, with the following properties: patientId, doctorId, appointmentDate
Update the Doctor and Patient models to include a list of appointments; define all the foreign keys and relevant model properties
Ensure the primary key for the Appointments model is a composite key of patientId and doctorId (this is specified in the OnModelCreating method of the DbContext class)
Create a migration and push the migration to the remote database; verify the tables were created correctly
Update the db context class and seed 2 doctors with hard-coded ids and names; create a few appointments for each doctor with some patients

### Part 3: Doctor & Appointment endpoints
Implement get all doctors, get doctor by id and create doctor endpoints in the controller; make sure to use DTOs as required for returning the results
Implement get all appointments, get appointment by id, get appointments by doctor id, get appointments by patient id and create new appointment endpoints in the controller; make sure to use DTOs as required for returning the results
Update all dtos for patient, doctor and appointments to include the relevant loaded fields via the relations:

- a patient should include its appointments and each appointment include the doctor's name / id
- a doctor should include its appointments and each appointment include the patient's name / id
- an appointment should include the patient's name / id and the doctor's name / id

### Part 4: Testing

Write some basic tests for the get all and create one for each of the controller endpoints. The get all should verify the seeded data.

## Extensions

- Create a Medicines model and a Prescription model;
  - Add a many-to-many relationship between the Medicines and Prescription models; Each medicine on the prescription should have a quantity, a notes section for instructions on how to take it
  - Each prescription should be associated to an appointment (and hence linked to a Doctor + Patient)
  - Implement the migration, update the database, seed some medicines and prescriptions
  - Create an endpoint controller to get prescriptions, to create prescriptions and attach to an appointment, etc
- Extend appointments to include the type of appointment: eg if it was in person or online; bonus: use enumerations for the appointment type

## Super Extension

- Implement both a generic IRepository AND Repository. Before you commit to this ensure that you understand the implications of the DbSet Include method on the generic repository!


## Configure Json

Create a new appsettings.json / appsettings.Development.json (see appsettings.Example.json) add the following json and update credentials
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnectionString": "Host=HOST Database=DATABASE; Username=USERNAME; Password=PASSWORD; "
  }
}
```

## Install Nugets (these have all been installed to the WebApi)

- Install the following packages into the WebApi project:
- Install-Package Microsoft.EntityFrameworkCore
- Install-Package Microsoft.EntityFrameworkCore.Tools
- Install-Package Microsoft.EntityFrameworkCore.Design
- Install-Package NpgSql.EntityFrameworkCore.PostgreSql

## Migrations
- `Add-Migration MIGRATION_NAME`
- `Update-Database`


## Test Project

Examine the test project.  This is a a standard NUnit Test project (`dotnet new nunit --name workshop.tests`) with the additional package:

Install-Package Microsoft.Aspnecore.Mvc.Testing

