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
            List<Patient> patients = new List<Patient>(); //Creates a list to store patients
            List<Physician> physicians = new List<Physician>(); //Creates a list to store physicians
            List<Appointment> appointments = new List<Appointment>(); //Creates a list to store appointments

            while (true) //Repeats itself until user chooses option 13
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("Option 1: Patient Menu");
                Console.WriteLine("Option 2: Physician Menu");
                Console.WriteLine("Option 3: Appointment Menu");
                Console.WriteLine("Option 4: Quit Program");
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
                    case 1: //Brings the user to the Patient Menu 
                        PatientMenu(patients);
                        break;
                    case 2: //Brings the user to the Physician Menu
                        PhysicianMenu(physicians);
                        break;
                    case 3: //Brings the user to the Appointment Menu
                        AppointmentMenu(patients, physicians, appointments);
                        break;
                    case 4: //Quits the program
                        Console.WriteLine("Quitting Program...");
                        return;
                    default: //Tells the user that the value that they inputted is not valid.
                        Console.WriteLine("Not a valid option. Please try again!");
                        break;
                }
            }

        }

        public static void PatientMenu(List<Patient> patients)
        {
            while (true) //Repeats itself until user chooses option 13
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("Option 1: Create a patient");
                Console.WriteLine("Option 2: Review a patient's information");
                Console.WriteLine("Option 3: Update a patient's information");
                Console.WriteLine("Option 4: Delete a patient");
                Console.WriteLine("Option 5: Go Back to Main Menu");
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
                        ReviewPatient(patients); //Calls the ReviewPatient method in the Patient Class
                        Console.WriteLine();
                        break;
                    case 3:
                        patients.ForEach(Console.WriteLine); //Prints out all patients in the patient list.
                        Console.Write("Enter patient ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId)) //Tries to parse the input into int data type
                        {
                            Patient? patientToUpdate = patients.FirstOrDefault(p => p.GetId() == updateId); //Finds the first patient that matches the user's inputted number and stores it into patientToUpdate
                            if (patientToUpdate != null) //If patient was found
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
                                switch (choice) //Has the user choose what field to update the patient
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
                            else //Else patient not found
                            {
                                Console.WriteLine("Patient not found.");
                            }
                        }
                        else //Else not an int
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;
                    case 4:
                        patients.ForEach(Console.WriteLine);
                        Console.Write("Paitent to Delete (Id): ");
                        var patientSelection = Console.ReadLine();  //Get a seletion from the user
                        if (int.TryParse(patientSelection ?? "0", out int patientIntSelection)) //Tries to parse the input as an int
                        {
                            var patientToDelete = patients //Grabs the first patient that matches user input and removes it from the list
                                .Where(p => p != null)
                                .FirstOrDefault(p => (p?.patientId ?? -1) == patientIntSelection);
                            patients.Remove(patientToDelete);
                        }
                        break;
                    case 5: //Returns to the main menu
                        Console.WriteLine("Returning to main menu...");
                        return;
                    default: //Tells the user that the value that they inputted is not valid.
                        Console.WriteLine("Not a valid option. Please try again!");
                        break;
                }
            }
        }

        public static void PhysicianMenu(List<Physician> physicians)
        {
            while(true) //Repeats itself until user chooses option 13
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("Option 1: Create a physician");
                Console.WriteLine("Option 2: Review a physician's information");
                Console.WriteLine("Option 3: Update a physician's information");
                Console.WriteLine("Option 4: Delete a physician");
                Console.WriteLine("Option 5: Return to Main Menu");
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
                        physicians.Add(new Physician());
                        break;
                    case 2:
                        ReviewPhysician(physicians); //Calls the ReviewPhysician method in the Physician Class
                        Console.WriteLine();
                        break;
                    case 3:
                        physicians.ForEach(Console.WriteLine); //Prints out all the physicians in the physicians list
                        Console.Write("Enter physician ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int phyId)) //Tries to parse the input into int data type
                        {
                            var physician = physicians.FirstOrDefault(p => p.GetId() == phyId); //Finds the first physician that matches the user's inputted number and stores it into physicianToUpdate
                            if (physician != null) //If physician was found
                            {
                                Console.WriteLine("Select field to update:");
                                Console.WriteLine("1. Name");
                                Console.WriteLine("2. Number");
                                Console.WriteLine("3. Graduation Date");
                                Console.WriteLine("4. Specializations");

                                string? choice = Console.ReadLine();
                                switch (choice) //Has the user choose what field to update the physician
                                {
                                    case "1": physician.UpdateName(); break;
                                    case "2": physician.UpdateNumber(); break;
                                    case "3": physician.UpdateGraduationDate(); break;
                                    case "4": physician.UpdateSpecializations(); break;
                                    default: Console.WriteLine("Invalid choice."); break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Physician not found."); //Physician was not found
                            }
                        }
                        else //Input was not an int value
                        {
                            Console.WriteLine("Invalid input.");
                        }
                        break;
                    case 4:
                        physicians.ForEach(Console.WriteLine);
                        Console.Write("Physicians to Delete (Id): ");
                        var physicianSelection = Console.ReadLine(); //Get a selection from the user
                        if (int.TryParse(physicianSelection ?? "0", out int physicianIntSelection)) //Tries to parse the input as an int
                        {
                            var physicianToDelete = physicians //Grabs the first physician that matches user input and removes it from the list
                                .Where(p => p != null)
                                .FirstOrDefault(p => (p?.physicianId ?? -1) == physicianIntSelection);
                            physicians.Remove(physicianToDelete);
                        }
                        break;
                    case 5: //Returns to main menu
                        Console.WriteLine("Returning to main menu...");
                        return;
                    default: //Tells the user that the value that they inputted is not valid.
                        Console.WriteLine("Not a valid option. Please try again!");
                        break;
                }
            }
        }

        public static void AppointmentMenu(List<Patient> patients, List<Physician> physicians, List<Appointment> appointments)
        {
            while (true) //Repeats itself until user chooses option 13
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Menu:");
                Console.WriteLine("Option 1: Create an appointment");
                Console.WriteLine("Option 2: Review an appointment");
                Console.WriteLine("Option 3: Update an appointment's information");
                Console.WriteLine("Option 4: Delete an appointment");
                Console.WriteLine("Option 5: Return to Main Menu");
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
                    case 1:
                        int patientId = -1; //Sets the value to -1 (eventually updated in the while loop)
                        int physicianId = -1; //Sets the value to -1 (eventually updated in the while loop)
                        while (true)
                        {
                            Console.WriteLine("What is the physician's Id");
                            string? inputPhysicianId = Console.ReadLine();
                            if (int.TryParse(inputPhysicianId, out int finalPhysicianId)) //Tries to convert string to an int if successful it stores the int value in id
                            {
                                Physician? found = physicians.FirstOrDefault(p => p.GetId() == finalPhysicianId); //Uses a LINQ method to search through the list and looks for the first physician to match the inputted id

                                if (found != null) //If physician was found then it sets the physicianId with the physician that was found
                                {
                                    physicianId = finalPhysicianId;
                                    break;
                                }
                                else //Else the physician couldn't be found
                                    Console.WriteLine($"Patient with id {inputPhysicianId} was not found.");
                            }
                            else //Else the number that was passed was not a integer
                            {
                                Console.WriteLine("Invalid ID. Please enter a number!");
                            }
                        }
                        while (true)
                        {
                            Console.WriteLine("What is the patients's Id");
                            string? inputPatientId = Console.ReadLine();
                            if (int.TryParse(inputPatientId, out int finalPatientId)) //Tries to convert string to an int if successful it stores the int value in id
                            {
                                Patient? found = patients.FirstOrDefault(p => p.GetId() == finalPatientId); //Uses a LINQ method to search through the list and looks for the first patient to match the inputted id

                                if (found != null) //If patient was found then it sets the physicianId with the patient that was foudd
                                {
                                    patientId = finalPatientId;
                                    break;
                                }

                                else //Else the patient couldn't be found
                                    Console.WriteLine($"Patient with id {inputPatientId} was not found.");
                            }
                            else //Else the number that was passed was not a integer
                            {
                                Console.WriteLine("Invalid ID. Please enter a number!");
                            }
                        }
                        Console.WriteLine("What is the Date and Time of the appointment Ex:(10/20/2026 9:30 AM)");
                        DateTime appointmentDate; //Creates empty date (eventually stores appointment date in the while loop)
                        while (true)
                        {
                            string? dateInput = Console.ReadLine();

                            if (DateTime.TryParse(dateInput, out appointmentDate)) //Takes the input and tries to parse it through DateTime data type
                            {
                                //Check if the date is not the weekend
                                if (appointmentDate.DayOfWeek == DayOfWeek.Saturday || appointmentDate.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    Console.WriteLine("Appointments cannot be scheduled on weekends. Try again: ");
                                    continue;
                                }

                                //Check between 8 AM and 5 PM
                                if (appointmentDate.Hour < 8 || appointmentDate.Hour > 16)
                                {
                                    Console.WriteLine("Appointments must be between 8:00 AM and 5:00 PM. Try again: ");
                                    continue;
                                }

                                //If the date and time chooosen is already occupied at the same time and by the same physician then it prompts the user to try again
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
                            else //Lets the user know that the date they tried inputting was not formatted correctly
                            {
                                Console.WriteLine("Invalid date format. Try again: ");
                            }
                        }
                        appointments.Add(new Appointment(patientId, physicianId, appointmentDate)); //Adds an appointment using the patientId, physicianId, and appointmentDate to the appointments list
                        Console.WriteLine("Appointment added! The appointment id is 100");
                        break;
                    case 2:
                        ReviewAppointment(appointments, patients, physicians); //Calls the ReviewAppointment method in the Appointment Class
                        break;
                    case 3:
                        appointments.ForEach(a => Console.WriteLine(a.appointInfoCondensed(patients, physicians))); //Prints out the appointments in the appointments list
                        Console.Write("Enter appointment ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int apptId)) //Tries to parse the input as an int
                        {
                            var appt = appointments.FirstOrDefault(a => a.GetId() == apptId); //Grabs the first appointmentId that is matched with input
                            if (appt != null) //If an appointmentId is found
                            {
                                Console.WriteLine("Select field to update:");
                                Console.WriteLine("1. Patient");
                                Console.WriteLine("2. Physician");
                                Console.WriteLine("3. Appointment Date");

                                string? choice = Console.ReadLine();
                                switch (choice) //Asks the user to choose a field to update
                                {
                                    case "1": appt.UpdatePatient(patients); break;
                                    case "2": appt.UpdatePhysician(physicians, appointments); break;
                                    case "3": appt.UpdateDate(appointments); break;
                                    default: Console.WriteLine("Invalid choice."); break;
                                }
                            }
                            else Console.WriteLine("Appointment not found."); //Else appointmentId not found
                        }
                        else Console.WriteLine("Invalid input."); //Else the input was not a valid int
                        break;
                    case 4:
                        appointments.ForEach(a => Console.WriteLine(a.appointInfoCondensed(patients, physicians)));
                        Console.Write("Appointments to Delete (Id): ");
                        var appointmentSelection = Console.ReadLine(); //Get a selection from the user
                        if (int.TryParse(appointmentSelection ?? "0", out int appointmentIntSelection)) //Tries to parse the input as an int
                        {
                            var appointmentToDelete = appointments //Grabs the first appointment that matches user input and removes it from the list
                                .Where(p => p != null)
                                .FirstOrDefault(a => a?.GetId() == appointmentIntSelection);
                            appointments.Remove(appointmentToDelete);
                        }
                        break;
                    case 5: //Returns to the Main Menu
                        Console.WriteLine("Returning to the Main Menu...");
                        return;
                    default: //Tells the user that the value that they inputted is not valid.
                        Console.WriteLine("Not a valid option. Please try again!");
                        break;
                }
            }
        }

        public static void ReviewPatient(List<Patient> patients) //Function that takes the patient list and tries to find the patient with the user inputted id
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

        public static void ReviewPhysician(List<Physician> physicians) //Function that takes the physician list and tries to find the physician with the user inputted id
        {
            Console.Write("Enter physician ID: "); //Prompts the user for the physician id first
            string? inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int id)) //Tries to convert string to an int if successful it stores the int value in id
            {
                Physician? found = physicians.FirstOrDefault(p => p.GetId() == id); //Uses a LINQ method to search through the list and looks for the first physician to match the inputted id

                if (found != null) //If physician was found then it prints the physician info
                    found.ReadPhysician();
                else
                    Console.WriteLine($"Patient with id {id} was not found.");
            }
            else
            {
                Console.WriteLine("Invalid ID. Please enter a number!");
            }
        }

        public static void ReviewAppointment(List<Appointment> appointments, List<Patient> patients, List<Physician> physicians) //Function that takes the patient list and tries to find the patient with the user inputted id
        {
            Console.Write("Enter appointment ID: "); //Prompts the user for the physician id first
            string? inputId = Console.ReadLine();

            if (int.TryParse(inputId, out int id)) //Tries to convert string to an int if successful it stores the int value in id
            {
                Appointment? found = appointments.FirstOrDefault(a => a.GetId() == id); //Uses a LINQ method to search through the list and looks for the first appointment to match the inputted id

                if (found != null) //If appointment was found then it prints the appointment info
                    found.PrintInfo(patients, physicians);
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
