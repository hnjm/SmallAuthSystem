using System;
using SmallAuthSystem.models;
using SmallAuthSystem.data;

namespace SmallAuthSystem
{

    class Program
    {
        private static ApplicationDbContext _db = new ApplicationDbContext();

        static void Main(string[] args)
        {
            
        }

        private static bool RegisterAccount(string pFirstNameIn, string pLastNameIn,
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

                Account account = new Account(pFirstNameIn, pLastNameIn, pEmailIn, pPasswordIn);

                _db.Accounts.Add(account);
                _db.SaveChanges();

                return true;

            }
            catch(Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"(!) Error - {ex.Message.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;

                return false;

            }
        }

    }
}