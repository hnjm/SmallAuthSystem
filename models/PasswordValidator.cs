using System;
using System.Text.RegularExpressions;

namespace SmallAuthSystem.models
{
    public class PasswordValidator
    {
        public static bool IsValidPassword(string pPasswordIn)
        {


            // Minimum and maximum lengths
            const int MIN_LENGTH = 8;
            const int MAX_LENGTH = 10;

            // Check if password is null or empty
            if((pPasswordIn == null) ||
            (pPasswordIn.Length == 0)) throw new ArgumentNullException();

            // Define a series of boolean
            // variables that will check tha validity
            bool meetsLengthRequirements = 
            pPasswordIn.Length >= MIN_LENGTH && pPasswordIn.Length <= MAX_LENGTH;
            bool hasUpperCaseLetter = false;
            bool hasLowerCaseLetter = false;
            bool hasDecimalDigit = false;

            if(meetsLengthRequirements)
            {
                foreach(char c in pPasswordIn)
                {
                    if (char.IsUpper(c)) hasUpperCaseLetter = true;
                    if (char.IsLower(c)) hasLowerCaseLetter = true;
                    if (char.IsDigit(c)) hasDecimalDigit =  true;
                }
            }

            bool isValid = meetsLengthRequirements
                           && hasUpperCaseLetter
                           && hasLowerCaseLetter
                           && hasDecimalDigit;
            
            return isValid;
            
        }
    }
}