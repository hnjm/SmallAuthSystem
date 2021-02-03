using BCrypt;

namespace SmallAuthSystem.models
{
    public class Account
    {

        public string accountId { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        private string HashPassword(string pPasswordIn)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            return BCrypt.Net.BCrypt.HashPassword(pPasswordIn, salt);
        }

        private string GenerateId()
        {
            return System.Guid.NewGuid().ToString("N");
        }

        public Account(string pFirstNameIn,
        string pLastNameIn, string pEmailIn, string pPasswordIn)
        {
            this.accountId = GenerateId();
            this.FirstName = pFirstNameIn;
            this.LastName = pLastNameIn;
            this.Email = pEmailIn;
            this.PasswordHash = HashPassword(pPasswordIn); 
        }

        public Account(){}

    }
}