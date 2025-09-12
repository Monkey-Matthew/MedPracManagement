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

    }
}
