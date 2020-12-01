using System;
using System.Threading;
using BloodbankCore;

namespace AdminUI
{
    class Application
    {
        public void Run()
        {
            //Om inloggning misslyckas returnerar vi till main och programmet avslutas
            if (CheckLogin() == false) return;

            //Detta är huvudloopen i programmet
            while (true)
            {
                ShowMenu();
            }
        }

        //Än så länge finns ingen logik här, utan alla lösenord och användarnamn är ok
        //Denna metod och logik tänker jag att jag vill lyfta ut till en annan klass
        //så småningom, då att kolla inloggning är ett eget ansvarsområde skilt från att
        //rita ut menyer osv
        private bool CheckLogin()
        {
            Console.Write("username: ");
            string userName = Console.ReadLine();
            Console.Write("password: ");
            string password = Console.ReadLine();

            //UserAuthentication.ValidateLogin(userName, password);

            Console.WriteLine("\nLogin successfull!");
            Thread.Sleep(1000);
            return true;
        }

        //Nu har jag börjar lista funktionalitet i grova drag.
        private void ShowMenu()
        {
            Console.Clear(); //Rensa skärmen innan menyn visas

            Console.WriteLine("Blood Donor System Version 1.0\n");
            Console.WriteLine("[1] Register donation");
            Console.WriteLine("[2] Register new donor");
            Console.WriteLine("[3] Quit");

            switch (GetIntFromUser())
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
            newDonor.ID = ReadIntFromLine("ID number: ");
            newDonor.FirstName = ReadStringFromLine("First name: ");
            newDonor.LastName = ReadStringFromLine("Last name: ");
            newDonor.Email = ReadStringFromLine("E-mail: ");
            newDonor.BloodType = GetBloodType();

            //TODO Lägg till donatorn till nån lista här!

            Console.WriteLine("\nDonor added successfully!");
            Thread.Sleep(1000);
        }

        private void ShowDonationMenu()
        {
            Console.Clear();
        }

        //Nu börjar det blir ganska många såna här metoder där jag mest hämtar in input på olika vis,
        //Tänker att det snart är dags att lyfta ut dem till en egen klass

        private int GetIntFromUser(string prompt = ":> ")
        {
            Console.Write(prompt);
            while (true)
            {
                if (Int32.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int value))
                {
                    return value;
                }
            }
        }

        private int ReadIntFromLine(string prompt = "")
        {
            while (true)
            {
                Console.Write(prompt);
                if (Int32.TryParse(Console.ReadLine(), out int value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("You must enter a number.");
                }
            }
        }

        private string ReadStringFromLine(string prompt = "")
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private BloodType GetBloodType()
        {
            Console.WriteLine("\nChoose blood type:\n");
            int value = 1;
            foreach (var item in Enum.GetNames(typeof(BloodType)))
            {
                Console.WriteLine($"{value}: {item}");
                value++;
            }

            while (true)
            {
                int choice = GetIntFromUser();
                if (choice <= Enum.GetValues(typeof(BloodType)).Length)
                {
                    return (BloodType) choice;
                }
            }
        }
    }
}