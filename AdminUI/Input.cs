using System;
using BloodbankCore;

namespace AdminUI
{
    class Input
    {
        public static int GetIntFromUser(string prompt = ":> ")
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

        public static int ReadIntFromLine(string prompt = "")
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

        public static string ReadStringFromLine(string prompt = "")
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static BloodType GetBloodType()
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