using System;
using System.Collections.Generic;
using System.Linq;

namespace CLI.MedPracManagement
{
    public class Physician
    {
        private static int nextId = 1000001; //Keeps track of the next physician's id
        public int physicianId;
        private string? physicianName;
        private string? physicianNumber;
        private DateTime graduationDate; 
        private List<string> physicianSpecializations = new List<string>(); //List that stores all the physician's specializations

        public Physician() //Physician Constructor
        {
            physicianId = nextId++; //Sets for current physician and icnrements for the next physician
            Console.Write("What is the physician's name?: ");
            string? name = Console.ReadLine();
            physicianName = name;
            Console.Write("What is the physician's number?: ");
            string? phyNumber = Console.ReadLine();
            physicianNumber = phyNumber;
            Console.Write("What was the physician's graduation date?: ");
            DateTime gradDate;
            while(!DateTime.TryParse(Console.ReadLine(), out gradDate)) //While date is not in valid format
            {
                Console.WriteLine("Invalid format. Please enter date as yyyy-MM-dd.");
            }
            graduationDate = gradDate;
            Console.WriteLine("What are the physician's specializations? (Seperate each specialization with a comma)");
            Console.Write("Specializations: ");
            string? specializationsInput = Console.ReadLine();
            if(!string.IsNullOrEmpty(specializationsInput)) //If specializations input is not null, it adds the splits the string and adds it to the physicians specializations List.
            {
                string[] specializations = specializationsInput.Split(",");

                foreach(string specialization in specializations) //Adds each specialization in the physicianSpecializations list
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


        public void ReadPhysician() //Method that prints out the physician's information
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

        public override string ToString() //Prints this out when physicians.ForEach(Console.WriteLine()) is called
        {
            return $"{physicianId}. {physicianName}";

        }

        public string GetName() //Returns the physician's name
        {
            return physicianName;

        }

        public void UpdateName() //Method that allows the user to update the physician's name
        {
            Console.Write("Enter new physician name: ");
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input)) //If the input is not empty or spaces
            {
                physicianName = input;
                Console.WriteLine("Physician name updated!");
            }
            else
            {
                Console.WriteLine("Invalid input. Name not changed.");
            }
        }

        public void UpdateNumber() //Method that allows the user to update the physician's number
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

        public void UpdateGraduationDate() //Method that allows the user to update the physician's graduation date
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

        public void UpdateSpecializations() //Method that lets the user update the physician's specializations
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

