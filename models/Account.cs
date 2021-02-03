using BCrypt;

namespace SmallAuthSystem.models
{
    public class Account
    {

        public string AccountId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Hashes a given password and adds a randomly
        /// generated salt, powered by BCrypt
        /// </summary>
        /// <param name="pPasswordIn"></param>
        private string HashPassword(string pPasswordIn)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(pPasswordIn, salt);
        }

        /// <summary>
        /// Generates a random GUID to assign to a new
        /// account
        /// </summary>
        /// <returns>string</returns>
        private string GenerateId()
        {
            return System.Guid.NewGuid().ToString("N");
        }

        /// <summary>
        /// Overloaded constructor for the use of registering
        /// new account(s)
        /// </summary>
        /// <param name="pAccountIdIn"></param>
        /// <param name="pFirstNameIn"></param>
        /// <param name="pLastNameIn"></param>
        /// <param name="pEmailIn"></param>
        /// <param name="pPasswordIn"></param>
        public Account(string pFirstNameIn,
        string pLastNameIn, string pEmailIn, string pPasswordIn)
        {
            this.AccountId = GenerateId();
            this.FirstName = pFirstNameIn;
            this.LastName = pLastNameIn;
            this.Email = pEmailIn;
            this.Password = HashPassword(pPasswordIn); 
        }

    }
}