using System;

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

        public void PrintInfo() //Prints the appointment information
        {
            Console.WriteLine();
            Console.WriteLine("Appointment Info<>");
			Console.WriteLine("Appointment Id: " + appointId);
            Console.WriteLine("Appointment Date: " + appointmentDate.ToString("MM/dd/yyyy"));
            Console.WriteLine("Appointment Time: " + appointmentDate.ToString("hh:mm tt"));
            Console.WriteLine("Patient Name: ");
			Console.WriteLine("Patient Id: " + patientId);
			Console.WriteLine("Physician Name: ");
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
    }
}
