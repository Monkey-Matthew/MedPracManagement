using System;
using System.Xml.Linq;

namespace CLI.MedPracManagement
{
    public class Patient
    {
        private static int nextId = 100001; //Keeps track of the next patient's id
        private int patientId;
        private string? name;
        private string? address;
        private DateTime birthdate;
        private List<string> race = new List<string>(); //List that stores all the races that the patient is
        private string? gender;
        private List<string> patientDiagnoses = new List<string>(); //List that stores all the diagnoses the patient has
        private List<string> patientPrescriptions = new List<string>(); //List that stores all the prescriptions the patient has

        public Patient() //Patient Constructor
        {
            patientId = nextId++; //Sets for current patient and increments for the next patient
            Console.Write("What is the patient's full name?: ");
            name = Console.ReadLine();
            Console.Write("What is the patient's address?: ");
            address = Console.ReadLine();
            Console.Write("What is the patient's birthdate? Ex:(yyyy-mm-dd): ");
            while(DateTime.TryParse(Console.ReadLine(), out birthdate) == false) //Tries to parse the input into DateTime, if the format isn't valid then it prompts the user to try again
            {
                Console.WriteLine("Invalid format! Please Try Again");
                Console.Write("What is the patient's birthdate? Ex:(yyyy-mm-dd): ");
            }
            displayRaceOptions();
            string? raceChoice = Console.ReadLine();

            if (!string.IsNullOrEmpty(raceChoice)) //If the raceChoice input is not empty then it splits the string and adds it to the patients race List.
            {
                int[] words = raceChoice.Split(',')
                                        .Select(s => int.Parse(s.Trim()) - 1)
                                        .Where(i => i >= 0 && i < raceOptions.Count) // validate index
                                        .ToArray();

                foreach (int index in words)
                {
                    race.Add(raceOptions[index]);
                }
            }
            
            displayGenderOptions();
            gender = chooseGender();

            Console.WriteLine("Does the patient have any known diagnoses? (if none enter none, if so enter each diagnos with commas in-between each one)");
            Console.Write("Diagnoses: ");
            string? diagnosesInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(diagnosesInput)) //If diagnoses input is not null, it adds the splits the string and adds it to the patient diagnoses List.
            {
                string[] diagnoses = diagnosesInput.Split(",");

                foreach (string diagnose in diagnoses)
                {
                    patientDiagnoses.Add(diagnose);
                }
            }
            else
            {
                patientDiagnoses.Add("None");
            }

            Console.WriteLine("Does the patient have any know prescriptions? (if none enter none, if so enter each prescription with commas in-between each one)");
            Console.Write("Prescriptions: ");
            string? prescriptionsInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(prescriptionsInput)) //If prescriptions input is not null, it adds the splits the string and adds it to the patient prescriptions List.
            {
                string[] prescriptions = prescriptionsInput.Split(",");

                foreach (string prescription in prescriptions)
                {
                    patientPrescriptions.Add(prescription);
                }
            }

            Console.WriteLine();
            Console.WriteLine("The patient was created successfully!");
            Console.WriteLine("The patient's id is " + patientId);

        }
        public void PrintInfo() //Prints the patients information
        {
            Console.WriteLine();
            Console.WriteLine("PATIENT INFO<>");
            Console.WriteLine("Patient Id: " + patientId);
            Console.WriteLine("Patient Name: " + name);
            Console.WriteLine("Patient Address: " + address);
            Console.WriteLine("Patient Birthdate: " + birthdate.ToShortDateString());
            Console.Write("Patient Race: " + string.Join(", ", race));
            Console.WriteLine("");
            Console.WriteLine("Patient Gender: " + gender);
            Console.WriteLine("Patient Diagnoses: " + string.Join(", ", patientDiagnoses));
            Console.WriteLine("Patient Prescriptions: " + string.Join(", ", patientPrescriptions));
        }

        public int GetId() //Grabs the id for the patient
        {
            return patientId;
        }

        private static readonly List<string> raceOptions = new() //Creates and intializes a readonly list of race options
        {
            "White", "Black or African American", "Asian",
            "Native American or Alaska Native", "Native Hawaiian or Other Pacific Islander",
            "Other / Prefer not to say"
        };

        static void displayRaceOptions() //Displays the race options to the user
        {
            Console.WriteLine("What is the patient's race/ethnicity?");
            for (int i = 0; i < raceOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {raceOptions[i]}");
            }
            Console.Write("Patient's race (you can choose multiple, separated by commas): ");
        }

        static void displayGenderOptions() //Displays the race options to the user
        {
            Console.WriteLine("What is the patient's gender?");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. Non-Binary/Other");
            Console.WriteLine("4. Prefer not to say");
            Console.Write("Patient's gender: ");
        }

        static string? chooseGender() //Assigns the gender based on the input given by the user
        {
            int genderChoice;
            string? genderInput = Console.ReadLine();
            while (int.TryParse(genderInput, out genderChoice) == false || genderChoice < 1 || genderChoice > 4) //Checks to see if the input is valid 
            {
                Console.WriteLine("Invalid Option! Please Try Again");
                displayGenderOptions();
                genderInput = Console.ReadLine();
            }

            switch (genderChoice)
            {
                case 1:
                    return "Male";
                case 2:
                    return "Female";
                case 3:
                    return "Non-binary/Other";
                case 4:
                    return "Prefer not to say";
            }

            return "Prefer not to say";
        }

    }
}

