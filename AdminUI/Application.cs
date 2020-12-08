using System;
using System.Threading;
using BloodbankCore;

namespace AdminUI
{
    class Application
    {
        ILogin login;
        DonorRepository donorRepository;

        public Application(ILogin login)
        {
            this.login = login;
            donorRepository = new DonorRepository();
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
            Thread.Sleep(1000);
        }

        private void ShowDonationMenu()
        {
            Console.Clear();
            // Mata in personnummer
            // Visa donatorinfo
            // Svara på hälsoundersökning
            // Skriv in ml blods som lämnats
            // Bekräfta uppgifter
            // Donation registrerad
        }
    }
}