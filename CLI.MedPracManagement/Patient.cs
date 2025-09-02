using System;
using System.Xml.Linq;

namespace CLI.MedPracManagement
{
    public class Patient
    {
        private static int nextId = 100001;
        private int patientId;
        private string? name;
        private string? address;
        private DateTime birthdate;
        private List<string> race = new List<string>();
        private string? gender;
        private List<string> patientDiagnoses = new List<string>();
        private List<string> patientPrescriptions = new List<string>();

        public Patient()
        {
            patientId = nextId++;
            Console.Write("What is the patient's full name?: ");
            name = Console.ReadLine();
            Console.Write("What is the patient's address?: ");
            address = Console.ReadLine();
            Console.Write("What is the patient's birthdate? Ex:(yyyy-mm-dd): ");
            while(DateTime.TryParse(Console.ReadLine(), out birthdate) == false)
            {
                Console.WriteLine("Invalid format! Please Try Again");
                Console.Write("What is the patient's birthdate? Ex:(yyyy-mm-dd): ");
            }
            displayRaceOptions();
            string? raceChoice = Console.ReadLine();

            if (!string.IsNullOrEmpty(raceChoice))
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
            if (!string.IsNullOrEmpty(diagnosesInput))
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
            if (!string.IsNullOrEmpty(prescriptionsInput))
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
        public void PrintInfo()
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

        public int GetId()
        {
            return patientId;
        }

        private static readonly List<string> raceOptions = new()
        {
            "White", "Black or African American", "Asian",
            "Native American or Alaska Native", "Native Hawaiian or Other Pacific Islander",
            "Other / Prefer not to say"
        };

        static void displayRaceOptions()
        {
            Console.WriteLine("What is the patient's race/ethnicity?");
            for (int i = 0; i < raceOptions.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {raceOptions[i]}");
            }
            Console.Write("Patient's race (you can choose multiple, separated by commas): ");
        }

        static void displayGenderOptions()
        {
            Console.WriteLine("What is the patient's gender?");
            Console.WriteLine("1. Male");
            Console.WriteLine("2. Female");
            Console.WriteLine("3. Non-Binary/Other");
            Console.WriteLine("4. Prefer not to say");
            Console.Write("Patient's gender: ");
        }

        static string? chooseGender()
        {
            int genderChoice;
            string? genderInput = Console.ReadLine();
            while (int.TryParse(genderInput, out genderChoice) == false || genderChoice < 1 || genderChoice > 4)
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

//Add Comments next to everything
