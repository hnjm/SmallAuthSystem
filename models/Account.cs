using System.ComponentModel.DataAnnotations;
using BCrypt;

namespace SmallAuthSystem.models
{
    public class Account
    {

        [Key]
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PasswordHash { get; set; }

        private string HashPassword(string pPasswordIn)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(pPasswordIn, salt);
        }

        public bool CheckPassword(string pPasswordIn)
        {
            if(BCrypt.Net.BCrypt.Verify(pPasswordIn, this.PasswordHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Account(string pEmailIn, string pFirstNameIn,
        string pLastNameIn, string pPasswordIn)
        {
            this.EmailAddress = pEmailIn;
            this.FirstName = pFirstNameIn;
            this.LastName = pLastNameIn;
            this.PasswordHash = HashPassword(pPasswordIn); 
        }

        public Account(){}

    }
}