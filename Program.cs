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
            System.Console.WriteLine(RegisterAccount("Martin", "Taylor", "martintaylor1635@gmail.com", "Passw0rd123"));
        }

        private static bool RegisterAccount(string pFirstNameIn, string pLastNameIn,
        string pEmailIn, string pPasswordIn)
        {
            try
            {
                
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