using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI.MedPracManagement
{
    public class Physician
    {
        private static int nextId = 1000001;
        public int physicianId;
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
            Console.WriteLine("Physician's Number: " + physicianNumber);
            Console.WriteLine("Physician's Grad Date: " + graduationDate);
            Console.Write("Physician's Specializations: ");
            foreach (string specialization in physicianSpecializations)
            {
                Console.Write($"{specialization} ");
            }
        }

        public override string ToString()
        {
            return $"{physicianId}. {physicianName}";

        }

        public string GetName()
        {
            return physicianName;

        }

        // --- Update Methods ---
        public void UpdateName()
        {
            Console.Write("Enter new physician name: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                physicianName = input;
                Console.WriteLine("Physician name updated!");
            }
            else
            {
                Console.WriteLine("Invalid input. Name not changed.");
            }
        }

        public void UpdateNumber()
        {
            Console.Write("Enter new physician number: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                physicianNumber = input;
                Console.WriteLine("Physician number updated!");
            }
            else
            {
                Console.WriteLine("Invalid input. Number not changed.");
            }
        }

        public void UpdateGraduationDate()
        {
            Console.Write("Enter new graduation date (yyyy-MM-dd): ");
            string? input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime newDate))
            {
                graduationDate = newDate;
                Console.WriteLine("Graduation date updated!");
            }
            else
            {
                Console.WriteLine("Invalid date. Graduation date not changed.");
            }
        }

        public void UpdateSpecializations()
        {
            Console.Write("Enter new specializations (comma-separated, or 'none'): ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                physicianSpecializations.Clear();
                if (input.ToLower().Trim() == "none")
                {
                    physicianSpecializations.Add("None");
                }
                else
                {
                    physicianSpecializations.AddRange(input.Split(',').Select(s => s.Trim()));
                }
                Console.WriteLine("Specializations updated!");
            }
            else
            {
                Console.WriteLine("No input. Specializations not changed.");
            }
        }
    }
}

