using PasswordChecker.Hashing;
using PasswordChecker.CheckDB;
using System;
using System.Runtime.CompilerServices;

namespace PasswordChecker
{
    public class Program
    {
        private static handler m_hashHandler = new handler();
        private static string hashes;
        private static httpclient m_httpClient = new httpclient();


        public static string response;
        private static string sUserInput;

        public static void Main()
        {
            initialize();

            getInput();

            hashes = m_hashHandler.setUserInput(sUserInput);

            checkDB();

            end();
        }

        private static void initialize()
        {
            Console.Clear();
            Console.Title = "Password Checker by Reduzer";
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Password Checker by Reduzer");
            Console.WriteLine("Currently only uses SHA1, as the api only supports SHA1");
            Console.WriteLine();
            Console.Write("Please write your password: ");
        }

        private static void getInput()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            string input;

            input = Convert.ToString(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Your Input: " + input);

            sUserInput = input;
        }

        private static void checkDB()
        {
            httpclient.request(hashes);
        }

        private static void end()
        {

            Console.WriteLine("Do you want to quit the program? [y/n]");
            string input = Convert.ToString(Console.ReadLine());
            if (input == "y")
            {
                return;
            }
            else if(input == "n")
            {
                Main();
            }
            else
            {
                Console.WriteLine("Invalid input");
                end();
            }
        }
    }
}