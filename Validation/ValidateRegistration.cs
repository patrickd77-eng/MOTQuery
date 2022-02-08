using System.Text.RegularExpressions;

namespace personalDev.MotHistory.Validation
{
    public class RegistrationValidation
    {
        public bool ValidateRegistration(string input)
        {
            //regex for a UK registration
            var regex = @"^([A-Z]{3}\s?(\d{1,3})\s?[A-Z])|([A-Z]\s?(\d{1,3})\s?[A-Z]{3})|(([A-HK-PRSVWY][A-HJ-PR-Y])\s?(0[2-9]|[1-9][0-9])\s?[A-HJ-PR-Z]{3})$";

            if (!string.IsNullOrEmpty(input))
            {
                Match match = Regex.Match(input.ToUpper().Trim(), regex, RegexOptions.IgnoreCase);

               bool result =  match.Success ?  true : false;

               return result;
            }
            //No valid input provided.
            return false;
        }
    }
}