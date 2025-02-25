using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerManager.Helpers
{
    internal static class ValidationServiceUtility
    {
        public static bool ValidateChoice(string? Choice, int TotalChoices)
        {
            if (Choice == null)
            {
                MessageWriterUtility.PrintWarning("Choose a choice to continue");
                return false;
            }
            bool IsValidChoice = false;
            IsValidChoice = int.TryParse(Choice, out int ParsedChoice);
            if (!IsValidChoice)
            {
                MessageWriterUtility.PrintWarning("Invalid Number");
                return false;
            }
            if (ParsedChoice > 0 && ParsedChoice <= TotalChoices)
            {
                return true;
            }
            else
            {
                MessageWriterUtility.PrintWarning("Choice out of range");
                return false;
            }

        }
    }
}
