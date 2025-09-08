using System;
using System.Collections.Generic;

namespace CLI.MedPracManagement
{
    public class Physician
    {
        private static int nextId = 1000001;
        private int physicianId;
        private string? physicianName;
        private string? physicianNumber;
        private DateTime graduationDate;
        private List<string> physicianSpecializations = new List<string>();

        public Physician()
        {
            physicianId = nextId++;
            Console.Write("What is the physician's name?: ");
            string? name = Console.ReadLine();
            physicianName = name;
            Console.Write("What is the physician's number?: ");
            string? phyNumber = Console.ReadLine();
            physicianNumber = phyNumber;
            Console.Write("What was the physician's graduation date?: ");
            DateTime gradDate;
            while(!DateTime.TryParse(Console.ReadLine(), out gradDate))
            {
                Console.WriteLine("Invalid format. Please enter date as yyyy-MM-dd.");
            }
            graduationDate = gradDate;
            Console.WriteLine("What are the physician's specializations? (Seperate each specialization with a comma)");
            Console.Write("Specializations: ");
            string? specializationsInput = Console.ReadLine();
            if(!string.IsNullOrEmpty(specializationsInput)) //If diagnoses input is not null, it adds the splits the string and adds it to the patient diagnoses List.
            {
                string[] specializations = specializationsInput.Split(",");

                foreach(string specialization in specializations)
                {
                    physicianSpecializations.Add(specialization);
                }
            }
            else
            {
                physicianSpecializations.Add("None");
            }
            Console.WriteLine("Physician was created successfully!");
            Console.WriteLine("The physician's id is " + physicianId);

        }

        public int GetId() //Grabs the id for the physician
        {
            return physicianId;
        }


        public void ReadPhysician()
        {
            Console.WriteLine("Physician's Name: " + physicianName);
        }

    
    }
}

