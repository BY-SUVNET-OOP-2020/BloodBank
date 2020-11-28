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
                Console.Clear(); //Rensa skärmen innan menyn visas
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
            Console.ReadLine();
            Console.Write("password: ");
            Console.ReadLine();

            Console.WriteLine("\nLogin successfull!");
            Thread.Sleep(1000);
            return true;
        }

        //Nu har jag börjar lista funktionalitet i grova drag.
        private void ShowMenu()
        {
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
                default:
                    Console.WriteLine("Please choose a number from the menu.");
                    break;
            }
        }

        private void ShowRegisterNewDonorMenu()
        {

        }

        private void ShowDonationMenu()
        {

        }

        //Gör en metod som visar en prompt och tar in en int från 0-9 från användaren. 
        //Tänker att det är en bra metod att återanvända
        private int GetIntFromUser()
        {
            Console.Write(":> ");
            while (true)
            {
                if (Int32.TryParse(Console.ReadKey(true).KeyChar.ToString(), out int value))
                {
                    return value;
                }
            }
        }
    }
}