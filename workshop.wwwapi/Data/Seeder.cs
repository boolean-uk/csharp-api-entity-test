using System;
using workshop.wwwapi.Models;

namespace workshop.wwwapi.Data
{
    public static class Seeder
    {
        private static List<Doctor> _doctor = new List<Doctor>()
        {
            new Doctor() {Id = 1, FullName = "Aksel Saugestad"},
            new Doctor() {Id = 2, FullName = "Nigel Nigelsen"}
        };

        public static List<Doctor> Doctors { get { return _doctor; } }

        private static List<Patient> _patient = new List<Patient>()
        {
            new Patient() {Id = 1, FullName = "God"},
            new Patient() {Id = 2, FullName = "Patient Patientson"}
        };
        private static DateTime _time = new DateTime(2025, 1, 27, 10, 1, 00).ToUniversalTime();

        public static List<Patient> Patients { get { return _patient; } }

        private static List<Appointment> _appointment = new List<Appointment>()
        {
            new Appointment() {id = 1, Booking = _time, DoctorId = 1, PatientId = 1, AppointmentType = "Person"},
            new Appointment() {id = 2, Booking = _time, DoctorId = 1, PatientId = 2, AppointmentType = "Person"},
            new Appointment() {id = 3, Booking = _time, DoctorId = 2, PatientId = 1, AppointmentType = "Person"},
            new Appointment() {id = 4, Booking = _time, DoctorId = 2, PatientId = 2, AppointmentType = "Online"}
        };

        public static List<Appointment> Appointments { get { return _appointment; } }

    }
}
