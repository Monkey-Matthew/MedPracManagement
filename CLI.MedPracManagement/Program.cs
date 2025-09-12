using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CLI.MedPracManagement
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Patient> patients = new List<Patient>(); //Creats a list to store patients
            List<Physician> physicians = new List<Physician>();
            List<Appointment> appointments = new List<Appointment>();

            while (true) //Repeats itself until user chooses option 9
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("Option 1: Create a patient");
                Console.WriteLine("Option 2: Create a physician");
                Console.WriteLine("Option 3: Create an appointment");
                Console.WriteLine("Option 4: Review a patient's information");
                Console.WriteLine("Option 5: Review a physician's information");
                Console.WriteLine("Option 6: Review an appointment");
                Console.WriteLine("Option 7: Update a patient's information");
                Console.WriteLine("Option 8: Update a physician's information");
                Console.WriteLine("Option 9: Update an appointment's information");
                Console.WriteLine("Option 10: Delete a patient");
                Console.WriteLine("Option 11: Delete a physician");
                Console.WriteLine("Option 12: Delete an appointment");
                Console.WriteLine("Option 13: Quit Program");
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
                        physicians.Add(new Physician());
                        break;
                    case 3:
                        int patientId = -1;
                        int physicianId = -1;
                        while (true)
                        {
                            Console.WriteLine("What is the physician's Id");
                            string? inputPhysicianId = Console.ReadLine();
                            if (int.TryParse(inputPhysicianId, out int finalPhysicianId)) //Tries to convert string to an int if successful it stores the int value in id
                            {
                                Physician? found = physicians.FirstOrDefault(p => p.GetId() == finalPhysicianId); //Uses a LINQ method to search through the list and looks for the first patient to match the inputted id

                                if (found != null) //If patient was found then it prints the patient info
                                {
                                    physicianId = finalPhysicianId;
                                    break;
                                }
                                else
                                    Console.WriteLine($"Patient with id {inputPhysicianId} was not found.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter a number!");
                            }
                        }
                        while(true)
                        {
                            Console.WriteLine("What is the patients's Id");
                            string? inputPatientId = Console.ReadLine();
                            if (int.TryParse(inputPatientId, out int finalPatientId)) //Tries to convert string to an int if successful it stores the int value in id
                            {
                                Patient? found = patients.FirstOrDefault(p => p.GetId() == finalPatientId); //Uses a LINQ method to search through the list and looks for the first patient to match the inputted id

                                if (found != null) //If patient was found then it prints the patient info
                                {
                                    patientId = finalPatientId;
                                    break;
                                }
                                    
                                else
                                    Console.WriteLine($"Patient with id {inputPatientId} was not found.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid ID. Please enter a number!");
                            }
                        }
                        Console.WriteLine("What is the Date and Time of the appointment Ex:(10/20/2026 9:30 AM)");
                        DateTime appointmentDate;
                        while (true)
                        {
                            string? dateInput = Console.ReadLine();

                            if (DateTime.TryParse(dateInput, out appointmentDate))
                            {
                                //Check if its not the weekend
                                if (appointmentDate.DayOfWeek == DayOfWeek.Saturday || appointmentDate.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    Console.WriteLine("Appointments cannot be scheduled on weekends. Try again: ");
                                    continue;
                                }

                                // Check between 8 AM and 5 PM
                                if(appointmentDate.Hour < 8 || appointmentDate.Hour > 16)
                                {
                                    Console.WriteLine("Appointments must be between 8:00 AM and 5:00 PM. Try again: ");
                                    continue;
                                }

                                bool conflict = appointments.Any(appt =>
                                appt.GetDate() == appointmentDate &&
                                appt.GetPhysicianId() == physicianId);

                                if (conflict)
                                {
                                    Console.WriteLine("This physician already has an appointment at that time. Try again: ");
                                    continue;
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Try again: ");
                            }
                        }
                        appointments.Add(new Appointment(patientId, physicianId, appointmentDate));
                        break;
                    case 4: //Prints out the patient's information
                        ReviewPatient(patients);
                        Console.WriteLine();
                        break;
                    case 5: //Prints out the physician's information
                        ReviewPhysician(physicians);
                        break;
                        Console.WriteLine();
                        break;
                    case 6:
                        ReviewAppointment(appointments, patients, physicians);
                        break;
                    case 7:
                        patients.ForEach(Console.WriteLine);
                        Console.Write("Enter patient ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Patient? patientToUpdate = patients.FirstOrDefault(p => p.GetId() == updateId);
                            if (patientToUpdate != null)
                            {
                                Console.WriteLine("Select the field to update:");
                                Console.WriteLine("1. Name");
                                Console.WriteLine("2. Address");
                                Console.WriteLine("3. Birthdate");
                                Console.WriteLine("4. Race");
                                Console.WriteLine("5. Gender");
                                Console.WriteLine("6. Diagnoses");
                                Console.WriteLine("7. Prescriptions");

                                string? choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1": patientToUpdate.UpdateName(); break;
                                    case "2": patientToUpdate.UpdateAddress(); break;
                                    case "3": patientToUpdate.UpdateBirthdate(); break;
                                    case "4": patientToUpdate.UpdateRace(); break;
                                    case "5": patientToUpdate.UpdateGender(); break;
                                    case "6": patientToUpdate.UpdateDiagnoses(); break;
                                    case "7": patientToUpdate.UpdatePrescriptions(); break;
                                    default: Console.WriteLine("Invalid option."); break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Patient not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case 8:
                        physicians.ForEach(Console.WriteLine);
                        Console.Write("Enter physician ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int phyId))
                        {
                            var physician = physicians.FirstOrDefault(p => p.GetId() == phyId);
                            if (physician != null)
                            {
                                Console.WriteLine("Select field to update:");
                                Console.WriteLine("1. Name");
                                Console.WriteLine("2. Number");
                                Console.WriteLine("3. Graduation Date");
                                Console.WriteLine("4. Specializations");

                                string? choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1": physician.UpdateName(); break;
                                    case "2": physician.UpdateNumber(); break;
                                    case "3": physician.UpdateGraduationDate(); break;
                                    case "4": physician.UpdateSpecializations(); break;
                                    default: Console.WriteLine("Invalid choice."); break;
                                }
                            }
                            else Console.WriteLine("Physician not found.");
                        }
                        else Console.WriteLine("Invalid input.");
                        break;
                    case 9:
                        appointments.ForEach(a => Console.WriteLine(a.appointInfoCondensed(patients, physicians)));
                        Console.Write("Enter appointment ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int apptId))
                        {
                            var appt = appointments.FirstOrDefault(a => a.GetId() == apptId);
                            if (appt != null)
                            {
                                Console.WriteLine("Select field to update:");
                                Console.WriteLine("1. Patient");
                                Console.WriteLine("2. Physician");
                                Console.WriteLine("3. Appointment Date");

                                string? choice = Console.ReadLine();
                                switch (choice)
                                {
                                    case "1": appt.UpdatePatient(patients); break;
                                    case "2": appt.UpdatePhysician(physicians, appointments); break;
                                    case "3": appt.UpdateDate(appointments); break;
                                    default: Console.WriteLine("Invalid choice."); break;
                                }
                            }
                            else Console.WriteLine("Appointment not found.");
                        }
                        else Console.WriteLine("Invalid input.");
                        break;
                    case 10:
                        patients.ForEach(Console.WriteLine);
                        Console.Write("Paitent to Delete (Id): ");
                        //get a seletion from the user
                        var patientSelection = Console.ReadLine();
                        //make the selection an int
                        if (int.TryParse(patientSelection ?? "0", out int patientIntSelection))
                        {
                            //get the blog to delete
                            var patientToDelete = patients
                                //dont consider null blogs
                                .Where(p => p != null)
                                //grab the first one that mathces the blog given id
                                .FirstOrDefault(p => (p?.patientId ?? -1) == patientIntSelection);
                            //remove it!
                            patients.Remove(patientToDelete);
                        }
                        break;
                    case 11:
                        physicians.ForEach(Console.WriteLine);
                        Console.Write("Physicians to Delete (Id): ");
                        //get a seletion from the user
                        var physicianSelection = Console.ReadLine();
                        //make the selection an int
                        if (int.TryParse(physicianSelection ?? "0", out int physicianIntSelection))
                        {
                            //get the blog to delete
                            var physicianToDelete = physicians
                                //dont consider null blogs
                                .Where(p => p != null)
                                //grab the first one that mathces the blog given id
                                .FirstOrDefault(p => (p?.physicianId ?? -1) == physicianIntSelection);
                            //remove it!
                            physicians.Remove(physicianToDelete);
                        }
                        break;
                    case 12:
                        appointments.ForEach(a => Console.WriteLine(a.appointInfoCondensed(patients, physicians)));
                        Console.Write("Appointments to Delete (Id): ");
                        //get a seletion from the user
                        var appointmentSelection = Console.ReadLine();
                        //make the selection an int
                        if (int.TryParse(appointmentSelection ?? "0", out int appointmentIntSelection))
                        {
                            //get the blog to delete
                            var appointmentToDelete = appointments
                                //dont consider null blogs
                                .Where(p => p != null)
                                //grab the first one that mathces the blog given id
                                .FirstOrDefault(a => a?.GetId() == appointmentIntSelection);
                            //remove it!
                            appointments.Remove(appointmentToDelete);
                        }
                        break;
                    case 13: //Quits the program
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

        public static void ReviewPhysician(List<Physician> physicians)
        {
            Console.Write("Enter physician ID: "); //Prompts the user for the patient id first
            string? inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int id)) //Tries to convert string to an int if successful it stores the int value in id
            {
                Physician? found = physicians.FirstOrDefault(p => p.GetId() == id); //Uses a LINQ method to search through the list and looks for the first patient to match the inputted id

                if (found != null) //If patient was found then it prints the patient info
                    found.ReadPhysician();
                else
                    Console.WriteLine($"Patient with id {id} was not found.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a number!");
            }
        }

        public static void ReviewAppointment(List<Appointment> appointments, List<Patient> patients, List<Physician> physicians)
        {
            Console.Write("Enter appointment ID: ");
            string? inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int id))
            {
                Appointment? found = appointments.FirstOrDefault(a => a.GetId() == id);

                if (found != null)
                    found.PrintInfo(patients, physicians); // pass in both lists
                else
                    Console.WriteLine($"Appointment with id {id} was not found.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a number!");
            }
        }

    }
}
