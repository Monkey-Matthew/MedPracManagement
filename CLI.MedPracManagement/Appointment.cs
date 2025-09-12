using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI.MedPracManagement
{
	public class Appointment
	{
		private static int nextId = 100;
		private int appointId;
		private int patientId;
		private int physicianId;
		private DateTime appointmentDate;

		public Appointment(int patientId, int physicianId, DateTime appointmentDate)
		{
			this.patientId = patientId;
			this.physicianId = physicianId;
			this.appointmentDate = appointmentDate;
			appointId = nextId++;
		}

        public int GetId() //Grabs the id for the appointment
        {
            return appointId;
        }

        public void PrintInfo(List<Patient> patients, List<Physician> physicians)
        {
            Console.WriteLine();
            Console.WriteLine("Appointment Info<>");
            Console.WriteLine("Appointment Id: " + appointId);
            Console.WriteLine("Appointment Date: " + appointmentDate.ToString("MM/dd/yyyy"));
            Console.WriteLine("Appointment Time: " + appointmentDate.ToString("hh:mm tt"));

            // Lookup patient
            Patient? patient = patients.FirstOrDefault(p => p.GetId() == patientId);
            if (patient != null)
                Console.WriteLine("Patient Name: " + patient.GetName());
            else
                Console.WriteLine("Patient not found");

            Console.WriteLine("Patient Id: " + patientId);

            // Lookup physician
            Physician? physician = physicians.FirstOrDefault(d => d.GetId() == physicianId);
            if (physician != null)
                Console.WriteLine("Physician Name: " + physician.GetName());
            else
                Console.WriteLine("Physician not found");

            Console.WriteLine("Physician Id: " + physicianId);
        }


        public DateTime GetDate()
		{
			return appointmentDate;
		}
        public int GetPhysicianId()
        {
            return physicianId;
        }

        public string appointInfoCondensed(List<Patient> patients, List<Physician> physicians)
        {
            string patientName = patients.FirstOrDefault(p => p.GetId() == patientId)?.GetName() ?? "Unknown";
            string physicianName = physicians.FirstOrDefault(d => d.GetId() == physicianId)?.GetName() ?? "Unknown";

            return $"ID:{appointId}. Patient: {patientName} | Physician: {physicianName} | Date: {appointmentDate:MM/dd/yyyy hh:mm tt}";
        }

        public void UpdatePatient(List<Patient> patients)
        {
            patients.ForEach(Console.WriteLine);
            Console.Write("Enter new patient ID: ");
            if (int.TryParse(Console.ReadLine(), out int newPatientId))
            {
                if (patients.Any(p => p.GetId() == newPatientId))
                {
                    patientId = newPatientId;
                    Console.WriteLine("Patient updated successfully!");
                }
                else Console.WriteLine("Patient ID not found. Update canceled.");
            }
            else Console.WriteLine("Invalid input. Update canceled.");
        }

        public void UpdatePhysician(List<Physician> physicians, List<Appointment> allAppointments)
        {
            physicians.ForEach(Console.WriteLine);
            Console.Write("Enter new physician ID: ");
            if (int.TryParse(Console.ReadLine(), out int newPhysicianId))
            {
                var physician = physicians.FirstOrDefault(p => p.GetId() == newPhysicianId);
                if (physician != null)
                {
                    // Check for conflict at current appointment time
                    bool conflict = allAppointments.Any(a =>
                        a.GetDate() == appointmentDate && a.GetPhysicianId() == newPhysicianId && a.GetId() != appointId);

                    if (!conflict)
                    {
                        physicianId = newPhysicianId;
                        Console.WriteLine("Physician updated successfully!");
                    }
                    else
                        Console.WriteLine("This physician already has an appointment at this time. Update canceled.");
                }
                else Console.WriteLine("Physician ID not found. Update canceled.");
            }
            else Console.WriteLine("Invalid input. Update canceled.");
        }

        public void UpdateDate(List<Appointment> allAppointments)
        {
            Console.Write("Enter new appointment date and time (MM/dd/yyyy hh:mm tt): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
            {
                // Check weekend
                if (newDate.DayOfWeek == DayOfWeek.Saturday || newDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    Console.WriteLine("Appointments cannot be on weekends. Update canceled.");
                    return;
                }

                // Check hours
                if (newDate.Hour < 8 || newDate.Hour > 16)
                {
                    Console.WriteLine("Appointments must be between 8 AM and 5 PM. Update canceled.");
                    return;
                }

                // Check conflict
                bool conflict = allAppointments.Any(a =>
                    a.GetDate() == newDate && a.GetPhysicianId() == physicianId && a.GetId() != appointId);

                if (conflict)
                {
                    Console.WriteLine("This physician already has an appointment at that time. Update canceled.");
                    return;
                }

                appointmentDate = newDate;
                Console.WriteLine("Appointment date updated successfully!");
            }
            else
            {
                Console.WriteLine("Invalid date. Update canceled.");
            }
        }

    }
}
