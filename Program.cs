using System;
using System.Threading.Tasks;
using SmallAuthSystem.models;
using SmallAuthSystem.data;

namespace SmallAuthSystem
{

    class Program
    {
        private static ApplicationDbContext _db = new ApplicationDbContext();
        private static Account _loggedInAccount;

        static void Main(string[] args)
        {
            Login();
        }

        private static void Login()
        {

            string username, password;
            System.Console.Write("Email address: ");
            username = Console.ReadLine();
            System.Console.Write("Password: ");
            password = Console.ReadLine();

            _loggedInAccount = LoginAccount(username, password);

            if(_loggedInAccount != null)
            {
                DisplayLoginMessage();
            }

        }

        private static void DisplayLoginMessage()
        {
            System.Console.WriteLine($"Hi {_loggedInAccount.FirstName}, welcome!");
        }

        private async static void RegisterAccount(string pEmailIn, string pFirstNameIn,
        string pLastNameIn, string pPasswordIn)
        {
            try
            {
                
                Account account = new Account(pEmailIn, pFirstNameIn, pLastNameIn, pPasswordIn);

                _db.Accounts.Add(account);
                await _db.SaveChangesAsync();

            }
            catch(Exception ex)
            {

                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"(!) Error - {ex.Message.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }

        private static Account LoginAccount(string pEmailIn, string pPasswordIn)
        {
            try
            {

                Account matchedAccount =  _db.Accounts.Find(pEmailIn);

                if(matchedAccount.CheckPassword(pPasswordIn))
                {
                    return matchedAccount;
                }
                else
                {
                    System.Console.WriteLine("Sorry, the email address or password is incorrect.");
                    return null;
                }

            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine($"(!) - {ex.Message.ToString()}");
                Console.ForegroundColor = ConsoleColor.White;
                return null;
            }
        }

    }
}