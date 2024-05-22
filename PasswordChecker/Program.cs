﻿using System;

namespace PasswordChecker
{
    public class Program
    {
        private static string sUserInput;

        public static void Main()
        {
            initialize();

            getInput();



            Console.ReadKey();
        }

        private static void initialize()
        {
            Console.Title = "Password Checker by Reduzer";
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Password Checker by Reduzer");
            Console.WriteLine();
            Console.WriteLine("Please write your password: ");
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
    }
}