using System;
using System.Threading;
using BloodbankCore;

namespace AdminUI
{
    class Application
    {
        ILogin login;
        DonorRepository donorRepository;
        BloodDonationRepository bloodDonationRepository;

        public Application(ILogin login)
        {
            this.login = login;
            donorRepository = new DonorRepository();
            bloodDonationRepository = new BloodDonationRepository();

            AddTestData();
        }

        public void Run()
        {
            if (CheckLogin() == false) return;

            while (true)
            {
                ShowMenu();
            }
        }

        //Ett interface, ILogin, har skapats, och en påhittad loginklass som använder 
        //sig av det interfaces har introduerats via konstruktorn och program-klassen.
        //Alla lösenord och logins är fortfarande ok, men grundsystemet är på plats,
        //åtminstonde här.
        private bool CheckLogin()
        {
            string userName = Input.ReadStringFromLine("Username: ");
            string password = Input.ReadStringFromLine("Password: ");

            bool isLoggedIn = login.AuthenticateLogin(userName, password);

            Console.WriteLine("\nLogin " + (isLoggedIn ? "successfull!" : "failed"));

            Thread.Sleep(1000);
            return isLoggedIn;
        }

        //Nu har jag börjar lista funktionalitet i grova drag.
        private void ShowMenu()
        {
            Console.Clear(); //Rensa skärmen innan menyn visas

            Console.WriteLine("Blood Donor System Version 1.0\n");
            Console.WriteLine("[1] Register donation");
            Console.WriteLine("[2] Register new donor");
            Console.WriteLine("[3] Quit");

            switch (Input.GetIntFromUser())
            {
                case 1:
                    ShowDonationMenu();
                    break;
                case 2:
                    ShowRegisterNewDonorMenu();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
            Thread.Sleep(3000);
        }

        private void ShowRegisterNewDonorMenu()
        {
            Console.Clear();

            Console.WriteLine("Register new donor:\n");

            Donor newDonor = new Donor();
            newDonor.Id = Input.ReadIntFromLine("ID number: ");
            newDonor.FirstName = Input.ReadStringFromLine("First name: ");
            newDonor.LastName = Input.ReadStringFromLine("Last name: ");
            newDonor.Email = Input.ReadStringFromLine("E-mail: ");
            newDonor.BloodType = Input.GetBloodType();

            donorRepository.AddDonor(newDonor);

            Console.WriteLine("\nDonor added successfully!");
        }

        private void ShowDonationMenu()
        {
            Console.Clear();
            // Mata in personnummer
            int id = Input.ReadIntFromLine("ID number: ");
            Donor donor = donorRepository.GetDonorById(id);
            if (donor != null)
            {
                // Visa donatorinfo 
                Console.WriteLine("Id: " + donor.Id);
                Console.WriteLine($"Name: {donor.FirstName} {donor.LastName}");
                Console.WriteLine("Blood type: " + donor.BloodType);

                // Svara på hälsoundersökning
                // if (donor.HealthSurvey == null)
                // {
                Console.WriteLine("Health Survey:");
                Console.ReadKey(true);
                // }

                if (donor.HealthSurvey.IsValid)
                {
                    Console.WriteLine("\nPerform donation procedure before continuing.\n");
                    Console.ReadLine();
                    // Skriv in ml blods som lämnats
                    BloodDonation newDonation = new BloodDonation(donor.Id);
                    newDonation.AmountInMl = Input.ReadIntFromLine("Enter amount of blood in ml: ");
                    // Bekräfta uppgifter
                    // Donation registrerad
                    bloodDonationRepository.AddBloodDonation(newDonation);
                    Console.WriteLine("Donation added!");
                }

            }
            else
            {
                Console.WriteLine("Donor not found!");
            }
        }

        void AddTestData()
        {
            Donor newDonor = new Donor();
            newDonor.Id = 1234;
            newDonor.FirstName = "Anna";
            newDonor.LastName = "Anka";
            newDonor.Email = "anna@anka.com";
            newDonor.BloodType = BloodType.On;
            donorRepository.AddDonor(newDonor);
        }
    }
}