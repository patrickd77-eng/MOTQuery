namespace  personalDev.MotHistory.Validation
{
    public class RegistrationValidation
    {
        public bool ValidateRegistration(string input)
        {
            if (!string.IsNullOrEmpty(input)){

            return true;
            }
            return false; 
        }
    }
}