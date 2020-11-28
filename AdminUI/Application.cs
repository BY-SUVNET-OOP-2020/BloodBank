using System;
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
            Console.Write("username:");
            Console.ReadLine();
            Console.Write("password:");
            Console.ReadLine();

            return true;
        }

        //Här kommer huvudsakliga meny-koden att ligga. Kanske lyfts även denna ut ur 
        //applikationsklassen så småningom
        private void ShowMenu()
        {
            Console.WriteLine("MENU:");
        }

    }
}