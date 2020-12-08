using System;
using BloodbankCore;

namespace AdminUI
{
    //Progamklassens huvudsakliga ansvarsområde är att ställa in olika saker som måste
    //ställas in i början av programmet, instantiera några startobjekt och koppla ihop dem
    //Här kommer fler saker att komma in så småningom, nu startar den bara menyklassen
    //Appllication via dess publika Run()-metod
    class Program
    {
        static void Main()
        {
            ILogin login = new LoginMock();
            Application app = new Application(login);

            app.Run();
        }
    }
}