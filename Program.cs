using System;
using SmallAuthSystem.models;

namespace SmallAuthSystem
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static void RegisterAccount(string pFirstNameIn, string pLastNameIn,
        string pEmailIn, string pPasswordIn)
        {
            try
            {

                if(pFirstNameIn.Contains(" ") || pFirstNameIn.Length == 0)
                {
                    System.Console.WriteLine(@"Sorry, you must enter a value
                    for first name.");
                } else if(pLastNameIn.Contains(" ") || pLastNameIn.Length == 0)
                {
                    System.Console.WriteLine(@"Sorry, you must enter a value
                    for last name.");
                } else if(pEmailIn.Contains(" ") || pEmailIn.Length == 0)
                {
                    System.Console.WriteLine(@"Sorry, you must enter a value
                    for email address.");
                } else if(!PasswordValidator.IsValidPassword(pPasswordIn))
                {
                    System.Console.WriteLine(@"Passwords must be between 8 and 10 characters, containing\nat least
                    one uppercase, lowercase and number");
                }

            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"(!) Error - {ex.Message.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

    }
}