namespace BoilerManager.Helpers
{
    public static class ValidationServiceUtility
    {
        public static bool ValidateChoice(string? Choice, int TotalChoices)
        {
            if (Choice == null)
            {
                MessageUtility.PrintWarning("Choose a choice to continue");
                return false;
            }
            bool IsValidChoice = false;
            IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
            if (!IsValidChoice)
            {
                MessageUtility.PrintWarning("Invalid Number");
                return false;
            }
            if (ParsedChoice > 0 && ParsedChoice <= TotalChoices)
            {
                return true;
            }
            else
            {
                MessageUtility.PrintWarning("Choice out of range");
                return false;
            }

        }
    }
}
