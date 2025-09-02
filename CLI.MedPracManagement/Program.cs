using System;

namespace CLI.MedPracManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>(); //Creats a list to store patients

            while (true) //Repeats itself until user chooses option 9
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("Option 1: Create a patient");
                Console.WriteLine("Option 2: Create a physician");
                Console.WriteLine("Option 3: Create an appointment");
                Console.WriteLine("Option 4: Review a patient's information");
                Console.WriteLine("Option 9: Quit Program");
                Console.WriteLine("-------------------------------------------");

                Console.Write("What option would you like?: ");
                string? input = Console.ReadLine(); //Input reads in either a string or null

                if (int.TryParse(input, out int option)) //Tries parsing the input into an int data type; if successful it
                {                                        //parses to a new declared option variable
                }
                else //If not successful it asks the user to try again
                {
                    Console.WriteLine("Not a valid option. Please try again!");
                    continue;
                }

                switch (option) //Switch statement for the user option
                {
                    case 1: //Creates a new patient
                        patients.Add(new Patient()); 
                        break;
                    case 2:
                        Console.WriteLine("Creating a physician....");
                        break;
                    case 3:
                        Console.WriteLine("Creating an appointment....");
                        break;
                    case 4: //Prints out the user's information
                        ReviewPatient(patients);
                        Console.WriteLine();
                        break;
                    case 9: //Quits the program
                        Console.WriteLine("Quitting Program...");
                        return;
                    default: //Tells the user that the value that they inputted is not valid.
                        Console.WriteLine("Not a valid option. Please try again!");
                        break;
                }
            }

        }

        public static void ReviewPatient(List<Patient> patients)
        {
            Console.Write("Enter patient ID: "); //Prompts the user for the patient id first
            string? inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int id)) //Tries to convert string to an int if successful it stores the int value in id
            {
                Patient? found = patients.FirstOrDefault(p => p.GetId() == id); //Uses a LINQ method to search through the list and looks for the first patient to match the inputted id

                if (found != null) //If patient was found then it prints the patient info
                    found.PrintInfo();
                else
                    Console.WriteLine($"Patient with id {id} was not found.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a number!");
            }
        }
    }
}
